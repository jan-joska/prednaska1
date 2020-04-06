using System;

namespace PrimitiveObsessionCorrect
{
    public class Person
    {
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Address)}: {Address}, {nameof(Weight)}: {Weight}";
        }

        public Person(int id, EmailAddress address, Kilogram weight)
        {
            Id = id;
            Address = address;
            Weight = weight;
        }

        public int Id { get; }
        public EmailAddress Address { get; }
        public Kilogram Weight { get; private set; }

        public void Thicken(Kilogram additionalWeight)
        {
            Console.WriteLine($"Ztučňuji osobu o {additionalWeight}");
            Weight = Weight.Combine(additionalWeight);
        }

        public void SendEmail(EmailAddress recipientAddress, string body, string subject)
        {
            Console.WriteLine($"Sending email from {Address} to {recipientAddress} ..");
        }
    }
}