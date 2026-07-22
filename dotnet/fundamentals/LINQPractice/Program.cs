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

using System.Globalization;
using LINQPractice;

/*var employees = new List<Employee>
{
    new("Monika", 12, "Engineering", 150000),
    new("Rahul", 5, "HR", 70000),
    new("Amit", 8, "Engineering", 100000),
    new("Priya", 2, "Finance", 60000),
    new("Neha", 10, "Engineering", 130000)
};*/

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
/*var highSal = employees.Max(e => e.Salary);
Console.WriteLine($"Highest Salary: {highSal}");*/

//---------Task 4 Sort employees by salary descending.
/*var desSalary = employees.OrderByDescending(e=>e.Salary);
foreach (var e in desSalary)
{
    Console.WriteLine(e.Salary);
}*/


//----------LINQ query to find: Number of employees earning more than 100000.
/*var sal = employees.Count(e => e.Salary > 100000);
Console.WriteLine(sal);

//-------------LINQ query to find: Number of employees in the Finance department.
var result = employees.Count(e=>e.Department == "Finance");
Console.WriteLine(result);

//------------LINQ query to find: Number of employees with experience greater than 5 years.
var expCount = employees.Count(e=>e.Experience>5);
Console.WriteLine(expCount);*/

/////////-----LINQ -- DISTINCT
/*var employeesList = new List<Employee>
{
    new("Monika", 12, "Engineering", 150000),
    new("Rahul", 5, "HR", 70000),
    new("Amit", 8, "Engineering", 100000),
    new("Priya", 2, "Finance", 60000),
    new("Neha", 10, "Engineering", 130000)
};

//-----------LINQ query to print all unique departments.
var departments = employeesList.Select(e => e.Department).Distinct();
foreach (var dep in departments)
{
    Console.WriteLine(dep);
}

//-----------LINQ query to print all unique experience values.
var exp = employeesList.Select(e => e.Experience).Distinct();
foreach (var e in exp)
{
    Console.WriteLine(e);
}

//-------------LINQ query to print the count of unique departments.
var uniqueDepCount = employeesList.Select(e => e.Department).Distinct().Count();
Console.WriteLine($"Unique department count: {uniqueDepCount}");

//------------code to print employees grouped by department.
var grpDept = employeesList.GroupBy(e => e.Department);
foreach (var grp in grpDept)
{
    Console.WriteLine(grp.Key);
    foreach (var e in grp)
    {
        Console.WriteLine(e.Name);
    }
}

//-----------code to print employee count per department.
var depCount = employeesList.GroupBy(e => e.Department);

foreach (var dep in depCount)
{
    Console.WriteLine($"{dep.Key} - {dep.Count()}");
}

//----------code to print average salary per department.
var depAvg = employeesList.GroupBy(e => e.Department);
foreach (var dep in depAvg)
{
    Console.WriteLine($"{dep.Key} - {dep.Average(e => e.Salary)}");
}

//----------code to find the department with the maximum number of employees.
var maxEmp = employeesList.GroupBy(e => e.Department)
    .OrderByDescending(k => k.Count()).First();

Console.WriteLine($"Max department count: {maxEmp}");
//Advance version
var maxDepartment = employeesList
    .GroupBy(e => e.Department)
    .MaxBy(g => g.Count());

Console.WriteLine(maxDepartment.Key);

//---------------Dictionary
//-- Task 1: Create: Dictionary<string, int> where: Key   = Employee Name, Value = Experience
var employeeDictionary =
    employeesList.ToDictionary(
        e => e.Name,
        e => e.Experience);
foreach (var item in employeeDictionary)
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}

//---Task 2:Create: Dictionary<string, Employee> where: Key = Employee Name Value = Entire Employee object
var empObject = employeesList.ToDictionary(e => e.Name);
Console.WriteLine(empObject["Amit"].Salary);

//---Task 3:

var mulDept = employees.ToDictionary(e => e.Department);
Console.WriteLine(mulDept["Engineering"]);*/

