using System;

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
            LoopingMatrix();
        }

        public static void LoopingMatrix()
        {
            int[,] matrix =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            foreach(int num in matrix)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine("");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] % 2 == 1)
                        Console.Write(matrix[i, j] + " ");
                    else
                        Console.Write("  ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] % 2 == 0)
                        Console.Write(matrix[i, j] + " ");
                    else
                        Console.Write("  ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                        Console.Write(matrix[i, j] + " ");
                    else
                        Console.Write("  ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");

            for (int i = 0, j = 2; i < matrix.GetLength(0); i++, j--)
            {
                Console.Write(matrix[i, j] + " ");
            }
        }


        public static void MultiDimensionalArrays()
        {
            string[,] matrix;

            int[,,] cube;

            int[,] array2D = new int[,]
            {
                {1,2,3}, // row 0
                {4,5,6}, // row 1
                {7,8,9}  // row 2
            };

            //    3D Array - Cube
            //            ______
            //         z / top /|   
            //          /_____/ |   <- right face
            //          |     | |
            //        y |front| /
            //          |_____|/   
            //             x
            //

            int[,,] array3D = new int[,,] // z,y,x
            {
                {   // z index 0
                    {1,2,3}, // y index 0
                    {4,5,6}, // y index 1
                    {7,8,9}  // y index 2
                },
                {   // z index 1
                    {11,12,13}, // y index 0
                    {14,15,16}, // y index 1
                    {17,18,19}  // y index 2
                },
                {   // z index 2
                    {21,22,23}, // y index 0
                    {24,25,26}, // y index 1
                    {27,28,29}  // y index 2
                }
            };
            
            
            Console.WriteLine("Central value in the 2d array is {0}", array2D[1, 1]);

            Console.WriteLine("The centre value of the right face in the 3d array is {0}", array3D[1, 1, 2]);

            Console.WriteLine("The top right value of the back face in the 3d array is {0}", array3D[2, 0, 2]);
        }
        
        public static void ArrayLoopChallenge()
        {
            Console.Write("Enter a value >> ");
            var input = Console.ReadLine();

            Console.Write("What data type is the value:\n" +
                                "1. String\n" +
                                "2. Integer\n" +
                                "3. Boolean\n" +
                                "data type >> ");

            int dataType = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("The value you has entered is: {0}", input);

            string validMessage = "It is a valid: ";
            string invalidMessage = "It is an invalid: ";

            switch (dataType)
            {
                case 1:
                    validMessage += "String";
                    invalidMessage += "String";

                    if (isAllAlphabetic(input))
                        Console.WriteLine(validMessage);
                    else
                        Console.WriteLine(invalidMessage);
                    
                    break;
                case 2:
                    validMessage += "Integer";
                    invalidMessage += "Integer";

                    if (Int32.TryParse(input, out int result))
                        Console.WriteLine(validMessage);
                    else
                        Console.WriteLine(invalidMessage);

                    break;
                case 3:
                    validMessage += "Boolean";
                    invalidMessage += "Boolean";
                    
                    if (Boolean.TryParse(input, out bool resultTwo))
                        Console.WriteLine(validMessage);
                    else
                        Console.WriteLine(invalidMessage);

                    break;
                default:
                    Console.WriteLine("You have not selected a valid data type");
                    break;
            }

        }
        
        public static bool isAllAlphabetic(string input)
        {
            foreach(char c in input)
            {
                if (!char.IsLetter(c))
                    return false;
                    
            }

            return true;
        }
            

        public static void FriendArray()
        {
            string[] friends = { "Beau", "Ryan", "Dylan", "Richard", "Rhiannon" };

            foreach (string friend in friends)
            {
                Console.WriteLine("Hello, {0}", friend);
            }
            Console.Read();
        }

        public static void ArrayDemoOne()
        {
            int[] grades = new int[5];

            grades[0] = 20;
            grades[1] = 15;
            grades[2] = 12;
            grades[3] = 9;
            grades[4] = 7;

            for(int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine("grades at index {0} : {1}", i, grades[i]);
            }

            int[] mathsGrades = { 25, 10, 9, 9, 7 };

            for (int i = 0; i < mathsGrades.Length; i++)
            {
                Console.WriteLine("Maths grades at index {0} : {1}", i, mathsGrades[i]);
            }

            int[] scienceGrades = { 21, 17, 15, 9, 7 };

            int element = 0;
            
            foreach (int grade in scienceGrades)
            {
                Console.WriteLine("Science grades at {1} : {0}", grade, element);

                element++;
            }

            Console.Read();
        }


        // exercise method below
        public static void MembersDestructorsDemo()
        {
            Member member1 = new Member();
            member1.Introducing(true);
            Console.ReadKey();
        }

        public static void PropertiesDemo()
        {
            Box box = new Box(3, 4, 5);
            Console.WriteLine("The box length is {0}", box.GetLength());
            try
            {
                box.SetLength(-4);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("You can set box variables to negatives");
            }
            box.DisplayInfo();
            box.Height = -6;
            box.Width = 9;
            box.DisplayInfo();
            Console.WriteLine("The box volume is {0}", box.Volume);
            Console.WriteLine("The box's front surface area is", box.FrontSurface);

            Console.Read();
        }

        public static void ClassDemos()
        {
            Human denis = new Human("Denis","Dick", "blue", 26);
            denis.IntroduceMyself();
            denis.lastName = "Rodman";
            denis.IntroduceMyself();
            Human atari = new Human("Atari", "Turner", "blue", 1);
            atari.IntroduceMyself();
            Human josh = new Human("Joshua", "Turner");
            josh.IntroduceMyself();
            Human rhi = new Human();
            rhi.IntroduceMyself();

            Console.Read();
        }



        public static void PeopleCounter()
        {
            bool repeat = true;
            int counter = 0;
            while (repeat)
            {
                Console.WriteLine("People on the Bus: " + counter++);
                Console.WriteLine("----------------------");
                Console.WriteLine("Press enter for every person who enters the bus");
                Console.WriteLine("or enter an integer then press enter to stop");
                
                string test = Console.ReadLine();
                bool isInt = Int32.TryParse(test, out int num);

                if(!isInt)
                {
                    Console.Clear();
                }
                else
                {
                    repeat = false;
                }
            }
        }

        public static void Looping()
        {
            for(int i = 0; i < 15; i++)
            {
                Console.WriteLine("For: " + (i + 1));
            }

            int counter = 0;

            do
            {
                Console.WriteLine("Do while: " + ++counter);
            } while (counter < 5);

            counter = 0;
            bool doNext = false;

            do
            {
                Console.WriteLine("Do while 2: " + ++counter);
                Console.Write("Want to keep going? (1=yes 0=no default=no) >> ");
                int repeat = Int32.Parse(Console.ReadLine());

                if(repeat == 1) // could just be if equals to one but felt like doing a switch
                    doNext = true;
            }while (doNext);


            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("For with a break: " + (i + 1));
                if(i == 3)
                {
                    Console.WriteLine("at 4 we stop");
                    break;
                }
            }

            for (int i = 0; i < 15; i++)
            {
                
                if (i == 3)
                {
                    Console.WriteLine("we skip 4");
                    continue;
                }
                Console.WriteLine("For with a continue: " + (i + 1));
            }


            Console.Read();
        }

        public static void TernaryChallenge()
        {
            Console.Write("Enter a temperater value as an integer >> ");
            string input = Console.ReadLine();

            bool isInt = Int32.TryParse(input, out int temperature);

            if (isInt)
            {
                string output = temperature <= 15 ? "it is too cold here" : 
                                temperature > 28 ? "it is too hot here" : 
                                /*if between 16 and 28*/ "it is ok";
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
            bool repeat = false;

            do
            {
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
                finally
                {
                    Console.WriteLine("You see me either way");
                }
            } while (repeat);
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
