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
            }

            if (button == 2)
            {
                GV.lamp1 = !GV.lamp1;
                GV.lamp2 = !GV.lamp2;
            }

            if (button == 3)
            {
                GV.lamp2 = !GV.lamp2;
                GV.lamp3 = !GV.lamp3;
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
            // Repeats while the lamps are not all on
            while (GV.puzzleDone == false)
            {
                int buttonPressed = 0;
            
                Console.WriteLine("Which button do you want to press?");
                // User chooses the button to press
                buttonPressed = int.Parse(Console.ReadLine());

                // Calls SwitchLamp method passing the button the user chose
                SwitchLamp(buttonPressed);

                // Displays the state of every lamp
                Console.WriteLine($"Lamp 1: {GV.lamp1}");
                Console.WriteLine($"Lamp 2: {GV.lamp2}");
                Console.WriteLine($"Lamp 3: {GV.lamp3}");
            }

            Console.WriteLine("Congratulations!");
        }
    }
}
