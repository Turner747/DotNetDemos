using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDemos
{
    class Radio : ElectricalDevice, IElectricalDevice
    {
        public Radio(bool isOn, string brand) : base(isOn, brand)
        {
        }

        new public void UseDevice()
        {
            if (IsOn)
            {
                Console.WriteLine("Listening to the radio!");
            }
            else
            {
                Console.WriteLine("Radio is off, switch it on first");
            }
        }
    }
}
