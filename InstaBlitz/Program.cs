using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using System.IO;

namespace InstaBlitz
{
    static class Program
    {
        const String CONSUMERKEY = "osSPa1TgSVQjRN4nSXchaGi8Ikco8AOqnOn5kZTgMsi8HMZBMR";
        const String CONSUMERSECRET = "TctWWCqLoeKCrYBAExdfqHRtb2gS8yxFB3nXwyg1lc5RfrTSn7";
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Config c = Config.GetInstance();
            
            Console.WriteLine("Read config: " + c);

            //OAuth.OAuthBase o = new OAuth.OAuthBase();
            String url = "https://www.instapaper.com/api/1/oauth/access_token?";
                   url += "x_auth_mode=client_auth&";
                   url += "x_auth_username=jan.monschke@gmail.com&";
                   url += "x_auth_password=ZF23cupNj";

            //url = System.Web.HttpUtility.UrlDecode(url);

            //String NormalizedUrl = "";
            //String NormalizedRequestParameters = "";

            ////String signature = o.GenerateSignature(
            //    //new Uri(url), CONSUMERKEY, CONSUMERSECRET,
            //    //"", "", "POST", o.GenerateTimeStamp(), o.GenerateNonce(),
            //    //OAuth.OAuthBase.SignatureTypes.HMACSHA1, out NormalizedUrl, out NormalizedRequestParameters);

            //Console.WriteLine("========SIGNATURE=========");
            //Console.WriteLine(signature);
            //Console.WriteLine("========INPUT=========");
            //Console.WriteLine(NormalizedUrl + " " + NormalizedRequestParameters);

            //signature = "0z9avg8yTVwTBPeT9cTerFdcXss=";
            //NormalizedRequestParameters = "oauth_consumer_key=osSPa1TgSVQjRN4nSXchaGi8Ikco8AOqnOn5kZTgMsi8HMZBMR&oauth_nonce=2dr0K613bGh&oauth_signature_method=HMAC-SHA1&oauth_timestamp=1324134391&oauth_version=1.0&x_auth_mode=client_auth&x_auth_password=ZF23cupNj&x_auth_username=jan.monschke%40gmail.com";

            //url = "https://www.instapaper.com/api/1/oauth/access_token";

            //WebRequest wr = WebRequest.Create(url);
            //wr.Method = "POST";
            //String body = NormalizedRequestParameters + "&oauth_signature=" + signature;
            ////body = "POST&https%3A%2F%2Fwww.instapaper.com%2Fapi%2F1%2Foauth%2Faccess_token&oauth_consumer_key%3DosSPa1TgSVQjRN4nSXchaGi8Ikco8AOqnOn5kZTgMsi8HMZBMR%26oauth_nonce%3D2dr0K613bGh%26oauth_signature_method%3DHMAC-SHA1%26oauth_timestamp%3D1324134391%26oauth_version%3D1.0%26x_auth_mode%3Dclient_auth%26x_auth_password%3DZF23cupNj%26x_auth_username%3Djan.monschke%2540gmail.com";
            //wr.Headers.Set(HttpRequestHeader.Authorization, body);
            //wr.ContentType = "application/x-www-form-urlencoded";
            //wr.ContentLength = body.Length;
            //Stream r = wr.GetRequestStream();
            //StreamWriter sr = new StreamWriter(r);
            //Console.WriteLine("========BODY=========");
            //for (int i = 0; i < body.Length; i++)
            //{
            //    sr.Write(body[i]);
            //    Console.Write(body[i]);
            //}
            //Console.WriteLine();
            //Console.WriteLine("========/BODY=========");
            //sr.Close();
            //r.Close();
            

            
            //try
            //{
            //    WebResponse res = wr.GetResponse();
            //    Console.WriteLine("========RESPONSE=========");
            //    Stream s = res.GetResponseStream();
            //    StreamReader sr2 = new StreamReader(s);
               
            //        Console.Write(sr2.ReadToEnd());
            //    Console.WriteLine("========/RESPONSE=========");
            //    s.Close();
            //    sr2.Close();
            //}
            //catch (WebException we)
            //{
            //    Console.WriteLine("========RESPONSE ERROR=========");
                
            //    Stream s = we.Response.GetResponseStream();
            //    StreamReader sr2 = new StreamReader(s);
            //        Console.WriteLine(sr2.ReadToEnd());
            //        sr2.Close();
            //    s.Close();
            //    Console.WriteLine("========EXCEPTION MESSAGE=========");
            //    Console.WriteLine(we);
            //    Console.WriteLine("========/RESPONSE ERROR=========");
            //}
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
