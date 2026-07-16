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
