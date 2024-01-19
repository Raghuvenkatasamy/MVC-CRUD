using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the start date");
            int startdate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the end date");
            var enddate = Convert.ToInt32(Console.ReadLine());
            var year = (startdate + enddate) / 365;
            var weeks = (startdate + enddate) / 7;
            Console.WriteLine($"{year}-years,{weeks}-weeks");
        }
    }
}
