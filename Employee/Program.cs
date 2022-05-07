using System.Diagnostics.Contracts;
using System.Reflection.Emit;
using Employee.Entities;
using Employee.Entities.Enums;

namespace Employee;

using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter department's name: ");
        string nameDepartment = Console.ReadLine();
        Console.WriteLine("Enter worker data: ");
        Console.Write("Name: ");
        string name = Console.ReadLine();
        // Conversão de string para o tipo WorkerLevel
        Console.Write("Level : Junior/MidLevel/Senior: ");
        WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
        Console.Write("Base salary: ");
        double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Department department = new Department(nameDepartment);
        Worker worker = new Worker(name, level, baseSalary, department);

        Console.Write("How many contracts to this worker? ");
        int quantity = int.Parse(Console.ReadLine());
        for (int i = 0; i < quantity; i++)
        {
            Console.WriteLine($"Enter #{i + 1}  Contract data: ");
            Console.Write("Date: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Value per hour: ");
            double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Duration: (hours) ");
            int hours = int.Parse(Console.ReadLine());

            // Instanciando um contrato
            HourContract contract = new HourContract(date, valuePerHour, hours);
            // Adicionando um contrato a um funcionário
            worker.AddContract(contract);
        }

        Console.Write("Enter month and year to calculate income (MM/YYYY): ");
        string monthAndYear = Console.ReadLine();
        // Converte a variavel monthAndYear para int
        // Recorta a string da posição 0 até a posição 2
        int month = int.Parse(monthAndYear.Substring(0, 2));

        // Especifica que será usada o valor partir da posição 3
        int year = int.Parse(monthAndYear.Substring(3));

        Console.WriteLine($"Name: {worker.Name}");
        Console.WriteLine($"Department: {worker.Department.Name}");
        Console.WriteLine($"Income: {monthAndYear}: {worker.Income(year, month)}");
    }
}