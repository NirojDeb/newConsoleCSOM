
using Microsoft.SharePoint.Client;
using SP= Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
                
            var authenticationManager = new OfficeDevPnP.Core.AuthenticationManager();
            ClientContext ctx = authenticationManager.GetWebLoginClientContext("https://niroj.sharepoint.com/sites/Test/",null);
            Web web = ctx.Web;
            SP.List oList = ctx.Web.Lists.GetByTitle("NJ");
            CamlQuery camlQuery = new CamlQuery();
            camlQuery.ViewXml = "<View><Query><Where><Geq><FieldRef Name='nj'/>" +
                "<Value Type='Number'>10</Value></Geq></Where></Query><RowLimit>100</RowLimit></View>";
            ListItemCollection cList = oList.GetItems(camlQuery);
            User user = web.CurrentUser;
            ctx.Load(web);
            ctx.Load(cList);
            ctx.Load(user);
            ctx.ExecuteQuery();
            Console.WriteLine("The web site title: " + web.Title);
            foreach (ListItem oListItem in cList)
            {
                Console.WriteLine("ID: {0} \nTitle: {1} \nBody: {2}", oListItem.Id, oListItem["nj"], oListItem["Title"]);
            }
            Console.Read();

            
        }
    }
}

    

