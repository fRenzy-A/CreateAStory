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

        static void InteractiveStory()
        {
            //string[] story = new string[] { "First;Second.;1;2;" };
            Console.WriteLine("Press Enter key to go");

            string story =  "First Page;Second Page;Third Page;Fourth Page" ;
            string choice = "1;2";
            string[] splitter = story.Split(';');
            string[] choicesplit = choice.Split(';');

            ConsoleKeyInfo KeyInfo;
            KeyInfo = Console.ReadKey(true);//KeyInfo.Key
            int x = 0;
            bool Game = false;
            if (KeyInfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Game = true;
            }
            while (Game == true)
            {
                Console.WriteLine(splitter[x]);
                foreach (string p in choicesplit)
                {
                    Console.WriteLine($"{p}");
                }
                if (KeyInfo.Key == ConsoleKey.Z)
                {
                    x++;
                    //Console.WriteLine(splitter[1]);
                }
                if (KeyInfo.Key == ConsoleKey.X)
                {
                    x = x + 2;
                    //Console.WriteLine(splitter[2]);
                }
                
                Console.ReadKey(true);
            }
            
            /*foreach (var s in splitter)
            {
                Console.WriteLine($"{s}");
                foreach (var p in choicesplit)
                {
                    Console.WriteLine($"{p}");
                }
                
            }*/

            Console.ReadKey(true);
        }
    }
}
