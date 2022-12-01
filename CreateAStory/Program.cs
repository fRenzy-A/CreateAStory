using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAStory
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            InteractiveStory();
        }
        static int x = 0;
        static void InteractiveStory()
        {
            Console.WriteLine("Press Enter key to go");

<<<<<<< Updated upstream
            string story = "First Page;Second Page;Third Page;Fourth Page;5;6;7;8;9;10" ;
            string[] showStory = story.Split(';');
=======
            string story = "First Page;Second Page;Third Page" + ";" + "Fourth Page;Fifth Page;Sixth Page" + ";" + "Seventh Page;Eight Page;Ninth Page;Tenth Page";
            string[] splitter = story.Split(';','-');
>>>>>>> Stashed changes


            ConsoleKeyInfo KeyInfo;
            KeyInfo = Console.ReadKey(true);//KeyInfo.Key
            
            bool GameStart = false;
            if (KeyInfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                GameStart = true;
<<<<<<< Updated upstream
                Console.WriteLine(showStory[x]);
=======
                Console.WriteLine(splitter[0]);
>>>>>>> Stashed changes
                while (GameStart == true)
                {
                    ConsoleKeyInfo KeyInfo1;
                    KeyInfo1 = Console.ReadKey(true);

                    if (KeyInfo1.Key == ConsoleKey.A)
                    {
                        x++;
                    }
                    else if (KeyInfo1.Key == ConsoleKey.D)
                    {
                        x = x + 2;
                    }
                    Console.WriteLine(showStory[x]);
                }
                Console.ReadKey(true);
            }
            
           
        }
        static void ChoiceMaker()
        {

        }

        static void Story()
        {

        }
    }
}
