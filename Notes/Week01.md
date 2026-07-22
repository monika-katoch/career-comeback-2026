# Week 1

## C# Topics Covered

### Records
- Positional records
- Value-based equality
- Generated members:
  - Equals()
  - GetHashCode()
  - ToString()
  - Deconstruct()
  - with expression support

### With Expression
- Creates a copy of a record with modified values.
- Original object remains unchanged.

Example:
var updated = employee with { Experience = 13 };

### Init Properties
- Values can only be assigned during object initialization.

### Required Properties
- Forces consumers to initialize properties during object creation.

### Nullable Reference Types
- Helps prevent NullReferenceException.
- Compiler warnings improve code quality.

### Pattern Matching
- Type pattern matching
- Property pattern matching

### Switch Expressions
- Cleaner replacement for traditional switch statements.

### Primary Constructors
- Constructor parameters declared directly in type declaration.
- Available for classes in C# 12.

Example:
public class Employee(string name)
{
    public string Name => name;
}

### Record vs Class

Record:
- Value equality
- Supports with expression
- Automatic ToString()
- Automatic Deconstruct()

Class:
- Reference equality
- No automatic with expression
- Manual implementation required

### Reference Equality vs Value Equality

Record:
new Employee("Monika",12) == new Employee("Monika",12)
=> True

Class:
new Employee("Monika",12) == new Employee("Monika",12)
=> False

List:
list1 == list2
=> compares references

list1.SequenceEqual(list2)
=> compares values


## LINQ Topics Covered

### Where()
Equivalent to SQL WHERE clause.

Example:
employees.Where(e => e.Experience >= 10)

### Select()
Equivalent to SQL SELECT clause.

Example:
employees.Select(e => e.Name)

### OrderBy()
Ascending sort.

### OrderByDescending()
Descending sort.

### Any()
Checks if at least one element satisfies the condition.

### Max()
Returns maximum value for selected property.

### SequenceEqual()
Compares collections element by element.
Order matters.

## AI Learning

### Copilot Learnings

- AI can generate multiple valid implementations.
- Not every generated implementation should be accepted.
- Developer review remains important.

### Examples observed

Good:
- Where()
- OrderByDescending()
- Query Syntax

Less useful:
- Select(x => x)
- Overcomplicated alternatives


## Questions To Revisit Later

- Deferred Execution
- IEnumerable vs List
- IQueryable
- LINQ execution behavior
- Developer review remain

## LINQ - First() and FirstOrDefault()

### First()

- Returns the first matching element.
- Throws `InvalidOperationException` if no matching element exists.

Example:

```csharp
var employee = employees.First(e => e.Department == "HR");
```

---

### FirstOrDefault()

- Returns the first matching element.
- Returns `default(T)` if no matching element exists.
- For reference types, `default(T)` is `null`.

Example:

```csharp
var employee = employees.FirstOrDefault(e => e.Department == "Legal");
```

---

### When to Use

Use `First()` when existence is guaranteed.

Use `FirstOrDefault()` when the item may not exist.

### Common Pitfall

`FirstOrDefault()` may return `null`.

Accessing properties directly without a null check can cause a `NullReferenceException`.

Example:

```csharp
var employee = employees.FirstOrDefault(e => e.Department == "Legal");

Console.WriteLine(employee.Name); // Throws NullReferenceException
```

Safe approach:

```csharp
Console.WriteLine(employee?.Name);
```


## LINQ - Single() and SingleOrDefault()

### Single()

- Returns the matching element if exactly one exists.
- Throws exception if no match exists.
- Throws exception if multiple matches exist.

### SingleOrDefault()

- Returns the matching element if exactly one exists.
- Returns `null` if no match exists.
- Throws exception if multiple matches exist.

### Comparison

| Method | 0 Matches | 1 Match | Multiple Matches |
|---------|----------|---------|------------------|
| First() | Exception | Return item | Return first item |
| FirstOrDefault() | null | Return item | Return first item |
| Single() | Exception | Return item | Exception |
| SingleOrDefault() | null | Return item | Exception |


## LINQ - Count()

### Count()

Returns the number of elements in a collection.

Example:

```csharp
employees.Count();
```

---

### Count with Predicate

Returns the number of elements matching the condition.

```csharp
employees.Count(e => e.Department == "Engineering");
```

Equivalent SQL:

```sql
SELECT COUNT(*)
FROM Employees
WHERE Department = 'Engineering'
```

---

### Important Notes

