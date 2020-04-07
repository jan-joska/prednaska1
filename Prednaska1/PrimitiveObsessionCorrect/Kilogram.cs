using System;
using System.Collections.Generic;

namespace PrimitiveObsessionCorrect
{
    /// <summary>
    /// Ukázka typu, který lze porovnávat s jinými, nikoliv pouze na rovnost.
    /// </summary>
    public class Kilogram : IEquatable<Kilogram>, IComparable<Kilogram>, IComparable
    {
        private readonly double _value;

        public Kilogram Combine(Kilogram otherKilogram)
        {
            if (otherKilogram == null)
            {
                throw new ArgumentNullException(nameof(otherKilogram));
            }

            var newValue = (this._value + otherKilogram._value);
            newValue = Math.Round(newValue, 2);
            return new Kilogram(newValue);
        }

        public Kilogram(double value)
        {
            // Záporné hodnoty hmotnosti ve vesmíru neexistují
            // Osoba nemůže vážit např. -5kg.
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Hodnota musí být nezáporný double");
            }

            // Hodnota větší než milion kilogramů je jasně nesmyslná.
            if (value > (10e6))
            {
                throw new ArgumentOutOfRangeException("Hondota musí být menší než jeden milion kilogramů.");
            }
            _value = value;
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return 1;
            }

            if (ReferenceEquals(this, obj))
            {
                return 0;
            }

            return obj is Kilogram other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Kilogram)}");
        }

        public int CompareTo(Kilogram other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            return _value.CompareTo(other._value);
        }

        public bool Equals(Kilogram other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return _value.Equals(other._value);
        }

        public override string ToString()
        {
            return $"{_value} kg";
        }

        public static bool operator < (Kilogram left, Kilogram right)
        {
            return Comparer<Kilogram>.Default.Compare(left, right) < 0;
        }

        public static bool operator > (Kilogram left, Kilogram right)
        {
            return Comparer<Kilogram>.Default.Compare(left, right) > 0;
        }

        public static bool operator <= (Kilogram left, Kilogram right)
        {
            return Comparer<Kilogram>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >= (Kilogram left, Kilogram right)
        {
            return Comparer<Kilogram>.Default.Compare(left, right) >= 0;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Kilogram) obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static Kilogram operator + (Kilogram left, Kilogram right)
        {
            return new Kilogram(left._value + right._value);
        }

        public static bool operator == (Kilogram left, Kilogram right)
        {
            return Equals(left, right);
        }

        public static bool operator != (Kilogram left, Kilogram right)
        {
            return !Equals(left, right);
        }

        // Zapouzdřeí konverzí z jiných hmotnostních jednotek

        public static Kilogram FromTons (double tons)
        {
            return new Kilogram(tons * 1000d);
        }

        public static Kilogram FromGrams (double grams)
        {
            return new Kilogram(grams / 1000d);
        }

        public static Kilogram FromDekaGram(double dekaGrams)
        {
            return new Kilogram(dekaGrams / 100d);
        }

        // Zapouzdření konverzí do jiných hmotnostních jednotek

        public double ToGrams()
        {
            return _value * 1000d;
        }

        public double ToDekagrams()
        {
            return _value * 100d;
        }

        public double ToTons()
        {
            return _value / 1000d;
        }

        public static implicit operator Kilogram(double input)
        {
            return new Kilogram(input);
        }

        public static explicit operator double(Kilogram kilogram)
        {
            return kilogram._value;
        }
    }
}