# JocDePacanele

Small Avalonia desktop sample that mimics a minimal slot/roulette game. Three emoji slots spin, and a win is triggered when all three match. Buttons allow spinning and resetting the board.

## Run the app
From the repository root:

```bash
dotnet restore
# Run with the classic desktop lifetime
dotnet run --project JocDePacanele.csproj
```

## Gameplay
- **SPIN**: randomizes the three emoji slots.
- **RESET**: restores the default symbols and clears the result.
- **Win condition**: all three slots show the same fruit (message turns green on win; red otherwise).

## Key files
- Program entry: Program.cs
- App wiring and window: App.axaml / App.axaml.cs
- UI layout: MainWindow.axaml
- UI logic: MainWindow.axaml.cs
