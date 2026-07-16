# AI Code Review Notes

## Records
Copilot explanations were accurate and useful.

## LINQ Alternatives
Copilot generated many valid alternatives.

Observations:
- Some alternatives are useful in production.
- Some alternatives add complexity without value.
- Human review remains necessary.


## LINQ Optimization

### Original

```csharp
employees.Where(e => e.Salary > 100000).Count();
```

### Suggested

```csharp
employees.Count(e => e.Salary > 100000);
```

### Reason

Prefer LINQ methods that accept predicates directly instead of chaining `Where()` first.

Benefits:

- Cleaner code
- Better readability
- Avoids unnecessary intermediate enumerables
- Considered idiomatic LINQ

# Dictionary Optimization

## Less Efficient

```csharp
var employee = employees.First(e => e.Name == "Monika");
```

Complexity:

```text
O(n)
```

---

## Optimized

```csharp
var employeeDictionary = employees.ToDictionary(e => e.Name);

var employee = employeeDictionary["Monika"];
```

Complexity:

```text
O(1)
```

## Reason

Dictionaries use hash tables internally and provide near constant-time lookups.


