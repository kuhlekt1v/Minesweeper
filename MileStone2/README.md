# Milestone 2: Interactive Playable Version

## Overview

In this milestone, students will create an interactive playable version of the Minesweeper game.

![Minesweeper Milestone 2 sample](Milestone2.jpg)

## Execution

Execute this assignment according to the following guidelines:

### 1. PrintBoardDuringGame:

Create a new helper function `PrintBoardDuringGame` inside the Program class that will display the contents of each that have been visted. This will be similar to the PrintBoard function developed in Milestone 1, but this time display either the number of live neighbors or an empty square if there are no live neighbors. If a cell has not been visting, print a question mark.

### 2. Game Loop:

Create a playable version of the game in a while loop within the main method of the program class. Use this pseudo code as a guide.

```
while (the game is not over yet) {
  1. Ask the user for a row and column number.
  2. If the grid contains a bomb at the chosen cell (row, column) then set the endgame condition true. Display failure message
  3. If all of the non-bomb cells have been revealed, then set the endgame condition to true. Display a success message.
  4. Print the grid.
}
```
