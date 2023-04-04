using System;

namespace LampPuzzle
{
    /// <summary>
    /// This class holds every global variable used in the program
    /// </summary>
    static class GV
    {
        public static bool lamp1 = false;
        public static bool lamp2 = false;
        public static bool lamp3 = false;

        public static bool puzzleDone = false;

        public static int turns = 0;

    }

    class Program
    {
        /// <summary>
        /// This method is used to switch the lamps states depending on the
        /// button the user selected. Button 1 switches lamp 1, button 2
        /// switches lamp 1 and 2, and button 3 switches lamp 2 and 3.
        /// </summary>
        /// <param name="button">Number of the button selected</param>
        static void SwitchLamp(int button)
        {

            if (button == 1)
            {
                GV.lamp1 = !GV.lamp1;
                GV.turns++;
            }

            if (button == 2)
            {
                GV.lamp1 = !GV.lamp1;
                GV.lamp2 = !GV.lamp2;
                GV.turns++;
            }

            if (button == 3)
            {
                GV.lamp2 = !GV.lamp2;
                GV.lamp3 = !GV.lamp3;
                GV.turns++;
            }

            if ((GV.lamp1 == true) && (GV.lamp2 == true) && (GV.lamp3 == true))
            {
                GV.puzzleDone = true;
            }
        }


        /// <summary>
        /// While the lamps are not all on, the method repeats, asking the user
        /// to choose the button to press and calling the SwitchLamp method to
        /// alter their states accordingly. It then displays the states of
        /// every lamp. When all the lamps are on, the loop ends and
        /// congratulates the user
        /// </summary>
        /// <param name="args">Arguments passed by the user, not
        /// used in the method</param>
        static void Main(string[] args)
        {
            // Set color for "Lamp Puzzle"
            // Yellow
            Console.WriteLine("Welcome to" + "\u001b[33m" + " Lamp Puzzle!\n");

            Console.WriteLine("\u001b[37m" + "In this game you have to turn " +
            "on 3 lamps by pressing 3 buttons that will affect if they are " +
            "on or off. You use the buttons " + "\u001b[34m" + " 1" +
            "\u001b[37m" + "," + "\u001b[34m" + " 2" + "\u001b[37m" + "," +
            "\u001b[34m" + " 3" + "\u001b[37m" + " to change the " +
            "lamps status and after each selection an update will be "
            + "displayed on screen. Pressing 1 will change the first lamp, " +
            "pressing 2 will change the first and second lamps, pressing 3 " +
            "will changes the second and third lamps. Be careful, " +
            "you only have " + "\u001b[31m" +
             "6 " + "\u001b[37m" + "turns to complete this task. Good Luck!\n");


            // Repeats while the lamps are not all on
            while (GV.puzzleDone == false && GV.turns < 6)
            {
                int buttonPressed = 0;

                Console.WriteLine("\u001b[37m" + "Which button do you want to press?");
                // User chooses the button to press
                buttonPressed = int.Parse(Console.ReadLine());

                // Calls SwitchLamp method passing the button the user chose
                SwitchLamp(buttonPressed);
                // Displays the state of every lamp
                Console.Write(GV.lamp1 ? "\u001b[32m" : "\u001b[31m");
                Console.WriteLine($"Lamp 1: {GV.lamp1}");
                Console.Write(GV.lamp2 ? "\u001b[32m" : "\u001b[31m");
                Console.WriteLine($"Lamp 2: {GV.lamp2}");
                Console.Write(GV.lamp3 ? "\u001b[32m" : "\u001b[31m");
                Console.WriteLine($"Lamp 3: {GV.lamp3}\n");

            }
            // Displays the "You Loose!" message if the player reaches 6 turns
            if (GV.turns == 6)
            {
                Console.Write("\u001b[31m");
                Console.WriteLine("You loose!");
            }
            // Displays the "Congratulations!" message if the player 
            //turns on all lamps in under 6 turns
            else
            {

                Console.Write("\u001b[37m");
                Console.WriteLine($"Turns needed: {GV.turns}");
                Console.Write("\u001b[32m");
                Console.WriteLine("Congratulations, you won!");
            }

        }
    }
}
