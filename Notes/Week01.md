# Week 1

## Covered Topics

- Records
- With Expressions
- Value Equality
- Reference Equality
- Init Properties
- Required Properties
- Nullable Reference Types
- Pattern Matching
- Switch Expressions

## Confidence

2/10

## Key Learnings

The concepts are rusty but familiar.


## LINQ Learnings

### Common LINQ Methods
- Where()
- Select()
- OrderBy()
- OrderByDescending()
- Max()
- Any()

### Key Concepts
- Deferred Execution
- Method Syntax vs Query Syntax
- IEnumerable vs List
- LINQ translates to loops internally

### AI Review Findings
- AI often generates multiple valid solutions.
- Some generated code may be unnecessary.


## LINQ Alternatives Learned

### Filtering

Standard approach:

employees.Where(e => e.Experience > 8)

Alternative query syntax:

from e in employees
where e.Experience > 8
select e

Alternative List<T> specific method:

employees.FindAll(e => e.Experience > 8)

Preferred approach in modern .NET:
Where()


- Developer review remains essential.
