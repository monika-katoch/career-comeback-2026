// LINQPractice: demonstrate query-expression syntax to find employees with >8 years
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
}
