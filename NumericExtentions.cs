using System;
using System.Text;
using System.Threading.Tasks;

namespace DotNetExtention
{

    public static class NumericExtentions
    {
        public static string SeprateDigits(this int number)
        {
            return string.Format("{0:n0}", number);
        }
        public static string SeprateDigits(this long number)
        {
            return string.Format("{0:n0}", number);
        }
        public static string SeprateDigits(this long? number)
        {
            if (number == null) return "";
            return number.SeprateDigits();
        }
        /// <summary>
        /// This function rounds input value by roundValue. e.g : 15670.RoundB(500) returns 16000
        /// </summary>
        /// <param name="roundBy"></param>
        /// <returns></returns>
        public static int RoundBy(this int value, int roundValue)
        {
            return (int)(Math.Round(value / (double)roundValue) * roundValue);
        }
    }
}
