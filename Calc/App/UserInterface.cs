using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calc.App
{
    //  класс отвечающий за работу с пользовательским интерфейсом

    public static class UserInterface
    {
        public static String Culture { get; set; } = "en-US";

        public static void GetCulture()
        {
            Console.WriteLine("Choose culture(default en-US): \n 1) en-US \n 2)uk-UA");

            String str = Console.ReadLine();

            switch(str)
            {
                case "1": Culture = "en-US"; break;
                case "2": Culture = "uk-UA"; break;
            }

           
        }



        public static String Operator(String? culture = null)
        {
            String oper = "";
            String temp = "";
            String[] array_operations = { "+", "-", "/", "*" };  //  набор допустимых операторов

            if (culture == null) culture = Culture;
            
            switch(culture)
            {
                case "uk-UA": Console.WriteLine("Введіть операцію (+ , - , *) : ");break;
                case "en-US": Console.WriteLine("Enter operation: (+ , - , *) : ");break;
                default: throw new Exception(Resources.GetInvalidCulture());
            }

            

            temp = Console.ReadLine();

            int ind = Array.IndexOf(array_operations, temp);  //  проверяем ввел ли пользователь оператор, который мы можем обработать

            if(ind == -1)
            {
                throw new ArgumentException(Resources.GetInvalidOperator()); //  иначе исключение
            }

            oper = temp;

            return oper;
        }

        public static String Number(String? culture = null)  //  просто получаем число от пользователя
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
