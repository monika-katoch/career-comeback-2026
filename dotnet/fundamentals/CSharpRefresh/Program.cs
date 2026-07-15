// See https://aka.ms/new-console-template for more information

//Console.WriteLine("Hello, World!");

//////// init Properties: to set value at the object creation time only //////////

/*using CSharpRefresh;

var emp = new Emp
{
    Name = "Monika",
    Experience = 12
};
Console.WriteLine(emp.Name);
Console.WriteLine(emp.Name?.Length ?? 0);
namespace CSharpRefresh
{
    public class Emp
    {
        public string? Name { get; init; }
        public int Experience { get; init; }
    }
}*/
///////// Nullable reference type ///////
/*string? managerName = null;

Console.WriteLine(managerName?.Length ?? 0);

managerName = "Rahul";

Console.WriteLine(managerName?.Length ?? 0);*/

////////////// Pattern Matching //////////////

/*object value = 12;

if (value is int years)
{
    Console.WriteLine(years);
}*/

/*string? managerName = null;

Console.WriteLine(managerName?.Length ?? 0);

managerName = "Monika";

Console.WriteLine(managerName?.Length ?? 0);

object value = 12;

if (value is int years && years > 10)
{
    Console.WriteLine($"Senior Developer with {years} years experience");
}*/

///////// Record //////////

/*var employee = new Employee(
    "Monika",
    12,
    "Engineering"
);

var promotedEmployee = employee with
{
    Experience = 13
};
Console.WriteLine(promotedEmployee);*/

///////////////////////////////// 
/*var employees = new List<CSharpRefresh.Employee>
{
    new("Monika",12,"Engineering"),
    new("Rahul",5,"HR"),
    new("Amit",8,"Engineering"),
    new("Priya",2,"Finance"),
    new("Neha",10,"Engineering")
};

// Find employees with more than 8 years of experience
var experiencedEmployees = employees.Where(e => e.Experience > 8).ToList();

Console.WriteLine("Employees with more than 8 years of experience:");
foreach (var emp in experiencedEmployees)
{
    Console.WriteLine($"{emp.Name} - {emp.Experience} years - {emp.Department}");
}

public record Employee(
    string Name,
    int Experience,
    string Department
);*/

using CSharpRefresh;

var employee = new Employee(
    "Monika",
    12
);

Console.WriteLine(employee.Name);
Console.WriteLine(employee.Experience);