# Modern C# Concepts

## Q: What is a Record in C#?

### Short Interview Answer

A record is a reference type introduced in C# 9 that provides built-in support for immutable data models and value-based equality.

Records automatically generate methods like `Equals()`, `GetHashCode()`, `ToString()`, and support `with` expressions and deconstruction.

### Detailed Explanation

Unlike classes, records compare object contents instead of object references.

Records are ideal for DTOs, API requests/responses, configuration objects, and immutable data structures.

### Example

```csharp
public record Employee(string Name, int Experience);

var e1 = new Employee("Monika", 12);
var e2 = new Employee("Monika", 12);

Console.WriteLine(e1 == e2); // True
```

### Follow-up Questions

- Difference between record and class?
- What is value equality?
- What is a positional record?

## Q: What is a `with` expression?

### Short Interview Answer

A `with` expression creates a copy of an existing record with selected properties modified.

### Detailed Explanation

It enables immutable updates without modifying the original object.

### Example

```csharp
var employee = new Employee("Monika", 12);

var updatedEmployee = employee with
{
    Experience = 13
};

Console.WriteLine(employee.Experience);       // 12
Console.WriteLine(updatedEmployee.Experience); // 13
```

### Follow-up Questions
- Why is `with` mainly associated with records?
- Can classes use `with` expressions?

## Q: What are `init` properties?

### Short Interview Answer

`init` properties can only be assigned during object initialization and become read-only afterwards.

### Example

```csharp
public class Employee
{
    public string Name { get; init; }
}

var employee = new Employee
{
    Name = "Monika"
};

// employee.Name = "Updated"; // Compilation error
```

### Follow-up Questions

- Difference between `set` and `init`?
- Why are init properties useful?

## Q: What are `required` properties?

### Short Interview Answer

The `required` keyword forces callers to initialize the property during object creation.

### Example

```csharp
public class Employee
{
    public required string Name { get; init; }
}

var employee = new Employee
{
    Name = "Monika"
};
```

### Follow-up Questions

- Difference between `required` and constructor injection?
- Can `required` be used with records?

## Q: What are Nullable Reference Types?

### Short Interview Answer

Nullable Reference Types help developers avoid `NullReferenceException` by enabling compile-time nullability checks.

### Example

```csharp
string name = "Monika";

string? middleName = null;
```

### Follow-up Questions

- Difference between `string` and `string?`
- Why were Nullable Reference Types introduced?

## Q: What is Pattern Matching in C#?

### Short Interview Answer

Pattern Matching allows checking object types and values in a concise and readable manner.

### Example

```csharp
if (employee is Employee e && e.Experience > 10)
{
    Console.WriteLine("Senior Employee");
}
```

### Follow-up Questions

- Property patterns
- Type patterns
- Relational patterns

## Q: What are Switch Expressions?

### Short Interview Answer

Switch Expressions provide a concise alternative to traditional switch statements and return values directly.

### Example

```csharp
var level = experience switch
{
    < 3 => "Junior",
    < 8 => "Mid",
    _ => "Senior"
};
```

### Follow-up Questions

- Difference between switch statement and switch expression?
- Benefits of switch expressions?

## Q: What is a Primary Constructor in C# 12?

### Short Interview Answer

A Primary Constructor allows constructor parameters to be declared directly in the type declaration.

### Detailed Explanation

For records, the parameters become positional properties.

For classes, the parameters are only available within the type body and must be explicitly exposed if needed.

### Example

```csharp
public class Employee(string name, int experience)
{
    public string Name => name;
    public int Experience => experience;
}
```

### Follow-up Questions

- Difference between record primary constructors and class primary constructors?
- When should primary constructors be used?

## Q: What is the difference between Value Equality and Reference Equality?

### Short Interview Answer

Value Equality compares object contents.

Reference Equality compares memory references.

### Example

