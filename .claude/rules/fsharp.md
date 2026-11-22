---
paths:
  - "**/*.fs"
  - "**/*.fsx"
  - "**/*.fsproj"
---
# F# rules

## Style

- Use the latest F# language version and its newer features:
  - `_.Property` shorthand in lambdas instead of `fun x -> x.Property`
  - `task { }` for asynchronous code, not `async { }`, unless Fable requires `async`
  - nullable reference types (`<Nullable>enable</Nullable>`) where supported
  - `ValueOption` for hot paths, plain `option` everywhere else
  - collection expressions and `[ for ... ]` instead of manual loops
- Model the domain with discriminated unions and records. Make illegal states unrepresentable.
- Use pattern matching with complete cases. Avoid wildcard matches on domain unions, so the compiler reports missing cases.
- Return `Result` or `option` for expected failures. Use exceptions only for truly exceptional situations.
- Avoid `mutable` and loops. Use `List`, `Seq`, `Map` and pipelines.
- Use the pipe operator for data flow, and keep pipelines short enough to read.
- Give public functions explicit type annotations. Let inference handle locals.
- One module per file, named after its content. Keep file order in the `.fsproj` meaningful: types first, then logic, then entry point.

## Naming

- Types and modules: `PascalCase`. Functions and values: `camelCase`.
- Names say what something is or does. No abbreviations except well-known ones such as `id`, `mqtt`.

## Akka.NET

- Define messages as discriminated unions or records. Messages are immutable.
- One actor has one responsibility. Keep state inside the actor and change it only by handling messages.
- Never block inside an actor. Use `PipeTo` for asynchronous results.
- Supervise child actors explicitly and choose a restart strategy on purpose.
- Test actors with Akka.TestKit and with a controllable clock, not with real delays.

## SAFE Stack

- Shared types live in `src/Shared` and describe the API contract. Change the contract there first.
- Elmish follows `Model`, `Msg`, `init`, `update`, `view`. Keep `update` free of side effects except returned commands.
- Keep views small. Extract a function for each logical piece of the UI.

## Rule DSL

- Conditions and actions are discriminated unions in `Shared`.
- A rule is plain data. Evaluation happens in one place in the engine.
- Add a test for every new rule case.
