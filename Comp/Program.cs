using System;
using Comp.Entities;
using Comp.Entities.Enum;
using System.Globalization;

namespace Comp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name:");
            string DeprtName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel lvl = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(DeprtName);
            Worker worker = new Worker(name, lvl, salary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #" + i + " contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double value = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, value, hours);
                worker.AddContract(contract);
              

            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string MonthYear = Console.ReadLine();
            int month = int.Parse(MonthYear.Substring(0, 2));
            int year = int.Parse(MonthYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department);
            Console.WriteLine("Income for " + MonthYear + ": " + worker.Income(month, year));
        }
    }
}
