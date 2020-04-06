using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClarityCorrect
{
    public class MaybeObject<T> where T : class
    {
        public MaybeObject(T value)
        {
            Value = value;
        }

        public static MaybeObject<T> NoValue => new MaybeObject<T>(null);

        public T Value { get; }

        public bool HasValue => Value != null;

        public bool HasNoValue => Value == null;
    }
}