- `Count()` returns `0` when no matching records exist.
- `Count()` never throws an exception due to missing records.

---

### Count() vs Any()

Use `Any()` when checking existence.

Use `Count()` when the total number of matching records is required.

Example:

```csharp
employees.Any(e => e.Department == "HR");
```

Preferred over:

```csharp
employees.Count(e => e.Department == "HR") > 0;
```
## LINQ - Distinct()

### Purpose

Removes duplicate values from a sequence.

### Example

```csharp
var departments = employees
    .Select(e => e.Department)
    .Distinct();
```

### Important Notes

- Keeps the first occurrence.
- Preserves order.
- Uses `Equals()` and `GetHashCode()` internally.
- Behavior differs for classes and records because of equality semantics.

## LINQ - GroupBy()

### Purpose

Groups records by a key.

Example:

```csharp
employees.GroupBy(e => e.Department);
```

### Common Aggregations

```csharp
group.Count()
group.Sum()
group.Average()
group.Min()
group.Max()
```

### Common Use Cases

- Employees by Department
- Orders by Status
- Sales by Region
- Revenue by Month
- Tickets by Priority

# LINQ - ToDictionary()

## Purpose

Converts a sequence into a dictionary for fast lookups.

## Syntax

```csharp
var employeeDictionary = employees.ToDictionary(
    e => e.Name,
    e => e.Salary);
```

## Result

```text
Monika -> 150000
Rahul -> 70000
Amit -> 100000
Priya -> 60000
Neha -> 130000
```

## Important Notes

- Dictionary keys must be unique.
- Duplicate keys throw `ArgumentException`.
- Dictionary lookup is approximately `O(1)`.
- Uses hash tables internally.

## Example

```csharp
var employeeDictionary = employees.ToDictionary(e => e.Name);

Console.WriteLine(employeeDictionary["Monika"].Salary);
```

## Output

```text
150000
```

# LINQ Join

## Join()

Equivalent to SQL INNER JOIN.

Example:

```csharp
employees.Join(
    departments,
    e => e.DepartmentId,
    d => d.Id,
    (e, d) => new
    {
        Employee = e.Name,
        Department = d.Name
    });
```

## Left Join

LINQ does not provide a direct LeftJoin() method.

Use:

```text
GroupJoin() + DefaultIfEmpty()
```

## Mental Model

INNER JOIN:

```text
Only matching rows survive.
```

LEFT JOIN:

```text
All left-side rows survive.
Missing right-side values become null.
```

# LINQ - SelectMany()

## Purpose

Flattens nested collections into a single sequence.

### Select()

```csharp
employees.Select(e => e.Skills)
```

Result:

```csharp
IEnumerable<List<string>>
```

### SelectMany()

```csharp
employees.SelectMany(e => e.Skills)
```

Result:

```csharp
IEnumerable<string>
```

## Common Use Cases

- Employee skills
- Orders and order items
- Departments and employees
- Categories and products
- API response flattening

# LINQ - Partitioning Operators

## Take()

Returns first N elements.

```csharp
numbers.Take(3)
```

---

## Skip()

Skips first N elements.

```csharp
numbers.Skip(3)
```

---

## TakeWhile()

Returns elements until condition becomes false.

```csharp
numbers.TakeWhile(x => x < 50)
```

---

## SkipWhile()

Skips elements until condition becomes false.

```csharp
numbers.SkipWhile(x => x < 50)
```

---

## Real World Usage

Pagination:

```csharp
employees
    .Skip((page - 1) * pageSize)
    .Take(pageSize);
```

# LINQ - Aggregation Operators

## Sum()

Calculates the total.

```csharp
employees.Sum(e => e.Salary);
```

---

## Average()

Calculates the average value.

```csharp
employees.Average(e => e.Experience);
```

---

## Min()

Returns the smallest value.

```csharp
employees.Min(e => e.Salary);
```

---

## Max()

Returns the largest value.

```csharp
employees.Max(e => e.Salary);
```

---

## Aggregate()

General-purpose aggregation operator.

Examples:

```csharp
numbers.Aggregate((a,b)=>a+b);

numbers.Aggregate((a,b)=>a*b);

words.Aggregate((a,b)=>a+","+b);
```

---

## Real-world Usage

- Dashboard totals
- Salary reports
- KPI calculations
- Invoice totals
- Revenue calculations

## LINQ Quantifier Operators

### All()

`All()` checks whether **every element** in a collection satisfies a specified condition.

