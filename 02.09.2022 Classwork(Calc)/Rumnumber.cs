﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork
{ // класс для римских чисел
    public record Rumnumber
    {

        public int Value { get; set; }

        public Rumnumber(int A = 0)
        {
            Value = A;
        }





        public static int Parse(String str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }
            if (str == "N")
            {
                return 0;
            }

            bool isNegative = false;
            if (str.StartsWith('-'))
            {
                isNegative = true;
                str = str[1..];
            }

            if (str.Length < 1)
            {
                throw new ArgumentException("Empty string not allowed");
            }

            char[] digits = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int[] digitValues = { 1, 5, 10, 50, 100, 500, 1000 };

            int pos = str.Length - 1;
            char digit = str[pos];
            int ind = Array.IndexOf(digits, digit);
            if (ind == -1)
            {
                throw new ArgumentException($"Invalid char {digit}");
            }
            int val = digitValues[ind];
            int res = val;
            int nextDigitVal = val;
            while (pos > 0)
            {
                pos -= 1;
                digit = str[pos];
                ind = Array.IndexOf(digits, digit);
                if (ind == -1)
                {
                    throw new ArgumentException($"Invalid char {digit}");
                }
                val = digitValues[ind];
                res += (val < nextDigitVal)
                        ? -val
                        : val;
                nextDigitVal = val;
            }
            return isNegative ? -res : res;
        }

        public Rumnumber Add(Rumnumber rn)
        {

            if (rn is null)
            {
                throw new ArgumentException(nameof(rn));
            }

            return new(this.Value + rn.Value);

        }
        public Rumnumber Add(int rn)
        {



            return new(this.Value + rn);

        }
        public Rumnumber Add(string roman)
        {
            return this.Add(new Rumnumber(Parse(roman)));
        }
        public Rumnumber Add(Rumnumber f, int s)
        {
            return this.Add(new Rumnumber(s));
        }
        public static Rumnumber Add(Rumnumber f, string s)
        {
            return new Rumnumber(f.Value + Parse(s));
        }
        public static Rumnumber Add(string f, string s)
        {
            return new Rumnumber(Parse(f) + Parse(s));
        }
        public static Rumnumber Add(Rumnumber f, Rumnumber s)
        {
            return new Rumnumber(f.Value + s.Value);
        }
        public static Rumnumber Add(int f, int s)
        {
            return new Rumnumber(f).Add(s);
        }

        public static Rumnumber Add(object obj1, object obj2)
        {
            var rns = new Rumnumber[] { null!, null! };
            var pars = new object[] { obj1, obj2 };

            for (int i = 0; i < 2; i++)
            {
                if (pars[i] is null) throw new ArgumentNullException($"obj{i + 1}");

                if (pars[i] is int val) rns[i] = new Rumnumber(val);
                else if (pars[i] is String str) rns[i] = new Rumnumber(Parse(str));
                else if (pars[i] is Rumnumber rn) rns[i] = rn;
                else throw new ArgumentException($"obj{i + 1}: type unsupported");
            }

            return rns[0].Add(rns[1]);   // заменить на цикл
        }
        public static Rumnumber AddOther(object obj1, object obj2)
        {
            var rns = new Rumnumber[] { null!, null! };
            var pars = new object[] { obj1, obj2 };

            for (int i = 0; i < 2; i++)
            {
                if (pars[i] is null) throw new ArgumentNullException($"obj{i + 1}");

                if (pars[i] is int val) rns[i] = new Rumnumber(val);
                else if (pars[i] is String str) rns[i] = new Rumnumber(Parse(str));
                else if (pars[i] is Rumnumber rn) rns[i] = rn;
                else throw new ArgumentException($"obj{i + 1}: type unsupported");
            }

            return rns[0].Add(rns[1]);   // заменить на цикл
        }

        public override string ToString()
        {
            if (this.Value == 0)
            {
                return "N";
            }
            int n = this.Value < 0 ? -this.Value : this.Value;
            String res = this.Value < 0 ? "-" : "";

            String[] parts = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

            for (int j = 0; j <= parts.Length - 1; j++)
            {
                while (n >= values[j])
                {
                    n -= values[j];
                    res += parts[j];
                }
            }

            return res;
        }

       
    }

}
