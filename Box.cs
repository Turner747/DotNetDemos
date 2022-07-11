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
        private int height;
        //public int width;
        private int volume;

        public int Width { get; set; }

        public Box(int length, int height, int width)
        {
            this.length = length;
            this.height = height;
            this.Width = width;
            this.CalculateVolume();
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if(value < 0)
                {
                    height = -value;
                }
                else
                {
                    height = value;
                }
                CalculateVolume();
            }
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

        public int Volume
        {
            get { return this.volume; }
        }

        public int FrontSurface
        {
            get
            {
                return this.length * this.Height;
            }
            
        }

        public void DisplayInfo()
        {
            CalculateVolume();
            Console.WriteLine(
                "Length is {0} and height is {1} and width is {2} so volume is {3}", 
                length, height, Width, volume); 
        }

        private void CalculateVolume()
        {
            this.volume = length * height * Width;
        }

    }
}
