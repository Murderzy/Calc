using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.App
{
    public static class UserInterface
    {
        public static String Culture { get; set; } = "en-US";

        public static String Operator(String? culture = null)
        {
            String oper = "";
            String temp = "";
            String[] array_operations = { "+", "-", "/", "*" };

            if (culture == null) culture = Culture;
            
            switch(culture)
            {
                case "uk-UA": Console.WriteLine("Введіть операцію: ");break;
                case "en-US": Console.WriteLine("Enter operation: ");break;
                default: throw new Exception("Unsupported culture");
            }

            

            temp = Console.ReadLine();

            int ind = Array.IndexOf(array_operations, temp);

            if(ind == -1)
            {
                throw new ArgumentException("Unsupported operation");
            }

            oper = temp;

            return oper;
        }

        public static String Number(String? culture = null)
        {
            String number = null;

            if (culture == null) culture = Culture;

            switch (culture)
            {
                case "uk-UA": Console.WriteLine("Введіть число: "); break;
                case "en-US": Console.WriteLine("Enter number: "); break;
                default: throw new Exception("Unsupported culture");
            }

            number = Console.ReadLine();    

            return number;
        }
    }
}
