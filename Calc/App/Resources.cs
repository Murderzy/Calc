using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.App
{
    public class Resources
    {
        //const String empty_string = "Empty string not allowed";
        //const String invalid_char = "Invalid char %";
        //const String unsupported_type = $"obj D : type unsupported";

        public static String GetEmptyStringMessage()
        {
            return "Empty string not allowed";
        }

        public static String GetInvalidCharMessage(char c)
        {
            return $"Invalid char {c}";
        }

        public static String GetInvalidTypeMessage(int d, String type)
        {
            return $"obj {d} : type '{type}' unsupported";
        }
    }
}
