using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.ExceptionServices;


namespace UdemyDemos
{
    enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
    enum Month { January = 1, February, March, April, May, June, July, August, September, October, November, December };

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
            RandomDemo();
        }
        

        public static void RandomDemo()
        {
            Console.Write("Ask a question >> ");
            Console.Read();

            Random yesNoMaybe = new Random();
            int answer;

            answer = yesNoMaybe.Next(1, 4);

            if (answer == 1)
            {
                Console.WriteLine("Yes");
            }
            else if (answer == 2)
            {
                Console.WriteLine("Maybe");
            }
            else
            {
                Console.WriteLine("No");
            }

        }

        public static void MathDemo()
        {
            Console.WriteLine("Ceiling: " + Math.Ceiling(17.2));
            Console.WriteLine("Floor: " + Math.Floor(5.9));

            int num1 = 13;
            int num2 = 9;

            Console.WriteLine("Lower of num1 {0} and num2 {1} is {2}", num1, num2, Math.Min(num1, num2));
            Console.WriteLine("Higher of num1 {0} and num2 {1} is {2}", num1, num2, Math.Max(num1, num2));
            Console.WriteLine("3 to the power 5 is " + Math.Pow(3, 5));
            Console.WriteLine(Math.PI);
            Console.WriteLine("Square root of 16 is " + Math.Sqrt(16));
            Console.WriteLine("Always positive (50 - 76): " + Math.Abs(50 - 76));
            Console.WriteLine("The cos of 1 is " + Math.Cos(1));
            
            

            Console.Read();
        }

        public static void EnumDemo()
        {
            Day fri = Day.Friday;
            Day sun = Day.Sunday;
            Day mon = Day.Monday;

            Console.WriteLine((int)fri == 4);

            Month jan = Month.January;
            Month feb = Month.February;
            Month test = Month.January;
            Month nov = Month.November;

            Console.WriteLine(jan == test);
            Console.WriteLine((int)nov == 11);
        }

        public static void StructDemo()
        {
            Game game1;

            game1.name = "Uncharted";
            game1.developer = "Naughty Dog";
            game1.releaseDate = "2007-11-19";
            game1.rating = 9.9;

            game1.Display();
        }

        struct Game
        {
            public string name;
            public string developer;
            public double rating;
            public string releaseDate;

            public Game(string name, string developer, double rating, string releaseDate)
            {
                this.name = name;
                this.developer = developer;
                this.rating = rating;
                this.releaseDate = releaseDate;
            }

            public void Display()
            {
                Console.WriteLine("Game 1 is {0}, developed by {1}, released on {2} and has a rating of {3}",
                    this.name, this.developer, this.releaseDate, this.rating);
            }
        }

        public static void WriteToTextFile()
        {
            string[] lines =
            {
                "first line",
                "second line",
                "third line"
            };

            File.WriteAllLines(@"D:\development\udemy\DemoApp\textFile2.txt", lines);

            string text = File.ReadAllText(@"D:\development\udemy\DemoApp\textFile2.txt");

            Console.WriteLine(text);

            string[] highScores =
            {
                "Josh - 2423465",
                "Atari - 3455"
            };

            File.WriteAllLines(@"D:\development\udemy\DemoApp\highScores.txt", highScores);

            string scores = File.ReadAllText(@"D:\development\udemy\DemoApp\highScores.txt");

            Console.WriteLine(scores);

            using (StreamWriter file = new StreamWriter(@"D:\development\udemy\DemoApp\textFile3.txt"))
            {
                foreach (string line in lines)
                {
                    if (line.Contains("second"))
                    {
                        file.WriteLine(line);
                    }
                }
            }

        }

        public static void ReadFromTextFile()
        {
            string text = System.IO.File.ReadAllText(@"D:\development\udemy\DemoApp\textFile.txt");

            Console.WriteLine(text);

            string[] lines = System.IO.File.ReadAllLines(@"D:\development\udemy\DemoApp\textFile.txt");

            foreach (string line in lines)
            {
                Console.Write(line + ", ");
            }
        }

        public static void AbstractDemo()
        {
            Shape[] shapes =
            {
                new Sphere(4.56),
                new Cube(6.2)
            };

            foreach (Shape shape in shapes)
            {
                shape.GetInfo();

                Cube iceCube = shape as Cube;
                if (iceCube == null)
                {
                    Console.WriteLine("This shape is not a cube");
                }

                if (shape is Cube)
                {
                    Console.WriteLine("This shape is a cube");
                }
            }

            object cube1 = new Cube(7);
            Cube cube2 = (Cube)cube1;

            Console.WriteLine("{0} has a voluem of {1}", cube2.Name, cube2.Volume());
        }

        public static void PolymorphicDemo1()
        {
            var cars = new List<Car>()
            {
                new Audi(200, "blue", "A4"),
                new BMW(250, "red", "M3")
            };

            foreach (var car in cars)
            {
                car.Repair();
            }

            Car bmwZ3 = new BMW(300, "black", "Z3");
            Car audiA3 = new Audi(300, "green", "A3");

            BMW bmwM5 = new BMW(350, "red", "M5");

            Car carB = (Car)bmwM5;

            bmwZ3.ShowDetails();
            audiA3.ShowDetails();
            bmwM5.ShowDetails();
            carB.ShowDetails();

            M3 myM3 = new M3(260, "red", "M3 Super Turbo");

            myM3.ShowDetails();

            bmwZ3.SetCarIDInfo(1234, "Joshua");
            audiA3.SetCarIDInfo(1235, "Rhiannon");

            bmwZ3.GetCarIDInfo();
            audiA3.GetCarIDInfo();

            Console.Read();
        }

        public static void EnumerableDemoTwo()
        {
            List<int> numberList = new List<int>() { 8, 6, 2 };

            int[] numberArray = new int[] { 1, 7, 1, 3 };

            Console.WriteLine(" ");
            CollectionSum(numberList);

            Console.WriteLine(" ");
            CollectionSum(numberArray);

            Console.Read();
        }

        static void CollectionSum(IEnumerable<int> anyCollection)
        {
            int sum = 0;

            foreach(int num in anyCollection)
            {
                sum += num;
            }

            Console.WriteLine("The sum is {0}", sum);
        }

        public static void EnumerableDemo()
        {
            IEnumerable<int> unknownCollection;
            unknownCollection = GetCollection(1);
            Console.WriteLine("Option 1");
            foreach(int num in unknownCollection)
            {
                Console.Write(num + " ");
            }

            unknownCollection = GetCollection(2);
            Console.WriteLine("\n\nOption 2");
            foreach (int num in unknownCollection)
            {
                Console.Write(num + " ");
            }

            unknownCollection = GetCollection(5);
            Console.WriteLine("\n\nOption >2");
            foreach (int num in unknownCollection)
            {
                Console.Write(num + " ");
            }
            Console.Read();
        }

        static IEnumerable<int> GetCollection(int option)
        {
            List<int> numbersList = new List<int>() { 1, 2, 3, 4, 5, };

            Queue<int> numbersQueue = new Queue<int>();
            numbersQueue.Enqueue(1);
            numbersQueue.Enqueue(2);
            numbersQueue.Enqueue(3);
            numbersQueue.Enqueue(4); 
            numbersQueue.Enqueue(5);
            numbersQueue.Enqueue(6);
            numbersQueue.Enqueue(7);
            numbersQueue.Enqueue(8);
            numbersQueue.Enqueue(9);
            numbersQueue.Enqueue(10);

            if(option == 1)
            {
                return numbersList;
            }
            else if( option == 2)
            {
                return numbersQueue;
            }
            else
            {
                return new int[] { 11, 12, 13, 14, 15 };
            }

        }

        public static void InheritanceDemoTwo()
        {
            Post post1 = new Post("Thanks for the birthday wishes", "Joshua Turner", true);
            Console.WriteLine(post1.ToString());

            Console.WriteLine();

            ImagePost imagePost = new ImagePost("Love the New Car",
                                                "Joshua Turner",
                                                "https://www.image.com/image.jpg",
                                                false);
            Console.WriteLine(imagePost.ToString());

            Console.WriteLine();

            VideoPost videoPost = new VideoPost("Watch the new video",
                                                "Joshua Turner",
                                                "https://www.video.com/video.mp4",
                                                30000);
            Console.WriteLine(videoPost.ToString());

            videoPost.Play();
            Console.WriteLine("Press any key to stop the video");
            Console.ReadKey();
            videoPost.Stop();
               
        }


        public static void InheritanceDemo()
        {
            Radio myRadio = new Radio(false, "Sony");
            myRadio.SwitchOn();
            myRadio.UseDevice();

            Console.WriteLine();

            TV myTV = new TV(false, "Samsung");
            myTV.SwitchOn();
            myTV.UseDevice();

            Console.WriteLine();

            ElectricalDevice myConsole = new ElectricalDevice(false, "Nintendo");
            myConsole.SwitchOn();
            myConsole.UseDevice();

            Console.WriteLine();

            Dog dog = new Dog("Fido", 2);
            Console.WriteLine("{0} is {1} years old", dog.Name, dog.Age);
            dog.MakeSound();
            dog.Play();
            dog.Eat();
            dog.Eat();
        }

        public static void OrderDemo()
        {
            Queue<Order> orderQueue = new Queue<Order>();

            foreach(Order o in ReceiveOrdersFromBranchOne())
            {
                orderQueue.Enqueue(o);
            }

            foreach (Order o in ReceiveOrdersFromBranchTwo())
            {
                orderQueue.Enqueue(o);
            }

            while (orderQueue.Count > 0)
            {
                Order currentOrder = orderQueue.Dequeue();
                currentOrder.ProcessOrder();
            }
        }
        
        public static void QueueDemo()
        {
            Queue<int> q = new Queue<int>();

            q.Enqueue(1);
            Console.WriteLine("Item at the start of the queue: {0}", q.Peek());
            q.Enqueue(2);
            Console.WriteLine("Item at the start of the queue: {0}", q.Peek());
            q.Enqueue(3);
            Console.WriteLine("Item at the start of the queue: {0}", q.Peek());

            int item = q.Dequeue();
            Console.WriteLine("Item at the start of the queue: {0}", q.Peek());

            q.Enqueue(4);
            q.Enqueue(5);

            while (q.Count > 0)
            {
                Console.WriteLine("Item {0} being processed has been removed from the queue", q.Peek());
                item = q.Dequeue();
            }
        }

        class Order
        {
            public int OrderID { get; set; }
            public int OrderQuantity { get; set; }

            public Order(int orderID, int orderQuantity)
            {
                this.OrderID = orderID;
                this.OrderQuantity = orderQuantity;
            }

            public void ProcessOrder()
            {
                Console.WriteLine($"Order {OrderID} processed!");
            }
        }

        static Order[] ReceiveOrdersFromBranchOne()
        {
            Order[] orders = new Order[]
            {
                new Order(1,5),
                new Order(2,4),
                new Order(6,10)
            };
            return orders;
        }
        static Order[] ReceiveOrdersFromBranchTwo()
        {
            Order[] orders = new Order[]
            {
                new Order(3,5),
                new Order(4,4),
                new Order(5,10)
            };
            return orders;
        }

        public static void StackDemo()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            Console.WriteLine("Item at the top of the stack: {0}", stack.Peek());
            stack.Push(2);
            Console.WriteLine("Item at the top of the stack: {0}", stack.Peek());
            stack.Push(3);
            Console.WriteLine("Item at the top of the stack: {0}", stack.Peek());
            stack.Push(4);
            Console.WriteLine("Item at the top of the stack: {0}", stack.Peek());
            stack.Push(5);
            Console.WriteLine("Item at the top of the stack: {0}", stack.Peek());

            int poppedItem = stack.Pop();
            
            Console.WriteLine("Popped item: {0}", poppedItem);

            Console.WriteLine("Item at the top of the stack: {0}", stack.Peek());
            
            while(stack.Count > 0)
            {
                Console.WriteLine("The value {0}, at the top was removed", stack.Pop());
                Console.WriteLine("There are now {0} items left in the stack", stack.Count);
            }

            int[] numbers = new int[] { 8, 2, 3, 4, 7, 6, 2 };

            Stack<int> numStack = new Stack<int>();

            foreach(int num in numbers)
            {
                Console.Write(num + " ");

                numStack.Push(num);
            }

            Console.WriteLine();

            while(numStack.Count > 0)
            {
                int tempNum = numStack.Pop();
                
                Console.Write(tempNum + " ");
            }
        }

        public static void DictionaryExamples()
        {
            Employee[] employees =
            {
                new Employee("CEO", "Gwyn", 95,200),
                new Employee("Manager", "Joe", 35,25),
                new Employee("HR", "Lora", 32,21),
                new Employee("Secretary", "Petra", 28,18),
                new Employee("Lead Developer", "Artorias", 55,35),
                new Employee("Intern", "Ernest", 22,8)
            };

            Dictionary<int, string> myDictionary = new Dictionary<int, string>()
            {
                {1, "One"},
                {2, "Two"},
                {3, "Three"}
            };

            Dictionary<string, Employee> employeesDirectory = new Dictionary<string, Employee>();
            foreach(Employee emp in employees)
            {
                employeesDirectory.Add(emp.Role, emp);
            }

            string key = "CEO";

            if (employeesDirectory.ContainsKey(key))
            {
                Employee empl = employeesDirectory[key];
                Console.WriteLine("Emploee name: {0}, Age: {1}, Role: {2}, Salary: {3}", empl.Name, empl.Age, empl.Role, empl.Salary);
            }
            else
            {
                Console.WriteLine("No employe was found with role: {0}", key);
            }

            Employee result = null;

            string key2 = "Intern";

            if (employeesDirectory.TryGetValue(key2, out result))
            {
                Console.WriteLine("\nValue retrieved!\n");

                Console.WriteLine("Emploee name: {0}", result.Name);
                Console.WriteLine("Age: {0}", result.Age);
                Console.WriteLine("Role: {0}", result.Role);
                Console.WriteLine("Salary: {0}", result.Salary);
            }
            else
            {
                Console.WriteLine("No employe was found with role: {0}", key2);
            }

            Console.WriteLine();

            string keyToUpdate = "HR";
            if (employeesDirectory.ContainsKey(keyToUpdate))
            {
                employeesDirectory[keyToUpdate] = new Employee("HR", "Eleka", 26, 18);
                Console.WriteLine("Employee with role/key {0} was updated!", keyToUpdate);
            }

            Console.WriteLine();

            string keyToRemove = "Intern";
            if (employeesDirectory.Remove(keyToRemove))
            {
                Console.WriteLine("Employee with role/key {0} was removed!", keyToRemove);
            }

            Console.WriteLine();

            for (int i = 0; i < employeesDirectory.Count; i++)
            {
                KeyValuePair<string, Employee> keyValuePair = employeesDirectory.ElementAt(i);

                Console.WriteLine("Key: {0}, {1}", keyValuePair.Key, i);

                Employee employeeValue = keyValuePair.Value;

                Console.WriteLine("Emploee name: {0}", employeeValue.Name);
                Console.WriteLine("Employee Age: {0}", employeeValue.Age);
                Console.WriteLine("Employee Role: {0}", employeeValue.Role);
                Console.WriteLine("Employee Salary: {0}", employeeValue.Salary);
            }

            Console.WriteLine();

            Console.WriteLine(ConvertNumber(3)); 
        }
        
        public static string ConvertNumber(int i)
        {
            Dictionary<int, string> numbers = new Dictionary<int, string>() {
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {4, "four"},
                {5, "five"}
            };

            if(numbers.TryGetValue(i, out string value))
                return value;
            else
                return "nope";
        }

        class Employee
        {
            public string Role { get; set; }
            public string Name { get; set; }
            public  int Age { get; set; }
            public float Rate { get; set; } = 20.50f;
            public float Salary 
            {
                get
                {
                    return ((Rate * 8) * 5) * 52;
                } 
            }

            public Employee(string role, string name, int age, float rate)
            {
                this.Role = role;
                this.Name = name;
                this.Age = age;
                this.Rate = rate;
            }
        }

        public static void HashtableChallenge()
        {
            Student[] students = new Student[5];
            students[0] = new Student(1, "Denis", 88);
            students[1] = new Student(2, "Olaf", 97);
            students[2] = new Student(6 ,"Ragner", 65);
            students[3] = new Student(1, "Luise", 73);
            students[4] = new Student(4, "Levi", 58);

            Hashtable studentsTable = new Hashtable();

            foreach (Student stud in students)
            {
                if (!studentsTable.ContainsKey(stud.Id))
                {
                    studentsTable.Add(stud.Id, stud);
                    Console.WriteLine("Student with ID: {0}, added", stud.Id);
                }  
                else
                    Console.WriteLine("Sorry a student already exist with ID: {0}", stud.Id);
            }
        }

        public static void HashtableExamples()
        {
            Hashtable studentTable = new Hashtable();

            Student stud1 = new Student(1, "Josh", 7f);
            Student stud2 = new Student(2, "Jason", 3.33f);
            Student stud3 = new Student(3, "Claire", 4.4f);
            Student stud4 = new Student(4, "Tim", 5.5f);
            Student stud5 = new Student(5, "Anna", 6.1f);

            studentTable.Add(stud1.Id, stud1);
            studentTable.Add(stud2.Id, stud2);
            studentTable.Add(stud3.Id, stud3);
            studentTable.Add(stud4.Id, stud4);
            studentTable.Add(stud5.Id, stud5);
            
            Student storedStudent1 = (Student) studentTable[4];

            Console.WriteLine("Student ID: {0}, Name: {1}, GPA: {2}", storedStudent1.Id, storedStudent1.Name, storedStudent1.GPA);

            Console.WriteLine();

            foreach (DictionaryEntry student in studentTable)
            {
                Student storedStudent = (Student)student.Value;
                Console.WriteLine("Student ID: {0}, Name: {1}, GPA: {2}", storedStudent.Id, storedStudent.Name, storedStudent.GPA);
            }

            Console.WriteLine();
            
            foreach(Student stud in studentTable.Values)
            {
                Console.WriteLine("Student ID: {0}, Name: {1}, GPA: {2}", stud.Id, stud.Name, stud.GPA);
            }
        }

        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public float GPA { get; set; }

            public Student(int id, string name, float gpa)
            {
                this.Id = id;
                this.Name = name;
                this.GPA = gpa;
            }
        }

        public static void CollectionListExamples()
        {
            List<int> list = new List<int>();

            for (int i = 100; i <= 170; i+=2)
            {
                list.Add(i);
            }

            foreach (int i in list)
            {
                Console.Write(i + " ");
            }
        }

        public static void CollectionArrayListExamples()
        {
            // declaring
            ArrayList myArrList = new ArrayList();      // undefined num of objects
            ArrayList myArrList2 = new ArrayList(100);  //defined num of objects

            // add elements
            myArrList.Add("Start");
            myArrList.Add(25);
            myArrList.Add("Hello");
            myArrList.Add(13.25);
            myArrList.Add(true);
            myArrList.Add(new DateTime(1994, 01, 16));
            myArrList.Add('@');
            myArrList.Add(25.13f);
            myArrList.Add("End");

            Console.WriteLine("Array before removing items - {0}", myArrList.Count);

            // remove specific value
            myArrList.Remove(true);

            // remove specific index
            myArrList.RemoveAt(2);

            Console.WriteLine("Array after removing items - {0}", myArrList.Count);

            double sum = 0;

            foreach(object obj in myArrList)
            {
                Console.WriteLine(obj);
            }

            foreach (object obj in myArrList)
            {
                if(obj is int)
                {
                    sum += Convert.ToDouble(obj);
                }
                else if (obj is double)
                {
                    sum += (double) obj;
                }
                else if (obj is string)
                {
                    Console.WriteLine(obj);
                }
            }

            Console.WriteLine("The sum is {0}", sum);
        }

        public static void ParamsExample()
        {
            int price = 50;
            float pi = 3.14f;
            char at = '@';
            string book = "The Hobbit";

            Console.WriteLine("price is {0}, pi is {1}, at is {2}", 32, PI, '@');
            ParamsTestMethod("this", "is", "a", "test", "this", "sentence", "is", "pointless", "but", "it", "could", "go", "forever", "...");

            Console.WriteLine();

            ParamsTestMethodTwo(price, pi, at, book);
            ParamsTestMethodTwo("Hello", 5.3, '$');
            ParamsTestMethodTwo();

            int min = MinV2(5, 4, 1, 2, 7, 3, -6);

            Console.WriteLine("Min is {0}", min);
        }

        public static int MinV2(params int[] numbers)
        {
            int min = int.MaxValue;

            foreach (int num in numbers)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            
            return min;
        }

        public static void ParamsTestMethod(params string[] sentence)
        {
            for (int i = 0; i < sentence.Length; i++)
            {
                Console.Write(sentence[i] + " ");
            }
        }
        public static void ParamsTestMethodTwo(params object[] objects)
        {
            foreach(object obj in objects){
                Console.Write(obj + " ");
            }
            Console.WriteLine();
        }


        public static void ArrayParameters()
        {
            int[] studentsGrades = new int[] { 15, 13, 8, 12, 6, 16 };
            double averageResult = GetAverage(studentsGrades);

            foreach (int grade in studentsGrades)
            {
                Console.WriteLine("Grade: {0}", grade);
            }

            Console.WriteLine($"The average result is {averageResult}");

            int[] happiness = new int[] { 15, 16, 18, 5, 3 };

            SunIsShining(happiness); // values after method: 17, 18, 20, 7, 5

            foreach (int i in happiness)
            {
                Console.Write(i + " ");
            }
        }

        public static void SunIsShining(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] + 2;
            }
        }
            

        // with method above
        static double GetAverage(int[] gradesArray)
        {
            int size = gradesArray.Length;
            double average;
            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                sum += gradesArray[i];
            }

            average = (double)sum / size;

            return average;
        }
        
        public static void JaggedArray()
        {
            // declare type one
            int[][] jaggedArray = new int[3][];

            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];

            jaggedArray[0] = new int[] { 2, 3, 5, 7, 11 };
            jaggedArray[1] = new int[] { 1, 2, 3 };
            jaggedArray[2] = new int[] { 13, 21 };


            // alternate way
            int[][] jaggedArray2 = new int[][]
            {
                new int[] { 2, 3, 5, 7, 11 },
                new int[] { 1, 2, 3 },
                new int[] { 13, 21 }
            };

            Console.WriteLine("The value is {0}", jaggedArray2[0][2]);

            for(int i = 0; i < jaggedArray.Length; i++)
            {
                
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");

            // friend jagged array
            Human[][] friends = new Human[][]
            {
            new Human[] { new Human("Joan", "Turner"), new Human("Norman", "Turner") },
            new Human[] { new Human("Carol", "Green"), new Human("Geoff", "Green") },
            new Human[] { new Human("Julie", "Howard"), new Human("Michael", "Howard") }
            };

            for (int i = 0; i < friends.Length; i++)
            {

                for (int j = 0; j < friends[i].Length; j++)
                {
                    friends[i][j].IntroduceMyself();
                }
                Console.WriteLine("");
            }
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
