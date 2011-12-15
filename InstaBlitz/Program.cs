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
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Config c = Config.GetInstance();

            Console.WriteLine("Read config: " + c);

            OAuth.OAuthBase o = new OAuth.OAuthBase();
            String url = "https://www.instapaper.com/api/1/oauth/access_token?";
            url += "x_auth_username=jan.monschke@gmail.com&";
            url += "x_auth_password=ZF23cupNj&";
            url += "x_auth_mode=client_auth";

            String o1 = "";
            String o2 = "";

            String signature = o.GenerateSignature(new Uri(url),
                "osSPa1TgSVQjRN4nSXchaGi8Ikco8AOqnOn5kZTgMsi8HMZBMR",
                "TctWWCqLoeKCrYBAExdfqHRtb2gS8yxFB3nXwyg1lc5RfrTSn7",
                "", "", "POST", o.GenerateTimeStamp(), o.GenerateNonce(),
                OAuth.OAuthBase.SignatureTypes.HMACSHA1, out o1, out o2);

            Console.WriteLine("========SIGNATURE=========");
            Console.WriteLine(signature);
            Console.WriteLine("========INPUT=========");
            Console.WriteLine(o1 + " " + o2);

            url = "https://www.instapaper.com/api/1/oauth/access_token";

            WebRequest wr = WebRequest.Create(url);
            wr.Method = "POST";
            String body = o2 + "&oauth_signature=" + signature;
            wr.Headers.Set(HttpRequestHeader.Authorization, body);
            wr.ContentType = "application/x-www-form-urlencoded";
            wr.ContentLength = body.Length;
            Stream r = wr.GetRequestStream();
            StreamWriter sr = new StreamWriter(r);
            Console.WriteLine("========BODY=========");
            for (int i = 0; i < body.Length; i++)
            {
                sr.Write(body[i]);
                Console.Write(body[i]);
            }
            Console.WriteLine();
            Console.WriteLine("========/BODY=========");
            sr.Close();
            r.Close();
            

            
            try
            {
                WebResponse res = wr.GetResponse();
                Console.WriteLine("========RESPONSE=========");
                Stream s = res.GetResponseStream();
                while (s.CanRead)
                    Console.Write(s.ReadByte());
                Console.WriteLine("========/RESPONSE=========");
                s.Close();
            }
            catch (WebException we)
            {
                Console.WriteLine("========RESPONSE ERROR=========");
                
                Stream s = we.Response.GetResponseStream();
                StreamReader sr2 = new StreamReader(s);
                    Console.WriteLine(sr2.ReadToEnd());
                    sr2.Close();
                s.Close();
                Console.WriteLine("========EXCEPTION MESSAGE=========");
                Console.WriteLine(we);
                Console.WriteLine("========/RESPONSE ERROR=========");
            }
            
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
