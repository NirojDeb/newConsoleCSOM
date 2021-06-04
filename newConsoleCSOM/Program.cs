using Microsoft.SharePoint.Client;
using PnP.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace newConsoleCSOM
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ClientContext ctx = new ClientContext("https://niroj.sharepoint.com/sites/Test/"))
            {
                AuthenticationManager auth = new AuthenticationManager();
                ctx.AuthenticationMode = ClientAuthenticationMode.Default;
                SecureString securePassword = new SecureString();
                foreach (char c in "Apex@123")
                    securePassword.AppendChar(c);
                ctx.Credentials = new SharePointOnlineCredentials("niroj@niroj.onmicrosoft.com", securePassword);
                Web web = ctx.Web;
                ctx.Load(web);
                ctx.ExecuteQuery();
                Console.WriteLine("The web site title: " + web.Title);
                Console.Read();
            }
        }
    }
}
