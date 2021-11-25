using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFay
{
    class Program
    {
        //====================================================ints==================================================
        //Determins how much pages the story has
        static string[] story = new string[10];

        //splits (';') char from string
        static char[] splits = {';'};

        //Determins which array in story you are in (Will change on input)
        static int pageNumber = 0;

        //Sub string of the story array 
        static string[] page = new string[3];

        //Initalizes parse
        static int parse1;
        static int parse2;

        static bool gameActive = true;

        static bool titleActive = true;
        //==========================================================================================================

        //Plays Code
        static void Main(string[] args)
        {
            GameLoop();
        }

        static void Story()
        {
            //==========================================Story Arrays=================================================
            story[0] = "Welcome to the title; Start(A) exit(B);1;0"; //Plot(1), Two story Options(2), Choices (3/4) (page[] Positions)
            story[1] = "PlotTwo;OptionOne.two OptionTwo.Two;2;5"; //Plot(1), Two story Options(2), Choices (3/4) (page[] Positions
            story[2] = "PlotThree;OptionOne.Three OptionTwo.Three;5;6"; //ect...
            story[3] = "Text4;op;2;3";
            story[4] = "Text5;op;4;2";
            story[5] = "You died; Game Over";
            //=======================================================================================================

            //turns page into story substring then splits the char (';') from it
            string[] sub = story[pageNumber].Split(splits);

            //Converts choice one into a int
            parse1 = int.Parse(sub[2]);
            
            //Converts choice two into an int
            parse2 = int.Parse(sub[3]);

            //Writes sub strings after split 

            //Display Story
            Console.Clear();
            Console.WriteLine(sub[0]);
            Console.WriteLine(sub[1]);
        }
        static void GameLoop()
        {
            while(gameActive == true)
            {
                Story();
                PlayerInput();
            }
        }

        static void PlayerInput()
        {
            //Player Input
            ConsoleKeyInfo Input = Console.ReadKey(true);
            if(Input.Key == ConsoleKey.A)
            {
                if(titleActive == true)
                {
                    titleActive = false;
                }

                pageNumber = parse1;
            }

            if (Input.Key == ConsoleKey.B)
            {
                if(titleActive == true)
                {
                    gameActive = false;
                }
                
                    pageNumber = parse2;
               
                

            }
        }
    }
}