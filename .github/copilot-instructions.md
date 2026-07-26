---
description: "Repository-specific instructions to guide Copilot and AI agents when editing the BlazingBlog Blazor app"
applyTo: "**/*"
---

# Purpose

These instructions give concise, actionable guidance for AI coding assistants working on this repository (Blazor / .NET 8). They capture project structure, conventions, and common workflows so Copilot can make safe, minimal, and consistent edits.

## Project overview (big picture)
- Single Blazor app project: BlazingBlog (BlazingBlog/BlazingBlog.csproj). Target framework: .NET 8.
- UI is Razor Components under BlazingBlog/Components. Server-side patterns and services are small and in-process (see BlogRepository.cs and IBlogRepository.cs).
- Data model: simple POCOs in BlazingBlog/Models (BlogPost.cs).

## Key files to read before changing behavior
- Program.cs — app host, DI registrations, and middleware ordering.
- BlogRepository.cs, IBlogRepository.cs — data access contract and in-memory/sample implementation used by pages.
- Components/Pages/* — component patterns (data-binding, EventCallbacks, lifecycle methods).
- Usings.cs — global usings used across the project; prefer existing conventions.

## Conventions and patterns
- Follow Blazor idioms: small components in .razor files, complex logic in .razor.cs code-behind or services.
- Use dependency injection for services (register in Program.cs). Keep repository interfaces in root (IBlogRepository.cs).
- Naming: PascalCase for components, public members, types; camelCase for private fields.
- Async all the way: prefer Task-returning methods for I/O and repository operations (use OnInitializedAsync in components).
- Keep edits minimal and targeted: prefer changing Program.cs registration or repository behavior instead of broad refactors.

## Build / run / debug
- Build locally: dotnet build BlazingBlog
- Run locally: dotnet run --project BlazingBlog
- Visual Studio: open BlogApp.sln and run BlazingBlog profile from launchSettings.json. Use the IDE debugger for Razor/Component breakpoints.

## Tests and validation
- This repository does not include automated tests. After changes, ensure project builds and run the app to validate component rendering and navigation.
- Use dotnet build and run; verify key pages: Home, BlogList, PostDetail.

## Safe change rules for AI
- When introducing new services, register them in Program.cs and add an interface in root-level folder.
- Do not modify global usings in Usings.cs without justification; prefer adding narrow using statements per-file if needed.
- Avoid large refactors across multiple components in a single PR. Make oneatomic behavior change per PR.

## Examples from this repo
- To change how posts are loaded, update BlogRepository.cs and adjust DI in Program.cs; components call IBlogRepository methods (see Components/Pages/BlogList.razor and PostDetail.razor).
- To add a new page, add a .razor under Components/Pages and register a Route in Components/Routes.razor if applicable.

## When unsure
- Prefer conservative edits and leave TODO comments referencing the file and reasoning (e.g., // TODO: simplify pagination — needs data service change).
- Ask a human for approval on changes that touch authentication, persistence, or project-level configuration.

---

