using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFay
{
    class Program
    {
        static bool isGameActive = true;

        static bool isGameOver = true;

        static bool chose = true;

        static string[] story = new string[10];

        static char[] splits = { '%' };

        static char[] AB = new char[2];

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

            //==========================Pages======================
            //--------------------------Title----------------------
            story[0] = ("The Temple of Mictlantecuhtli,");
            //-----------------------------------------------------
            //--------------------------choice 1-------------------
            story[1] = ("You take a deep breath of fresh forest air.%The trees sway back and forth from the wind, yet the sky sat obscured by the meny leaves above.%More jungle lays before you, sounds of insects and animals were heard within its darkness.%%You are an archaeologist.%%You have heard rumors about a so called temple deep in this jungle.%It is said to be home of the Aztec god of death... Mictlantecuhtli.%The first of meny choices lay before you.%%Will you;%%A - Adventure Onward, or B - Leave The Forest?");                       
            story[2] = ("You Push onwards through the vast jungle."); // A
            story[3] = ("You descide to turn back and leave this adventure to someone more brave."); // B
            //-----------------------------------------------------
            //--------------------------choice 2-------------------
            story[4] = ("Page4");
            story[5] = ("Page5"); // A
            story[6] = ("Page6"); // B
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
            while (isGameActive)
            {
                // intitlizes input int
                int choice = 0;

                //=================================================Title=============================================================
                Page(choice); // Title

                chose = true;
                do
                {
                    ConsoleKeyInfo Input = Console.ReadKey(true);

                    if (Input.Key == ConsoleKey.A)
                    {
                        // Changes page
                        choice = choice + 1;
                        chose = false;
                        isGameOver = false;
                    }

                    else if (Input.Key == ConsoleKey.B)
                    {
                        // Changes page
                        isGameActive = false;
                        break;
                    }
                }
                while (chose == true);
                //===================================================================================================================


                // ===================================== Game plays well loop is active =============================================
                while (isGameOver == false)
                {
                    // Shows story
                    Page(choice);

                    // -----------------------------------------Reads user input-----------------------------------------------------
                    chose = true;
                    do
                    {
                        ConsoleKeyInfo Input = Console.ReadKey(true);

                        if (Input.Key == ConsoleKey.A)
                        {
                            // Changes page
                            choice = choice + 1;
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
    }
}
