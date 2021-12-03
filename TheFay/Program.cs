using System;
using System.IO;
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
        static string[] story;

        //Saves current page to file
        static string saveGame;

        //splits (';') char from string
        static char[] splits = {';'};

        //Determins which array in story you are in (Will change on input)
        static int pageNumber = 0;
       
        static string nextPageA;
        static string nextPageB;

        //initilizes choice ints
        static int choiceA;
        static int choiceB;

        //Initalizes subArray
        static string[] sub = new string[3];
        static string[] paragraph = new string[10];

        //Initilizes gameLoop
        static bool gameLoop = true;

        //Disables Input
        static bool inputDis = false;

        //initilizes "story.txt" file
        static string storyFile = "Story.txt";

        //initilizes "SavedGame.txt" file
        static string saveFile = "SavedGame.txt";

        static string test = "bob";

       
        //==========================================================================================================

        //Plays Code
        static void Main(string[] args)
        {
            GameLoop();
        }

        //Displays story
        static void Story()
        {
            //==========================================Story Arrays=================================================
            // use (';') to split strings.
            // use (end) for end page.
            // use (title) to determine title page
            story = File.ReadAllLines(storyFile);
            //=======================================================================================================

            //splits storyArray into subArray (sub)
            Split();

            //Display Story
            Console.Clear();
            Console.WriteLine("Page " + pageNumber);
            Console.WriteLine("");
            Console.WriteLine(sub[0]);
            Console.WriteLine(sub[1]);

            //Checks if gameOver
            GameEnd();          
         
        }

        //Loops Game
        static void GameLoop()
        {
            while (gameLoop == true)
            {
                Story();
                PlayerInput();
            }
        }

        //Reads player input
        static void PlayerInput()
        {
            //Player Input
            ConsoleKeyInfo Input = Console.ReadKey(true);
            if (inputDis == false)
            {
                //turns string to int
                Parse();

                //Detects if A is pressed
                if (Input.Key == ConsoleKey.A)
                {           
                    //Page number changes to slected choice
                    pageNumber = choiceA;
                }

                //Detects if B is pressed
                if (Input.Key == ConsoleKey.B)
                {
                   
                    //Stops game if Title is active
                    if (sub.Contains("title"))
                    {
                        gameLoop = false;
                    }

                    //Page number changes to slected choice
                    pageNumber = choiceB;
                }

                //Detects if S is pressed
                if (Input.Key == ConsoleKey.S)
                {

                    File.WriteAllText(saveFile, test);
                }
            }                 
        }

        static void GameEnd()
        {
            //Checks if subArray has "end" in it
            // if it does. End the game
            if (sub.Contains("end"))
            {
                gameLoop = false;
                inputDis = true;
            }
        }

        static void Split()
        {
            //turns page into story substring then splits the char (';') from it
            sub = story[pageNumber].Split(splits);
            

        }

        static void Parse()
        {
            nextPageA = sub[2];
            nextPageB = sub[3];

            //Converts choice one into a int
            Int32.TryParse(nextPageA, out choiceA);

            //Converts choice two into an int
            Int32.TryParse(nextPageB, out choiceB);
        }
    }
}