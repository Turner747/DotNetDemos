using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDemos
{
    public class BMW : Car
    {
        private string brand = "BMW";
        public string Model { get; set; }

        public BMW()
        {

        }

        public BMW(int hp, string colour, string model) : base(hp, colour)
        {
            this.Model = model;
        }

        public void ShowDetails()
        {
            Console.WriteLine("{3}: Model: {2}, Horsepower: {0}, Colour: {1}", this.HP, this.Colour, this.Model, brand);
        }

        public override void Repair()
        {
            Console.WriteLine("The {0} {1} was repaired", brand, this.Model);
        }
    }
}
