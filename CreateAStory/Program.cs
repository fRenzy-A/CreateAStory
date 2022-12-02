using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace CreateAStory
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            Story();
            Console.ReadKey(true);
        }

        static void InteractiveStory()
        {
            Story();

            ConsoleKeyInfo ReadKey;
            ReadKey = Console.ReadKey(true);

            Console.WriteLine(story[0]);
       
            if (ReadKey.Key == ConsoleKey.A)
            {
                
            }
            


            
           
        }
        static void ChoiceMaker()
        {
            
        }

        static void Story()
        {
            string[] story = { "FirstPage;FlipToPage2;FlipToPage3", "SecondPage;FlipToPage4;FlipToPage6", "ThirdPage;FlipToPage5;FlipToPage6", "4thPage", "5thPage", "6thPage" };
            for (int i = 0; i < story.Length; i++)
            {
                string[] storysplitter = story[i].Split(';');

                IDictionary<string, int> PageFlip = new Dictionary<string, int>();
                PageFlip.Add(storysplitter[1], 3);
                PageFlip.Add(storysplitter[2], 4);
                PageFlip.Add(storysplitter[4], 9);
                PageFlip.Add(storysplitter[5], 10);
            }
        }
    }
}
