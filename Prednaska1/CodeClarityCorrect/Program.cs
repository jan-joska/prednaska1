using System;
using System.Linq;
using CodeClarity;

namespace CodeClarityCorrect
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                //TestMathOperation();
                //TestPersonRepository();
                TestIncorrectInput();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }


        private static void TestIncorrectInput()
        {
            Result<CustomerNumber> customerNumber = CustomerNumber.Parse("3ABC");
            if (customerNumber.IsFailure)
            {
                Console.WriteLine(string.Join(",",customerNumber.Errors.Select(i => i.Details)));
                return;
            } 
            Console.WriteLine($"Welcome, user {customerNumber.Value}");
        }

        private static void TestMathOperation()
        {
            Console.WriteLine(MathOperations.Divide(10, new NonZeroInt(5)));
        }

        private static void TestPersonRepository()
        {
            MaybeObject<Person> person = PersonRepository.GetPersonById(2);
            if (person.HasNoValue)
            {
                Console.WriteLine("Osoba neexistuje");
            }

        }
    }
}
