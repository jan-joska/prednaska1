using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodeClarityCorrect
{

    

    public class CustomerNumber
    {
        private readonly string _customerNumber;
        private static readonly  Regex regex = new Regex(@"\d{3}.*", RegexOptions.Singleline |  RegexOptions.IgnoreCase);

        public CustomerNumber(string customerNumber)
        {
            _customerNumber = customerNumber;
        }

        public static Result<CustomerNumber> Parse(string input)
        {
            if (!regex.IsMatch(input))
            {
                return new Result<CustomerNumber>(null, false, new List<Error>() { new Error() { Details = $"Poskytnutý vstup '{input}' není platné zákaznické číslo" } });
            }
            return new Result<CustomerNumber>(new CustomerNumber(input), true,null);
        }
    }
}
