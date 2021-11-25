using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFay
{
    class Program
    {
        //Determins how much pages the story has
        static string[] story = new string[10];

        //Determins splits value
        static char[] splits = {';'};

        //Determins which array in story you are
        static int pageNumber = 0;

        //Determins the current page of story array
        static string[] page = new string[10];

        static void Main(string[] args)
        {
            Story();
            Console.ReadKey(true);
        }
        static void Story()
        {
            story[0] = "PlotOne;OptionOne.one OptionTwo.one;1;2"; //Plot1, Two story Options2, Choices 3/4
            story[1] = "PlotTwo;OptionOne.two OptionTwo.Two;3;4"; //Plot1, Two story Options2, Choices 3/4
            story[2] = "PlotThree;OptionOne.Three OptionTwo.Three;5;6"; //ect...
            story[3] = "Text4";
            story[4] = "Text5";
            story[5] = "Text6";

            string[] page = story[pageNumber].Split(splits);

            int parse = int.Parse(page[2]);

            foreach (string sub in page)
            {
                //Console.WriteLine($"{sub}");
                Console.WriteLine($"{parse}");
            }
        }
        static void GameLoop()
        {
            //Player Input

        }
    }
}