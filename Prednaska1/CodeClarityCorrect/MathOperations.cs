using System;
using CodeClarityCorrect;

namespace CodeClarity
{
    public class MathOperations
    {
        public static int Divide(int a, NonZeroInt b)
        {
            return a / b.Value;
        }
    }
}