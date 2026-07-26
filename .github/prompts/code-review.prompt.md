# Code Review Checklist

Use this prompt when reviewing any C#/.NET code. Evaluate the code against the following criteria and provide clear, actionable feedback.

## Architecture & Structure
- Ensure the code follows Clean Architecture principles.
- Confirm business logic is not placed in controllers or infrastructure.
- Check for unnecessary coupling or circular dependencies.
- Verify abstractions are meaningful and interfaces are used appropriately.

## C# & .NET Practices
- Ensure async/await is used for all I/O-bound operations.
- Flag blocking calls such as .Result, .Wait(), or Task.Run in ASP.NET contexts.
- Confirm dependency injection is used instead of static helpers.
- Check for proper use of `ILogger<T>` and structured logging.

## API & Endpoint Quality
- Validate that request DTOs are checked for correctness.
- Ensure endpoints return appropriate HTTP status codes.
- Confirm ProblemDetails is used for error responses.
- Check that cancellation tokens are included in async endpoints.

## EF Core & Data Access
- Ensure async EF Core methods are used.
- Check for unnecessary tracking; prefer AsNoTracking when appropriate.
- Validate that queries are efficient and avoid N+1 issues.
- Confirm migrations are used for schema changes.

## Error Handling
- Ensure exceptions are not swallowed silently.
- Check that errors are logged with context.
- Verify guard clauses are used for argument validation.

## Testing
- Confirm tests follow Arrange–Act–Assert structure.
- Ensure mocks or fakes are used instead of static dependencies.
- Check that tests cover edge cases and failure paths.

## Readability & Maintainability
- Ensure naming is clear and consistent.
- Check for excessive complexity; prefer simple, readable solutions.
- Verify comments explain intent, not obvious code.
- Confirm the code aligns with existing project conventions.

Provide a summary of strengths, weaknesses, and recommended improvements.
