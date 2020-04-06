using System;
using CodeClarity;

namespace CodeClarityCorrect
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                TestMathOperation();
                TestPersonRepository();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
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
