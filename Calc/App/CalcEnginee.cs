using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calc.App
{
    // класс отвечающий за работу калькулятора, его "движок"
    public static class CalcEnginee
    {
        private static RomanNumber number1;
        private static RomanNumber number2;
        private static String operation;

        private static void GetOperation()
        {
            operation = UserInterface.Operator();  // получаем оператор
        }



        private static void GetNumbers()
        {
            String val1;
            String val2;


            bool flag = true;
            do
            {
                try
                {
                    val1 = UserInterface.Number();
                    number1 = new RomanNumber(val1);
                    flag = false;
                }
                catch (ArgumentNullException) { Console.WriteLine("System error. Program termunated"); }
                catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            } while (flag);
            flag = true;
            do
            {
                try
                {
                    val2 = UserInterface.Number();
                    number2 = new RomanNumber(val2);
                    flag = false;
                }
                catch (ArgumentNullException) { Console.WriteLine("System error. Program termunated"); }
                catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            } while (flag);


        }

        public static void GetRezult()
        {
            switch(operation)
            {
                case "+": Console.WriteLine($"{number1.ToString()} + {number2.ToString()} = {(number1.Add(number2)).ToString()}"); break;  //  выводим результат выбранной операции
                case "*": Console.WriteLine($"{number1.ToString()} * {number2.ToString()} = {(number1.Mult(number2)).ToString()}"); break;  //  выводим результат выбранной операции  //  выводим результат выбранной операции
                case "-": Console.WriteLine($"{number1.ToString()} - {number2.ToString()} = {(number1.Sub(number2)).ToString()}"); break;  //  выводим результат выбранной операции

            }

            
        }

        public static void Work()
        {
            //  собираем все методы для работы калькулятора

            UserInterface.GetCulture();
            GetOperation();
            GetNumbers();
            GetRezult();
        }

    }
}