```csharp
var result = numbers.All(n => n > 0);
```

Returns:

- `true` if every element satisfies the condition.
- `false` if at least one element fails the condition.

Example:

```csharp
var numbers = new List<int>
{
    10, 20, 30, 40, 50
};

var result = numbers.All(n => n > 0);

Console.WriteLine(result);
```

Output:

```text
true
```

### Important Edge Case

For an empty collection:

```csharp
var numbers = new List<int>();

var result = numbers.All(n => n > 0);
```

The result is:

```text
true
```

No exception is thrown.

This is because there is no element that violates the condition.

### All() vs Any()

```csharp
numbers.All(n => n > 0);
```

Asks:

> Do all elements satisfy the condition?

```csharp
numbers.Any(n => n > 0);
```

Asks:

> Does at least one element satisfy the condition?

---

## Contains()

`Contains()` checks whether a collection contains a specific value.

Example:

```csharp
var numbers = new List<int>
{
    10, 20, 30, 40, 50
};

var result = numbers.Contains(30);
```

Output:

```text
true
```

If the value does not exist:

```csharp
var result = numbers.Contains(100);
```

Output:

```text
false
```

### Contains() with Projected Values

When working with objects, `Select()` can be used to project a property before calling `Contains()`.

Check whether an employee named Monika exists:

```csharp
var result = employees
    .Select(e => e.Name)
    .Contains("Monika");
```

Check whether Engineering exists as a department:

```csharp
var result = employees
    .Select(e => e.Department)
    .Contains("Engineering");
```

### Contains() vs Any()

`Contains()` checks for a **specific value**.

```csharp
employees
    .Select(e => e.Name)
    .Contains("Monika");
```

`Any()` checks whether **at least one element satisfies a condition**.

```csharp
employees.Any(e => e.Name == "Monika");
```

For example, to check whether any employee has a salary greater than 100000:

```csharp
employees.Any(e => e.Salary > 100000);
```

This is preferred over:

```csharp
employees
    .Select(e => e.Salary)
    .Contains(100000);
```

because `Contains(100000)` checks for a salary **exactly equal to 100000**, while the requirement is to find a salary **greater than 100000**.

### Contains() and Equality

`Contains()` relies on equality comparison.

For a normal class, reference equality is used by default unless equality is overridden.

For a record, value-based equality is used by default.

Example with a record:

```csharp
public record Employee(
    string Name,
    int Experience,
    string Department,
    int Salary);
```

Two records with the same property values are considered equal:

```csharp
new Employee("Monika", 12, "Engineering", 150000)
==
new Employee("Monika", 12, "Engineering", 150000)
```

Result:

```text
true
```

Therefore, `Contains()` can find a matching record based on its values.

### Key Concept

```text
Contains()
    ↓
Equality comparison
    ↓
Class → reference equality by default
Record → value equality by default
```

## LINQ Type Operators

### OfType<T>()

`OfType<T>()` is a LINQ type operator used to filter a collection and return only elements that are compatible with the specified type.

It is particularly useful when working with collections containing objects of different types.

Example:

```csharp
var items = new List<object>
{
    10,
    "Monika",
    20,
    "Rahul",
    30,
    true
};

var numbers = items.OfType<int>();

foreach (var number in numbers)
{
    Console.WriteLine(number);
}
```

### Cast<T>()

`Cast<T>()` attempts to cast every element in a collection to the specified type.

Example:

```csharp
var numbers = new List<object>
{
    10,
    20,
    30
};

var result = numbers.Cast<int>();

foreach (var number in result)
{
    Console.WriteLine(number);
}
```


### Zip()

- Combines two sequences element-by-element based on their position/index.
- Pairs the first element of the first sequence with the first element of the second sequence, and so on.
- When sequences have different lengths, `Zip()` stops when the shorter sequence ends.
- Remaining elements in the longer sequence are ignored.
- Does not add `null` for unmatched elements.
- Supports a result selector to directly control the output format.

Example:

var employeeNames = employees.Select(e => e.Name);
var departments = employees.Select(e => e.Department);

var result = employeeNames.Zip(
    departments,
    (name, department) => $"{name} - {department}"
);

foreach (var item in result)
{
    Console.WriteLine(item);
}

Output:

Monika - Engineering
Rahul - HR
Amit - Engineering
Priya - Finance
Neha - Engineering

Key Point:

`Zip()` combines two sequences element-by-element and stops when the shorter sequence ends.

