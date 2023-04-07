using System;

namespace LampPuzzle
{
    /// <summary>
    /// This class holds every global variable used in the program
    /// </summary>
    static class GV
    {
        public static Lamp lamp1;
        public static Lamp lamp2;
        public static Lamp lamp3;

        public static bool puzzleDone = false;

        public static int turns = 0;
        public static int onePressed = 0;
        public static int twoPressed = 0;
        public static int threePressed = 0;
    }

    class Program
    {
        /// <summary>
        /// This method is used to switch the lamps states depending on the
        /// button the user selected. Button 1 switches lamp 1,
        /// button 2 switches the states between lamp 1 and 2,
        /// and button 3 switches the states between lamp 2 and 3.
        /// </summary>
        /// <param name="button">Number of the button selected</param>
        static void SwitchLamp(int button)
        {

            // If user chose button 1, turns on or off lamp 1, depending on
            // its current state
            if (button == 1)
            {
                GV.lamp1 = SwitchStates(GV.lamp1);
                GV.turns++;
                GV.onePressed++;
            }

            // If user chose button 2, switches the states of lamp 1 and 2
            // between them
            if (button == 2)
            {
                if (((GV.lamp1 & Lamp.On) == Lamp.On) !=
                ((GV.lamp2 & Lamp.On) == Lamp.On))
                {
                    GV.lamp1 = SwitchStates(GV.lamp1);
                    GV.lamp2 = SwitchStates(GV.lamp2);
                }

                GV.turns++;
                GV.twoPressed++;
            }

            // If user chose button 3, switches the states of lamp 2 and 3
            // between them
            if (button == 3)
            {
                if (((GV.lamp2 & Lamp.On) == Lamp.On) !=
                ((GV.lamp3 & Lamp.On) == Lamp.On))
                {
                    GV.lamp2 = SwitchStates(GV.lamp2);
                    GV.lamp3 = SwitchStates(GV.lamp3);
                }
                
                GV.turns++;
                GV.threePressed++;
            }

            // If every lamp is on, the puzzle is complete
            if (((GV.lamp1 & Lamp.On) == Lamp.On) && 
            ((GV.lamp2 & Lamp.On) == Lamp.On) &&
            ((GV.lamp3 & Lamp.On) == Lamp.On))
            {
                GV.puzzleDone = true;
            }
        }

        /// <summary>
        /// This method changes the state of the lamp
        /// </summary>
        /// <param name="lampToSwitch"></param>
        /// <returns>The state of the lamp after the switch</returns>
        static Lamp SwitchStates(Lamp lampToSwitch)
        {
            return lampToSwitch ^= Lamp.On;
        }

        /// <summary>
        /// This method is used to check if the user completed the puzzle,
        /// displaying a congratulatory message if the user completed the
        /// puzzle, or loss message if the player couldn't solve the puzzle
        /// within the turn limit
        /// </summary>
        /// <param name="WinCon">Used to check if the user completed
        /// the puzzle or not</param>
        static void GameOver(bool WinCon)
        {
            // Displays the "Congratulations!" message if the player 
            //turns on all lamps in 6 turns
            if (WinCon == true)
            {
                Console.Write("\u001b[37m");
                Console.WriteLine($"Turns needed: {GV.turns}");
                Console.Write("\u001b[32m");
                Console.WriteLine("Congratulations, you won!");
            }

            // Displays the "You Lose!" message if the player reaches 6 turns
            // without every lamp on
            if ((WinCon == false) && (GV.turns == 6))
            {
                Console.Write("\u001b[37m");
                Console.WriteLine("You couldn't finish the task in 6 turns...");
                Console.Write("\u001b[31m");
                Console.WriteLine("You lose!");
            }
        }

        /// <summary>
        /// While the lamps are not all on, the method repeats, asking the user
        /// to choose the button to press and calling the SwitchLamp method to
        /// alter their states accordingly. It calls the GameOver method
        /// to check if the puzzle has been completed or the turn limit has
        /// been reached
        /// </summary>
        /// <param name="args">Arguments passed by the user, not
        /// used in the method</param>
        static void Main(string[] args)
        {
            //Ascii codes to change color of the text
            Console.WriteLine("Welcome to" + "\u001b[33m" + " Lamp Puzzle!\n");

            Console.WriteLine("\u001b[37m" + "In this game you have to turn " +
            "on 3 lamps by pressing 3 buttons that will affect if they are " +
            "on or off. You use the buttons " + "\u001b[34m" + " 1" +
            "\u001b[37m" + "," + "\u001b[34m" + " 2" + "\u001b[37m" + "," +
            "\u001b[34m" + " 3" + "\u001b[37m" + " to change the " +
            "lamps status and after each selection an update will be "
            + "displayed on screen. Pressing 1 will change the first lamp, " +
            "pressing 2 will switch the first and second lamps, pressing 3 " +
            "will switch the second and third lamps. Be careful, " +
            "you only have " + "\u001b[31m" +
             "6 " + "\u001b[37m" + "turns to complete this task. Good Luck!\n");

            //Displays the initial state of all lamps to the player before 
            //asking for the first command according to the enumeration value
            Console.Write((GV.lamp1 & Lamp.On) == Lamp.On ?
            "\u001b[32m" : "\u001b[31m");
            Console.WriteLine($"Lamp 1: {GV.lamp1}");
            Console.Write((GV.lamp2 & Lamp.On) == Lamp.On ?
            "\u001b[32m" : "\u001b[31m");
            Console.WriteLine($"Lamp 2: {GV.lamp2}");
            Console.Write((GV.lamp3 & Lamp.On) == Lamp.On ?
            "\u001b[32m" : "\u001b[31m");
            Console.WriteLine($"Lamp 3: {GV.lamp3}\n");

            // Repeats while the lamps are not all on
            while (GV.puzzleDone == false && GV.turns < 6)
            {
                int buttonPressed = 0;

                Console.WriteLine("\u001b[37m" +
                "Which button do you want to press?");
                // User chooses the button to press
                buttonPressed = int.Parse(Console.ReadLine());

                // Calls SwitchLamp method passing the button the user chose
                SwitchLamp(buttonPressed);
                // Displays the state of every lamp using the enumeration value
                Console.Write((GV.lamp1 & Lamp.On) == Lamp.On ?
                "\u001b[32m" : "\u001b[31m");
                Console.WriteLine($"Lamp 1: {GV.lamp1}");
                Console.Write((GV.lamp2 & Lamp.On) == Lamp.On ?
                "\u001b[32m" : "\u001b[31m");
                Console.WriteLine($"Lamp 2: {GV.lamp2}");
                Console.Write((GV.lamp3 & Lamp.On) == Lamp.On ?
                "\u001b[32m" : "\u001b[31m");
                Console.WriteLine($"Lamp 3: {GV.lamp3}\n");

                // Displays how many times each button was pressed
                Console.WriteLine("\u001b[37m" +
                "Button 1 pressed: " + "\u001b[34m" +
                $"{GV.onePressed}" + "\u001b[37m" + " times");
                Console.WriteLine("\u001b[37m" +
                "Button 2 pressed: " + "\u001b[34m" +
                $"{GV.twoPressed}" + "\u001b[37m" + " times");
                Console.WriteLine("\u001b[37m" +
                "Button 3 pressed: " + "\u001b[34m" + 
                $"{GV.threePressed}" + "\u001b[37m" + " times\n");

                // Calls method to check if the game as ended
                GameOver(GV.puzzleDone);
            }
        }
    }
}
