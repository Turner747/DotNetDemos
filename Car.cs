using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDemos
{
    public class Car
    {
        public int HP { get; set; }
        public string Colour { get; set; }

        protected CarIDInfo carIDInfor = new CarIDInfo();

        public void SetCarIDInfo(int idNum, string owner)
        {
            carIDInfor.IDNum = idNum;
            carIDInfor.Owner = owner;
        }

        public void GetCarIDInfo()
        {
            Console.WriteLine("The car has an ID of {0} and is owned by {1}", carIDInfor.IDNum, carIDInfor.Owner);
        }

        public Car()
        {

        }

        public Car(int hp, string colour)
        {
            this.HP = hp;
            this.Colour = colour;
        }

        public void ShowDetails()
        {
            Console.WriteLine("Car: Horsepower: {0}, Colour: {1}", this.HP, this.Colour);
        }

        public virtual void Repair()
        {
            Console.WriteLine("The car was repaired");
        }
    }
}
