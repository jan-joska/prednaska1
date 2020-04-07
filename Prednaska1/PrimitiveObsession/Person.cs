using System;

namespace PrimitiveObsession
{
    public class Person
    {
        private string _email;
        private float _weight; // in kg

        public int Id { get; set; }

        // Hmotnost člověka v kilogramech
        public float Weight
        {
            get => _weight;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Hodnota kilogramu je mimo rozsah");
                }
            }
        }

        // Emailová adresa
        public string Email
        {
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