Easy Way to Remember:

`Zip()` → Pair elements from two sequences based on their position.

### Range()

- Generates a sequence of consecutive integers.
- Syntax: `Enumerable.Range(start, count)`
- The first parameter specifies the starting number.
- The second parameter specifies how many values to generate.
- When `count` is `0`, it returns an empty sequence.
- A negative `count` throws an `ArgumentOutOfRangeException`.
- Can be combined with other LINQ operators such as `Where()`, `Select()`, and `Sum()`.

Example:

var numbers = Enumerable.Range(1, 5);

foreach (var number in numbers)
{
    Console.WriteLine(number);
}

Output:

1
2
3
4
5

Using `Range()` with `Where()`:

var evenNumbers = Enumerable.Range(1, 10)
                             .Where(n => n % 2 == 0);

Output:

2
4
6
8
10

Using `Range()` with `Sum()`:

var sum = Enumerable.Range(1, 10).Sum();

Result:

55

Special Cases:

Enumerable.Range(1, 0);

Returns an empty sequence.

Enumerable.Range(1, -1);

Throws `ArgumentOutOfRangeException`.

Key Point:

`Enumerable.Range(start, count)` starts from the specified starting number and generates the specified number of consecutive integers.

Easy Way to Remember:

`Range(start, count)` → Start number + Number of values to generate.


### Repeat()

- Generates a sequence where the same value is repeated a specified number of times.
- Syntax: `Enumerable.Repeat(value, count)`
- The first parameter specifies the value to repeat.
- The second parameter specifies how many times to repeat the value.
- When `count` is `0`, it returns an empty sequence.
- A negative `count` throws an `ArgumentOutOfRangeException`.

Example:

var result = Enumerable.Repeat("Hello", 5);

foreach (var item in result)
{
    Console.WriteLine(item);
}

Output:

Hello
Hello
Hello
Hello
Hello

Using `Repeat()` with `Count()`:

var count = Enumerable.Repeat("Pending", 3).Count();

Result:

3

Special Cases:

Enumerable.Repeat("Hello", 0);

Returns an empty sequence.

Enumerable.Repeat("Hello", -1);

Throws `ArgumentOutOfRangeException`.

### Range() vs Repeat()

`Range()` generates consecutive values.

Example:

Enumerable.Range(1, 5);

Output:

1
2
3
4
5

`Repeat()` generates the same value multiple times.

Example:

Enumerable.Repeat(1, 5);

Output:

1
1
1
1
1

### Key Point

`Repeat()` generates the same value repeatedly for the specified number of times.

### Easy Way to Remember

`Range()` → Different consecutive values

`Repeat()` → Same value repeated

### Empty()

- `Enumerable.Empty<T>()` returns an empty sequence of the specified type.
- It contains zero elements.
- It is useful when a method needs to return an empty sequence instead of `null`.
- `Count()` returns `0`.
- `Any()` returns `false`.
- `foreach` performs zero iterations.
- It can be safely enumerated without a `NullReferenceException`.
- `Enumerable.Empty<T>()` returns an empty sequence, while `new List<T>()` creates a mutable empty list.

Example:

var result = Enumerable.Empty<int>();

Console.WriteLine(result.Count());

Output:

0

Using `Any()`:

var result = Enumerable.Empty<string>();

Console.WriteLine(result.Any());

Output:

False

Using `foreach`:

var result = Enumerable.Empty<Employee>();

foreach (var employee in result)
{
    Console.WriteLine(employee);
}

Nothing is printed because the sequence contains zero elements.

### Returning Empty Sequence Instead of null

Example:

public IEnumerable<Employee> GetEmployees()
{
    if (employees == null)
    {
        return Enumerable.Empty<Employee>();
    }

    return employees;
}

This allows callers to safely enumerate the result without checking for `null`.

Example:

foreach (var employee in GetEmployees())
{
    Console.WriteLine(employee);
}

### Empty Sequence vs Empty List

`Enumerable.Empty<int>()`:

- Returns an empty sequence.
- Intended for representing an empty `IEnumerable<T>`.
- Cannot be directly modified using `Add()`.

`new List<int>()`:

- Creates an empty `List<int>`.
- Is mutable.
- Supports operations such as `Add()` and `Remove()`.

### Key Point

`Enumerable.Empty<T>()` returns a valid empty sequence instead of `null`, making it safer for callers to enumerate.

### Easy Way to Remember

`Empty<T>()` → Valid sequence with zero elements.


