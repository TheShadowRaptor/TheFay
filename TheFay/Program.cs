using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFay
{
    class Program
    {
        // intitlizes input int
        static int choice = 0;

        //Main program loop
        static bool gameLoop = true;

        //checks if game is active
        static bool isStoryActive = false;

        static bool chose = true;

        static string[] story = new string[10];

        static char[] splits = {'%'};

        static char[] AB = new char[2];

        static string[] page = new string[10];

        static void Main(string[] args)
        {

            GameLoop();

        }

        static void Page(int letterPicked)
        {

            // each page should display 
            // 
            // plot
            // two story options
            // two destination page numbers
            // pages that end the story will be blank

            // 
            // % Splits string lines
            // ex:
            //
            // Before %
            // "I went to the store. I got milk."
            //
            // After %
            // "I went to the store."
            // "I got some milk."
            //
            //==========================Pages======================
            //--------------------------Title----------------------
            story[0] = ("The Temple of Mictlantecuhtli.%%Press any button to begin.%%Press esc to exit");
            //-----------------------------------------------------
            //--------------------------choice 1-------------------
            story[1] = ("You take a deep breath of fresh forest air.%The trees sway back and forth from the wind, yet the sky sat obscured by the meny leaves above.%More jungle lays before you, sounds of insects and animals were heard within its darkness.%%You are an archaeologist.%%You have heard rumors about a so called temple deep in this jungle.%It is said to be home of the Aztec god of death... Mictlantecuhtli.%The first of meny choices lay before you.%%Will you;%%A - Adventure Onward, or B - Leave The Forest?%%3%%4");                       
            story[2] = ("You Push onwards through the vast jungle."); // A
            story[3] = ("You descide to turn back and leave this adventure to someone more brave."); // B
            //-----------------------------------------------------
            //--------------------------choice 2-------------------
            story[4] = ("Page4;Select A;Select B;5;6");
            story[5] = ("Page5;Select A;Select B;7;8"); // A
            story[6] = ("Page6;Select A;Select B;9;10"); // B
            //-----------------------------------------------------
            //--------------------------choice 3-------------------
            story[7] = ("Page7");
            story[8] = ("Page8"); // A
            story[9] = ("Page9"); // B
            //------------------------------------------------------
            //======================================================
            Console.Clear();
            string[] page = story[letterPicked].Split(splits);

            foreach (string sub in page)
            {
                Console.WriteLine($"{sub}");
            }

            //------------------------------------------------------

        }

        static void GameLoop()
        {
            //In
            while (gameLoop)
            {
                // Displays title
                Title();

                // ===================================== Game plays well loop is active =============================================
                while (isStoryActive == true)
                {
                    // Shows story
                    Page(choice);

                    // -----------------------------------------Reads user input=====================================================
                    chose = true;
                    do
                    {
                        ConsoleKeyInfo Input = Console.ReadKey(true);

                        if (Input.Key == ConsoleKey.A)
                        {
                            // Changes page

                            choice = int.Parse(page[3]);
                            chose = false;
                        }

                        else if (Input.Key == ConsoleKey.B)
                        {
                            // Changes page
                            choice = choice + 2;
                            chose = false;
                        }
                    }
                    while (chose == true);

                    // Ends GameLoop
                    //isGameActive = false;
                }
                // ===================================================================================================================
            }

        }
        static void Test()
        {
           
        }

        static void Title()
        {
            //=================================================Title=============================================================
            Page(choice); // Title

            chose = true;
            do
            {
                ConsoleKeyInfo Input = Console.ReadKey(true);

                if (Input.Key == ConsoleKey.Escape)
                {
                    // Changes page
                    gameLoop = false;
                    break;
                }

                else 
                {
                    // Changes page
                    choice = choice + 1;
                    chose = false;
                    isStoryActive = true;                    
                }
            }
            while (chose == true);
            //===================================================================================================================
        }
    }
}