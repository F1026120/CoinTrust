using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoinTrust.Models;
using CoinTrust.DataAccessLayer;
using CoinTrust.ViewModels;
using System.Web.Security;
using System.Web.Helpers;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net.Mail;


namespace CoinTrust.Controllers
{
    /*
     * 20180318: 
     *   使用Authorize需要增加webconfig的codes (特別注意要修改SignIn的URL 不然expired會無法重新導向至sign in)
     *   
     */


    [Authorize]
    public class AccountController : Controller
    {
        const string SALT = "^C@o#i$n*T!r(u~s_t&"; //Ernest, 此字串不可變更
        private DatabaseContext db = new DatabaseContext();
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "AccountId,Password,ConfirmPassword,Phone")] Account account)
        {
            bool Fail = !ModelState.IsValid;
            if (db.Account.Find(account.AccountId) != null)
            {
                Fail = true;
                ModelState.AddModelError("AccountId", "帳戶已經存在");
            }
            if (account.Password != account.ConfirmPassword)
            {
                Fail = true;
                ModelState.AddModelError("Password", "密碼不符");
            }
            if (!Fail)
            {
                account.Password = Encrypt(account.Password); //Ernest, 註冊/登入...等, 任何需要用到密碼的地方, 都要加密
                account.ConfirmPassword = Encrypt(account.ConfirmPassword);
                Debug.WriteLine(account.Password);
                Debug.WriteLine(account.ConfirmPassword);
                account.CreateAt = DateTime.Now;
                account.UpdateAt = DateTime.Now;
                string CertificationCode = Crypto.SHA256((DateTime.Now).GetHashCode().ToString() + account.AccountId);//產生認證碼
                account.CertificationCode = CertificationCode;
                account.Certified = false;
                account.UseGoogleAuthenticator = false;
                account.UsePhoneAuthenticator = false;
                db.Account.Add(account);
                string msg = String.Format(
                    "這是CoinTrust認證信\n\n請點選以下連結驗證帳號\r\n" +
                    "http://pafiretw.myddns.me:50655/Account/CertifyEmail/ {0}/{1}",
                    account.AccountId,
                    CertificationCode
                );
                try
                {
                    db.SaveChanges();
                    Helper.EmailHelper emailHelper = new Helper.EmailHelper();
                    emailHelper.SendToEmailWithSubjectAndMsg(account.AccountId, "註冊認證信", msg);
                    //SendToEmailWithSubjectAndMsg(account.AccountId, "註冊認證信", msg);
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }
                //return RedirectToAction("Account", "SignIn");
            }
            return RedirectToAction("SignIn", "Account");
        }

        [AllowAnonymous]
        public ActionResult SignIn()
        {
            return View();
        }

        // 當expire時,點選accountInfo之類需要登入的頁面時,會有錯誤,需要重導向至首頁
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignIn sign_in)
        {

            bool fail = !ModelState.IsValid;
            var context = new DatabaseContext();
            var account = db.Account.Find(sign_in.AccountId);
            if (account == null ||
                VerifyHash(account.Password, sign_in.password))
            {
                fail = true;
                ModelState.AddModelError("AccountId", "請輸入正確的帳號或密碼!");
            }

            if (!fail)
            {

                this.CreateCookies(account, true);
                account.UpdateAt = DateTime.Now;
                LoginHistory loginHistory = new LoginHistory();
                loginHistory.LoginAt = DateTime.Now;
                loginHistory.User = account;
                loginHistory.Ip = GetIPAddress();
                loginHistory.Locale = null;
                db.LoginHistory.Add(loginHistory);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //[HttpPost]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            this.TearDownCookies();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(Account account)
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword([Bind(Include = "email,phone")] Account account)
        {
            var dbAccount = db.Account.Find(account.AccountId);
            if (dbAccount == null)
                return View("Error");
            else
                if (dbAccount.Phone == account.Phone)
                return View("Good");


            return View();
        }

        public bool Certify(Account account)
        {
            bool valid = true;
            //TODO 驗證其他資訊 比如有開啟google authentication
            return valid;
        }

        [AllowAnonymous]
        public ActionResult CertifyEmail()
        {
            // async
            return View();
        }
        //http://localhost:50655/Account/CertifyEmail/mays2288@gmail.com/EF02B6B46D3D624822C3A1F0758618DDC3C7764C19130049F0AA226C50064B80
        [HttpGet]
        [AllowAnonymous]
        public ActionResult CertifyEmail(string id, string code)
        {
            var account = db.Account.Find(id);
            if (account == null)
                return Content("找不到此ID:  " + id);
            if (account.CertificationCode == code && account.Certified == false)
            {
                account.Certified = true;

                //認證成功的帳號 設置Account CoinFund
                RealCoinFund realCoinFund = new RealCoinFund();
                realCoinFund.AccoundId = id;
                realCoinFund.Amount = 20000;
                realCoinFund.CoinStatus = CoinStatus.Free;
                account.Fund = realCoinFund;
                db.RealCoinFund.Add(realCoinFund);

                db.SaveChanges();
                account.Fund = realCoinFund;

                return RedirectToAction("Index", "Home", null);
            }
            else if (account.Certified == true)
            {
                return Content("此帳號已認證過");
            }

            return Content("認證碼錯誤");
        }


        //Ernest, Cryptography是密碼學的意思, 應該使用Encrypt(加密)
        //protected string CryptographyPassword(string password, string salt)
        protected string Encrypt(string password, string salt = SALT)
        {
            ////Ernest, 這邊編譯器有提示要更換已經過時的function
            //string cryptographyPassword =
            //    //FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, "sha1");
            //    Crypto.HashPassword(password + salt);
            //return cryptographyPassword;

            string encryptedPassword = Crypto.SHA256(password);
            return encryptedPassword;
        }

        private bool VerifyHash(string hashedPassword, string password, string salt = SALT)
        {
            return !(hashedPassword == Encrypt(password, salt));
        }

        //Ernest, functions 應該使用動詞為prefix, 這裡Process其實很難看出function是要做什麼
        //Ernest, 然後像user與isRemember這兩個參數不好記, 記得寫一下summary, 否則很難知道func(user, True)的true是什麼意思
        //private void LoginProcess(Account user, bool isRemeber)
        private void CreateCookiesOld(Account account, bool isRemeber)
        {
            var now = DateTime.Now;
            //string roles = string.Join(",", user.Password.Select(x => x.AccountId).ToArray());
            var ticket = new FormsAuthenticationTicket(
                version: 1,
                name: account.AccountId,
                issueDate: now,
                expiration: now.AddMinutes(30),
                isPersistent: isRemeber,
                userData: "logon",
                cookiePath: FormsAuthentication.FormsCookiePath);
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            Response.Cookies.Add(cookie);
        }

        private void CreateCookies(Account account, bool isPersistent)
        {
            var encryptedTicket = FormsAuthentication.Encrypt(
                new FormsAuthenticationTicket(
                    version: 1,
                    name: "AccountId",
                    issueDate: DateTime.Now,
                    expiration: DateTime.Now.AddMinutes(30),
                    isPersistent: false,
                    userData: account.AccountId
                )
            );
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //cookie.Values["AccountId"] = account.AccountId; maybe dangerous
            cookie.HttpOnly = true;
            Response.Cookies.Add(cookie);
        }

        private void TearDownCookiesOld()
        {
            //清除所有的 session
            Session.RemoveAll();
            //建立一個同名的 Cookie 來覆蓋原本的 Cookie
            HttpCookie cookie1 = new HttpCookie("AccountCookie", "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            //建立 ASP.NET 的 Session Cookie 同樣是為了覆蓋
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
        }

        private void TearDownCookies()
        {
            Response.Cookies.Remove("account");
        }

        //private void AddCookie(Account account)//產生 cookie 
        //{
        //    HttpCookie myCookie = new HttpCookie("AccountCookie");
        //    myCookie["ID"] = account.AccountId;
        //    myCookie.Expires = DateTime.Now.AddMinutes(30);
        //    Response.Cookies.Add(myCookie);
        //}

        private bool isEmailCertificationSucceed(Account account)
        {
            return account.Certified;
        }

        //private bool isGoogleCertificationSucceed(Account account)
        //{
        //    return !account.UseGoogleAuthenticator || false;
        //}

        //private bool isPhoneCertificationSucceed(Account account)
        //{
        //    return !account.UsePhoneAuthenticator || false;
        //}

        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}

/*

// Add custom authentication filter
/// <summary>
/// Filter user has been logon or not.
/// </summary>
public class Auth : ActionFilterAttribute
{
    public bool annoymous = false;
    public string LogonAccointId = "";
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var cookie = filterContext.HttpContext.Request.Cookies["AccountCookie"];
        Debug.Write(cookie);
        if (!annoymous && cookie == null)
        {
            filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "SignIn" }
            ));
            filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
        }
        else if (annoymous && cookie != null)
        {
            filterContext.Result = new RedirectToRouteResult(
                new System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "Index" }
            ));
            filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
        }
        base.OnActionExecuting(filterContext);
    }
    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        base.OnActionExecuted(filterContext);
    }
    public override void OnResultExecuting(ResultExecutingContext filterContext)
    {
        base.OnResultExecuting(filterContext);
    }
    public override void OnResultExecuted(ResultExecutedContext filterContext)
    {
        base.OnResultExecuted(filterContext);
    }
}
[Auth]
public class AccountController : Controller
{
    const string SALT = "^C@o#i$n*T!r(u~s_t&"; //Ernest, 此字串不可變更
    private DatabaseContext db = new DatabaseContext();
    [Auth(annoymous = true)]
    public ActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    [Auth(annoymous = true)]
    [ValidateAntiForgeryToken]
    public ActionResult SignUp([Bind(Include = "AccountId,Password,ConfirmPassword,Phone")] Account account)
    {
        bool Fail = !ModelState.IsValid;
        if (db.Account.Find(account.AccountId) != null)
        {
            Fail = true;
            ModelState.AddModelError("AccountId", "帳戶已經存在");
        }
        if (account.Password != account.ConfirmPassword)
        {
            Fail = true;
            ModelState.AddModelError("Password", "密碼不符");
        }
        if (!Fail)
        {
            account.Password = Encrypt(account.Password); //Ernest, 註冊/登入...等, 任何需要用到密碼的地方, 都要加密
            account.ConfirmPassword = Encrypt(account.ConfirmPassword);
            Debug.WriteLine(account.Password);
            Debug.WriteLine(account.ConfirmPassword);
            account.CreateAt = DateTime.Now;
            account.UpdateAt = DateTime.Now;
            string CertificationCode = Crypto.SHA256((DateTime.Now).GetHashCode().ToString() + account.AccountId);//產生認證碼
            account.CertificationCode = CertificationCode;
            account.Certified = false;
            account.UseGoogleAuthenticator = false;
            account.UsePhoneAuthenticator = false;
            db.Account.Add(account);
            string msg = String.Format(
                "這是CoinTrust認證信\n\n請點選以下連結驗證帳號\r\n" +
                "http://pafiretw.myddns.me:50655/Account/CertifyEmail/ {0}/{1}",
                account.AccountId,
                CertificationCode
            );
            try
            {
                db.SaveChanges();
                SendEmail(account.AccountId, "註冊認證信", msg);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            //return RedirectToAction("Account", "SignIn");
        }
        return View();
    }

    [Auth(annoymous = true)]
    public ActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    [Auth(annoymous = true)]
    [ValidateAntiForgeryToken]
    public ActionResult SignIn(SignIn sign_in)
    {
        //var systemuser = db.Account.FirstOrDefault(x => x.accout == SignIn.email);
        //var account = db.Account //Ernest, 已重新命名,systemuser很像administrator
        //    //.Include(x => x.SystemRoles)
        //    .FirstOrDefault(x => x.AccountId == sign_in.email);

        //Ernest, 這邊建議省掉重複的程式碼
        //if (account == null)
        //{
        //    ModelState.AddModelError("", "請輸入正確的帳號或密碼!");
        //    return View();
        //}

        //Ernest, 使用salt, 是提升字串的安全性, salt必須為不變的
        //var PasswordSalt = db.Account.Find(SignIn.email).Password;
        //var password = CryptographyPassword(SignIn.password, PasswordSalt);
        bool fail = !ModelState.IsValid;
        var context = new DatabaseContext();
        //var account = db.Account.FirstOrDefault(x => x.AccountId == sign_in.email);.
        //var account = context.Account.Where(x => x.AccountId == sign_in.email).FirstOrDefault();
        var account = db.Account.Find(sign_in.AccountId);


        if (account == null ||
            VerifyHash(account.Password, sign_in.password))
        {
            fail = true;
            ModelState.AddModelError("AccountId", "請輸入正確的帳號或密碼!");
        }

        if (!fail)
        {
            //Session.RemoveAll();
            //this.CreateCookies(account, true); // 測試用 暫時為TRUE :isRemeber
            this.CreateCookies(account, true);

            LoginHistory loginHistory = new LoginHistory();
            loginHistory.LoginAt = DateTime.Now;
            loginHistory.User = account;
            loginHistory.Ip = GetIPAddress();
            loginHistory.Locale = null;
            db.LoginHistory.Add(loginHistory);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    //[HttpPost]
    public ActionResult SignOut()
    {
        FormsAuthentication.SignOut();

        ////清除所有的 session
        //Session.RemoveAll();
        ////建立一個同名的 Cookie 來覆蓋原本的 Cookie
        //HttpCookie cookie1 = new HttpCookie("AccountCookie", "");
        //cookie1.Expires = DateTime.Now.AddYears(-1);
        //Response.Cookies.Add(cookie1);

        ////建立 ASP.NET 的 Session Cookie 同樣是為了覆蓋
        //HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
        //cookie2.Expires = DateTime.Now.AddYears(-1);
        //Response.Cookies.Add(cookie2);
        this.TearingDownCookies();


        return RedirectToAction("Index", "Home");
    }

    public ActionResult ResetPassword()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult ResetPassword(Account account)
    {
        return View();
    }

    [Auth(annoymous = true)]
    public ActionResult ForgotPassword()
    {




        return View();
    }

    [HttpPost]
    public ActionResult ForgotPassword([Bind(Include = "email,phone")] Account account)
    {
        var dbAccount = db.Account.Find(account.AccountId);
        if (dbAccount == null)
            return View("Error");
        else
            if (dbAccount.Phone == account.Phone)
            return View("Good");


        return View();
    }

    public bool Certify(Account account)
    {
        bool fail = false;
        //TODO 驗證其他資訊 比如有開啟google authentication
        return fail;
    }

    [Auth(annoymous = true)]
    public ActionResult CertifyEmail()
    {
        // async
        return View();
    }
    //http://localhost:50655/Account/CertifyEmail/mays2288@gmail.com/EF02B6B46D3D624822C3A1F0758618DDC3C7764C19130049F0AA226C50064B80
    [HttpGet]
    [Auth(annoymous = true)]
    public ActionResult CertifyEmail(string id, string code)
    {
        var account = db.Account.Find(id);
        if (account == null) return Content("找不到此ID:  " + id);
        if (account.CertificationCode == code)
        {
            account.Certified = true;

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
            return Content("認證完成\n" + id + "\n" + code);
        }
        else return Content("認證碼錯誤");


        //return Content("認證失敗\n" + id + "\n" + code);
    }

    private void SendEmail(string TargetAddress, string subject, string htmlMessage)
    {
        MailMessage msg = new MailMessage();
        //收件者，以逗號分隔不同收件者 ex "test@gmail.com,test2@gmail.com"
        msg.To.Add(TargetAddress);
        msg.From = new MailAddress("mays2277@gmail.com", "CoinTrust", System.Text.Encoding.UTF8);
        //郵件標題 
        msg.Subject = subject;
        //郵件標題編碼  
        msg.SubjectEncoding = System.Text.Encoding.UTF8;
        //郵件內容
        msg.Body = htmlMessage;
        msg.IsBodyHtml = true;
        msg.BodyEncoding = System.Text.Encoding.UTF8;//郵件內容編碼 
        msg.Priority = MailPriority.Normal;//郵件優先級 
                                           //建立 SmtpClient 物件 並設定 Gmail的smtp主機及Port 
        SmtpClient MySmtp = new SmtpClient("smtp.gmail.com", 587);
        //設定你的帳號密碼
        MySmtp.Credentials = new System.Net.NetworkCredential("mays2277@gmail.com", "a26622252");
        //Gmial 的 smtp 使用 SSL
        MySmtp.EnableSsl = true;
        MySmtp.Send(msg);
    }

    //Ernest, Cryptography是密碼學的意思, 應該使用Encrypt(加密)
    //protected string CryptographyPassword(string password, string salt)
    protected string Encrypt(string password, string salt = SALT)
    {
        ////Ernest, 這邊編譯器有提示要更換已經過時的function
        //string cryptographyPassword =
        //    //FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, "sha1");
        //    Crypto.HashPassword(password + salt);
        //return cryptographyPassword;

        string encryptedPassword = Crypto.SHA256(password);
        return encryptedPassword;
    }

    private bool VerifyHash(string hashedPassword, string password, string salt = SALT)
    {
        return !(hashedPassword == Encrypt(password, salt));
    }

    //Ernest, functions 應該使用動詞為prefix, 這裡Process其實很難看出function是要做什麼
    //Ernest, 然後像user與isRemember這兩個參數不好記, 記得寫一下summary, 否則很難知道func(user, True)的true是什麼意思
    //private void LoginProcess(Account user, bool isRemeber)
    private void CreateCookiesOld(Account account, bool isRemeber)
    {
        var now = DateTime.Now;
        //string roles = string.Join(",", user.Password.Select(x => x.AccountId).ToArray());
        var ticket = new FormsAuthenticationTicket(
            version: 1,
            name: account.AccountId,
            issueDate: now,
            expiration: now.AddMinutes(30),
            isPersistent: isRemeber,
            userData: "logon",
            cookiePath: FormsAuthentication.FormsCookiePath);
        var encryptedTicket = FormsAuthentication.Encrypt(ticket);
        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

        Response.Cookies.Add(cookie);
    }

    private void CreateCookies(Account account, bool isPersistent)
    {
        var encryptedTicket = FormsAuthentication.Encrypt(
            new FormsAuthenticationTicket(
                version: 1,
                name: "account",
                issueDate: DateTime.Now,
                expiration: DateTime.Now.AddMinutes(30),
                isPersistent: false,
                userData: account.AccountId
            )
        );
        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

        cookie.HttpOnly = true;

        Response.Cookies.Add(cookie);
    }

    private void TearingDownCookies()
    {
        Response.Cookies.Remove("account");
    }

    private void AddCookie(Account account)//產生 cookie 
    {
        HttpCookie myCookie = new HttpCookie("AccountCookie");
        myCookie["ID"] = account.AccountId;
        myCookie.Expires = DateTime.Now.AddMinutes(30);
        Response.Cookies.Add(myCookie);
    }

    private bool isCertified(Account account)
    {
        return account.Certified;
    }

    protected string GetIPAddress()
    {
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipAddress))
        {
            string[] addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                return addresses[0];
            }
        }

        return context.Request.ServerVariables["REMOTE_ADDR"];
    }
}
*/

