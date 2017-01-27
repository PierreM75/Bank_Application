using System;
using System.Globalization;

namespace BankApplication.Tests
{
    public static class Helper
    {
        internal static DateTime ConvertDate(this string date)
        {
            return DateTime.Parse(date, new CultureInfo("fr-FR", true), DateTimeStyles.AssumeLocal);
        }
    }
}