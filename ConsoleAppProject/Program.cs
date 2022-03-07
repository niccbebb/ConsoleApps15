using ConsoleAppProject.App01;
using ConsoleAppProject.App03;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start App01 to App05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Nicole Bebb 06/03/2022
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine();
            Console.WriteLine("   =================================================");
            Console.WriteLine("      BNU CO453 Applications Programming 2021-2022! ");
            Console.WriteLine("                  by Nicole Bebb                    ");
            Console.WriteLine("   =================================================");
            Console.WriteLine();


            DistanceConverter app01 = new DistanceConverter();
            app01.Run();
        }
    }
}
