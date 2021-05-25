using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    class RationalNumber : IEquatable<RationalNumber>, IComparable<RationalNumber>, IFormattable
    {
        public int Numerator { get; private set; }

        public uint denominator;
        public uint Denominator
        {
            get 
            {
                return denominator;
            }
            private set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("We cannot make divide by zero.");
                }
                if (value < 0)
                {
                    throw new ArgumentException("We can only enter natural numbers.");
                }
                denominator = value;
            }
        }

        public RationalNumber(int num = 0, uint denum = 1)
        {
            if (denum == 0)
            {
                throw new DivideByZeroException("We cannot make divide by zero."); 
            }
            Numerator = num;
            Denominator = denum;
        }

        public RationalNumber(RationalNumber rn)
        {
            Numerator = rn.Numerator;
            Denominator = rn.Denominator;
        }

        public void Reduce()
        {
            if (Numerator == Denominator)
            {
                Numerator = 1;
                Denominator = 1;
                return;
            }
            int gcd = MathFunc.GCD(Numerator, (int)Denominator);
            Numerator /= gcd;
            Denominator /= (uint)gcd;
        }

        public static void CommonDenominator(RationalNumber r1, RationalNumber r2)
        {
            if (r1.Denominator == r2.Denominator)
            {
                return;
            }
            uint lcm = (uint)MathFunc.LCM((int)r1.Denominator, (int)r2.Denominator);
            uint mult1 = lcm / r1.Denominator;
            uint mult2 = lcm / r2.Denominator;
            r1.Numerator *= (int)mult1;
            r1.Denominator = lcm;
            r2.Numerator *= (int)mult2;
            r2.Denominator = lcm;
        }

        public static RationalNumber operator +(RationalNumber r)
        {
            return r;  
        }

        public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
        {
            RationalNumber result = new RationalNumber();
            result.Denominator = (uint)MathFunc.LCM((int)r1.Denominator, (int)r2.Denominator);
            result.Numerator = r1.Numerator * ((int)result.Denominator / (int)r1.Denominator) +
                               r2.Numerator * ((int)result.Denominator / (int)r2.Denominator);
            result.Reduce();
            return result;
        }

        public static RationalNumber operator -(RationalNumber r)
        {
            return new RationalNumber(-r.Numerator, r.Denominator);
        }

        public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
        {
            RationalNumber result = new RationalNumber();
            result.Denominator = (uint)MathFunc.LCM((int)r1.Denominator, (int)r2.Denominator);
            result.Numerator = r1.Numerator * ((int)result.Denominator / (int)r1.Denominator) -
                               r2.Numerator * ((int)result.Denominator / (int)r2.Denominator);
            result.Reduce();
            return result;
        }

        public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
        {
            RationalNumber result = new RationalNumber();
            result.Numerator = r1.Numerator * r2.Numerator;
            result.Denominator = r1.Denominator * r2.Denominator;
            result.Reduce();
            return result;
        }

        public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
        {
            if (r2.Numerator == 0)
            {
                throw new DivideByZeroException("You cannot divide by 0.");
            }
            RationalNumber result = new RationalNumber();
            result.Numerator = (int)r1.Numerator * (int)r2.Denominator;
            result.Denominator = (uint)(r1.Denominator * r2.Numerator);
            result.Reduce();
            return result;
        }

        public static bool operator ==(RationalNumber r1, RationalNumber r2)
        {
            r1.Reduce();
            r2.Reduce();
            return r1.Numerator == r2.Numerator && r1.Denominator == r2.Denominator;
        }

        public static bool operator !=(RationalNumber r1, RationalNumber r2)
        {
            return !(r1 == r2);
        }

        public static bool operator <(RationalNumber r1, RationalNumber r2)
        {
            if (r1.Numerator < 0 && r2.Numerator >= 0) { return true; }
            if (r2.Numerator < 0 && r1.Numerator >= 0) { return false; }
            RationalNumber temp1 = r1;
            RationalNumber temp2 = r2;
            CommonDenominator(temp1, temp2);
            if (temp1.Numerator < temp2.Numerator) return true;
            return false;
        }

        public static bool operator >(RationalNumber r1, RationalNumber r2)
        {
            return r1 < r2 && r1 != r2;
        }

        public static bool operator <=(RationalNumber r1, RationalNumber r2)
        {
            return r1 < r2 || r1 == r2;
        }

        public static bool operator >=(RationalNumber r1, RationalNumber r2)
        {
            return r1 > r2 || r1 == r2;
        }

        public bool Equals(RationalNumber r)
        {
            r.Reduce();
            return this == r;
        }

        public override bool Equals(object obj)
        {
            RationalNumber r = obj as RationalNumber;
            if (r == null) return false;
            return r == this;
        }

        public int CompareTo(RationalNumber r)
        {
            if (r > this) return 1;
            else if (r < this) return -1;
            return 0;
        }
        public override int GetHashCode()
        {
            return Numerator ^ (int)Denominator;
        }

        public override string ToString()
        {
            string str = Numerator + "/" + Denominator;
            return str;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return ToString(format);
        }

        public string ToString(string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return ToString();
            }
            switch (format)
            {
                case "F": return Numerator + " div by " + Denominator;
                case "D": return Numerator + "/" + Denominator;
                case "B": return "(" + Numerator + "/" + Denominator + ")";
                default: throw new FormatException("Unknown format.");
            }
        }

        public static bool TryParse(string str, out RationalNumber r)
        {
            r = new RationalNumber();
            string format = "";
            if (string.IsNullOrEmpty(str)) return false;
            if (str[0] == '(' && str[str.Length-1] == ')')
            {
                format = "B";
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '/')
                    {
                        format = "D";
                        break;
                    }
                }
            }
            if (format == "")
            {
                if (str.Contains("div by"))
                {
                    string temp = str;
                    string[] parts = temp.Split("div by");
                    if (parts.Length != 2) return false;
                    if (!int.TryParse(parts[0], out int num))
                    {
                        return false;
                    }
                    if (!int.TryParse(parts[1], out int denom))
                    {
                        return false;
                    }
                    format = "F";
                }
            }
            if (format == "B")
            {
                str = str.Remove(0, 1);
                str = str.Remove(str.Length - 1, 1);
                string[] parts = str.Split('/');
                if (parts.Length != 2) return false;
                if (!int.TryParse(parts[0], out int num))
                {
                    return false;
                }
                if (!int.TryParse(parts[1], out int denom))
                {
                    return false;
                }
                if (denom == 0) return false;
                r.Numerator = num;
                r.Denominator = (uint)denom;
                return true;
            }
            else if (format == "D")
            {
                string[] parts = str.Split('/');
                if (parts.Length != 2) return false;
                int num;
                int denom;
                if (!int.TryParse(parts[0], out num))
                {
                    return false;
                }
                if (!int.TryParse(parts[1], out denom))
                {
                    return false;
                }
                if (denom == 0) return false;
                r.Numerator = num;
                r.Denominator = (uint)denom;
                return true;
            }
            else if(format == "F")
            {
                string[] parts = str.Split("div by");
                if (parts.Length != 2) return false;
                if (!int.TryParse(parts[0], out int num))
                {
                    return false;
                }
                if (!int.TryParse(parts[1], out int denom))
                {
                    return false;
                }
                if (denom == 0) return false;
                r.Numerator = num;
                r.Denominator = (uint)denom;
                return true;
            }
            return false;
        }

        public static implicit operator float(RationalNumber r)
        {
            return (float)r.Numerator / r.Denominator;
        }

        public static implicit operator double(RationalNumber r)
        {
            return (double)r.Numerator / r.Denominator;
        }

        public static explicit operator int(RationalNumber r)
        {
            return r.Numerator / (int)r.Denominator;
        }

        public static explicit operator decimal(RationalNumber r)
        {
            return (decimal)r.Numerator / r.Denominator;
        }

        public static explicit operator long(RationalNumber r)
        {
            return r.Numerator / r.Denominator;
        }
    }
}
