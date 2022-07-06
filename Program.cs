﻿using System;

namespace UdemyDemos
{
    class Program
    {
        // global variables
        const double PI = 3.14159265359;
        const int Weeks = 52, MONTHS = 12;
        const int Days = 365;

        const string Birthday = "1994-01-16";

        static string[] users = { "Joshua", "Rhiannon", "Indi" };


        public static void Main(string[] args)
        {
            TernaryChallenge();
        }


        // exercise method below

        public static void TernaryChallenge()
        {
            Console.Write("Enter a temperater value as an integer >> ");
            string input = Console.ReadLine();

            bool isInt = Int32.TryParse(input, out int temperature);

            if (isInt)
            {
                string output = temperature <= 15 ? "it is too cold here" : temperature > 28 ? "it is too hot here" : "it is ok";
                Console.Write(output);
            }
            else
            {
                Console.WriteLine("You must enter an integer");
            }
        }

        private static void EnhancedIfDemo()
        {
            int temperature = -15;
            string stateOfMatter;

            stateOfMatter = temperature < 0 ? "Solid" : temperature > 100 ? "Gas" : "Liquid";

            Console.WriteLine("The state of matter is {0}", stateOfMatter);
        }

        private static string LowUpper(string word)
        {
            string lowUpper, upper, low;

            upper = word.ToUpper();
            low = word.ToLower();
            lowUpper = low + upper;

            return lowUpper;
        }

        private static void Count(string word)
        {
            int charTotal = word.Length;

            Console.WriteLine("The amount of characters is {0}.",charTotal);
        }

        private static bool IsRegistered(string name)
        {
            bool isRegistered = false;

            foreach(string user in users)
            {
                if(name.Equals(user, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("name: {0} found to match user: {1}", name, user);
                    isRegistered = true;
                    break;
                }
            }

            return isRegistered;
        }

        private static void IfDemo()
        {
            string name;
            int age;
            string ageString;
            bool success;
            const int MinLength = 6;

            Console.Write("Enter your name >> ");
            name = Console.ReadLine();
            Console.Write("Enter your age >> ");
            ageString = Console.ReadLine();

            success = Int32.TryParse(ageString, out age);

            if (success)
            {
                int years = 5;

                int ageInYears = age + years;

                Console.WriteLine("In {0} years you will be {1}!", years, ageInYears);

                if (name.Length >= MinLength)
                {
                    Console.WriteLine("Hello {0}!!", name);

                    if (IsRegistered(name))
                    {
                        Console.WriteLine("You are a registered user");
                    }
                }
                else
                {
                    Console.WriteLine("your name is not long enough");
                }
            }
        }

        private static void TryCatchDemo()
        {
            bool repeat = true;

            while (repeat)
            {
                repeat = false;

                int number;

                Console.Write("Enter a integer and press enter >> ");
                String input = Console.ReadLine();

                try
                {
                    number = int.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Incorrect value entered, please enter an integer only");
                    repeat = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Value entered is too long, please enter a shorter number");
                    repeat = true;
                }
            }
        }

        private static void InputStringDemo()
        {
            string name;

            Console.Write("Enter your name >> ");
            name = Console.ReadLine();

            Console.WriteLine("Entered name: {0}", name);
            Console.WriteLine("UPPERCASE: {0}", name.ToUpper());
            Console.WriteLine("lowercase: {0}", name.ToLower());
            Console.WriteLine("Trimmed: {0}", name.Trim());

            int nameLength = name.Trim().Length;
            int halfwayPointOfName = nameLength / 2;

            Console.WriteLine("First half (Trimmed): {0}", name.Trim().Substring(0, halfwayPointOfName));
        }

        private static void MethodDemo()
        {
            string firstName = "Joshua";
            string lastName = "Turner";
            string fullName;

            fullName = ConcatName(firstName, lastName);

            Console.WriteLine(fullName);
        }

        private static void CharaterPlaceFinder()
        {
            string word, firstName, lastName;
            char letter;
            int place;

            Console.Write("Enter a string and press enter >> ");
            word = Console.ReadLine();
            Console.Write("Enter a a character to search for in the string entered above and press enter >> ");
            letter = Char.Parse(Console.ReadLine());

            place = (word.IndexOf(letter)) + 1;
            Console.WriteLine("{0} is character {2} in {1}", letter, word, place);

            Console.Write("Enter your first name and press enter >> ");
            firstName = Console.ReadLine();
            Console.Write("Enter your last name and press enter >> ");
            lastName = Console.ReadLine();

            Console.WriteLine("{0} {1}", firstName, lastName);

            Console.Read();
        }

        private static void GeneralStringOutput()
        {
            int age = 28;
            string name = "Joshua";
            string job = "Software Support Specialist";


            Console.WriteLine("String concat");
            Console.WriteLine("My name is " + name + ", I am " + age + " years old");

            Console.WriteLine("\nString formatting");
            Console.WriteLine("Hello my name is {0}, I am {1} years old", name, age);

            Console.WriteLine("\nString interpolation");
            Console.WriteLine($"Hello my name is {name}, I am {age} years old, I am a {job}");
        }

        private static void GeneralVariableDemo()
        {
            int num1;

            num1 = 13;

            int num2 = 30;

            int sum = num1 + num2;

            float flt = 12.4456f;

            double dlt = 12.5615141654;

            decimal dsum = (decimal)flt * (decimal)dlt;

            string name = "Joshua";

            string uname = name.ToUpper();

            String numString = "45";



            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Clear();

            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(sum);

            Console.WriteLine(num1 + " plus " + num2 + " equals " + sum);

            Console.WriteLine(dsum);

            Console.WriteLine(name);
            Console.WriteLine(uname);

            Console.Read();



            string stringForFloat = "0.85";
            string stringForInt = "12345";


            float myFloat = float.Parse(stringForFloat);
            int myInt = Int32.Parse(stringForInt);
        }

        private static String ConcatName(string firstName, string lastName)
        {
            String fullName;

            fullName = firstName + " " + lastName;

            return fullName;
        }
    }
}