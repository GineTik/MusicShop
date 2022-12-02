using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MusicShop.Core.Entities.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class GreaterThanUtcNowAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var s = value as string;
            if (s != null && string.IsNullOrEmpty(s))
                return true;

            return DateTime.UtcNow.CompareTo(value) <= 0;
        }

        public override string FormatErrorMessage(string name) =>
            string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, DateTime.UtcNow);
    }
}
