using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json;

namespace CoinTrust.Helper
{
    public class ETHAddressHelper
    {


        protected string APIKey = "GRVMICHRSJGMGZMBBUYQ6R1H7I7TS2ICT9";
        //API: GRVMICHRSJGMGZMBBUYQ6R1H7I7TS2ICT9
        //regex " @"[0-9a-f]{40}$
        public bool IsValid(string address)
        {
            string pattern = "0x[0-9a-fA-F]{40}$";
            address.Trim();
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
            bool result = reg.IsMatch(address);
            return result;
        }
        public double GetBalance(string address)
        {
            //https://api.etherscan.io/api?module=account&action=balance&address=0xA842B788a13aeD9748671F9992Af07876e594E3a&tag=latest&apikey=GRVMICHRSJGMGZMBBUYQ6R1H7I7TS2ICT9
            //https://api.etherscan.io/api?module=account&action=balance&address=0xddbd2b932c763ba5b1b7ae3b362eac3e8d40121a&tag=latest&apikey=YourApiKeyToken
            address.Trim();
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create("https://api.etherscan.io/api?module=account&action=balance&address=" +
                                                   address + "&tag=latest&apikey=" + APIKey);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            Debug.WriteLine(responseFromServer);
            dynamic stuff = JsonConvert.DeserializeObject(responseFromServer);
            double balance = stuff.result * 0.000000000000000001;
            reader.Close();
            dataStream.Close();
            response.Close();
            return balance;
        }
        /*
        public string[] GetTransactionStatus(string txhash)
        {
            
            //https://api.etherscan.io/api?module=transaction&action=gettxreceiptstatus&txhash=0x513c1ba0bebf66436b5fed86ab668452b7805593c05073eb2d51d3a52f480a76&apikey=YourApiKeyToken
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create("https://api.etherscan.io/api?module=proxy&action=eth_getTransactionByHash&txhash=" +
                                                   txhash + "&apikey=" + APIKey);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            dynamic stuff = JsonConvert.DeserializeObject(responseFromServer);
            bool Status = (stuff.result != "null"); //True is Success
            string[] str = new string[4];
            string from = "";
            string to = "";
            string Quantity = "";
            if (Status)
            {
                 from = stuff.from;
                 to = stuff.to;
                string value = stuff.value;
                Quantity = (Convert.ToInt32(value, 16) * 0.000000000000000001).ToString();


            }
            str[0] = from;


            reader.Close();
            dataStream.Close();
            response.Close();
            return Status;
            */
    }
    public class TransactionByTxhash : ETHAddressHelper
    {
        public string from;
        public string to;
        public double Quantity;
        public bool Status;
        public TransactionByTxhash(string txhash)
        {
            WebRequest request = WebRequest.Create("https://api.etherscan.io/api?module=proxy&action=eth_getTransactionByHash&txhash=" +
                                               txhash + "&apikey=" + APIKey);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            dynamic stuff = JsonConvert.DeserializeObject(responseFromServer);
            //Status = (stuff.result != "null"); //True is Success


                from = stuff.result.from;
                to = stuff.result.to;
                string value = stuff.result.value;
                Quantity = (Convert.ToInt64(value, 16) * 0.000000000000000001);

            
            reader.Close();
            dataStream.Close();
            response.Close();

        }
    }
    //https://api.etherscan.io/api?module=proxy&action=eth_getTransactionByHash&txhash=0x521b341fbe11e7b2b2769adb14e273a19190c8ca86a4e5c100ad3b364484ed4d&apikey=GRVMICHRSJGMGZMBBUYQ6R1H7I7TS2ICT9
}
