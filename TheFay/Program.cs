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
        static string[] story = new string[11];

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

        //Initilizes gameLoop
        static bool gameLoop = true;

        //Disables Input
        static bool inputDis = false;

       
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
            story[0] = "Exploring The Fay \n;Start(A) exit(B);1;0;title"; //Plot(1), Two story Options(2), Choices (3/4) (page[] Positions)
            story[1] = "Cold forest air brush chills over your body. \nDirt hugs your face smearing its essence in your pours. \nYour eyes snap open, The veiw of the ground sat before you. \nYou stand off the ground brushing the dirt off your clothes.\n\nA bit droopy you struggle to keep up on your feet. \nThe thought of where you are and how you got here kept moving through your mind. \nTwo paths laid before you. \n\nThe LEFT path leads into a dark forest. \n\nThe Right path leads into a bright Meadow, a sweet smell pulls you a bit towrds that direction.;\n(A) LEFT, (B) RIGHT;2;3"; //Plot(1), Two story Options(2), Choices (3/4) (page[] Positions
            story[2] = "You enter the dark forest. \n\nRight on entering you were ment with a ominous chill, even more cold then the area you just came from. \nFreezing, you held yourself tight as you walked. \n\nYou think you hear something following you. \n\n... The sound of a branch snapping behind you confirms your suspicion. \n;(A) Run, (B) Hide;4;5"; //ect...
            story[3] = "You decide that the sweet smell was to intoxicating to resist. \n\nYou can't remember if that was the real reason you picked Right. \nActually... You can't really remember anything. \n\nYou didn't even notce that you walked right into the jaws of a giant man eating plant. \n\nIts jaws closed instently crushed your bones and skull. \n\nBadEnd 1 - Plant Fertilizer... \n;Game Over;end;";
            story[4] = "You decide to run. \n\nIf there was something behind you, you didn't want to wait around an find out what it was. \nSure enough as soon as you started to run, Big footsteps followed suit. \n\nWhat ever this thing was, it is not pursuing you from behind. \nIt was faster then you, you could tell from the footsteps gaining on you. \n\nYou have to make a decision \n;(A) Loose it in the trees, (B) Continue running and hope;6;7";
            story[5] = "What erver it is may not have fully seen you yet. \n\nYou decide to hide in a nearby bush. \n\nYou soon notice this was a mistake when you heard fast paced stomping coming twords your position. \nYou were ripped in half by a black figure before you could even react. \n\nBadEnd 2 - What were you thinking?... \n;Game Over;end";
            story[6] = "You decide to try and out maneuver what ever was after you. \n\nYou ran around trees and over logs. \nYou jumped holes in the ground and dodged rocks. \nNothing you did seemed to shake what ever that is after you off. \nThat was untill you saw light shining through the dark. \nIt was almost to good to be true. \n; (A) run towards the light, (B) Take your chances in the dark;8;9";
            story[7] = "You keep running and hope that something would to save you. \n\nYou Die of course, Ripped in ribbions by an unkown creature. \nBut it was the thought that counts right? \n\nBadEnd 3 - Its the thought that counts... Right?... \n;Game Over;end";
            story[8] = "You bolt towards the light as fast as you could. \n\nThe light was blinding at first, You had to shield your eyes from the burning rays. \nOn reopening them, you found yourself in a whole new area. \nMatter of fact, the dark forest you were just in was gone. \nInstead you stood in a opened plain of flowers. \n;Press (A or B) To continue;10;10";
            story[9] = "You decide the light is no good and continue running in the dark. \n\nYou soon get cut off by a bunch of red eyes in the dark. \nYou turn to run but did not get to far. \nThe creatures in the dark all leap onto you and had a feeding frenzy. \nYou were eaten alive. \n\nWhat a way to go... \n\nBadEnd - 4 Chow served skeptical... \n;Game Over;end";
            story[10] = "You Continue through the plains untill you notice a town in the herizon. \nOverjoyed that you may finally get some answers about where you are. \nYou push foward towards the town. \n;You Win;end";
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
                    //Checks if Title is active                   
                    pageNumber = choiceA;
                }

                //Detects if B is pressed
                if (Input.Key == ConsoleKey.B)
                {
                    //checks if Title is active
                    if (sub.Contains("title"))
                    {
                        gameLoop = false;
                    }

                    pageNumber = choiceB;

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