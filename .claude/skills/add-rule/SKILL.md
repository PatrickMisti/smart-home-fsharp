---
name: add-rule
description: Add a new automation rule to the rule engine, including the DSL case, evaluation, a test and the dashboard entry. Use when the user asks for a new rule or a new condition or action type.
---

# Add an automation rule

Follow these steps in order. Keep each change small and readable.

1. Describe the rule in one English sentence, for example "When the window is open for five minutes while heating is on, lower the heating and notify".
2. Check `src/Shared` for existing condition and action cases. Reuse them. Add a new discriminated union case only if no existing case fits.
3. Define the rule as plain data in the rule definitions of `src/Api`. A rule contains an id, a name, its conditions and its actions.
4. If a new condition or action case was added, handle it in the single evaluation function of the engine. Do not use a wildcard match, so the compiler lists every unhandled case.
5. Add a test in `tests/Api.Tests` that describes the behavior in its name. Use a controllable clock and a test kit, never real delays.
6. Make sure the rule appears in the rule list of the dashboard. If the shared types changed, update the API contract in `src/Shared` first, then the server, then the UI.
7. Run `dotnet build` and `dotnet test`. Fix every warning and failure before finishing.
8. Report what was added in two or three sentences.

Rules for this skill:
- All code, names and comments are in English.
- Do not add configuration or abstractions that the new rule does not need.
