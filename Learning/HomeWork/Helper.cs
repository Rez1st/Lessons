using System;
using System.Linq;
using System.Text;

namespace HomeWork
{
    public static class Helper
    {
        public static void PrintAt(this string str, int x, int y, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(x, y);
            Console.Write(str);
            Console.ResetColor();
        }

        public static string GetStrWithLength(this char ch, int length)
        {
            var sb = new StringBuilder();

            for (var i = 0; i < length; i++) sb.Append(ch);

            return sb.ToString();
        }

        public static string RemovePunctuation(this string str)
        {
            return new string(str.Where(c => !char.IsPunctuation(c)).ToArray());
        }

        public static string[] SplitToWords(this string str)
        {
            return str.Split(' ');
        }

        public static string ReplaceNewLine(this string str)
        {
            return str.Replace(Environment.NewLine, " ");
        }

        public static string[] ItemsToLower(this string[] strArr)
        {
            for (var i = 0; i < strArr.Length; i++)
                strArr[i] = strArr[i].ToLower();
            return strArr;
        }

        public static string[] RemoveWhiteSpace(this string[] strArr)
        {
            for (var i = 0; i < strArr.Length; i++)
                strArr[i] = strArr[i].Trim();
            return strArr;
        }

        public static string[] RemoveEmptyStrings(this string[] strArr)
        {
            return strArr.Where(s => s != string.Empty).ToArray();
        }
    }
}