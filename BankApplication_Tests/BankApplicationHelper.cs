using System;
using System.Globalization;

namespace BankApplicationTests
{
    internal static class BankApplicationHelper
    {
        internal static DateTime ConvertDate(this string date)
        {
            return DateTime.Parse(date, new CultureInfo("fr-FR", true), DateTimeStyles.AssumeLocal);
        }
    }
}