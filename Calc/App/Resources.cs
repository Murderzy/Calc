using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.App
{
    public static class Resources
    {
        public static String Culture { get; set; } = "en-US";

        public static String GetEmptyStringMessage(String? culture = null)
        {
            if (culture == null) culture = Culture;
            switch (culture)
            {
                case "uk-UA": return "Порожній рядок неприпустимий";
                case "en-US": return "Empty string not allowed";
            }
            throw new Exception("Unsupported culture");
        }

        public static String GetInvalidOperator(String? culture = null)
        {
            if (culture == null) culture = Culture;
            switch (culture)
            {
                case "uk-UA": return "Операция невозможна";
                case "en-US": return "Unsupported operation";
            }
            throw new Exception("Unsupported culture");
        }

        public static String GetInvalidCulture(String? culture = null)
        {
            if (culture == null) culture = Culture;
            switch (culture)
            {
                case "uk-UA": return "Не поддерживается";
                case "en-US": return "Unsupported culture";
            }
            throw new Exception("Unsupported culture");
        }

        public static String GetInvalidCharMessage(char c, String? culture = null)
        {
            culture ??= Culture;
            switch(culture) 
            {
                case  "uk-UA" : return $"Недозволений символ {c}";
                case "en-US": return $"Invalid char {c}";
            }
            throw new Exception("Unsupported culture");
        }
        public static String GetInvalidTypeMessage( String type, String? culture = null)
        {
            culture = culture ?? Culture;
            switch  (culture) 
            {
                case "uk-UA": return $"тип '{type}' не підтримується";
                case "en-US": return $"type '{type}' unsupported";
            }
            throw new Exception("Unsupported culture");
        }
        public static String GetMispalcedNMessage(String? culture = null)
        {
            if (culture == null) culture = Culture;
            switch (culture)
            {
                case "uk-UA": return "'N' не дозволяється у даному контексті";
                case "en-US": return "'N' is not allowed in this context";
            }
            throw new Exception("Unsupported culture");
        }
    }
}
