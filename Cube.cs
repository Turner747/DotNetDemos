using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDemos
{
    class Cube : Shape
    {
        public double Length { get; set; }

        public Cube(double length)
        {
            this.Name = "Cube";
            this.Length = length;
        }

        public override double Volume()
        {
            double volume = Math.Pow(this.Length, 3);
            return volume;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"This is a {this.Name} with length of {this.Length} and a volume of {this.Volume()}");
        }
    }
}
