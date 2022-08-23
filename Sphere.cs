using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDemos
{
    class Sphere : Shape
    {
        public double Radius { get; set; }

        public Sphere(double radius)
        {
            this.Name = "Sphere";
            this.Radius = radius;
        }

        public override double Volume()
        {
            double volume = (4 / 3) * Math.PI * Math.Pow(this.Radius, 3);
            return volume;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"This is a {this.Name} with radius of {this.Radius} and a volume of {this.Volume()}");
        }
    }
}