```csharp
public record EmployeeRecord(string Name, int Experience);

var r1 = new EmployeeRecord("Monika", 12);
var r2 = new EmployeeRecord("Monika", 12);

Console.WriteLine(r1 == r2); // True
```

```csharp
public class EmployeeClass(string name, int experience)
{
    public string Name => name;
    public int Experience => experience;
}

var c1 = new EmployeeClass("Monika", 12);
var c2 = new EmployeeClass("Monika", 12);

Console.WriteLine(c1 == c2); // False
```

### Follow-up Questions

- Difference between record and class equality?
- How does Equals() behave?

## Q: What is the difference between `==` and `SequenceEqual()`?

### Short Interview Answer

`==` compares object references for reference types.

`SequenceEqual()` compares collection contents element by element.

### Example

```csharp
var list1 = new List<int> {1,2,3};
var list2 = new List<int> {1,2,3};

Console.WriteLine(list1 == list2);               // False
Console.WriteLine(list1.SequenceEqual(list2));  // True
```

### Follow-up Questions

- Does order matter in SequenceEqual()?
- How does SequenceEqual() work internally?

## Q: Difference between `First()` and `FirstOrDefault()`?

### Short Interview Answer

`First()` throws an exception if no matching element exists.

`FirstOrDefault()` returns the default value instead of throwing an exception.

### Detailed Explanation

Use `First()` when business logic guarantees the existence of the record.

Use `FirstOrDefault()` when the record may not exist.

### Example

```csharp
var employee = employees.First(e => e.Id == 1);

var employee2 = employees.FirstOrDefault(e => e.Id == 100);
```

### Follow-up Questions

- Difference between `First()` and `Single()`
- Difference between `Single()` and `SingleOrDefault()`


## Q: Difference between `First()`, `FirstOrDefault()`, `Single()` and `SingleOrDefault()`?

### Short Interview Answer

- `First()` requires at least one match.
- `FirstOrDefault()` allows zero or more matches and returns `null` when none exist.
- `Single()` requires exactly one match.
- `SingleOrDefault()` allows zero or one match but throws an exception if multiple matches exist.

### Example

| Method | 0 Matches | 1 Match | Multiple Matches |
|---------|----------|---------|------------------|
| First() | Exception | Return item | Return first item |
| FirstOrDefault() | null | Return item | Return first item |
| Single() | Exception | Return item | Exception |
| SingleOrDefault() | null | Return item | Exception |

### Follow-up Questions

- When should you use `Single()` instead of `First()`?
- Which method is appropriate for unique database constraints?

## Q: Difference between `Count() > 0` and `Any()`?

### Short Interview Answer

`Any()` is preferred for existence checks because it stops as soon as the first matching element is found.

`Count()` evaluates all matching elements to calculate the total count.

### Example

```csharp
employees.Any(e => e.Department == "HR");
```

Preferred over:

```csharp
employees.Count(e => e.Department == "HR") > 0;
```

### Follow-up Questions

- Does `Any()` short-circuit?
- When should `Count()` be used instead?


## Q: Which is preferred and why?

```csharp
employees.Where(e => e.Department == "HR").Count();
```

or

```csharp
employees.Count(e => e.Department == "HR");
```

### Interview Answer

Prefer:

```csharp
employees.Count(e => e.Department == "HR");
```

because it is more concise, avoids unnecessary intermediate enumerables, and is considered idiomatic LINQ.


## Q: Why can `Distinct()` produce different results for classes and records?

### Short Interview Answer

`Distinct()` uses `Equals()` and `GetHashCode()` internally.

Records implement value equality automatically, while classes use reference equality by default.

### Example

```csharp
var employees = new List<Employee>
{
    new("Monika",12),
    new("Monika",12)
};

Console.WriteLine(employees.Distinct().Count());
```

### Result

- Record → `1`
- Class → `2`

### Follow-up Questions

- How does `Distinct()` work internally?
- How can custom classes support value equality?








