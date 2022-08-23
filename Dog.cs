using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDemos
{
    internal class Dog : Animal
    {
        public bool IsHappy { get; set; }

        public Dog(string name, int age, bool isHungry = true, bool isHappy = true) : base(name, age, isHungry)
        {
            IsHappy = isHappy;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Woof");
        }

        public override void Eat()
        {
            base.Eat();
        }

        public override void Play()
        {
            if (IsHappy)
            {
                base.Play();
            }
            else
            {
                Console.WriteLine("{0} is not happy, and does not want to play", Name);
            }
        }
    }
}
