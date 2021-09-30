using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Utilities
{
    public static class HelpersClass
    {
        public const string role_User_Indiv = "Individual Customer"; 
        public const string role_User_Comp = "Company Customer";
        public const string role_Admin = "Admin";
        public const string role_Emp = "Employee";

        public static double GetPriceQuantity(double quantity,double price, double price50, double price100)
        {

            if (quantity < 50){ return price; }
            else if(quantity < 100) { return price50;  }
            else { return price100; }
        }
    }
}
