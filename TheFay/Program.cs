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
            story[0] = "TextOne;SubOne;";
            story[1] = "Text2";
            story[2] = "Text3";
            story[3] = "Text4";
            story[4] = "Text5";
            story[5] = "Text6";

            string[] page = story[pageNumber].Split(splits);

            foreach (string sub in page)
            {
                Console.WriteLine($"{sub}");
            }
        }
        static void GameLoop()
        {
            //Player Input

        }
    }
}