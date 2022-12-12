using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreateAStory
{
    internal class Program
    {
        //static readonly string textfile = @"C:\Users\w0463280\Documents\InteractiveStory-Radiate";
        //Setup for other methods to use
        static bool GameStart = false;
        static readonly string[] textstory = System.IO.File.ReadAllLines(@"story.txt");
        static readonly string[] save = System.IO.File.ReadAllLines(@"savegame.txt");
        static int page = 0;
        static int option1 = 0;
        static int option2 = 0;
        static void Main(string[] args)
        {
            while (true)
            {
                MainMenu();
                while (GameStart == true)
                {
                    InteractiveStory();
                }
            }
            
        }

        static void MainMenu()
        {
            Console.Clear();
            Title();
            Console.WriteLine("\n\nPress A - New Game\n\nPress B - Load Game\n\nPress ESC - Exit Game");
            ConsoleKeyInfo KeyReader = Console.ReadKey(true);
            if (KeyReader.Key == ConsoleKey.A)
            {
                GameStart = true;
            }
            else if (KeyReader.Key == ConsoleKey.B)
            {
                if (new FileInfo("savegame.txt").Length == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("There are no saved games. Consider doing a new playthrough");
                    Thread.Sleep(2000);
                }
                else if (save[0] == textstory[0])
                {
                    page = int.Parse(save[1]);
                    GameStart = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("The save file does not line up with the current story. Please make sure the story.txt file has the same story used or make a new playthrough");
                    Thread.Sleep(2000);
                }
            }
            else if (KeyReader.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }            
        }
        static void InteractiveStory()
        {
            Console.Clear();
            StorySetUp();
            PlayerChoice(Console.ReadKey(true));
        }

        static void StorySetUp()
        {
            string line = textstory[page];
            string[] splitter = line.Split(';');
            ChoiceandPrinter(splitter);           
        }
        static void ChoiceandPrinter(string[] storypage)
        {
            //if it reads an element with delimiters
            if (storypage.Length > 1)
            {
                option1 = int.Parse(storypage[3]);
                option2 = int.Parse(storypage[4]);
                Console.WriteLine("Plot:\n\n" + storypage[0]);
                Console.WriteLine();
                Console.WriteLine("Make your choice: ");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Press A - " + storypage[1] + " (flip to page " + option1 + ")");
                Console.WriteLine("Press B - " + storypage[2] + " (flip to page " + option2 + ")");
                Console.WriteLine();
                Console.WriteLine("Press C - Save Game");
                Console.WriteLine("Press ESC - Return to Menu");
                Console.WriteLine();
            }
            else
            {
                //if it reads an element with no delimiters. 
                Console.WriteLine(storypage[0] + "\n");
                Console.WriteLine("THE END\n");
                Console.WriteLine("Press ESC to exit");
                PlayerExit(Console.ReadKey(true));
            }           
        }
        static void PlayerChoice(ConsoleKeyInfo ReadKey)
        {
            if (ReadKey.Key == ConsoleKey.A)
            {
                page = option1 - 1;
            }
            else if (ReadKey.Key == ConsoleKey.B)
            {
                page = option2 - 1;
            }
            else if (ReadKey.Key == ConsoleKey.C)
            {
                string[] savereader = { textstory[0], Convert.ToString(page) };
                File.WriteAllLines("savegame.txt", savereader);
                Console.WriteLine("Game Saved");
                Thread.Sleep(2000);
            }               
            if (ReadKey.Key == ConsoleKey.Escape)
            {
                page = 0;
                option1 = 0;
                option2 = 0;
                GameStart = false;
            }
        }
        static void PlayerExit(ConsoleKeyInfo ReadKeyExit)
        {        
            if (ReadKeyExit.Key == ConsoleKey.Escape)
            {
                page = 0;
                option1 = 0;
                option2 = 0;
                GameStart = false;
                return;
            }
        }
        static void Title()
        {
            string[,] Title = new string[,]
            {   {"    _/_/_/                    _/  _/              _/              "},
                {"   _/    _/    _/_/_/    _/_/_/        _/_/_/  _/_/_/_/    _/_/   " },
                {"  _/_/_/    _/    _/  _/    _/  _/  _/    _/    _/      _/_/_/_/   " },
                {" _/    _/  _/    _/  _/    _/  _/  _/    _/    _/      _/          " },
                {"_/    _/    _/_/_/    _/_/_/  _/    _/_/_/      _/_/    _/_/_/    " }
            };

            for (int t = 0; t < Title.GetLength(0); t++)
            {
                for (int y = 0; y < Title.GetLength(1); y++)
                {
                    Console.Write(Title[t, y]);
                }
                Console.WriteLine();
            }
        }


        // LEGACY CODE
        /*static void InteractiveStory()
        {
            Console.WriteLine("Press Enter to start the game");

            //The story contents
            string[] story = { "Page 1:\n\n   You take the path to the power plant. Trees with a bit of life surround the ruins. Nature is starting to take over. Your detector crackles a bit louder as you get closer. An entrance with 2 big doors is in front of you, another perculiar building on the side you noticed, but your body wants to walk away from the facility.\n What will you do?;\n Go away(page 3) - Press A;Go inside the two doors(page 7)- Press D;1;1",
                "Page 2:\n\n Are you sure?;\n Go away(page 3) - Press A;Go inside the two doors(page 7)- Press D;2;6",
                "Page 3:\n\n You decide to go away from the power plant, but you find another path you never saw. Curiosity fills your mind.\n What will you choose?;\n Walk towards the path (page 5) - Press A;Keep walk away (page 6)- Press D;3;3",
                "Page 4:\n\n Are you sure?;\n Walk towards the path (page 5) - Press A;Keep walk away (page 6) - Press D;4;5",
                "Page 5:\n\n You take the path laid in front of you. You keep going further, not realizing you are now lost in the middle of the woods;\n Lost Ending.;Press ESC to exit;12;12",
                "Page 6:\n\n Still, you decided to walk away. Though you may not have done what you are tasked to do, Im sure your peers would understand;\n Strayer Ending.;Press ESC to exit;12;12",
                "Page 7:\n\n The doors creak loudly as you step inside the building. Everything looks demolished. Equipment destroyed, walls scratched. Nothing looks even somewhat recognizable. You walked around inside the facility more, noticing a stairway leading to a basement. As you approach the stairwell, that other building in the back of your mind creeps up. your curiosity wants to lead you to that building.\n What will you do?;\n Keep going(page 9) - Press A; Go back to that building(page 10) - Press D;7;7",
                "Page 8:\n\n Are you sure?;\n Keep going(page 9) - Press A; Go back to that building(page 10) - Press D;8;9",
                "Page 9:\n\n You go down the basement. You go deeper and deeper until you rach the lowest point. your radiator detector shoots through the roof. You explore the dark room until you notice a moving blob, viscous like honey. You realize you are in danger. Its too late. The substance jumps towards you;\n Bad Ending; Press ESC to exit;12;12",
                "Page 10:\n\n You go back to the building you spotted a while back. As you enter the building, it looks to be a security room. It somehow looks untouched, still running with power, somehow the cameras miraclously working. You realize you are able to take the footage and watch what happened to the facility. You take the saved footage and immediately exit; Security Ending; Press ESC to exit;12;12"};
                      

            //key reader
            ConsoleKeyInfo ReadKey;
            ReadKey = Console.ReadKey(true);
            bool GameStart = false;


            if (ReadKey.Key == ConsoleKey.Enter)
            {
                GameStart = true;


                Console.Clear();
                //Starting message
                Console.WriteLine("Detector crackling, hazmat crunching. You alone arrive to an abandoned nuclear power plant " +
                    "to investigate an anomaly going on inside the facility.");
                Console.WriteLine();
                Console.WriteLine("Press A to continue");

                //The game itself
                while (GameStart == true)
                {

                    //Second key reader
                    ConsoleKeyInfo ReadKey1;
                    ReadKey1 = Console.ReadKey(true);

                    //This is to take individual elements in the story and split the contents in a selected element accordingly
                    string splitter = story[pg];
                    string[] page = splitter.Split(';');

                    //Both an input reader and a line printer

                    Console.Clear();
                    if (ReadKey1.Key == ConsoleKey.A)
                    {
                        if (page.Length > 2)
                        {
                            pg = Int32.Parse(page[3]);
                            for (int i = 0; i < 3; i++)
                            {
                                Console.WriteLine(page[i]);
                            }
                        }
                        if (page.Length == 1)
                        {
                            Console.WriteLine(page[0]);
                        }

                    }

                    if (ReadKey1.Key == ConsoleKey.D)
                    {
                        if (page.Length > 2)
                        {
                            pg = Int32.Parse(page[4]);
                            for (int i = 0; i < 3; i++)
                            {
                                Console.WriteLine(page[i]);
                            }
                        }
                        if (pg == 1)
                        {
                            Console.WriteLine(page[0]);
                        }

                    }

                }
            }               
        }*/
    }
}
