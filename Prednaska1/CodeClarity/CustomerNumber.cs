using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeClarity
{
    public class CustomerNumber
    {
        private readonly string _customerNumber;
        private static readonly  Regex regex = new Regex(@"\d{3}.*", RegexOptions.Singleline |  RegexOptions.IgnoreCase);

        public CustomerNumber(string customerNumber)
        {
            _customerNumber = customerNumber;
        }

        public static CustomerNumber Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(input));
            }
            if (!regex.IsMatch(input))
            {
                throw new FormatException($"Poskytnutý vstup '{input}' není platné zákaznické číslo");
            }
            return new CustomerNumber(input);
        }
    }
}
