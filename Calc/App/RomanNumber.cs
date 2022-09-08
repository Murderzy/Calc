using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.App
{
    public class RomanNumber
    {
        //Получение числа из строки
        public static int Parse(String str)
        {
            //char[] digits = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

            //int[] digitValues = { 1, 5, 10, 50, 100, 500, 1000 };

            ////int len = str.Length - 1;

            //int pos = str.Length - 1;//положение последней цифры
            //char digit = str[pos]; //символ цифры
            //int ind = Array.IndexOf(digits, digit);
            //if (ind == -1)
            //{
            //    throw new ArgumentException($"Invalid char {digit}");
            //}
            //int val = digitValues[ind];
            //int number1 = val;
            //int res = val;

            //pos -= 1;

            //while (pos >= 0)
            //{
            //    char digitS = str[pos]; //символ цифры
            //    int indS = Array.IndexOf(digits, digitS);
            //    if (indS == -1)
            //    {
            //        throw new ArgumentException($"Invalid char {digitS}");
            //    }
            //    int valS = digitValues[indS];
            //    int number2 = valS;

            //    if (val > valS )//проверки на добавление и вычитание
            //    {
            //        val -= valS;
            //        //res = val;


            //    }
            //    else if (valS == number1)
            //    {
            //        val += valS;
            //    }
            //    else
            //    {
            //        val += valS;


            //        //val *= -1;
            //    }

            //    pos--;
            //    //number1 = number2;
            //}

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("res");
            //return val;

            char[] digits = { 'N','I', 'V', 'X', 'L', 'C', 'D', 'M' };

            int[] digitValues = { 0,1, 5, 10, 50, 100, 500, 1000 };

            if (str == "N") {return 0;}
           

            int len = str.Length;

            int pos = str.Length - 1;//положение последней цифры

            

            int res = 0;
            int temp = 0;
            for (int i = 0; i < str.Length; i++)
            {
                
                char digit = str[pos]; //символ цифры
                int ind = Array.IndexOf(digits, digit);
                if (ind == -1)
                {
                    throw new ArgumentException($"Invalid char {digit}");
                }
                
                int val = digitValues[ind];
                int number1 = val;

               

                if (len > 1)
                {
                    if (temp > val)
                    {
                        res -= val;
                    }
                    else
                    {
                        res += val;
                    }
                    temp = val;
                }
                else
                {
                    res = val;
                }
                pos -= 1;
            }

            return res;

        }

        }
}
