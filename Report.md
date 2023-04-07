# Lamp Puzzle

## Authors

Miguel Feliciano - 22002782

- Added the instructions
- Added messages when player looses
- Added colors to text in instructions, when the lamps are on or off and when the player wins or looses
- Added the 6 turn limiter
- Added turn display
- Added comments
- Created SwitchLamp and SwitchStates flow charts
- Report

Nelson Milheiro - 21904365

- Added lamps switch states based on the button pressed
- Added check to see if lamps are on
- Logic, buttons and end game fixes
- Added Lamp enum and converted the code in Main to use it
- Added comments
- Added display of how many times each button was pressed
- Created Main and GameOver flow charts
- Report

Git repository used: https://github.com/Mikapuccino/LP1Project1

---

Solution: After displaying the instructions, the user is asked to choose a button to press while the puzzle is incomplete and 6 turns haven't passed. If the user selects a valid button, it calls the SwitchLamp method passing the chosen button, that changes the states of the lamps accordingly.

Each lamp is a Lamp object that only has the On flag, which determines if the lamp is on or not. The SwitchLamp method calls the SwitchStates method for the appropriate lamps and increments the turn counter. Then if the turn limit has been reached, or if the puzzle is complete, the program calls the GameOver method to check if the puzzle is done and display the proper message depending wether the puzzle was completed or not.

The program also uses the variables in the GV class, meant to be global variables used by every method in the Program class.

---
Main Method:

![Alt text](LampPuzzleMain.png)

SwitchLamp Method:

![Alt text](SwitchLamp.png)

SwitchStates Method:

![Alt text](SwitchStates.png)

GameOver Method:

![Alt text](LampPuzzleGameOver.png)