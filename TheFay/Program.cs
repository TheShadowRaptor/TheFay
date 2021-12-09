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
        //Opens story file on start
        static string[] story;

        //splits (';') char from string
        static char[] splits = {';'};

        //Determins which array in story you are in (Will change on input)
        static int currentPage;
       
        //Grabs page number from array
        static string OptionOne;
        static string OptionTwo;

        //Converts Options into int
        static int choiceOne;
        static int choiceTwo;

        //Initalizes subArray
        static string[] pageContents = new string[3];

        //Checks if game is running
        static bool gameLoop = true;

        //Checks if Title is active
        static bool isTitleActive = true;

        //----------------------------Text Files------------------------------------
        //initilizes "story.txt" file
        static string storyFile = "Story.txt";

        //initilizes "SaveFiles.txt" file
        static string saveFile1 = "SaveFile1.txt";
        static string saveFile2 = "SaveFile2.txt";
        static string saveFile3 = "SaveFile3.txt";

        //initilizes "Title.txt" file
        static string titleFile = "Title.txt";
        //--------------------------------------------------------------------------

        //converts pageNumber to string
        static string pageToString;

        //Detetects if on endPage
        static bool endPageActive = false;


        //==========================================================================================================

        //Plays Code
        static void Main(string[] args)
        {
            DebugLog();
            InitiateStory();
            RunGame();
        }

        //---------------------------------------------------methods--------------------------------------------------
        //
        //in order from A -> Z
        //

        //Displays Story
        static void DisplayStory()
        {
            if (isTitleActive == true)
            {
                ShowTitle();
                Console.WriteLine("");
                Console.WriteLine("");
                ShowMainMenu();
            }
            
            else
            {
                //splits storyArray into subArray (sub)
                SplitStory();

                //Checks if gameOver
                EndGame();

                //Displays Story
                Console.Clear();

                Console.WriteLine("Page " + (currentPage + 1));                             
                Console.WriteLine("");

                //Writes everyline in pageContents up till the last 4 (Option1, Option2, page1, page2)
                //If end page it will display everything
                foreach (string s in pageContents)
                {                  
                    Console.WriteLine(s);
                    if (endPageActive == false)
                    {
                        if (s == pageContents[pageContents.Length - 5])
                        {
                            break;
                        }
                    }                    
                }

                //Shows players options
                //It 
                if (endPageActive == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - " + pageContents[pageContents.Length - 4]);
                    Console.WriteLine("2 - " + pageContents[pageContents.Length - 3]);
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        //Checks if everything is alright before playing the game
        static void DebugLog()
        {

            //-----------------------checks if the story file exists-----------------------

            Console.Write("Checking if Story.txt exists... ");
            if (File.Exists(storyFile))
            {
                Console.Write("(Exists)");
            }

            else
            {
                Console.Write("(Missing)");
                Console.ReadKey(true);
                gameLoop = false;
            }

            //---------------------Checks if the save file Exists--------------------------

            Console.Write("Checking if SaveGame.txt exists... ");
            if (File.Exists(saveFile1))
            {
                Console.Write("(Exists)");
            }

            else
            {
                Console.Write("(Missing)");
                Console.ReadKey(true);
                gameLoop = false;
            }
        }

        //Ends the gameLoop
        static void EndGame()
        {           
            //Checks if pageContents has "GameOver" in it
            // if it does. Kick player to the title
            if (pageContents.Contains("GameOver"))
            {
                endPageActive = true;
                isTitleActive = true;
            }
        }

        //Calls Story.txt
        static void InitiateStory()
        {
            //==========================================Story Arrays=================================================
            // use (';') to split strings.
            // use (end) for end page.
            // use (title) to determine title page
            story = File.ReadAllLines(storyFile);
            //=======================================================================================================               
        }

        //Parses the Substring
        static void ParseSub()
        {
            OptionOne = pageContents[pageContents.Length - 2];
            OptionTwo = pageContents[pageContents.Length - 1];

            //Converts choice one into a int
            Int32.TryParse(OptionOne, out choiceOne);

            //Converts choice two into an int
            Int32.TryParse(OptionTwo, out choiceTwo);
        }

        //Loops Game
        static void RunGame()
        {
            while (gameLoop == true)
            {             
                DisplayStory();
                ReadInput();                  
            }
        }

        //Reads player input
        static void ReadInput()
        {
            bool waitingForInput = true;

            if(endPageActive == false)
            {
                while (waitingForInput == true)
                {
                    //Player Input
                    ConsoleKeyInfo Input = Console.ReadKey(true);
                    if (isTitleActive == false)
                    {
                        //turns string to int
                        ParseSub();
                    }

                    //Detects if 1 is pressed
                    if (Input.Key == ConsoleKey.D1)
                    {
                        //If title is active then D1 = New Game
                        if (isTitleActive == true)
                        {
                            isTitleActive = false;
                        }

                        else
                        {
                            //Page number changes to slected choice
                            currentPage = choiceOne;
                        }
                        break;
                    }

                    //Detects if 2 is pressed
                    else if (Input.Key == ConsoleKey.D2)
                    {
                        if (isTitleActive == true)
                        {
                            SaveData();
                        }

                        else
                        {
                            //Page number changes to slected choice
                            currentPage = choiceTwo;
                        }
                        break;
                    }

                    //Detects if 3 is pressed
                    else if (Input.Key == ConsoleKey.D3)
                    {
                        if (isTitleActive == true)
                        {
                            //options                        
                        }

                        else
                        {
                            SaveGame();                          
                        }
                        break;
                    }

                    //Detects if 4 is pressed
                    else if (Input.Key == ConsoleKey.D4)
                    {
                        if (isTitleActive == true)
                        {
                            gameLoop = false;
                        }

                        else
                        {
                            SaveData();
                        }
                        break;
                    }

                    else if (Input.Key == ConsoleKey.Escape)
                    {
                        if (isTitleActive == true)
                        {
                            gameLoop = false;
                        }

                        else
                        {
                            isTitleActive = true;
                        }
                        break;
                    }

                    else
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.Write(new string(' ', Console.BufferWidth));
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("{Error} Button does not exist");
                    }
                }
            }
            else
            {
                Console.ReadKey(true);
            }
                         
        }

        //Splits Story into sub
        static void SplitStory()
        {
            //turns page into story substring then splits the char (';') from it
            if (currentPage > 0) 
            { 
                currentPage -= 1; 
            }

            pageContents = story[currentPage].Split(splits);
        }

        //Holds and Loads Save Data
        static void SaveData()
        {           
            string savedGame;
            Console.Clear();
            savedGame = File.ReadAllText(saveFile1);
            if (savedGame == "")
            {
                Console.WriteLine("No save data found");
            }
            else
            {
                Console.WriteLine("Choose a slot to load");
                ConsoleKeyInfo Input = Console.ReadKey(true);
                currentPage = int.Parse(savedGame);
            }

        }

        //Saves game within saveFile
        static void SaveGame()
        {
            Console.Clear();
            bool saveLoop = true;

            string slotOne = saveFile1;
            string slotTwo = saveFile2;
            string slotThree = saveFile3;
            while (saveLoop == true)
            {
                //Saves Current Page
                Console.WriteLine("Choose a save slot");
                pageToString = currentPage.ToString();

                Console.WriteLine("1 - Slot One " + "[ " + slotOne + " ]");
                Console.WriteLine(" ");
                Console.WriteLine("2 - Slot Two " + "[ " + slotTwo + " ]");
                Console.WriteLine(" ");
                Console.WriteLine("3 - Slot Three " + "[ " + slotThree + " ]");
                Console.WriteLine(" ");
                Console.WriteLine("4 - Back");
                ConsoleKeyInfo Input = Console.ReadKey(true);

                if (Input.Key == ConsoleKey.D1)
                {
                    File.WriteAllText(saveFile1, pageToString);
                }

                else if (Input.Key == ConsoleKey.D2)
                {
                    File.WriteAllText(saveFile2, pageToString);
                }

                else if (Input.Key == ConsoleKey.D3)
                {
                    File.WriteAllText(saveFile3, pageToString);
                }

                else if (Input.Key == ConsoleKey.D4)
                {
                    saveLoop = false;
                }

                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write(new string(' ', Console.BufferWidth));
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.WriteLine("{Error} Button does not exist");
                }
            }            
        }

        //Shows the Title
        static void ShowTitle()
        {
            string title = File.ReadAllText(titleFile);
            Console.Clear();
            Console.WriteLine(title);                
        }

        //Shows the Main Menu
        static void ShowMainMenu()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("|                        1.New Game                        |");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("|                        2.Load Game                       |");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("|                        3.Options                         |");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("|                        4.Exit                            |");
            Console.WriteLine("|                                                          |");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("");
            ResetStory();

        }

        static void ResetStory()
        {
            currentPage = 0;
            endPageActive = false;
        }
    }
}