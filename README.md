# Connect-4
Connect 4 Application

This is one of my senior high school projects which was creating a connect four application.
The objective of which was to create a working connect 4 game application, the theme was completely up to you granted it was appropriate.
I decided to do one based on M&M's since they were circular and was an easy theme considering they bore the same resemblence to regular connect 4. 
Although with the addition of a giant Eminem in the background just to make my teacher chuckle.

The Program Works as Follows:

 - First displaying the board and locking all the objects on the board. 
   The only way to proceed is to enter in the name of the first player.
   
 - After entering a name and clicking the button a second prompt will appear.
   This will take in the name of the second username.
   
 - One of the players will randomly be selected to go first.
   A random variable will be used to simulate a coin and based on the number that results either 1 or 2 the 
   corresponding player will go first.
   
 - Player 1 will be assigned the Blue M&M and Player 2 the Yellow M&M.
   The Player 1 and Player 2 will also change according to the username entered.
   
 - The M&M of the chosen player will then be able to be dropped.
   The very top row will display the M&M and the column in which it will be dropped in.

 - When the M&M is dropped the next player will be able to go changing the M&M's colour accordingly.

 - The game will continue until either of the players has four of their counters lined up horizontally, vertically or diagonally.

 - When a player wins a popup will appear with the name of the player and saying they win.

 - All objects will then lock and a new "Exit" button will appear which when presses will close the application.



The development process of this application taught me a number of things.
First off, this was the first time I made sure to lock all user interactions with objects on screen until user information was entered. This ensured that no unnecessary bugs were encountered and made the program feel more interactive as there was progress to the game every time a field was entered or a button was clicked. This was also the first time I had used a random variable in one of my projects. Rather than just having Player 1 go first, by making a random variable to simulate a coinflip allowed for games to be more dynamic and exciting instead of repeating the same scenario over and over. 

Initialization

The application uses a turn based system involving a turn boolean variable, this variable is true when it is Player 1's turn and false when it's Player 2's turn. The board itself uses a 2-D array to assign positions to each empty spot on the board. For example the top left would be [0,0] the one next to it being [1,0] and so on.

DropIt()

Each box on the board is already defined with a name which is then placed in a broken chracter array. Since the boxes all follow similar naming conventions such as pb00 the first two indexs in the character array can be ignored. Index 2 however corresponds to the x coordinate of the box and index 3 corresponds to the y coordinate. These two numbers are then used in determining where the M&M is to be dropped. Before it is dropped the dropspot is checked which takes the column number and runs it through function blanks which checks how many array spots are present with value 0. If there are no blanks availible then the column has been filled and no more can be dropped however if there is a free spot then the number of rows availible to be dropped in is equal to the current - 1 row. Then based on the turn boolean variable the corresponding image will slot itself into the availible spot. That spot will also recieve a value either 1 or 2 based on the play who puts a counter in that spot.

WinScenarios()

This function checks all possible scenarios to each player winning. Using nested for loops the function preforms vertical checks horizontal checks looping through the whole 2D array and adding each index's value as a string to a temporary string using the .ToString() function. using .Contains it checks if at any point the string contains "1111" or "2222" which in that case means either Player 1 or Player 2 won. finally it checks every diagonal combination which in this 7x6 board there are 12 possible combinations. In a string array called diagonal each combination is put together and using a foreach loop it loops through all the combinations and checks if it contains the previously mentioned "1111" or "2222". Then the corresponding player is considered the winner and is taken to the Win() function.

Win()

This is a simple if else statement that shows a message box for "Player 1 wins" or "Player 2 wins" based on which boolean variable player1win or player2win is set as true at the end of WinScenarios(). Simultaneously, the exit button will become enabled allowing for user interaction with it and also made visible.
