﻿using System;
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
        private static int number1;
        private static int number2;
        private static String operation;

        private static void GetOperation()
        {
            operation = UserInterface.Operator();  // получаем оператор
        }

        private static void GetNumbers()
        {
           String val1 = UserInterface.Number();
           String val2 = UserInterface.Number();

            

            if(Int32.TryParse(val1, out number1))  //  проверяем пользователь ввел число или строку, если true - число
            {

            }
            else
            {
                number1 = RomanNumber.Parse(val1);  // строку парсим в число
            }

            if (Int32.TryParse(val2, out number2))  //  проверяем пользователь ввел число или строку, если true - число
            {

            }
            else
            {
                number2 = RomanNumber.Parse(val2);  // строку парсим в число
            }
        }

        public static void GetRezult()
        {
            switch(operation)
            {
                case "+": Console.WriteLine((RomanNumber.Add(number1, number2)).ToString()); break;  //  выводим результат выбранной операции

            }

            
        }

        public static void Work()
        {
            //  собираем все методы для работы калькулятора

            GetOperation();
            GetNumbers();
            GetRezult();
        }

    }
}
