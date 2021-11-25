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

        //==========================================================================================================

        //Plays Code
        static void Main(string[] args)
        {
            GameLoop();
        }

        static void Story()
        {
            //==========================================Story Arrays=================================================
            story[0] = "PlotOne;OptionOne.one OptionTwo.one;1;2"; //Plot(1), Two story Options(2), Choices (3/4) (page[] Positions)
            story[1] = "PlotTwo;OptionOne.two OptionTwo.Two;3;4"; //Plot(1), Two story Options(2), Choices (3/4) (page[] Positions
            story[2] = "PlotThree;OptionOne.Three OptionTwo.Three;5;6"; //ect...
            story[3] = "Text4";
            story[4] = "Text5";
            story[5] = "Text6";
            //=======================================================================================================

            //turns page into story substring then splits the char (';') from it
            string[] page = story[pageNumber].Split(splits);

            //Converts choice one into a int
            parse1 = int.Parse(page[2]);
            
            //Converts choice two into an int
            parse2 = int.Parse(page[3]);

            //Writes sub strings after split 

            //Display Story
            Console.WriteLine(page[0]);
            Console.WriteLine(page[1]);
        }
        static void GameLoop()
        {
            while(gameActive == true)
            {
                Story();
                DisplayText();
                PlayerInput();
            }
        }
        static void DisplayText()
        {
            
        }

        static void PlayerInput()
        {
            //Player Input
            string input = Console.ReadLine();
            switch (input)
            {
                //Player types a
                case "a":
                    pageNumber = parse1;
                    break;

                //Play types b 
                case "b":
                    pageNumber = parse2;
                    break;
            }
        }
    }
}