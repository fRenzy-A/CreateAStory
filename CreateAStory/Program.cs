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

            string story =  "First Page;Second Page;Third Page;Fourth Page;5;6;7;8;9;10" ;
            string[] splitter = story.Split(';');


            ConsoleKeyInfo KeyInfo;
            KeyInfo = Console.ReadKey(true);//KeyInfo.Key
            
            bool GameStart = false;
            if (KeyInfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                GameStart = true;
                Console.WriteLine(splitter[x]);
                while (GameStart == true)
                {
                    ConsoleKeyInfo KeyInfo1;
                    KeyInfo1 = Console.ReadKey(true);

                    if (KeyInfo1.Key == ConsoleKey.A)
                    {
                        x++;
                    }
                    else if (KeyInfo1.Key == ConsoleKey.S)
                    {
                        x = x + 2;
                    }
                    Console.WriteLine(splitter[x]);
                }
                Console.ReadKey(true);
            }
            
           
        }
    }
}
