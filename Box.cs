using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDemos
{
    internal class Box
    {
        // member variables
        private int length;
        public int height;
        public int width;
        public int volume;

        public Box(int length, int height, int width)
        {
            this.length = length;
            this.height = height;
            this.width = width;
            this.CalculateVolume();
        }

        public void SetLength(int length)
        {
            if (length < 0)
                throw new ArgumentOutOfRangeException("length cannot be a negative");
            this.length = length;
            this.CalculateVolume();
        }

        public int GetLength()
        {
            return this.length;
        }



        public void DisplayInfo()
        {
            Console.WriteLine(
                "Length is {0} and height is {1} and width is {2} so volume is {3}", 
                length, height, width, volume); 
        }

        private void CalculateVolume()
        {
            this.volume = length * height * width;
        }

    }
}
