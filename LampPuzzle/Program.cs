using System;

namespace LampPuzzle
{
    static class GV
    {
        public static bool lamp1 = false;
        public static bool lamp2 = false;
        public static bool lamp3 = false;

        public static bool puzzleDone = false;
    }
    
    class Program
    {   
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
        
        static void Main(string[] args)
        {
            while (GV.puzzleDone == false)
            {
                int buttonPressed = 0;
            
                Console.WriteLine("Which button do you want to press?");
                buttonPressed = int.Parse(Console.ReadLine());

                SwitchLamp(buttonPressed);
            }
        }
    }
}
