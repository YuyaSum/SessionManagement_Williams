using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SessionManagement_Williams
{
    public class Hashing : IHttpModule
    {
        public static Dictionary<string, string> table = new Dictionary<string, string>();
        public void Dispose() { }
        public void Init(HttpApplication context)
        {
            context.EndRequest += new EventHandler(OnEndRequest);
        }
        private void OnEndRequest(object sender, EventArgs e)
        {
            
            HttpContext context = ((HttpApplication)sender).Context;

            string URL = context.Request.Path;
            string user = context.Request.QueryString["u"];
            string pass = context.Request.QueryString["p"];
            string userSHA = "";
            string passSHA = "";

            if (!string.IsNullOrEmpty(user))
            {
                if (!table.ContainsKey(userSHA))
                {
                    userSHA = TheHashSlingingSlasher(user);
                    passSHA = TheHashSlingingSlasher(pass);
                    table.Add(userSHA, user);
                    table.Add(passSHA, pass);
                }

                // Forces final page to load
                if (URL.Contains("SecondPage.aspx") && table.Count > 4) { URL = "MembersMain.aspx"; }

                context.RewritePath(URL, string.Empty, "u=" + userSHA + "&p=" + passSHA, true);
                if (table.ContainsKey(pass) && table.ContainsValue(pass))
                {
                    if (table.ContainsKey(user))
                    {
                        context.RewritePath(URL, string.Empty, "u=" + table[user] + "&p=" + table[pass], true);
                    }
                }
                else if (table.ContainsValue(user)) { context.Response.Redirect(context.Request.Url.ToString()); }
            }
        }

        private string TheHashSlingingSlasher(string text)
        {
            Random time = new Random(DateTime.Now.Millisecond);

            string salt = time.Next(100000, 999999).ToString();
            text += salt;
            byte[] bytes;
            byte[] hash;
            bytes = UTF8Encoding.UTF8.GetBytes(text);
            hash = new SHA256CryptoServiceProvider().ComputeHash(bytes);
            StringBuilder hashedInfo = new StringBuilder(hash.Length);
            for (int a = 0; a < hash.Length; a++) { hashedInfo.Append(hash[a].ToString("X2")); }
            return hashedInfo.ToString();
        }
    }
}