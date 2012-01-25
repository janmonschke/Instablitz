using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Runtime.Remoting.Messaging;
using System.Web;
using InstaBlitz;
using fastJSON;
using InstaBlitz.Models;

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

        private WebRequest createRequest(String url, String[] scriptParams)
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

            Console.WriteLine("sig: " + signature);

            // the request's body
            String body = NormalizedRequestParameters + "&oauth_signature=" + signature;

            Console.WriteLine("body: " + body);

            // prepare the webrequest
            currentRequest = WebRequest.Create(url);
            currentRequest.Method = "POST";
            currentRequest.Headers.Set(HttpRequestHeader.Authorization, System.Web.HttpUtility.UrlEncode(body));
            currentRequest.ContentType = "application/x-www-form-urlencoded";
            currentRequest.ContentLength = body.Length;
            // write the request's body
            StreamWriter sr = new StreamWriter(currentRequest.GetRequestStream());
            for (int i = 0; i < body.Length; i++)
            {
                sr.Write(body[i]);
            }
            sr.Close();

            return currentRequest;
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
            
            Console.WriteLine("----Response: " + readResult());
            
        }

        private String readResult() {
            WebResponse res = currentRequest.GetResponse();
            Stream s = res.GetResponseStream();
            StreamReader sr2 = new StreamReader(s);
            String response = sr2.ReadToEnd();
            s.Close();
            sr2.Close();
            Console.WriteLine(response);
            return response;
        }

        public void VerifyCredentials()
        {
            String url = "https://www.instapaper.com/api/1/account/verify_credentials";
            String[] scriptParams = { url };
            createRequest(url, scriptParams);

            // do the request
            try
            {
                currentRequest.BeginGetResponse(new AsyncCallback(__verifyDone), null);
            }
            catch (WebException we)
            {
                Console.WriteLine("========RESPONSE ERROR=========");

                Stream s = we.Response.GetResponseStream();
                StreamReader sr2 = new StreamReader(s);
                String response = sr2.ReadToEnd();
                JsonParser p = new JsonParser(response);
                var decoded = p.Decode();
                Console.WriteLine(decoded.GetType());
                sr2.Close();
                s.Close();
                Console.WriteLine("========EXCEPTION MESSAGE=========");
                Console.WriteLine(we);
                Console.WriteLine("========/RESPONSE ERROR=========");
                readResult();
            }
        }

        private void __verifyDone(IAsyncResult asyn)
        {
            JsonParser p = new JsonParser(readResult());
            var decoded = p.Decode();
            Console.WriteLine(decoded.GetType() == typeof(System.Collections.ArrayList));
            ArrayList arr = decoded as ArrayList;
            Console.WriteLine(arr[0].GetType());
            Dictionary<String, Object> vals = arr[0] as Dictionary<String, Object>;
            foreach(String k in vals.Keys)
                Console.WriteLine(k + " " + vals[k]);
        }

        private void callApi(String url, String[] parameters, AsyncCallback callback)
        {
            createRequest(url, parameters);
            
            // do the request
            try
            {
                currentRequest.BeginGetResponse(callback, null);
            }
            catch (WebException we)
            {
                Console.WriteLine("========RESPONSE ERROR=========");
                StreamReader sr2 = new StreamReader(we.Response.GetResponseStream());
                MessageBox.Show(sr2.ReadToEnd());
                sr2.Close();
                Console.WriteLine("========EXCEPTION MESSAGE=========");
                Console.WriteLine(we);
                Console.WriteLine("========/RESPONSE ERROR=========");
            }
        }

        public void GetFolderList(User user, AsyncCallback callback)
        {
            String url = "https://www.instapaper.com/api/1/folders/list";
            String[] scriptParams = { url };
            callApi(url, scriptParams, delegate(IAsyncResult result){
                String respResult = readResult();
                List<Folder> folders = new List<Folder>();

                // manually add the predefined folders
                Folder unread = new Folder(this);
                unread.Id = Folder.UNREAD;
                unread.Title = "Unread";
                Folder starred = new Folder(this);
                starred.Id = Folder.STARRED;
                starred.Title = "Starred";
                Folder archive = new Folder(this);
                archive.Id = Folder.ARCHIVE;
                archive.Title = "Archive";
                folders.Add(unread);
                folders.Add(starred);
                folders.Add(archive);

                JsonParser parser = new JsonParser(respResult);
                var parsedFolderResult = parser.Decode();

                ArrayList folderArray = parsedFolderResult as ArrayList;

                foreach (Dictionary<String, Object> folder in folderArray)
                {
                    Folder current = new Folder(this);
                    current.Id = folder["folder_id"] as String;
                    current.Title = folder["title"] as String;
                    folders.Add(current);
                }

                user.Folders = folders;
                callback.Invoke(result);
            });
        }


        public void GetBookmarks(Folder folder, AsyncCallback callback)
        {
            String url = "https://www.instapaper.com/api/1/bookmarks/list";
            String[] scriptParams = { url, "folder_id", folder.Id };
            callApi(url, scriptParams, new AsyncCallback(delegate(IAsyncResult res)
            {
                String respResult = readResult();
                List<Bookmark> bookmarks = new List<Bookmark>();

                JsonParser parser = new JsonParser(respResult);
                var parsedBookmarksResult = parser.Decode();

                ArrayList bookmarkArray = parsedBookmarksResult as ArrayList;

                foreach (Dictionary<String, Object> bookmark in bookmarkArray)
                {
                    if ((bookmark["type"] as String).Equals("bookmark"))
                    {
                        Bookmark current = new Bookmark(this);
                        current.Id = (String)bookmark["bookmark_id"];
                        current.Title = (String)bookmark["title"];
                        current.Url = (String)bookmark["url"];
                        current.Starred = ((String)bookmark["starred"]).Equals("1");
                        bookmarks.Add(current);
                    }

                }

                folder.Bookmarks = bookmarks;
                callback.Invoke(res);
            }));
        }

        public void StarBookmark(Bookmark bookmark, AsyncCallback callback)
        {
            String url = "https://www.instapaper.com/api/1/bookmarks/star";
            String[] scriptParams = { url, "bookmark_id", bookmark.Id };
            callApi(url, scriptParams, new AsyncCallback(delegate(IAsyncResult res)
            {
                bookmark.Starred = true;
                callback.Invoke(res);
            }));    
        }

        public void UnStarBookmark(Bookmark bookmark, AsyncCallback callback)
        {
            String url = "https://www.instapaper.com/api/1/bookmarks/unstar";
            String[] scriptParams = { url, "bookmark_id", bookmark.Id };
            callApi(url, scriptParams, new AsyncCallback(delegate(IAsyncResult res)
            {
                bookmark.Starred = false;
                callback.Invoke(res);
            }));    
        }

        public void GetBookmarkText(Bookmark bookmark, AsyncCallback callback)
        {
            String url = "https://www.instapaper.com/api/1/bookmarks/get_text";
            String[] scriptParams = { url, "bookmark_id", bookmark.Id };
            callApi(url, scriptParams, new AsyncCallback(delegate(IAsyncResult res) {
                bookmark.HtmlText = readResult();
                callback.Invoke(res);
            }));    
        }
    } 

    
}
