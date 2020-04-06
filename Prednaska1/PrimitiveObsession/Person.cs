using System;

namespace PrimitiveObsession
{
    public class Person
    {
        private string _email;

        public int Id { get; set; }

        public float Weight { get; set; }

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