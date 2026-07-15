/*// LINQPractice: demonstrate query-expression syntax to find employees with >8 years
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQPractice
{
    public record Employee(string Name, int Experience, string Department);

    public class Program
    {
        public static void Main()
        {
            var employees = new List<Employee>
            {
                new("Monika",12,"Engineering"),
                new("Rahul",5,"HR"),
                new("Amit",8,"Engineering"),
                new("Priya",2,"Finance"),
                new("Neha",10,"Engineering")
            };

            // LINQ query expression: find employees with more than 8 years
            var experienced = from e in employees
                              where e.Experience > 8
                              select e;

            Console.WriteLine("LINQ (query syntax) - Employees with more than 8 years of experience:");
            foreach (var emp in experienced)
            {
                Console.WriteLine($"{emp.Name} - {emp.Experience} years - {emp.Department}");
            }
        }
    }
}*/

using LINQPractice;

var employees = new List<Employee>
{
    new("Monika", 12, "Engineering", 150000),
    new("Rahul", 5, "HR", 70000),
    new("Amit", 8, "Engineering", 100000),
    new("Priya", 2, "Finance", 60000),
    new("Neha", 10, "Engineering", 130000)
};

//--------- LINQ Operation 1: Where()
/* var seniorEmployees = employees.Where(e => e.Experience >= 10);

 foreach (var emp in seniorEmployees)
 {
     Console.WriteLine(emp.Name);
}*/

//------------LINQ Operation 2: Select()

/*var employeeNames = employees
    .Select(e => e.Name);

foreach(var name in employeeNames)
{
    Console.WriteLine(name);
}*/

//------LINQ Operation 3: OrderBy()
/*var sortedEmployees = employees
    .OrderBy(e => e.Experience);

foreach(var employee in sortedEmployees)
{
    Console.WriteLine($"{employee.Name} - {employee.Experience}");
}*/

//------LINQ Operation 5: Any()
/*var hasSeniorEmployee = employees
    .Any(e => e.Experience > 10);

Console.WriteLine(hasSeniorEmployee);*/




//-----Task 1: Print only employee names.
/*var empNames = employees.Select(e=>e.Name);
foreach(var name in empNames)
{
    Console.WriteLine(name);
}*/

//------Task 2: Find employees from Engineering department.
/*var depEmp = employees.Where(e => e.Department == "Engineering");
foreach (var dep in depEmp)
{
    Console.WriteLine(dep.Name);
}*/

//-----Task 3 Find the highest salary.
var highSal = employees.Max(e => e.Salary);
Console.WriteLine($"Highest Salary: {highSal}");

//---------Task 4 Sort employees by salary descending.
var desSalary = employees.OrderByDescending(e=>e.Salary);
foreach (var e in desSalary)
{
    Console.WriteLine(e.Salary);
}