///////////-------JOIN---------
/*//Dataset 1 — Employees
var employeesSet = new List<Employee>
{
    new("Monika", 12, 1),
    new("Rahul", 5, 2),
    new("Amit", 8, 1),
    new("Priya", 2, 3)
};

//Dataset 2 — Departments
var departmentSet = new List<Department>
{
    new(1, "Engineering"),
    new(2, "HR")
//    new(3, "Finance")
};


//Exercise 1: Write an INNER JOIN that prints:

var result = employeesSet.Join(
    departmentSet, // second collection
    e => e.DepartmentId, // employee key
    d => d.Id, // department key
    (e, d) => new // result selector
    {
        Name = e.Name, DepartmentName = d.Name
    });

foreach (var item in result)
{
    Console.WriteLine($"{item.Name} - {item.DepartmentName}");
}
public record Employee(
    string Name,
    int Experience,
    int DepartmentId);

public record Department(
    int Id,
    string Name);*/

/////--------------------SelectMany---------------------------/////////////

/*var employees = new List<Employee>
{
    new("Monika", new List<string>
    {
        "C#",
        ".NET",
        "Angular"
    }),

    new("Rahul", new List<string>
    {
        "SQL",
        "Azure"
    }),

    new("Amit", new List<string>
    {
        "Angular",
        "JavaScript"
    })
};

//Exercise 1: Write a LINQ query to print all skills using SelectMany().
var result = employees.SelectMany(e=>e.Skills);
foreach (var skill in result)
{
    Console.WriteLine(skill);
}

//Exercise 2: Write a LINQ query to print all unique skills.
var resultList = employees.SelectMany(e=>e.Skills).Distinct();
foreach (var skill in resultList)
{
    Console.WriteLine(skill);
}

//Exercise 3: Write a LINQ query to count the total number of skills including duplicates.
var totalSkills = employees.SelectMany(e=>e.Skills).Count();
Console.WriteLine(totalSkills);

//Exercise 4: Write a LINQ query to count the number of unique skills.
var uniqueSkills = employees.SelectMany(e=>e.Skills).Distinct().Count();
Console.WriteLine(uniqueSkills);

public record Employee(
    string Name,
    List<string> Skills);*/

///////////////////-------SkillWhile() TakeWhile()------------///////////////
/*var numbers = new List<int>
{
    10,20,30,40,50,60,70,80
};

//Exercise 1: Write a LINQ query using TakeWhile() to print:
var numbersRes = numbers.TakeWhile(n => n < 60);
foreach (var number in numbersRes)
{
    Console.WriteLine(number);
}

//Exercise 2: Write a LINQ query using SkipWhile() to print:
var numberSkip = numbers.SkipWhile(n => n < 60);
foreach (var number in numberSkip)
{
    Console.WriteLine(number);
}*/

////////////////-----------Aggregation Functions---------------/////////

var employees = new List<Employee>
{
    new("Monika", 12, "Engineering", 150000),
    new("Rahul", 5, "HR", 70000),
    new("Amit", 8, "Engineering", 100000),
    new("Priya", 2, "Finance", 60000),
    new("Neha", 10, "Engineering", 130000)
};
/*//Exercise 1: Write a LINQ query to calculate the total salary.
var totalSal = employees.Sum(e => e.Salary);
Console.WriteLine($"Total Salary: {totalSal}");

//Exercise 2: Write a LINQ query to calculate the average experience.
var avgExp =  employees.Average(e => e.Experience);
Console.WriteLine($"Average Experience: {avgExp}");

//Exercise 3: Write a LINQ query to find the minimum experience.
var minExp = employees.Min(e=>e.Experience);
Console.WriteLine($"Minimum Experience: {minExp}");

//Exercise 4: Write a LINQ query to find the maximum salary.
var maxSal = employees.Max(e=>e.Salary);
Console.WriteLine($"Maximum Salary: {maxSal}");
*/

