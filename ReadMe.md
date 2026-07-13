# Conway's Game of Life

A performance-optimized implementation of John Conway's famous cellular automaton, built using **C#** and the **MonoGame** framework. 

This project simulates the emergence of complex patterns from a simple set of mathematical rules, rendering thousands of individual cells smoothly in real-time.

## 🚀 Features

*   **Real-Time Simulation:** Smooth grid updating and rendering loop.
*   **Interactive Grid:** Click or drag to draw and erase cells dynamically.
*   **Simulation Controls:** Pause, play, step forward single frames, and clear the grid.
*   **Variable Speed:** Speed up or slow down the generation ticks.
*   **Procedural Seeding:** Randomly populate the grid with a customizable density.

## 📐 The Rules of Life

The universe of the Game of Life is an infinite, two-dimensional orthogonal grid of square cells. At each step in time, the following transitions occur:

1.  **Underpopulation:** Any live cell with fewer than two live neighbours dies.
2.  **Survival:** Any live cell with two or three live neighbours lives on to the next generation.
3.  **Overpopulation:** Any live cell with more than three live neighbours dies.
4.  **Reproduction:** Any dead cell with exactly three live neighbours becomes a live cell.

## 🛠️ Prerequisites

Before building the project, ensure you have the following installed:

*   [.NET 8.0 SDK](https://microsoft.com) (or later)
*   [Visual Studio 2022](https://microsoft.com) (with the *Shared management wallet for .NET* workload)
*   [MonoGame mpack / extension](https://monogame.net)

## 💻 Getting Started

1.  **Clone the Repository:**
    ```bash
    git clone https://github.com
    cd ConwaysGameOfLife
    ```
2.  **Restore Dependencies:**
    ```bash
    dotnet restore
    ```
3.  **Run the Application:**
    ```bash
    dotnet run
    ```

## 🎮 Controls

*   **`Spacebar`**: Pause / Resume simulation.
*   **`Left Click`**: Draw alive cells.
*   **`Right Click`**: Erase cells.
*   **`C`**: Clear the entire grid.
*   **`R`**: Randomly seed the grid.
*   **`Up / Down Arrows`**: Adjust simulation speed (ticks per second).

## 📦 Project Structure

*   `/Content`: Houses the MonoGame Content Pipeline (`Content.mgcb`) for textures and fonts.
*   `Game1.cs`: The core MonoGame life cycle logic (Initialize, LoadContent, Update, Draw).
*   `Grid.cs`: Encapsulates the 2D array matrix logic and rule calculations.
