using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDemos
{
    internal class Human
    {
        // member variables
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string eyeColour { get; set; }
        public int age { get; set; }

        public Human()
        {
        }

        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Human(string firstName, string lastName, string eyeColour, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColour = eyeColour;
            this.age = age;
        }


        // member methods
        public void IntroduceMyself()
        {
            if(age != 0 && eyeColour != null)
            {
                if(age > 1)
                    Console.WriteLine("Hi I'm {0} {1}, I am {2} years old and my eyes are {3}", firstName, lastName, age, eyeColour);
                else
                    Console.WriteLine("Hi I'm {0} {1}, I am {2} year old and my eyes are {3}", firstName, lastName, age, eyeColour);
            }
            else if (firstName != null && lastName != null)
            {
                Console.WriteLine("Hi I'm {0} {1}", firstName, lastName);
            }
            else
            {

                Console.WriteLine("Hi I'm a human");
            }
        }

    }
}