/////////////----------Contains()-----------///////////
/*var numbers = new List<int>
{
    10, 20, 30, 40, 50
};

//Exercise 1: Write a LINQ query to check whether the collection contains 30.
var result = numbers.Contains(30);
Console.WriteLine(result);

//Exercise 2: Write a LINQ query to check whether the collection contains 100.
var result2 = numbers.Contains(100);
Console.WriteLine(result2);

//Exercise 3: Using employee list, write a LINQ query to check whether any employee has the name "Monika" using Contains()
var checkEmp = employees.Select(e=>e.Name).Contains( "Monika");
Console.WriteLine(checkEmp);

//Exercise 4: Write a LINQ query to check whether any employee has "Engineering" as their department, using Contains().
var checkDep = employees.Select(e=>e.Department).Contains("Engineering");
Console.WriteLine(checkDep);*/

/////////////----------OffType()---------////////////
/*var items = new List<object>
{
    10,
    "Monika",
    20,
    "Rahul",
    30,
    true
};

//Exercise 1 — OfType<int>() Write code to print only the integer values.
var resultInt =  items.OfType<int>();
foreach (var item in resultInt)
{
    Console.WriteLine(item);
}

//Exercise 2 — OfType<string>() Write code to print only the string values.
var resultString = items.OfType<string>();
foreach (var item in resultString)
{
    Console.WriteLine(item);
}

//Exercise 3 — Count integers Write a LINQ query using OfType<int>() to find how many integer values are present.
var resCount = items.OfType<int>().Count();
Console.WriteLine(resCount);

//Exercise 4 — Count strings Write a LINQ query using OfType<string>() to find how many string values are present.
var resStringCount = items.OfType<string>().Count();
Console.WriteLine(resStringCount);

////------Cast<int>()
var numbers = new List<object>
{
    10,
    20,
    30
};

//Exercise 5 — Cast<int>()
var castRes = numbers.Cast<int>();
foreach (var item in castRes)
{
    Console.WriteLine(item);
}*/


//------------ZIP()-------------//
/*var employeeNames = employees.Select(e => e.Name);
var departments = employees.Select(e => e.Department);
var enumEmp = employeeNames.ToList();
var enumDep = departments.ToList();

//Exercise 1: Use Zip() to combine employee names and departments.
var empD = enumEmp.Zip(enumDep);
foreach (var emp in empD)
{
    Console.WriteLine($"{emp.First} - {emp.Second}");   
}

//Exercise 2 Use Zip() to combine: employee names and salaries.
var empNames = employees.Select(e => e.Name);
var salaries = employees.Select(e => e.Salary);

var empSal = empNames.Zip(salaries);
foreach (var emp in empSal)
{
    Console.WriteLine($"{emp.First} - {emp.Second}");
}

//Exercise 3: Use Zip() with a result selector to directly create a formatted string.
var result = enumEmp.Zip(
    enumDep,
    (name, department) => $"{name} - {department}"
);

foreach (var emp in result)
{
    Console.WriteLine(emp);
}*/

///////-----------RANGE---------///////////

//Exercise 1: Write a LINQ query using Range() to print:
var res = Enumerable.Range(1, 10);
foreach (var i in res)
{
    Console.WriteLine(i);
}

//Exercise 2: Write a LINQ query using Range() to print:
var resList = Enumerable.Range(10,6);
foreach (var i in resList)
{
    Console.WriteLine(i);
}

//Exercise 3: Use Range() with LINQ to print only the even numbers from 1 to 10.
var evenList = Enumerable.Range(1, 10).Where(n => n % 2 == 0);
foreach (var i in evenList)
{
    Console.WriteLine(i);
}

//Exercise 4: Use Range() with LINQ to calculate the sum of numbers from 1 to 10.
var rangeSum = Enumerable.Range(1, 10).Sum();
Console.WriteLine(rangeSum);

