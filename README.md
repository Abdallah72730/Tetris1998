# Tetris 1998 — C# WPF Desktop Game

A fully functional Tetris clone built in C# using WPF (Windows Presentation Foundation) and XAML. Features a real-time game loop, all seven standard tetrominoes with proper rotation, collision detection, line-clearing, and score tracking.

Built to practice advanced C# and object-oriented design — specifically how to separate game logic, state management, and UI rendering into clean, independent classes.

---

## Features

- All 7 tetrominoes (I, O, T, S, Z, J, L) with correct rotation behaviour
- Real-time game loop with smooth piece falling
- Collision detection on walls, floor, and stacked pieces
- Line clearing with score tracking
- Ghost piece preview (shows where the current piece will land)
- Next piece preview panel
- Game over detection and restart
- Clean WPF/XAML UI

---

## Project Structure

```
Tetris1998/
├── GameGrid.cs         # The 2D game board — tracks occupied cells
├── GameManager.cs      # Core game loop — spawning, falling, clearing, scoring
├── Shape.cs            # Abstract base class for all tetromino shapes
├── Tetromino.cs        # Defines the 7 tetromino types and their tile layouts
├── TetrisBlock.cs      # Individual block/cell representation
├── RotationHelper.cs   # Handles rotation matrix logic for all piece orientations
├── MainWindow.xaml     # WPF UI layout — game grid, preview panels, score display
├── MainWindow.xaml.cs  # UI code-behind — connects game events to visual updates
├── App.xaml            # Application entry point
└── AssemblyInfo.cs
```

---

## Tech Stack

- **C#** — all game logic
- **WPF (Windows Presentation Foundation)** — desktop UI framework
- **XAML** — declarative UI layout
- **.NET** — runtime

---

## OOP Design

The architecture uses a clear class hierarchy where each class has a single responsibility:

| Class | Responsibility |
|---|---|
| `GameGrid` | Tracks which cells are occupied; handles row clearing |
| `GameManager` | Runs the game loop; manages piece spawning, movement, and game state |
| `Shape` | Abstract base — defines the interface all tetrominoes share |
| `Tetromino` | Extends Shape; defines the 7 piece types and their tile coordinates |
| `TetrisBlock` | Represents a single cell on the grid |
| `RotationHelper` | Computes rotated positions for any piece and orientation |
| `MainWindow` | UI layer — renders state, handles keyboard input |

This separation means the game logic in `GameManager` has no knowledge of WPF or the UI — it just updates state. The UI reads that state and renders it. If the UI framework changed, the game logic would be completely unaffected.

---

## How to Run

### Requirements
- Visual Studio 2022 or later
- .NET 8.0+
- Windows (WPF is Windows-only)

### Steps

1. Clone the repository:
```bash
git clone https://github.com/Abdallah72730/Tetris1998.git
```
2. Open `Tetris1998.slnx` in Visual Studio
3. Press **F5** to build and run

### Controls

| Key | Action |
|---|---|
| Arrow Left / Right | Move piece left or right |
| Arrow Down | Soft drop |
| Arrow Up or X | Rotate clockwise |
| Z | Rotate counter-clockwise |
| Space | Hard drop |

---

## What I Learned

- Building a real-time game loop in C# with async/await timing
- Designing an OOP class hierarchy where logic, data, and UI are fully separated
- Working with WPF and XAML for desktop UI (more complex than Windows Forms)
- Implementing rotation matrix logic for spatial transformations
- Debugging real-time state issues where timing and rendering interact

---

## Author

**Abdallah Najmudin Syed** — Computer Programming Student, Red Deer Polytechnic  
[github.com/Abdallah72730](https://github.com/Abdallah72730)
