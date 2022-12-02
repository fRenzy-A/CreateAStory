using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
            string[] story = { "FirstPage;FlipToPage2;FlipToPage3;1;2", "SecondPage;FlipToPage4;FlipToPage6;3;4", "ThirdPage;FlipToPage5;FlipToPage6;4;5", "4thPage", "5thPage", "6thPage" };


            bool GameStart = false;

            
            
            ConsoleKeyInfo ReadKey;
            ReadKey = Console.ReadKey(true);

            Console.WriteLine("Press Enter to start");
            if (ReadKey.Key == ConsoleKey.Enter)
            {        
                GameStart = true;
            }
            int pg = 0;
            while (GameStart == true)
            {

                ConsoleKeyInfo ReadKey1;
                ReadKey1 = Console.ReadKey(true);

                Console.Clear();

                string splitter = story[pg];
                string[] page = splitter.Split(';');

                if (ReadKey1.Key == ConsoleKey.A)
                {
                    if (page.Length > 2)
                    {
                        pg = Int32.Parse(page[3]);
                    }
 
                }
                else if (ReadKey1.Key == ConsoleKey.D)
                {
                    if (page.Length > 2)
                    {
                        pg = Int32.Parse(page[4]);
                    }

                }
                for (int i = 0; i < page.Length; i++)
                {
                    Console.WriteLine(page[i]);
                }
                //Console.ReadKey(true);
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
