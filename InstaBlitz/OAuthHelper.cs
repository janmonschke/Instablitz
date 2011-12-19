using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InstaBlitz
{
    public struct OAuthSignedValues
    {
        public String Signature;
        public String NormalizedRequestParameters;
    }
    class OAuthHelper
    {
        private WebBrowser browser;

        public OAuthHelper(WebBrowser b) { this.browser = b; }

        public OAuthSignedValues signRequestLikeABoss(String[] scriptParams)
        {
            // let the js implementation of oauth-hashing hash our params, LIKE A BOSS!
            OAuthSignedValues values = new OAuthSignedValues();
            String oauthShizzle = (String)browser.Document.InvokeScript("signParams", scriptParams);
            String[] splitted = oauthShizzle.Split('|');
            values.Signature = System.Web.HttpUtility.UrlEncode(splitted[0]);
            values.NormalizedRequestParameters = splitted[1];
            return values;
        }
    }
}
