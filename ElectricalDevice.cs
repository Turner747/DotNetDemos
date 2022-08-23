using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDemos
{
    class ElectricalDevice : IElectricalDevice
    {
        public bool IsOn { get; set; }
        public string Brand { get; set; }

        public ElectricalDevice(bool isOn, string brand)
        {
            IsOn = isOn;
            Brand = brand;
        }

        public void SwitchOn()
        {
            IsOn = true;
        }

        public void SwitchOff()
        {
            IsOn = false;
        }

        public void UseDevice()
        {
            if (IsOn)
            {
                Console.WriteLine("Using {0} Device!", Brand);
            }
            else
            {
                Console.WriteLine("{0} device is off, switch it on first", Brand);
            }
        }
    }
}
