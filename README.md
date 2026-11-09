# HelloWorld

A small console-based Snake game written in C# with .NET 10.

## Requirements

- .NET 10 SDK
- A console that supports cursor positioning and keyboard input
- Windows is recommended because the game uses `Console.Beep` when food is collected

## Run the game

From the repository root:

```powershell
dotnet run --project .\HelloWorld\HelloWorld.csproj
```

To build without running:

```powershell
dotnet build .\HelloWorld\HelloWorld.csproj
```

## Controls

Use the arrow keys to move the snake:

- Up Arrow
- Down Arrow
- Left Arrow
- Right Arrow

Collect `*` to grow the snake and increase the score. The game ends when the snake hits the border or itself.

## Project structure

- `HelloWorld/Program.cs` - application entry point and game loop
- `HelloWorld/GameField.cs` - game state, movement, collisions, and scoring
- `HelloWorld/Player.cs` - snake movement and input handling
- `HelloWorld/Renderer.cs` - console rendering
