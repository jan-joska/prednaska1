using System;

namespace CodeClarity
{
    internal class Program
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