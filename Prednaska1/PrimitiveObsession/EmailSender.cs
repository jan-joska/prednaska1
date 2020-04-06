using System;

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
}