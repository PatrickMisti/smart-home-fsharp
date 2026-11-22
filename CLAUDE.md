# Project instructions for Claude

Smart home rule engine built with F#, Akka.NET, MQTT (Zigbee2MQTT) and the SAFE Stack.

## Structure

- `src/Shared`: pure F# types shared by server and browser. No Akka, MQTT or server packages here, because this code is compiled by Fable.
- `src/Api`: web server, MQTT client, Akka.NET actors and the rule engine.
- `src/UI`: Fable and Elmish front end.
- `tests/`: unit and integration tests.

## Language

- Write everything in English: code, identifiers, comments, commit messages, issue titles, pull request text and documentation.
- Never write German anywhere in the repository.

## Code principles

- Write clean, readable code. Readability beats cleverness.
- Keep it simple. Choose the simplest solution that works and stop there.
- Use the newest language features available in the current F# and .NET versions when they make code shorter or clearer.
- Prefer small functions that do one thing and have descriptive names.
- Prefer immutable data and pure functions. Keep side effects at the edges (actors, MQTT, I/O).
- Do not add abstractions, layers or configuration that are not needed yet.
- Remove dead code instead of commenting it out.

## Comments

- Comments are in English.
- Explain why, not what. If a comment only repeats the code, delete it and improve the names instead.
- Use XML doc comments only on public API that is not obvious.

## Dependencies

- Package versions are managed centrally in `Directory.Packages.props`. Never put a version in a `.fsproj`.
- Add a package only when it clearly saves effort. Prefer the standard library.

## Tests

- Add or update tests for every behavior change.
- Test names describe the behavior, for example `Window open for five minutes lowers heating`.
- Tests are deterministic. Do not depend on real time, network or hardware; use fakes and test kits.

## Process

- Do not mention planning terms such as epics, milestones or phases in code, comments or documentation.
- Make small, focused changes. Do not refactor unrelated code.

## Commands

- Restore and build: `dotnet restore`, `dotnet build`
- Run the server: `dotnet run --project src/Api`
- Run the UI: `dotnet fable watch src/UI`
- Run tests: `dotnet test`
- Add a package: `dotnet add <project> package <name>` (the version goes to `Directory.Packages.props`)

## Further rules

- F# rules are in `.claude/rules/fsharp.md` and load automatically when F# files are involved.
- Use the `add-rule` skill when adding a new automation rule to the engine.
