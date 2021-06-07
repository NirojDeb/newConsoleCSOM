
using Microsoft.SharePoint.Client;
using SP= Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace App2
{
    class Program
    {
        static CrudService crudService = new CrudService();
        static void Main(string[] args)
        {
          
            var authenticationManager = new OfficeDevPnP.Core.AuthenticationManager();
            ClientContext ctx = authenticationManager.GetWebLoginClientContext("https://niroj.sharepoint.com/sites/Test/",null);

            //AskOption();
            AskOption(ctx);
        }

        static void AskOption(ClientContext ctx)
        {
            Console.WriteLine("1.Create");
            Console.WriteLine("2.Read");
            Console.WriteLine("3.Update");
            Console.WriteLine("4.Delete");
            Console.WriteLine("Enter Your Option:");

            Int32.TryParse(Console.ReadLine(), out int option);

            if (option == 1)
            {
                Create(ctx);
            }
            if(option==2)
            {
                Read(ctx);
            }
            if (option == 3)
            {
                Update(ctx);
            }
            if (option == 4)
            {
                Delete(ctx);
            }

        }
        static void Create(ClientContext ctx)
        {
            Console.WriteLine("Enter Title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter single line of text");
            string singleLineOfText = Console.ReadLine();
            Console.WriteLine("Enter multiple lines");
            string multipleLines = Console.ReadLine();
            Console.WriteLine("Enter Street");
            string street = Console.ReadLine();
            Console.WriteLine("Enter City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Number");
            Int32.TryParse(Console.ReadLine(), out int number);
            Console.WriteLine("Enter true or false for YesNo");
            Boolean.TryParse(Console.ReadLine(), out bool yesno);
            Console.WriteLine("Enter Choice between red blue and yellow or a new color you would like to  add");
            string color = Console.ReadLine();
            Console.WriteLine("Enter hyperlink");
            string hyperlink = Console.ReadLine();
            Console.WriteLine("Enter Currency in INR");
            Int32.TryParse(Console.ReadLine(), out int currency);
            Console.WriteLine("Enter Date in dd-mm-yy format");
            DateTime.TryParse(Console.ReadLine(), out DateTime dt);
            Console.WriteLine("Enter EmployeeId for LOOKUP");
            Int32.TryParse(Console.ReadLine(), out int empId);

            EmployeeModel employee = new EmployeeModel(title, singleLineOfText, multipleLines, street, city, state, number, yesno, color, hyperlink, currency, empId, dt);

            crudService.Create(ctx,employee);
        }
        static void Read(ClientContext ctx)
        {
            crudService.Read(ctx);
            Console.ReadLine();
        }
        static void Update(ClientContext ctx)
        {
            crudService.Read(ctx);
            Console.WriteLine("Enter the Row which you want to edit");
            Int32.TryParse(Console.ReadLine(), out int editId);
            crudService.Update(ctx,editId);
                


        }
        static void Delete(ClientContext ctx)
        {
            crudService.Read(ctx);
            Console.WriteLine("Enter the row to be deleted");
            Int32.TryParse(Console.ReadLine(), out int deleteId);
            crudService.Delete(ctx, deleteId);
        }
    }
}

    

