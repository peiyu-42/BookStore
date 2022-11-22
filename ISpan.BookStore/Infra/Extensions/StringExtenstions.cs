using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISpan.BookStore.Infra.Extensions
{
    public static class StringExtenstions
    {
        public static int ToInt(this string source,int defaultValue)
        {
            bool isInt = int.TryParse(source, out int number);

            return isInt ? number : defaultValue;
        }
        public static DateTime ToDateTime(this string source, DateTime date)
        {
            bool isDate = DateTime.TryParse(source, out DateTime result);

            return isDate ? result : date;
        }
    }
}
