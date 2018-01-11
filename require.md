> funcs

use case
===
* 註冊
    - required
        + account
        + passwd
        + confirm_passwd
        + phone
        + email
* 登入
    - required
        + account
        + passwd
        + google reCatcha
    - optional
        + google authenticator (recommend)
* 個人資料
    required
        + account
        + passwd (hidden)
        + phone
        + email
        + trade_history
            * buy
            * sell
    optional
        - bank account
        - coin address
* both side:
    - cash
        + list
        + withdraw
            1. iceberg
        + deposit
* sell side:
    > CR~~U~~D

    1. create order to sell digit coins
        - form (post):
            client
                symbol
                price
                    remind (compare to any/avg exchange)
                quantity
                min_quantity
                balance
                address

            server
                check the quantity if enough or not in the address
                add to market
    2. list order
        order_id (unique depend user)
        symbol
        balance
        quantity
        address
    3. delete existed order
        form (post):
            order_id
* buy side:
    1. list market
        form:
            client:
                trade (pick up)
                    select or insert an address
                    check large than min_quantity (js)
                    TODO: check that has enough cash (AJAX)
            server:
                check large than min_quantity (doubly check)
                check that has enough cash
                    accept:
                        update order
                        send sms/mail to owner of the order
* system side:
    1. indicative_price (other exchange)
        only important
    
註冊
    use google reCaptcha

Tables:
    user
        int id: unique, 唯一、自動增加
        int phone: 
        string name: 
        string account: 不要限制長度
        string password: (SHA) 不要限制長度
