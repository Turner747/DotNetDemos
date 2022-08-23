using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDemos
{
    class TV : ElectricalDevice, IElectricalDevice
    {
        public TV(bool isOn, string brand) : base(isOn, brand)
        {
        }

        new public void UseDevice()
        {
            if (IsOn)
            {
                Console.WriteLine("Watching TV!");
            }
            else
            {
                Console.WriteLine("TV is off, switch it on first");
            }
        }

    }
}
