using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1 {
    class RatNum {
        private int m;
        private int n;

        private static int GCD(int a, int b) {
            if (b < 0) b = -b;
            if (a < 0) a = -a;
            while (b != 0) {
                int t = b;
                b = a % b;
                a = t;
            }
            return a;
        }

        private static int LCM(int a, int b) => Math.Abs(a * b) / GCD(a, b);

        public RatNum(int _m, int _n) {
            if (_n <= 0) throw new ArgumentException("Denominator can't be zero.");
            m = _m;
            n = _n;
        }

        public RatNum(int _m) {
            m = _m;
            n = 1;
        }

        public RatNum Reduce { 
            get {
                int t = GCD(m, n);
                return new RatNum(m / t, n / t);
            }
        }

        public static bool operator ==(RatNum a, RatNum b) => ((a.m * b.n) == (b.m * a.n));

        public static bool operator !=(RatNum a, RatNum b) => ((a.m * b.n) != (b.m * a.n)); // !(a == b)

        public static bool operator >(RatNum a, RatNum b) => ((a.m * b.n) > (b.m * a.n));

        public static bool operator <(RatNum a, RatNum b) => ((a.m * b.n) < (b.m * a.n));

        public static bool operator >=(RatNum a, RatNum b) => ((a.m * b.n) >= (b.m * a.n)); // !(a < b)

        public static bool operator <=(RatNum a, RatNum b) => ((a.m * b.n) <= (b.m * a.n)); // !(a > b)

        public override bool Equals(Object a) => (a != null) && this.GetType().Equals(a.GetType()) && (this == (RatNum)a);

        public static RatNum operator +(RatNum a, RatNum b) {
            int t = LCM(a.n, b.n);
            return new RatNum((a.m * (t / a.n)) + (b.m * (t / b.n)), t);
        }

        public static RatNum operator -(RatNum a, RatNum b) {
            int t = LCM(a.n, b.n);
            return new RatNum((a.m * (t / a.n)) - (b.m * (t / b.n)), t);
        }

        public static RatNum operator -(RatNum a) => new RatNum(-a.m, a.n);

        public static RatNum operator ++(RatNum a) => new RatNum(a.m + a.n, a.n); // a + 1;

        public static RatNum operator --(RatNum a) => new RatNum(a.m - a.n, a.n); // a - 1;

        public static implicit operator RatNum(int a) => new RatNum(a);

        public static explicit operator double(RatNum a) => a.m / (float)a.n;

        public static RatNum operator *(RatNum a, RatNum b) => new RatNum(a.m * b.m, a.n * b.n);

        public static RatNum operator /(RatNum a, RatNum b) => new RatNum(a.m * b.n, a.n * b.m);

        public override string ToString() => (m % n == 0) ? $"{m / n}" : $"{m}/{n}";
    }

    class Program {
        static void Main(string[] args) {
            var x = new RatNum(1, 2);
            RatNum y = 4;
            var z = new RatNum(7, 14);
            var p = new RatNum(1, 3);
            var q = new RatNum(3, 5);

            Console.WriteLine($"{x + 2} = {(float)(x + 2)}");
            Console.WriteLine($"{z} = {z.Reduce}");
            Console.WriteLine($"{x} == {z} : {x == z}");
            Console.WriteLine($"{p} == {q} : {p == q}");
            Console.WriteLine($"{p} - {q} = {p - q} == {p + (-q)} : {p - q == p + (-q)}");
            Console.WriteLine($"{p} != {q} : {p != q}");
            Console.WriteLine($"{p} > {q} : {p > q}");
            Console.WriteLine($"{p} < {q} : {p < q}");
            Console.WriteLine($"{p} >= {q} : {p >= q}");
            Console.WriteLine($"{p} <= {q} : {p <= q}");
            Console.WriteLine($"{p} * {q} = {p * q}");
            Console.WriteLine($"{p} / {q} = {p / q}");
            Console.WriteLine($"{p} / 7 = {p / 7}");
            Console.WriteLine($"{q} * 5 = {q * 5}");

            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey(true);
        }
    }
}
