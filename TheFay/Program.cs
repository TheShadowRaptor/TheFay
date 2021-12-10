using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TheTemple
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

        //initilizing slots for saving and loading
        static string slotOne;
        static string slotTwo;
        static string slotThree;

        static int slotParseOne;
        static int slotParseTwo;
        static int slotParseThree;

        //initilizes "Title.txt" file
        static string titleFile = "Title.txt";
        //--------------------------------------------------------------------------

        //converts pageNumber to string
        static string pageToString;

        //Detetects if on endPage
        static bool endPageActive = false;

        //Turns the Input Method off
        static bool isInputActive = true;


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

                //Displays Story
                Console.Clear();

                Console.WriteLine("Page " + (currentPage + 1));                             
                Console.WriteLine("");         
                
                 //Checks if gameOver
                EndGame();

                //Writes everyline in pageContents up till the last 4 (Option1, Option2, page1, page2)
                //If end page it will display everything
                //------------------------------------------------------------------------------------

                //error checks for a misformated line
                if (pageContents.Length < 5)
                {
                    Console.WriteLine("{Error} The Correct story format (Plot, Options1, Options2, Destination1, Destination2) Does not exist.");
                    Console.WriteLine("Please check the Story.txt file for any errors");
                    Console.WriteLine("Press any key to close the application");
                    Console.ReadKey(true);
                    isInputActive = false;
                    gameLoop = false;
                }               
                //-------------------------------------------------------------------------

                //Checks for a blank line
                else if (pageContents.Length <= 0)
                {
                    Console.WriteLine("{Error} The story line is blank.");
                    Console.WriteLine("Please check the Story.txt file for any errors");
                    Console.WriteLine("Press any key to close the application");
                    Console.ReadKey(true);
                    isInputActive = false;
                    gameLoop = false;
                }

                else
                {
                    //------------------------------------Top Border---------------------------

                    Console.WriteLine("=======================================================================");

                    //Displays story text and leaves out Options and Destinations
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
                }

                //---------------------------------Bottem Border-----------------------------

                Console.WriteLine("=======================================================================");
                //---------------------------------------------------------------------------

                //Shows players Options
                if (endPageActive == false)
                {
                    if (pageContents.Length >= 5)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("=======================================");
                        Console.WriteLine("[1] - " + pageContents[pageContents.Length - 4]);
                        Console.WriteLine("[2] - " + pageContents[pageContents.Length - 3]);
                        Console.WriteLine("=======================================");
                        Console.WriteLine("");
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("|                                     |");
                        Console.WriteLine("|  [3] - SaveGame    [4] - LoadGame   |");
                        Console.WriteLine("|       [Esc] - Return to title       |");
                        Console.WriteLine("|                                     |");
                        Console.WriteLine("---------------------------------------");
                    }                   
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
                Console.WriteLine("(Exists)");
            }

            else
            {
                Console.Write("(Missing)");
                Console.ReadKey(true);
                gameLoop = false;
            }

            Console.WriteLine("");

            Console.Write("Checking if Title.txt exists... ");
            if (File.Exists(titleFile))
            {
                Console.WriteLine("(Exists)");
            }

            else
            {
                Console.Write("(Missing)");
                Console.ReadKey(true);
                gameLoop = false;
            }

            Console.WriteLine("");

            //---------------------Checks if the save file Exists--------------------------

            Console.Write("Checking if SaveFile1.txt exists... ");
            if (File.Exists(saveFile1))
            {
                Console.WriteLine("(Exists)");
            }

            else
            {
                Console.Write("(Missing)");
                Console.ReadKey(true);
                gameLoop = false;
            }

            Console.Write("Checking if SaveFile2.txt exists... ");
            if (File.Exists(saveFile2))
            {
                Console.WriteLine("(Exists)");
            }

            else
            {
                Console.Write("(Missing)");
                Console.ReadKey(true);
                gameLoop = false;
            }

            Console.Write("Checking if SaveFile3.txt exists... ");
            if (File.Exists(saveFile3))
            {
                Console.WriteLine("(Exists)");
            }

            else
            {
                Console.Write("(Missing)");
                Console.ReadKey(true);
                gameLoop = false;
            }

            if (!File.Exists(storyFile) || !File.Exists(titleFile) || !File.Exists(saveFile1) || !File.Exists(saveFile2) || !File.Exists(saveFile3))
            {
                Console.WriteLine("{Error} Files are missing...");
                Console.WriteLine("Press any key to close the application");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("");
                Console.ReadKey(true);
            }           
        }

        //Ends the gameLoop
        static void EndGame()
        {           
            //Checks if pageContents has "GameOver" in it
            // if it does. Kick player to the title
            if (pageContents.Contains("GameOver") || pageContents.Contains("You Win"))
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
                if (isInputActive == true)
                {
                    ReadInput();
                }                                
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
                            LoadGame();
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
                            OptionsMenu();                      
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
                            LoadGame();
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
        static void LoadGame()
        {           
            Console.Clear();
            slotOne = File.ReadAllText(saveFile1);
            slotTwo = File.ReadAllText(saveFile2);
            slotThree = File.ReadAllText(saveFile3);

            if (slotOne == "")
            {
                slotParseOne = -1;
            }

            if (slotTwo == "")
            {
                slotParseTwo = -1;
            }

            if (slotThree == "")
            {
                slotParseThree = -1;
            }

            bool loadLoop = true;           

            while (loadLoop == true)
            {
                Console.WriteLine("Choose a slot to load");

                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("1 - Slot One " + "[ " + "Page" + "{" + (slotParseOne + 1) + "}" + " ]");
                Console.WriteLine(" ");
                Console.WriteLine("2 - Slot Two " + "[ " + "Page" + "{" + (slotParseTwo + 1) + "}" + " ]");
                Console.WriteLine(" ");
                Console.WriteLine("3 - Slot Three " + "[ " + "Page" + "{" + (slotParseThree + 1) + "}" + " ]");
                Console.WriteLine(" ");
                Console.WriteLine("4 - Back");
                Console.WriteLine("---------------------------------------------------------------");

                ConsoleKeyInfo Input = Console.ReadKey(true);

                if (Input.Key == ConsoleKey.D1)
                {
                    if (slotParseOne == -1)
                    {
                        Console.Clear();
                        Console.WriteLine("No saved data to load...");
                    }
                    else
                    {
                        currentPage = slotParseOne + 1;
                        loadLoop = false;
                        isTitleActive = false;

                        Console.WriteLine("Loaded slot one!");
                        Console.WriteLine("Press an key to continue");
                        Console.ReadKey(true);
                    }
                }

                else if (Input.Key == ConsoleKey.D2)
                {
                    if (slotParseTwo == -1)
                    {
                        Console.Clear();
                        Console.WriteLine("No saved data to load...");                        
                    }
                    else
                    {
                        currentPage = slotParseTwo + 1;
                        loadLoop = false;
                        isTitleActive = false;

                        Console.WriteLine("Loaded slot two!");
                        Console.WriteLine("Press an key to continue");
                        Console.ReadKey(true);
                    }
                }

                else if (Input.Key == ConsoleKey.D3)
                {
                    if (slotParseThree == -1)
                    {
                        Console.Clear();
                        Console.WriteLine("No saved data to load...");
                    }

                    else
                    {
                        currentPage = slotParseThree + 1;
                        loadLoop = false;
                        isTitleActive = false;

                        Console.WriteLine("Loaded slot three!");
                        Console.WriteLine("Press an key to continue");
                        Console.ReadKey(true);
                    }
                }

                else if (Input.Key == ConsoleKey.D4)
                {
                    loadLoop = false;
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

        //The Options menu
        static void OptionsMenu()
        {
            bool optionsLoop = true;

            while (optionsLoop == true)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("|                              OPTIONS                          |");
                Console.WriteLine("|                      1 - Change text colour                   |");
                Console.WriteLine("|                      2 - Back                                 |");
                Console.WriteLine("|                                                               |");
                Console.WriteLine("-----------------------------------------------------------------");

                ConsoleKeyInfo Input = Console.ReadKey(true);

                if (Input.Key == ConsoleKey.D1)
                {
                    ChangeTextColor();
                }

                else if (Input.Key == ConsoleKey.D2)
                {
                    optionsLoop = false;
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
            
        //Saves game within saveFile
        static void SaveGame()
        {
            Console.Clear();
            bool saveLoop = true;            

            while (saveLoop == true)
            {
                //---------------------------------Saves Current Page------------------------------------                           
                Console.WriteLine("Choose a save slot");

                slotOne = File.ReadAllText(saveFile1);
                slotTwo = File.ReadAllText(saveFile2);
                slotThree = File.ReadAllText(saveFile3);

                if (slotOne == "")
                {
                    slotParseOne = -1;
                }

                else
                {
                    slotParseOne = int.Parse(slotOne);
                }

                if (slotTwo == "")
                {
                    slotParseTwo = -1;
                }

                else
                {
                    slotParseTwo = int.Parse(slotTwo);
                }

                if (slotThree == "")
                {
                    slotParseThree = -1; 
                }

                else
                {
                    slotParseThree = int.Parse(slotThree);
                }

                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("1 - Slot One " + "[ " + "Page" + "{" + (slotParseOne + 1) + "}" + " ]");
                Console.WriteLine(" ");
                Console.WriteLine("2 - Slot Two " + "[ " + "Page" + "{" + (slotParseTwo + 1) + "}" + " ]");
                Console.WriteLine(" ");
                Console.WriteLine("3 - Slot Three " + "[ " + "Page" + "{" + (slotParseThree + 1) + "}" + " ]");
                Console.WriteLine(" ");
                Console.WriteLine("4 - Back");
                Console.WriteLine("---------------------------------------------------------------");

                pageToString = currentPage.ToString();
                ConsoleKeyInfo Input = Console.ReadKey(true);
                Console.Clear();

                if (Input.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    File.WriteAllText(saveFile1, pageToString);
                    Console.WriteLine("Saved in slot one!");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);
                    Console.Clear();
                }

                else if (Input.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    File.WriteAllText(saveFile2, pageToString);
                    Console.WriteLine("Saved in slot two!");
                    Console.ReadKey(true);
                    Console.Clear();
                }

                else if (Input.Key == ConsoleKey.D3)
                {
                    Console.Clear();
                    File.WriteAllText(saveFile3, pageToString);
                    Console.WriteLine("Saved in slot three!");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey(true);
                    Console.Clear();
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

                if (slotOne != "")
                {
                    slotParseOne = int.Parse(slotOne);
                }

                if (slotTwo != "")
                {
                    slotParseTwo = int.Parse(slotTwo);
                }

                if (slotThree != "")
                {
                    slotParseThree = int.Parse(slotThree);
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

        //Resets values in story
        static void ResetStory()
        {
            currentPage = 0;
            endPageActive = false;
            isInputActive = true;
        }

        //Changes Text colour
        static void ChangeTextColor()
        {
            bool textColorLoop = true;

            while (textColorLoop == true)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------");
                Console.WriteLine("|                            CHOICES                            |");
                Console.WriteLine("|                        1 - White                              |");
                Console.WriteLine("|                        2 - Red                                |");
                Console.WriteLine("|                        3 - Green                              |");
                Console.WriteLine("|                        4 - Blue                               |");
                Console.WriteLine("|                        5 - Matt's favroute colour             |");
                Console.WriteLine("|                        6 - Back                               |");
                Console.WriteLine("|                                                               |");
                Console.WriteLine("-----------------------------------------------------------------");

                ConsoleKeyInfo Input = Console.ReadKey(true);

                if (Input.Key == ConsoleKey.D1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (Input.Key == ConsoleKey.D2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                if (Input.Key == ConsoleKey.D3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                if (Input.Key == ConsoleKey.D4)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                if (Input.Key == ConsoleKey.D5)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                else if (Input.Key == ConsoleKey.D6)
                {
                    textColorLoop = false;
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
    }
}