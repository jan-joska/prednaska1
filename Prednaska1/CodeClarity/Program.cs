using System;
using System.Security.Cryptography;

namespace CodeClarity
{
    internal class Program
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
            try
            {
                var cn2 = CustomerNumber.Parse("1ABC");
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex);
            }
            catch (FormatException fex)
            {
                Console.WriteLine(fex);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void TestMathOperation()
        {
            Console.WriteLine(MathOperations.Divide(10, 20));
            //Console.WriteLine(MathOperations.Divide(10, 0));
        }

        private static void TestPersonRepository()
        {
            var p = PersonRepository.GetPersonById(2);
            
            Console.WriteLine(p.Name);
        }
    }
}