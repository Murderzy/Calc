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

        public static RomanNumber EvalExpression(String expression)
        {
            var Operations = new String[] { "+", "-" };



            String[] parts = expression.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length != 3)
            {
                throw new ArgumentException("Invalid expression");
            }
            if (Array.IndexOf(Operations, parts[1]) == -1)
            {
                throw new ArgumentException("Invalid operation");
            }
            RomanNumber rn1 = new(RomanNumber.Parse(parts[0]));
            RomanNumber rn2 = new(RomanNumber.Parse(parts[2]));
            RomanNumber res =
                parts[1] == Operations[0]
                ? rn1.Add(rn2)
                : rn1.Sub(rn2);



            return res;
        }

        public static void Work1()    //  первый вариант
        {
            //  собираем все методы для работы калькулятора

            UserInterface.GetCulture();
            GetOperation();
            GetNumbers();
            GetRezult();
        }  

        public static void Work2()    //  второй вариант
        {
            UserInterface.GetCulture();
            // GetOperation();
            // GetNumbers();
            // GetRezult();

            String? userInput;
            RomanNumber res = null!;
            do
            {
                Console.Write("Enter expression (like XC + CD): ");


                userInput = Console.ReadLine() ?? "";
                try
                {
                    res = EvalExpression(userInput);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (res is null);



            Console.WriteLine($"{userInput} = {res}");
        }

    }
}
