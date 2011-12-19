using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Runtime.Remoting.Messaging;
using InstaBlitz;

namespace Instablitz
{
    public class AuthenticationException : Exception {
        public AuthenticationException(String message) : base(message) {  }
    }

    public class OAuthTokenEventArgs : EventArgs {
        public String OAuthToken;
        public String OAuthTokenSecret;
    }

    class InstapaperConnector
    {
        private WebRequest currentRequest = WebRequest.Create(new Uri("http://localhost"));
        private OAuthHelper helper = null;

        public InstapaperConnector(OAuthHelper h)
        {
            this.helper = h;
        }

        public delegate void OAuthFailed(String message);
        public event OAuthFailed OnOAuthFail;
        public delegate void OAuthTokenReceivedHandler(OAuthTokenEventArgs oae);
        public event OAuthTokenReceivedHandler OnOAuthTokenReceived;

        private void cleanUp(AsyncCallback callback)
        {
            currentRequest.Abort();
        }

        private void createRequest(String url, String[] scriptParams)
        {
            ConfigData cd = Config.GetData();
            if(cd.oauth_token.Length > 0 && cd.oauth_token_secret.Length > 0){
                String[] additionals = {"oauth_token", cd.oauth_token, "oauth_token_secret", cd.oauth_token_secret};
                String[] temp = new String[scriptParams.Length + additionals.Length];
                for (int i = 0; i < temp.Length; i++)
                    if (i < scriptParams.Length)
                        temp[i] = scriptParams[i];
                    else
                        temp[i] = additionals[i - scriptParams.Length];
                scriptParams = temp;
            }

            foreach (String s in scriptParams)
                Console.WriteLine(s);
                
            OAuthSignedValues values = helper.signRequestLikeABoss(scriptParams);
            String signature = values.Signature;
            String NormalizedRequestParameters = values.NormalizedRequestParameters;

            // the request's body
            String body = NormalizedRequestParameters + "&oauth_signature=" + signature;

            // prepare the webrequest
            currentRequest = WebRequest.Create(url);
            currentRequest.Method = "POST";
            currentRequest.Headers.Set(HttpRequestHeader.Authorization, System.Web.HttpUtility.UrlEncode(body));
            currentRequest.ContentType = "application/x-www-form-urlencoded";
            currentRequest.ContentLength = body.Length;
            // write the request's body
            Stream r = currentRequest.GetRequestStream();
            StreamWriter sr = new StreamWriter(r);
            for (int i = 0; i < body.Length; i++)
            {
                sr.Write(body[i]);
            }
            sr.Close();
            r.Close();
        }

        public void GetOAuthToken(String user, String password) {
            // the base url
            String url = "https://www.instapaper.com/api/1/oauth/access_token";
            String[] scriptParams = { url, "x_auth_username", user, "x_auth_password", password, "x_auth_mode", "client_auth" };
            createRequest(url, scriptParams);

            // do the request
            try
            {
                currentRequest.BeginGetResponse(new AsyncCallback(__receivedOAuthToken), null);
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
                OnOAuthFail("Wrong user/password combination.");
            }

        } // GetOAuthToken

        private void __receivedOAuthToken(IAsyncResult result)
        {
            currentRequest.EndGetResponse(result);
            WebResponse res = currentRequest.GetResponse();
            Stream s = res.GetResponseStream();
            StreamReader sr2 = new StreamReader(s);
            String response = sr2.ReadToEnd();
            Console.WriteLine("response: " + response);
            NameValueCollection values = System.Web.HttpUtility.ParseQueryString(response);
            s.Close();
            sr2.Close();
            OAuthTokenEventArgs oae = new OAuthTokenEventArgs();
            oae.OAuthToken = values.Get("oauth_token");
            oae.OAuthTokenSecret = values.Get("oauth_token_secret");
            OnOAuthTokenReceived(oae);
        }

        private void __printResult(IAsyncResult result)
        {
            currentRequest.EndGetResponse(result);
            WebResponse res = currentRequest.GetResponse();
            Stream s = res.GetResponseStream();
            StreamReader sr2 = new StreamReader(s);
            String response = sr2.ReadToEnd();
            Console.WriteLine("----Response: " + response);
            s.Close();
            sr2.Close();
        }

        public void VerifyCredentials()
        {
            String url = "https://www.instapaper.com/api/1/account/verify_credentials";
            String[] scriptParams = { url };
            createRequest(url, scriptParams);

            // do the request
            try
            {
                currentRequest.BeginGetResponse(new AsyncCallback(__printResult), null);
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
                OnOAuthFail("Wrong user/password combination.");
            }
        }

        public void GetFolderList()
        {
            
          


        }
    } 

    
}
