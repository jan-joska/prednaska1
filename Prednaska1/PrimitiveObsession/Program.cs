using System;
using System.Security.Cryptography.X509Certificates;

namespace PrimitiveObsession
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person()
            {
                Id = 1,
                Email = "neplatny_email.@seznam.cz",
                Weight = 150
            };

            EmailSender.SendEmail(p.Email, "Test","Test");

            var p2 = new Person()
            {
                Id = 1,
                Email = "jan@joska.net",
                Weight = 82.5f
            };

            var p3 = new Person()
            {
                Id = 1,
                Email = "jan@joska.net",
                Weight = 825f
            };


        }
    }
}
