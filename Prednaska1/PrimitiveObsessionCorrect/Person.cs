using System;

namespace PrimitiveObsessionCorrect
{
    public class Person
    {
        public Person(int id, EmailAddress address, Kilogram weight)
        {
            Id = id;
            Address = address;
            Weight = weight;
        }

        public int Id { get; }
        
        // Emailová adresa
        public EmailAddress Address { get; }
        
        // Hmotnost člověka v kilogramech
        public Kilogram Weight { get; private set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Address)}: {Address}, {nameof(Weight)}: {Weight}";
        }

        // Zapouzdřené ztloustnutí osoby
        public void Thicken(Kilogram additionalWeight)
        {
            Console.WriteLine($"Ztučňuji osobu o {additionalWeight}");
            Weight = Weight.Combine(additionalWeight);
        }

        // Odeslání emailu bez obav o formát emailové adresy
        public void SendEmail(EmailAddress recipientAddress, string body, string subject)
        {
            Console.WriteLine($"Sending email from {Address} to {recipientAddress} ..");
        }
    }
}