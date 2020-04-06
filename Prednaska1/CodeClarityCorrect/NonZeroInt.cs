using System;

namespace CodeClarityCorrect
{
    public class NonZeroInt
    {
        public NonZeroInt(int value)
        {
            if (value == 0)
            {
                throw new ArgumentOutOfRangeException("Zadaná hodnota musí být nenulový integer");
            }

            Value = value;
        }

        public int Value { get; }
    }
}