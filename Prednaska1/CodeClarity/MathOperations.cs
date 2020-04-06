using System;

namespace CodeClarity
{
    public class MathOperations
    {
        public static int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new ArgumentOutOfRangeException("Parametr b nesmí být nula");
            }
            return a / b;
        }
    }
}