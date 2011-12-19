﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Runtime.Remoting.Messaging;

namespace InstaBlitz
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

        public delegate void OAuthTokenReceivedHandler(OAuthTokenEventArgs oae);
        public event OAuthTokenReceivedHandler OnOAuthTokenReceived;

        private void cleanUp(AsyncCallback callback)
        {
            currentRequest.Abort();
        }

        public void GetOAuthToken(String email, String password, WebBrowser browser) {
            // let the js implementation pf the oauth hashing hash our params, LIKE A BOSS!
            String[] scriptParams = { email, password };
            String oauthShizzle = (String)browser.Document.InvokeScript("signParams", scriptParams);
            
            // parse the response
            String[] splitted = oauthShizzle.Split('|');
            String signature = System.Web.HttpUtility.UrlEncode(splitted[0]);
            String NormalizedRequestParameters = splitted[1];

            // the base url
            String url = "https://www.instapaper.com/api/1/oauth/access_token";
            // the request's body
            String body = NormalizedRequestParameters + "&oauth_signature=" + signature;

            // prepare the webrequest
            currentRequest = WebRequest.Create(url);
            currentRequest.Method = "POST";
            currentRequest.Headers.Set(HttpRequestHeader.Authorization, body);
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
                throw new AuthenticationException("Wrong user/password combination.");
            }

        } // GetOAuthToken

        private void __receivedOAuthToken(IAsyncResult result)
        {
            currentRequest.EndGetResponse(result);
            WebResponse res = currentRequest.GetResponse();
            Stream s = res.GetResponseStream();
            StreamReader sr2 = new StreamReader(s);
            String response = sr2.ReadToEnd();
            NameValueCollection values = System.Web.HttpUtility.ParseQueryString(response);
            s.Close();
            sr2.Close();
            OAuthTokenEventArgs oae = new OAuthTokenEventArgs();
            oae.OAuthToken = values.Get("oauth_token");
            oae.OAuthTokenSecret = values.Get("oauth_token_secret");
            OnOAuthTokenReceived(oae);
        }
    } 

    
}