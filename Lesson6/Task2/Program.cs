using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2 {
    abstract class Figure {
        public enum Color {
            Black,
            Red,
            Green,
            Yellow,
            Blue,
            Magenta,
            Cyan,
            White
        }

        protected Color color;
        
        protected bool visible;

        public abstract void MoveHorisontal(double distance);

        public abstract void MoveVertical(double distance);

        public virtual double GetArea() => 0;

        public void SetColor(Color newcolor) { color = newcolor; }

        public void Show() { visible = true; }
        
        public void Hide() { visible = false; }

        public bool IsVisible() => visible;

        public virtual string Details() => $"Color: {color}. Visible: {visible}. Area: {Area():f2}";

        public override string ToString() => "Figure: " + Details();

        public void PrintState() { 
            switch (color) {
                case Color.Black: Console.ForegroundColor = ConsoleColor.DarkGray;  break;
                case Color.Red: Console.ForegroundColor = ConsoleColor.Red; break;
                case Color.Green: Console.ForegroundColor = ConsoleColor.Green; break;
                case Color.Yellow: Console.ForegroundColor = ConsoleColor.Yellow; break;
                case Color.Blue: Console.ForegroundColor = ConsoleColor.Blue; break;
                case Color.Magenta: Console.ForegroundColor = ConsoleColor.Magenta; break;
                case Color.Cyan: Console.ForegroundColor = ConsoleColor.Cyan; break;
                case Color.White: Console.ForegroundColor = ConsoleColor.White; break;
            }
            Console.WriteLine(this);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        protected Figure(Color Color, bool Visible) {
            color = Color;
            visible = Visible;
        }
    }

    class Point : Figure {
        double x, y;

        public override void MoveHorisontal(double distance) { x += distance; }

        public override void MoveVertical(double distance) { y += distance; }

        public override string Details() => $"({x:f2}, {y:f2}). " + base.Details();

        public override string ToString() => "Point: " + Details();

        public Point(double _x, double _y, Color _color, bool _visible) : base(_color, _visible) {
            x = _x;
            y = _y;
        }
    }

    class Circle : Point {
        double r;

        public override double Area() => Math.PI * r * r;

        public override string Details() => $"Radius: {r:f2}. Center: " + base.Details();

        public override string ToString() => "Circle: " + Details();

        public Circle(double _x, double _y, double _r, Color _color, bool _visible) : base(_x, _y, _color, _visible) { r = _r; }
    }

    class Rectangle : Point {
        double width, height;

        public override double Area() => width * height;

        public override string Details() => $"Width: {width:f2}. Height: {height:f2}. Upper-Left point: " + base.Details();

        public override string ToString() => "Rectangle: " + Details();

        public Rectangle(double _x, double _y, double _width, double _height, Color _color, bool _visible) : base(_x, _y, _color, _visible) {
            width = _width;
            height = _height;
        }
    }

    class Program {
        static Random rnd = new Random();

        static Figure.Color GetRandomColor() {
            switch(rnd.Next(8)) {
                case 0: return Figure.Color.Black;
                case 1: return Figure.Color.Blue;
                case 2: return Figure.Color.Cyan;
                case 3: return Figure.Color.Green;
                case 4: return Figure.Color.Magenta;
                case 5: return Figure.Color.Red;
                case 6: return Figure.Color.White;
                case 7: return Figure.Color.Yellow;
                default: return Figure.Color.Black;
            }
        }

        static void Main(string[] args) {
            var list = new List<Figure>();
            
            for(int i=0; i < 100; i++) {
                switch(rnd.Next(3)) {
                    case 0: list.Add(new Point(rnd.Next(100), rnd.Next(100), GetRandomColor(), rnd.Next(2) == 1)); break;
                    case 1: list.Add(new Circle(rnd.Next(100), rnd.Next(100), rnd.Next(100), GetRandomColor(), rnd.Next(2) == 1)); break;
                    case 2: list.Add(new Rectangle(rnd.Next(100), rnd.Next(100), rnd.Next(100), rnd.Next(100), GetRandomColor(), rnd.Next(2) == 1)); break;
                }
            }

            foreach (Figure f in list) f.PrintState();

            Console.WriteLine(); Console.Write("Press any key to exit..."); Console.ReadKey(true);
        }
    }
}
