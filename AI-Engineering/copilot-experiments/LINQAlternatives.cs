// Comprehensive demonstration of alternative LINQ implementations
// All examples filter employees with Experience > 8

using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQPractice
{
    public record Employee(string Name, int Experience, string Department);

    public class LINQAlternativesDemo
    {
        public static void Main()
        {
            var employees = new List<Employee>
            {
                new("Monika", 12, "Engineering"),
                new("Rahul", 5, "HR"),
                new("Amit", 8, "Engineering"),
                new("Priya", 2, "Finance"),
                new("Neha", 10, "Engineering")
            };

            Console.WriteLine("========== ALTERNATIVE LINQ IMPLEMENTATIONS ==========\n");

            // 1. Method Syntax with Where().ToList()
            Console.WriteLine("1. METHOD SYNTAX - Where().ToList():");
            var alt1 = employees.Where(e => e.Experience > 8).ToList();
            PrintEmployees(alt1);

            // 2. Query Expression Syntax
            Console.WriteLine("\n2. QUERY EXPRESSION SYNTAX:");
            var alt2 = (from e in employees
                       where e.Experience > 8
                       select e).ToList();
            PrintEmployees(alt2);

            // 3. List<T>.FindAll() method
            Console.WriteLine("\n3. List<T>.FindAll() - Legacy approach:");
            var alt3 = employees.FindAll(e => e.Experience > 8);
            PrintEmployees(alt3);

            // 4. Where() with explicit Select()
            Console.WriteLine("\n4. Where() with explicit Select():");
            var alt4 = employees
                .Where(e => e.Experience > 8)
                .Select(e => e)
                .ToList();
            PrintEmployees(alt4);

            // 5. Method Syntax without ToList() - deferred execution
            Console.WriteLine("\n5. DEFERRED EXECUTION - Without ToList():");
            IEnumerable<Employee> alt5 = employees.Where(e => e.Experience > 8);
            PrintEmployees(alt5);

            // 6. Using Where with index
            Console.WriteLine("\n6. Where() with index:");
            var alt6 = employees
                .Where((e, index) => e.Experience > 8)
                .ToList();
            PrintEmployees(alt6);

            // 7. Query syntax with orderby
            Console.WriteLine("\n7. QUERY SYNTAX - With OrderBy:");
            var alt7 = (from e in employees
                       where e.Experience > 8
                       orderby e.Experience descending
                       select e).ToList();
            PrintEmployees(alt7);

            // 8. Method chaining with OrderByDescending
            Console.WriteLine("\n8. METHOD SYNTAX - With OrderByDescending():");
            var alt8 = employees
                .Where(e => e.Experience > 8)
                .OrderByDescending(e => e.Experience)
                .ToList();
            PrintEmployees(alt8);

            // 9. Custom extension method
            Console.WriteLine("\n9. CUSTOM EXTENSION METHOD - IsExperienced():");
            var alt9 = employees.Where(e => e.IsExperienced()).ToList();
            PrintEmployees(alt9);

            // 10. Using AsEnumerable explicitly (for LINQ to Objects)
            Console.WriteLine("\n10. AsEnumerable() - explicit LINQ to Objects:");
            var alt10 = employees
                .AsEnumerable()
                .Where(e => e.Experience > 8)
                .ToList();
            PrintEmployees(alt10);

            // 11. Using First() with Any() check
            Console.WriteLine("\n11. Using First() with filter - first senior employee:");
            var alt11 = employees.FirstOrDefault(e => e.Experience > 8);
            Console.WriteLine($"   {alt11?.Name} - {alt11?.Experience} years - {alt11?.Department}");

            // 12. Using Skip and Take with Where
            Console.WriteLine("\n12. Where() with Skip() and Take():");
            var alt12 = employees
                .Where(e => e.Experience > 8)
                .Skip(0)
                .Take(10)
                .ToList();
            PrintEmployees(alt12);

            // 13. Query syntax with multiple conditions
            Console.WriteLine("\n13. QUERY SYNTAX - Multiple Where clauses:");
            var alt13 = (from e in employees
                        where e.Experience > 8
                        where e.Department == "Engineering"
                        select e).ToList();
            PrintEmployees(alt13);

            // 14. Method syntax with multiple Where clauses
            Console.WriteLine("\n14. METHOD SYNTAX - Chained Where():");
            var alt14 = employees
                .Where(e => e.Experience > 8)
                .Where(e => e.Department == "Engineering")
                .ToList();
            PrintEmployees(alt14);

            // 15. Anonymous type projection then filter
            Console.WriteLine("\n15. Project to Anonymous Type with Where:");
            var alt15 = employees
                .Select(e => new { e.Name, e.Experience, e.Department })
                .Where(x => x.Experience > 8)
                .ToList();
            foreach (var emp in alt15)
            {
                Console.WriteLine($"   {emp.Name} - {emp.Experience} years - {emp.Department}");
            }

            // 16. Using Count or Any before displaying
            Console.WriteLine("\n16. Check existence with Any() before filtering:");
            if (employees.Any(e => e.Experience > 8))
            {
                var alt16 = employees.Where(e => e.Experience > 8).ToList();
                Console.WriteLine($"   Found {alt16.Count} experienced employees");
                PrintEmployees(alt16);
            }

            // 17. Using Aggregate or foreach
            Console.WriteLine("\n17. Manual iteration alternative (imperative):");
            var alt17 = new List<Employee>();
            foreach (var emp in employees)
            {
                if (emp.Experience > 8)
                    alt17.Add(emp);
            }
            PrintEmployees(alt17);

            // 18. Array conversion then filter
            Console.WriteLine("\n18. Array Filter (ToArray then ToList):");
            Employee[] empArray = employees.ToArray();
            var alt18 = empArray.Where(e => e.Experience > 8).ToList();
            PrintEmployees(alt18);

            // 19. Using LINQ Cast for type consistency
            Console.WriteLine("\n19. Cast() for type consistency:");
            var alt19 = employees
                .Cast<Employee>()
                .Where(e => e.Experience > 8)
                .ToList();
            PrintEmployees(alt19);

            // 20. Reverse then filter
            Console.WriteLine("\n20. Reverse() then Where():");
            var alt20 = employees
                .Reverse()
                .Where(e => e.Experience > 8)
                .ToList();
            PrintEmployees(alt20);
        }

        private static void PrintEmployees(IEnumerable<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine($"   {emp.Name} - {emp.Experience} years - {emp.Department}");
            }
        }
    }

    // Custom extension method
    public static class EmployeeExtensions
    {
        public static bool IsExperienced(this Employee employee, int yearsThreshold = 8)
        {
            return employee.Experience > yearsThreshold;
        }
    }
}

