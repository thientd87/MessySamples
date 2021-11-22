using System;

namespace MessyExample.DesignPatterns.Creation.Factory
{
    public enum CoordinationSystem
    {
        Cartesian,
        Polar
    }
    // the simple class with stupid contructor
    public class Point
    {
        private double x, y;

        public Point()
        {
            x = 0;
            y = 0;
        }

        protected Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        protected Point(double x, double y, CoordinationSystem system = CoordinationSystem.Cartesian)
        {
            
            var point = new Point(x: x, y: y);
            switch (system)
            {
                case CoordinationSystem.Cartesian:
                    break;
                case CoordinationSystem.Polar:
                    point =  new Point(x: Math.Cos(d: x), y: Math.Sin(a: y));
                    break;
            }
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
}