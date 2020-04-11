using System;

namespace PrimitiveObsessionCorrect
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("TESTING EMAIL ADDRESS");
                TestAddress();
                Console.WriteLine();
                Console.WriteLine("TESTING KILOGRAM");
                TestKilogram();
                Console.WriteLine();
                Console.WriteLine("TESTING PERSON");
                TestPerson();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }

        private static void TestAddress()
        {
            
            var addr = new EmailAddress("jan@joska.net");
            var otherAddr = new EmailAddress("jan@joska.net");
            
            // Equals
            Console.WriteLine($"Are {addr} and {otherAddr} same {addr.Equals(otherAddr)}");
            
            // Implicitní cast
            string addressAsString = addr;
            
            // Explicitní cast
            var addr2 = (EmailAddress)"jan@joska.net";

            var emailToTest = "michal.altair.valasek.@email.cz";
            var isValidEmail = EmailAddress.IsValidEmail(emailToTest);
            Console.WriteLine($"Je email {emailToTest} platný: {isValidEmail}");
        }

        private static void TestKilogram()
        {
            var a = new Kilogram(82.5d);
            var b = new Kilogram(95.75d);
            var c = new Kilogram(95.0005d);

            Console.WriteLine($"{a} = {a.ToDekagrams()} dkg");
            Console.WriteLine($"{a} = {a.ToGrams()} g");
            Console.WriteLine($"{a} = {a.ToTons()} t");
 
            Console.WriteLine($"{a} >  {b} = {a > b}");
            Console.WriteLine($"{a} == {b} = {a == b}");
            Console.WriteLine($"{a} +  {b} = {a + b}");
        }

        private static void TestPerson()
        {
            var p = new Person(1, new EmailAddress("petr.bezruc@seznam.cz"), new Kilogram(55));
            p.Thicken((Kilogram)1.25d);
            Console.WriteLine(p);
            p.Thicken(Kilogram.FromGrams(1000d));
            Console.WriteLine(p);
            p.SendEmail(new EmailAddress("michal.altair.valasek@rider.cz"), "teest","test");
        }
    }
}


