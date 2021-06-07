using Microsoft.SharePoint.Client;
using SP = Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    public class CrudService
    {
        public void Create(ClientContext ctx,EmployeeModel employee)
        {
            List oList = ctx.Web.Lists.GetByTitle("New List Check");

            ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
            ListItem oListItem = oList.AddItem(itemCreateInfo);
            oListItem["Title"] = employee.Title;
            oListItem["singlelineoftext"] = employee.SingleLineOfText;
            oListItem["multiplelines"] = employee.MultipleLines;
            oListItem["LOcatiom"] = "{'Address':{'Street':'" + employee.Street + "','City':'" + employee.City + "','State':'" + employee.State + "'}}";
            oListItem["Number"] = employee.Number;
            oListItem["Yesno"] = employee.YesNo;
            oListItem["Choice"] = employee.Choice;
            oListItem["Hyperlink"] = employee.Hyperlink;
            oListItem["Currency"] = employee.Currency;
            oListItem["Date"] = employee.Date;
            oListItem["EMployee_x0020_ID"] = employee.EmployeeID;

            oListItem.Update();
            ctx.ExecuteQuery();
        }

        public void Read(ClientContext ctx)
        {
            List oList = ctx.Web.Lists.GetByTitle("New List Check");
            CamlQuery camlQuery = new CamlQuery();
            camlQuery.ViewXml = "<View><Query><Where><Geq><FieldRef Name='ID'/>" +
                "<Value Type='Number'>10</Value></Geq></Where></Query><RowLimit>100</RowLimit></View>";
            ListItemCollection collListItem = oList.GetItems(camlQuery);
            ctx.Load(collListItem);
            ctx.ExecuteQuery();
            foreach (ListItem oListItem in collListItem)
            {
                Console.WriteLine("Id : {0} Title: {1} Date:{2}",oListItem["ID"],oListItem["Title"], oListItem["Date"]);
            }

        }
        public void Update(ClientContext ctx,int editId)
        {
            List oList = ctx.Web.Lists.GetByTitle("New List Check");
            
            ListItem oListItem = oList.GetItemById(editId);
            oListItem["Title"] = "Changed.";
            oListItem.Update();
            ctx.ExecuteQuery();
        }

        public void Delete(ClientContext ctx,int deleteId)
        {
            List oList = ctx.Web.Lists.GetByTitle("New List Check");
            ListItem oListItem = oList.GetItemById(deleteId);
            oListItem.DeleteObject();
            ctx.ExecuteQuery();
        }
    }
}
