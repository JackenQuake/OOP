using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2 {
    class Complex {
        private double re;
        private double im;

        public Complex(double _re, double _im) {
            re = _re;
            im = _im;
        }

        public Complex(double _re) : this(_re, 0) { }
        
        public Complex() : this(0) { }

        public double Re { get => re; set { re = value; } }

        public double Im { get => im; set { im = value; } }

        public static Complex operator +(Complex a, Complex b) => new Complex(a.re + b.re, a.im + b.im);

        public static Complex operator -(Complex a) => new Complex(-a.re, -a.im);

        public static Complex operator -(Complex a, Complex b) => new Complex(a.re - b.re, a.im - b.im); // (a + (-b))

        public static Complex operator *(Complex a, Complex b) => new Complex(a.re * b.re - a.im * b.im, a.re * b.im + a.im * b.re);

        public static Complex operator /(Complex a, Complex b) => new Complex((a.re * b.re + a.im * b.im) / (b.re * b.re + b.im * b.im), (a.re * b.im - a.im * b.re) / (b.re * b.re + b.im * b.im));

        public static bool operator ==(Complex a, Complex b) => ((a.re == b.re) && (a.im == b.im));

        public static bool operator !=(Complex a, Complex b) => ((a.re != b.re) || (a.im != b.im)); // !(a == b)

        public void SetPolar(double r, double phi) {
            re = r * Math.Cos(phi);
            im = r * Math.Sin(phi);        
        }

        public static implicit operator Complex(double a) => new Complex(a);

        public double R { get => Math.Sqrt(re * re + im * im); set { SetPolar(value, Phi); } }
        
        public double Phi { get => ((re == 0) && (im == 0)) ? 0 : Math.Atan2(im, re); set { SetPolar(R, value); } }

        public static Complex Pow(Complex a, double n) {
            Complex b = new Complex();
            b.SetPolar(Math.Pow(a.R, n), n * a.Phi);
            return b;
        }

        public static Complex Sqrt(Complex a) => Pow(a, 0.5);
        
        public static Complex Sqr(Complex a) => Pow(a, 2);

        public static Complex Root(Complex a, double n) => Pow(a, 1 / n);

        public static Complex Exp(Complex a) {
            Complex b = new Complex();
            b.SetPolar(Math.Exp(a.Re), a.im);
            return b;
        }

        public override string ToString() {
            if (Math.Abs(im) < 1e-10) return $"{re:f2}"; 
            return $"{re:f2} + {im:f2}i";
        }
    }

    class Program {
        static void Main(string[] args) {
            var x = new Complex(1, 1);
            var y = new Complex(3, 3);
            var z = Complex.Root(y, 4);

            Console.WriteLine($"-({x}) = {-x}");
            Console.WriteLine($"({x}) + ({y}) = {x + y}");
            Console.WriteLine($"({x}) - ({y}) = {x - y}");
            Console.WriteLine($"({x}) * ({y}) = {x * y}");
            Console.WriteLine($"({x}) / ({y}) = {x / y}");
            Console.WriteLine($"({x}) == ({y}) : {x == y}");
            Console.WriteLine($"({x}) != ({y}) : {x != y}");
            Console.WriteLine($"({z})^8  = {Complex.Pow(z, 8)}");
            Console.WriteLine($"e^i*pi = {Complex.Exp(new Complex(0, Math.PI))}");

            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey(true);
        }
    }
}
