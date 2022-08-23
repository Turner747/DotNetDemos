using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDemos
{
    abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsHungry { get; set; }

        protected Animal(string n, int a, bool h = true)
        {
            Name = n;
            Age = a;
            IsHungry = h;
        }

        public virtual void MakeSound()
        {
            
        }

        public virtual void Eat()
        {
            if (IsHungry)
            {
                Console.WriteLine("{0} is eating", Name);
                IsHungry = false;
            }
            else
            {
                Console.WriteLine("{0} is not hungry", Name);
            }
        }

        public virtual void Play()
        {
            Console.WriteLine("{0} is playing", Name);
        }
    }
}
