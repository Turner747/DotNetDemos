using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyDemos
{
    internal class Member
    {
        // member - private field
        private string memberName;
        private string jobTitle;
        private int salary = 20000;

        // member - public fields
        public int age;

        // member properties
        public string JobTitle 
        {
            get
            {
                return jobTitle;
            } 
            set
            {
                jobTitle = value;
            }
        }

        // public member method
        public void Introducing(bool isFriend)
        {
            if (isFriend)
            {
                SharingPrivateInfo();
            }
            else
            {
                Console.WriteLine("Hi, my name is {0}, my job title is {1}. I am {2} years old.", memberName, jobTitle, age);
            }
        }

        private void SharingPrivateInfo()
        {
            Console.WriteLine("My salary is {0}", salary);
        }

        

        // member constructor
        public Member()
        {
            age = 30;
            memberName = "Lucy";
            salary = 60000;
            jobTitle = "Developer";
            Console.WriteLine("Member object created");
        }

        // member - finaliser - destructor
        ~Member()
        {
            Console.WriteLine("Destruction of member objects");
            Debug.Write("Destruction of member objects");
        }
    }
}
