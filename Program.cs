using System.Security.Cryptography;
using System.Text;


namespace Payabl

{
    class Powercash213ds
    {
        private static void Main(string[] args)
        {
            double amount = 1.23;
            string cardholder_name = "Tony Stoyanov";
            string ccn = "4242424242424242";
            string city = "Sofia";
            string country = "BGR";
            string currency = "EUR";
            string customerid = "7654321";
            string customerip = "37.60.143.9";
            int cvc_code = 123;
            string email = "integration@tiebreak.solutions";
            int exp_month = 12;
            int exp_year = 2021;
            string firstname = "Tony";
            string language = "en";
            string lastname = "Stoyanov";
            string merchantid = "gateway_test_3d";
            string notification_url = "https://db46a064326442f75c6172ae6772049a.m.pipedream.net";
            string orderid = DateTime.Now.ToString("yyyyMMddHHmmssms") + "7654321";
            int payment_method = 1;
            string phone = "359888123456";
            string street = "Nikola Tesla";
            string zip = "1000";
            string url_return = "https://tnstoyanov.wixsite.com/payment-response";
            string param_3d = "always3d";

            string secret = "b185";

            string checksum = Hash(
                amount
                + cardholder_name
                + ccn
                + city
                + country
                + currency
                + customerid
                + customerip
                + cvc_code
                + email
                + exp_month
                + exp_year
                + firstname
                + language
                + lastname
                + merchantid
                + notification_url
                + orderid
                + param_3d
                + payment_method
                + phone
                + street
                + url_return
                + zip
                + secret
                );

            Console.WriteLine(
                "https://sandbox.powercash21.com/pay/backoffice/payment_authorize?"
                + "amount="
                + amount
                + "&cardholder_name="
                + cardholder_name
                + "&ccn="
                + ccn
                + "&city="
                + city
                + "&country="
                + country
                + "&currency="
                + currency
                + "&customerid="
                + customerid
                + "&customerip="
                + customerip
                + "&cvc_code="
                + cvc_code
                + "&email="
                + email
                + "&exp_month="
                + exp_month
                + "&exp_year="
                + exp_year
                + "&firstname="
                + firstname
                + "&language="
                + language
                + "&lastname="
                + lastname
                + "&merchantid="
                + merchantid
                + "&notification_url="
                + notification_url
                + "&orderid="
                + orderid
                + "&payment_method="
                + payment_method
                + "&phone="
                + phone
                + "&street="
                + street
                + "&zip="
                + zip
                + "&url_return="
                + url_return
                + "&param_3d="
                + param_3d
                + "&signature="
                + checksum
                );

            Console.ReadLine();


            string Hash(string input)
            {
                using (SHA1Managed sha1 = new SHA1Managed())
                {
                    var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                    var sb = new StringBuilder(hash.Length * 2);

                    foreach (byte b in hash)
                    {
                        // "x2" if you want lowercase
                        sb.Append(b.ToString("x2"));
                    }

                    return sb.ToString();
                }
            }
        }
    }
}