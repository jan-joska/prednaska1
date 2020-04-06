using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;
using System.Text;

namespace PrimitiveObsession
{
    public class EmailSender
    {
        public static void SendEmail(string email, string body, string subject)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email nebyl zadan");
            }
            if (!email.Contains("@"))
            {
                throw new ArgumentException("Neplatný email. Zavinac chybi.");
            }
            if (!email.Contains("."))
            {
                throw new ArgumentException("Neplatný email. Alespon jedna tecka je vyzadovana.");
            }
            /// .. další a další kontroly
            Console.WriteLine($"Sending email to {email}");
        }
    }

    public class Person
    {
        private string _email;

        public int Id { get; set; }

        public float Weight { get; set; }

        public string Email {
            get => _email;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email nebyl zadan");
                }
                if (!value.Contains("@"))
                {
                    throw new ArgumentException("Neplatný email. Zavinac chybi.");
                }
                if (!value.Contains("."))
                {
                    throw new ArgumentException("Neplatný email. Alespon jedna tecka je vyzadovana.");
                }
                /// .. další a další kontroly
                _email = value;
            }
        }


    }
}
