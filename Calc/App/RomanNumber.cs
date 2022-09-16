using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.App
{
    public class RomanNumber
    {
        //const String empty_string = "Empty string not allowed";
        //const String invalid_char = "Invalid char %";
        //const String unsupported_type = $"obj D : type unsupported";

        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; } 
        }
        

        //  Получение числа из строки
        public RomanNumber()
        {
            this._value = 0; 
        }

        public RomanNumber(int val)
        {
            this._value = val;
        }

        public RomanNumber(object obj)
        {
            if (obj is null) throw new ArgumentNullException($"obj");



            if (obj is int val) this._value = val;
            else if (obj is String str) this._value = Parse(str);
            else if (obj is RomanNumber rn) this._value = rn._value;
            else throw new ArgumentException(Resources.GetInvalidTypeMessage(obj.GetType().ToString()));
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
           

            char[] digits = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

            int[] digitValues = { 1, 5, 10, 50, 100, 500, 1000 };

            if (str == "N") {return 0;}

            if (str == null)
            {
                throw new ArgumentNullException();
            }
            if (str.Length == 0)
            {
                throw new ArgumentException(App.Resources.GetEmptyStringMessage());
            }

            int len = str.Length;

            int pos = str.Length - 1;  //  положение последней цифры

            

            int res = 0;
            int temp = 0;
            int flag = 0;

            if(str.StartsWith("-"))
            {
                flag = 1;
            }

            for (int i = flag; i < str.Length; i++)
            {
                
                char digit = str[pos];  //  символ цифры
                int ind = Array.IndexOf(digits, digit);
                
                
               
                    if (ind == -1)
                    {
                        throw new ArgumentException(App.Resources.GetInvalidCharMessage(digit));
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

        //public static RomanNumber Add(int rn1, int rn2)
        //{
        //    //if (rn is null)
        //    //{
        //    //    throw new ArgumentNullException();
        //    //}

        //    RomanNumber rn = new();
        //    rn.Value = rn1 + rn2;
        //    return rn;
        //}

        //public static RomanNumber Add(RomanNumber rn1, RomanNumber rn2)
        //{
        //    //if (rn is null)
        //    //{
        //    //    throw new ArgumentNullException();
        //    //}

        //    RomanNumber rn = new();
        //    rn.Value = rn1.Value + rn2.Value;
        //    return rn;
        //}

        //public static RomanNumber Add(RomanNumber rn1, int rn2)
        //{
        //    //if (rn is null)
        //    //{
        //    //    throw new ArgumentNullException();
        //    //}

        //    RomanNumber rn = new();
        //    rn.Value = rn1.Value + rn2;
        //    return rn;
        //}

        //public static RomanNumber Add(RomanNumber rn1, String rn2)
        //{
        //    //if (rn is null)
        //    //{
        //    //    throw new ArgumentNullException();
        //    //}

        //    RomanNumber rn = new();
        //    rn.Value = rn1.Value + RomanNumber.Parse(rn2);
        //    return rn;
        //}

        //public static RomanNumber Add(String rn1, String rn2)
        //{
        //    //if (rn is null)
        //    //{
        //    //    throw new ArgumentNullException();
        //    //}

        //    RomanNumber rn = new();
        //    rn.Value = RomanNumber.Parse(rn1) + RomanNumber.Parse(rn2);
        //    return rn;
        //}

        //before refactoring

        //public RomanNumber Add(RomanNumber rn)
        //{
        //    if (rn is null)
        //    {
        //        throw new ArgumentNullException();
        //    }

        //    RomanNumber r = new();
        //    r.Value = rn.Value+ this.Value;
        //    return r;
        //}

        //public RomanNumber Add(int rn)
        //{
        //    //if (rn is null)
        //    //{
        //    //    throw new ArgumentNullException();
        //    //}

        //    RomanNumber r = new();
        //    r.Value = rn + this.Value;
        //    return r;
        //}

        //public RomanNumber Add(String rn)
        //{
        //    //if (rn is null)
        //    //{
        //    //    throw new ArgumentNullException();
        //    //}

        //    RomanNumber r = new();
        //    r.Value = RomanNumber.Parse(rn) + this.Value;
        //    return r;
        //}

        //after refactoring
        public RomanNumber Add(RomanNumber rn)
        {
            if (rn is null)
            {
                throw new ArgumentNullException();
            }

            RomanNumber r = new();
            r.Value = rn.Value + this.Value;
            return r;
        }

        public RomanNumber Add(int rn)
        {
            //  вместо дублирования -- делегируем
            
            return this.Add(new RomanNumber(rn));
        }

        public RomanNumber Add(String rn)
        {
            return this.Add(new RomanNumber(Parse(rn)));
        }

        //public static RomanNumber Add(object rn1, object rn2)
        //{
        //    if (rn1 is null || rn2 is null)
        //    {
        //        throw new ArgumentNullException();
        //    }

        //    if (rn1 is int && rn2 is int) return new RomanNumber((int)rn1).Add((int)rn2);
        //    else if (rn1 is String && rn2 is String) return new RomanNumber(RomanNumber.Parse((String)rn1)).Add((String)rn2);
        //    else if (rn1 is int && rn2 is String) return new RomanNumber((int)rn1).Add((String)rn2);
        //    else if (rn1 is String && rn2 is int) return new RomanNumber((int)rn2).Add((String)rn1);

        //    return new RomanNumber();
        //}


        public static RomanNumber Add(int rn1, int rn2)
        {
            RomanNumber rn = new();
            rn.Value = rn1 + rn2;
            return rn;
        }

        public static RomanNumber Add(RomanNumber rn1, RomanNumber rn2)
        {
            return RomanNumber.Add(rn1.Value,rn2.Value);
        }

        public static RomanNumber Add(RomanNumber rn1, int rn2)
        {
            return RomanNumber.Add(rn1.Value, rn2);
        }

        public static RomanNumber Add(RomanNumber rn1, String rn2)
        {
            return RomanNumber.Add(rn1.Value, RomanNumber.Parse(rn2));
        }

        public static RomanNumber Add(String rn1, String rn2)
        {

            return RomanNumber.Add(RomanNumber.Parse(rn1), RomanNumber.Parse(rn2));
        }


        //  object method add

        public static RomanNumber Add(object obj1, object obj2)
        {

            var rn1 = (obj1 is RomanNumber r1) ? r1 : new RomanNumber(obj1);
            var rn2 = (obj2 is RomanNumber r2) ? r2 : new RomanNumber(obj2);
            return rn1.Add(rn2);
            
        }



        //  sub RomanNumber object

        public RomanNumber Sub(RomanNumber rn)
        {
            if (rn is null)
            {
                throw new ArgumentNullException();
            }

            
            return new RomanNumber(this.Add(rn.Value * (-1)));
        }

        public static RomanNumber Sub(object obj1, object obj2)
        {

            var rn1 = (obj1 is RomanNumber r1) ? r1 : new RomanNumber(obj1);
            var rn2 = (obj2 is RomanNumber r2) ? r2 : new RomanNumber(obj2);
            return rn1.Sub(rn2);

        }

        //  умножение римских чисел

        public RomanNumber Mult(RomanNumber rn)
        {
            if (rn is null)
            {
                throw new ArgumentNullException();
            }


            return new RomanNumber(this.Value * rn.Value);
        }

        public static RomanNumber Mult(object obj1, object obj2)
        {

            var rn1 = (obj1 is RomanNumber r1) ? r1 : new RomanNumber(obj1);
            var rn2 = (obj2 is RomanNumber r2) ? r2 : new RomanNumber(obj2);
            return rn1.Mult(rn2);

        }

        //divide RomanNumber


        public RomanNumber Divide(RomanNumber rn)
        {
            if (rn is null)
            {
                throw new ArgumentNullException();
            }


            return new RomanNumber(this.Value / rn.Value);
        }

        public static RomanNumber Divide(object obj1, object obj2)
        {

            var rn1 = (obj1 is RomanNumber r1) ? r1 : new RomanNumber(obj1);
            var rn2 = (obj2 is RomanNumber r2) ? r2 : new RomanNumber(obj2);
            return rn1.Divide(rn2);

        }
    }
}
