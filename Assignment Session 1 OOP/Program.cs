namespace Assignment_Session_1_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1-Create an Enum called "WeekDays" with the days of the week (Monday to Sunday) as its members. Then, write a C# program that prints out all the days of the week using this Enum.

            Console.WriteLine("Here are all the days of the week : ");

            foreach (WeekDays Day in Enum.GetValues(typeof(WeekDays)))
            {
                Console.WriteLine(Day);
            }


            #endregion



            #region 2-Create an Enum called "Seas on" with the four seasons (Spring, Summer, Autumn, Winter) as its members. Write a C# program that takes a season name as input from the user and displays the corresponding month range for that season. Note range for seasons ( spring march to may , summer june to august , autumn September to November , winter December to February)

            Season season = new Season();
            Months month = new Months();
            bool isParsed;
            Season SeasonName;
            do
            {
                Console.Write("Please Enter Season Name : ");
                isParsed = Enum.TryParse(Console.ReadLine(), out SeasonName);
            } while (!isParsed || SeasonName < Season.Spring || SeasonName > Season.Winter); // Check if isparsed is not True and check that is my number from Spring to Winter ( From 1 to 4)
            season = SeasonName;


            string seasonMonths = season switch
            {
                Season.Spring => $"\n{Months.March}\n{Months.April}\n{Months.May}",
                Season.Summer => $"\n{Months.June}\n{Months.July}\n{Months.August}",
                Season.Autumn => $"\n{Months.September}\n{Months.October}\n{Months.November}",
                Season.Winter => $"\n{Months.December}\n{Months.January}\n{Months.February}",
            };

            Console.WriteLine($"Your Season Name is {season}\nand your month range for that season are {seasonMonths}");
            #endregion

            #region 3-Assign the following Permissions (Read, write, Delete, Execute) in a form of Enum ,Create Variable from previous Enum to Add and Remove Permission from variable, check if specific Permission existed inside variable

            Permissions permission = new Permissions();

            permission = (Permissions)3; //Convert 3 into binary 
                                         //3 / 2 = 1 , reminder = 1
                                         // 1 / 2 = 0 , reminder = 1
                                         // binary of 3 = 0000 0011(which is read = 1, Write = 2)

            //using Hasflag Function to check if specific Permission existed inside variable, then use XOR(^) to to Add permissions if its not exists, since we check by hasflag at if else so it will be never remove, because if its exists it will print thats its exists if not he will add it

            Console.WriteLine($"Old Permissions are {permission}");

            bool isexecute = permission.HasFlag(Permissions.Execute);

            if (isexecute)

            {
                Console.WriteLine("You Have Execute Permession");
            }

            else
            {
                permission ^= Permissions.Execute; // execute = 4 , permression = 3 
                                                   // 0100 ^
                                                   // 0011 
                                                   // ----
                                                   // 0000 0111  => 7 ( it will print  Read , Write and it will add execute since its not exists )
            }

            Console.WriteLine($"Updated Permissions are {permission}");



            // You can also use OR ( | )
            // It will check if permission existed => do nothing
            // It will chec if permission is not exists => it will add it

            permission |= Permissions.Execute;  // execute = 4 , permression = 3 
                                                // 0100 |
                                                // 0011 
                                                // ----
                                                // 0000 0111  => 7 ( it will print  Read , Write and it will add execute since its not exists )

            Console.WriteLine($"Updated Permissions are {permission}");

            #endregion

            #region 4.Create an Enum called "Colors" with the basic colors (Red, Green, Blue) as its members. Write a C# program that takes a color name as input from the user and displays a message indicating whether the input color is a primary color or not.

            Colors color = new Colors();
            bool isParsed;
            Colors ColorName;
            do
            {
                Console.Write("Please Enter Color Name : ");
                isParsed = Enum.TryParse(Console.ReadLine(), out ColorName);
                            do
            { 
                Console.Write("Please Enter Color Name : ");
                isParsed = Enum.TryParse(Console.ReadLine(), out colorName);
                Console.WriteLine(isParsed
                          ? (colorName == Colors.Red || colorName == Colors.Blue || colorName == Colors.Green 
                              ? $"The {colorName} color is a primary color."
                              : "")
                          : "This Color is not a primary Color");
            } while (!isParsed); // Check if isparsed is not True

            #endregion
        }
    }
}
