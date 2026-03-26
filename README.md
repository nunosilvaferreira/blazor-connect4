# Blazor Connect Four

Blazor Connect Four is a web implementation of the classic Connect Four game, built with ASP.NET Core Blazor and C#.  
Two players alternate turns, drop pieces into one of seven columns, and the first to connect four pieces in a row wins.

## Project Goals

This project was created to practice building an interactive web application with Blazor components, Razor syntax, and C# game logic.  
It focuses on clean separation between UI behavior and domain logic.

## Features

- Interactive 7x6 Connect Four board
- Turn-based gameplay for Player 1 and Player 2
- Animated piece drop effect based on landing row
- Win detection for horizontal, vertical, and diagonal connections
- Tie detection when the board is full
- Friendly error messages for invalid actions (full column, invalid column, game already finished)
- Game reset functionality
- Move history tracking with turn, player, column, and row details

## Tech Stack

- .NET (ASP.NET Core Blazor Web App)
- Blazor Interactive Server render mode
- C#
- Razor components
- CSS (including component-scoped styles)

## Architecture Overview

The project uses a small but clear structure:

- `GameState.cs` contains the game rules and board state management.
- `Components/Board.razor` renders the board UI and handles player actions.
- `Components/Board.razor.css` contains styling and drop animations.
- `Components/Pages/Home.razor` defines the default route and hosts the board.
- `Program.cs` configures services and registers `GameState` as a singleton.

### Core Game Logic

`GameState` manages:

- The 6x7 board as a two-dimensional array
- Current turn and active player calculation
- Piece placement rules
- Win state evaluation (`None`, `Player1_Wins`, `Player2_Wins`, `Tie`)

Win checking is implemented by scanning board positions and validating four-in-a-row in four directions:

- Horizontal
- Vertical
- Diagonal down-right
- Diagonal down-left

## How to Run Locally

1. Open a terminal in the project folder.
2. Restore dependencies and build:

```powershell
dotnet build
```

3. Run the application:

```powershell
dotnet run
```

4. Open the local URL shown in the terminal (usually `https://localhost:<port>`).

## How to Play

1. Click `Drop` above a column to place your piece.
2. Players alternate automatically after each valid move.
3. The game ends when one player connects four pieces in a row or when the board is full.
4. Click `Reset Game` to start a new match.

## Error Handling

The game validates key invalid states and surfaces clear messages:

- Selecting an invalid column
- Dropping into a full column
- Attempting to play after the game has ended

## Possible Improvements

- Add scoreboard persistence across matches
- Add player name input
- Highlight the winning four slots
- Add AI single-player mode
- Add unit tests for `GameState`

