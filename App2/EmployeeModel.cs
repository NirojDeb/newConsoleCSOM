using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    public class EmployeeModel
    {
        public string Title { get; set; }
        public string SingleLineOfText { get; set; }
        public string MultipleLines { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string  State { get; set; }
        public int Number { get; set; }
        public bool YesNo { get; set; }
        public string Choice { get; set; }
        public string Hyperlink { get; set; }
        public int Currency { get; set; }
        public int EmployeeID { get; set; }
        public DateTime Date { get; set; }

        public EmployeeModel(string title,string  singleLineOfText,string multipleLines,string street,string city,string state,int number,bool yesNo,string choice,string hyperlink,int currency,int employeeId,DateTime date)
        {
            Title = title;
            SingleLineOfText = singleLineOfText;
            MultipleLines = multipleLines;
            Street = street;
            City = city;
            State = state;
            Number = number;
            YesNo = yesNo;
            Choice = choice;
            Hyperlink = hyperlink;
            Currency = currency;
            EmployeeID = employeeId;
            Date = date;       
        }

    }
}
