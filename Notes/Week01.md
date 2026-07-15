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
