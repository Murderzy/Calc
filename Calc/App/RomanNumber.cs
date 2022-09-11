using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.App
{
    public class RomanNumber
    {
        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; } 
        }
        

        //Получение числа из строки
        public RomanNumber()
        {
            this._value = 0; 
        }

        public RomanNumber(int val)
        {
            this._value = val;
        }

        public override string ToString()
        {
            if (this._value == 0)
            {
                return "N";
            }

            int n = this._value<0? -this._value:this._value;
            String res = this._value<0? "-":"";
            String[] parts = {"M", "CM", "D","CD","C","XC","L","XL","X","IX","V","IV","I"};
            int[] values = {1000,900,500,400,100,90,50,40,10,9,5,4,1};


            for (int j = 0; j <= parts.Length - 1; j++)
            {
                while (n >= values[j])
                {
                    n -= values[j];
                    res += parts[j];

                }
            }
            return res;
        }

        public static int Parse(String str)
        {
           

            char[] digits = { 'N','I', 'V', 'X', 'L', 'C', 'D', 'M' };

            int[] digitValues = { 0,1, 5, 10, 50, 100, 500, 1000 };

            if (str == "N") {return 0;}

            if (str == null)
            {
                throw new ArgumentNullException();
            }
            if (str.Length == 0)
            {
                throw new ArgumentException("Empty string not allowed");
            }

            int len = str.Length;

            int pos = str.Length - 1;//положение последней цифры

            

            int res = 0;
            int temp = 0;
            int flag = 0;

            if(str.StartsWith("-"))
            {
                flag = 1;
            }

            for (int i = flag; i < str.Length; i++)
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

            if(str.StartsWith('-'))
            {
                res *= -1;
            }
            return res;

        }

        public static RomanNumber Add(int rn1, int rn2)
        {
            //if (rn is null)
            //{
            //    throw new ArgumentNullException();
            //}

            RomanNumber rn = new();
            rn.Value = rn1 + rn2;
            return rn;
        }

        public static RomanNumber Add(RomanNumber rn1, RomanNumber rn2)
        {
            //if (rn is null)
            //{
            //    throw new ArgumentNullException();
            //}

            RomanNumber rn = new();
            rn.Value = rn1.Value + rn2.Value;
            return rn;
        }

        public static RomanNumber Add(RomanNumber rn1, int rn2)
        {
            //if (rn is null)
            //{
            //    throw new ArgumentNullException();
            //}

            RomanNumber rn = new();
            rn.Value = rn1.Value + rn2;
            return rn;
        }

        public static RomanNumber Add(RomanNumber rn1, String rn2)
        {
            //if (rn is null)
            //{
            //    throw new ArgumentNullException();
            //}

            RomanNumber rn = new();
            rn.Value = rn1.Value + RomanNumber.Parse(rn2);
            return rn;
        }

        public static RomanNumber Add(String rn1, String rn2)
        {
            //if (rn is null)
            //{
            //    throw new ArgumentNullException();
            //}

            RomanNumber rn = new();
            rn.Value = RomanNumber.Parse(rn1) + RomanNumber.Parse(rn2);
            return rn;
        }

        public RomanNumber Add(RomanNumber rn)
        {
            if (rn is null)
            {
                throw new ArgumentNullException();
            }

            RomanNumber r = new();
            r.Value = rn.Value+ this.Value;
            return r;
        }

        public RomanNumber Add(int rn)
        {
            //if (rn is null)
            //{
            //    throw new ArgumentNullException();
            //}

            RomanNumber r = new();
            r.Value = rn + this.Value;
            return r;
        }

        public RomanNumber Add(String rn)
        {
            //if (rn is null)
            //{
            //    throw new ArgumentNullException();
            //}

            RomanNumber r = new();
            r.Value = RomanNumber.Parse(rn) + this.Value;
            return r;
        }

    }
}
