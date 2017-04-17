using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{ 
    /// <summary>
    /// View Class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS

        private enum ViewStatus
        {
            TraineeInitialization,
            PlayingGame
        }

        #endregion

        #region FIELDS

        //
        // Declare game objects for the ConsoleView object to use
        //
        Trainee _gameTrainee;
        BlackForest _blackForest;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Trainee gameTrainee, BlackForest blackForest)
        {
            _gameTrainee = gameTrainee;
            _blackForest = blackForest;

            _viewStatus = ViewStatus.TraineeInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText"></param>
        /// <param name="messageBoxText"></param>
        /// <param name="menu"></param>
        /// <param name="inputBoxPrompt"></param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
            DisplayStatusBox();
        }

        /// <summary>
        /// Wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// Get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public TraineeAction GetActionMenuChoice(Menu menu)
        {
            TraineeAction choosenAction = TraineeAction.None;
            Console.CursorVisible = false;

            //
            // Create an array if valid keys from menu dictionary
            //
            char[] validKeys = menu.MenuChoices.Keys.ToArray();

            //
            // Validate key pressed as in MenuChoice dictionary
            //
            char keyPressed;
            do
            {
                ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
                keyPressed = keyPressedInfo.KeyChar;
            } while (!validKeys.Contains(keyPressed));

            choosenAction = menu.MenuChoices[keyPressed];
            Console.CursorVisible = true;

            return choosenAction;
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        /*public int GetInteger()
        {
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// get an bool value from the user
        /// </summary>
        /// <returns></returns>
        public bool GetBool()
        {

            return bool.Parse(Console.ReadLine());
        }*/

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            //
            // Validate on tange either minimumValue and maximumValue are not 0
            //
            bool validateRange = (minimumValue != 0 || maximumValue != 0);

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (validateRange)
                    {
                        if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                        {
                            validResponse = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                            DisplayInputBoxPrompt(prompt);
                        }
                    }
                    else
                    {
                        validResponse = true;
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an interger value. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            Console.CursorVisible = false;

            return true;
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetDouble(string prompt, double minimumValue, double maximumValue, out double doubleChoice)
        {
            bool validResponse = false;
            doubleChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (double.TryParse(Console.ReadLine(), out doubleChoice))
                {
                    if (doubleChoice >= minimumValue && doubleChoice <= maximumValue)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter an number value between {minimumValue} and {maximumValue}. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an number value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.RaceType GetRace()
        {
            Character.RaceType raceType;
            Enum.TryParse<Character.RaceType>(Console.ReadLine(), out raceType);

            return raceType;
        }

        /// <summary>
        /// Get a trainee language value from the user
        /// </summary>
        /// <returns></returns>
        public Trainee.LanguageType GetLanguage()
        {
            Trainee.LanguageType languageType;
            Enum.TryParse<Trainee.LanguageType>(Console.ReadLine(), out languageType);

            return languageType;
        }

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySplashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 35);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(tabSpace + @"                            THE BLACK FOREST");
            Console.WriteLine(tabSpace + @"                                  Final Training                  ");

            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "The Black Forest";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, TraineeAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != TraineeAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gameTrainee, _blackForest))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// Draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// Display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public Trainee GetIntitialTraineeInfo()
        {
            Trainee trainee = new Trainee();

            //
            // intro
            //
            DisplayGamePlayScreen("Mission Initialization", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            //
            // get traveler's first name
            //
            DisplayGamePlayScreen("Mission Initialization - FirstName", Text.InitializeMissionGetTraineeFirstName(), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your name: ");
            trainee.FirstName = GetString();

            //
            // get trainee's last name
            //
            DisplayGamePlayScreen("Mission Initialization - LastName", Text.InitializeMissionGetTranieeLastName(trainee), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your last name: ");
            trainee.LastName = GetString();

            //
            // get traveler's age
            //
            DisplayGamePlayScreen("Mission Initialization - Age", Text.InitializeMissionGetTraineeAge(trainee), ActionMenu.MissionIntro, "");
            int gameTraineeAge;

            GetInteger($"Enter your age {trainee.FirstName}: ", 0, 1000000, out gameTraineeAge);
            trainee.Age = gameTraineeAge;

            //
            // get traveler's race
            //
            DisplayGamePlayScreen("Mission Initialization - Race", Text.InitializeMissionGetTraineeRace(trainee), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your race {trainee.FirstName}: ");
            trainee.Race = GetRace();


            //
            // get trainee height
            //
            DisplayGamePlayScreen("Mission Initialization - Languages ", Text.InitializeMissionGetTraineeLanguage(trainee), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt($"Enter your laguage {trainee.FirstName}: ");
            trainee.Language = GetLanguage();

            /*
            //
            //get trainee answer if they are immortal
            //
            DisplayGamePlayScreen("Mission Initialization - is immortal", Text.InitializeMissionGetIsImmortal(trainee), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your immortality status: ");
            trainee.IsImmortal = Get; */

            //
            // echo the traveler's info
            //
            DisplayGamePlayScreen("Mission Initialization - Complete", Text.InitializeMissionEchoTraineeInfo(trainee), ActionMenu.MissionIntro, "");
            GetContinueKey();

            _viewStatus = ViewStatus.PlayingGame;

            return trainee;
        }

        #region ----- display responses to menu action choices -----

        public void DisplayTraineeInfo()
        {
            ForestTimeLocation currentForestTimeLocation = _blackForest.GetBlackForestTimeLocationById(_gameTrainee.BlackForestTimeLocationID);
            DisplayGamePlayScreen("Trainee Information", Text.TraineeInfo(_gameTrainee, currentForestTimeLocation), ActionMenu.MainMenu, "");
        }

        public void DisplayCurrentLocationInfo()
        {
            ForestTimeLocation currentForestTimeLocation = _blackForest.GetBlackForestTimeLocationById(_gameTrainee.BlackForestTimeLocationID);
            DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(currentForestTimeLocation), ActionMenu.MainMenu, "");
        }

        public void DisplayConfirmTraineeObjectRemovedFromInventory(TraineeObject objectRemovedFromTraineeInventory)
        {
            DisplayGamePlayScreen("Put Down Game Object", $"The {objectRemovedFromTraineeInventory.Name} has been removed from your inventory.", ActionMenu.MainMenu, "");
        }

        public void DisplayListOfAllForestObjects()
        {
            DisplayGamePlayScreen("List: Forest Objects", Text.ListAllForestObjects(_blackForest.ForestObjects), ActionMenu.AdminMenu, "");
        }

        public void DisplayListOfBlackForestTimeLocations()
        {
            DisplayGamePlayScreen("List: Forest Time Locations", Text.ListAllBlackForestLocations(_blackForest.ForestTimeLocations), ActionMenu.AdminMenu, "");
        }
       
        public void DisplayConfirmTraineeObjectAddedToTraineeInventory(TraineeObject objectAddedToTraineeInventory)
        {
            DisplayGamePlayScreen("Pick Up Lesson Object", $"The {objectAddedToTraineeInventory.Name} has been added to your inventory.", ActionMenu.MainMenu, "");
        }

        public void DisplayTraineeInventory()
        {
            DisplayGamePlayScreen("Current Inventory", Text.CurrentTraineeInventory(_gameTrainee.TraineeInventory), ActionMenu.MainMenu, "");
        }

        public void DisplayGameObjectInfo(ForestObjects forestObjects)
        {
            DisplayGamePlayScreen("Current Location", Text.LookAt(forestObjects), ActionMenu.MainMenu, "");
        }

        public void DisplayLookAround()
        {
            //
            // Get current balck forest time location
            //
            ForestTimeLocation currentForestTimeLocation = _blackForest.GetBlackForestTimeLocationById(_gameTrainee.BlackForestTimeLocationID);

            //
            // Get list of forest object in surrent black forest time location
            //
            List<ForestObjects> forestObjectsInCurrentBlackForestTimeLocation = _blackForest.GetForestObjectsByBlackForestTimeLocationId(_gameTrainee.BlackForestTimeLocationID);

            string messageBoxText = Text.LookAround(currentForestTimeLocation) + Environment.NewLine + Environment.NewLine;
            messageBoxText += Text.ForestObjectsChooseList(forestObjectsInCurrentBlackForestTimeLocation);

            DisplayGamePlayScreen("Current Location", messageBoxText, ActionMenu.MainMenu, "");
        }

        public int DisplayGetForestObjectsToLookAt()
        {
            int forestObjecstId = 0;
            bool validForestObjectsId = false;

            //
            // Get a list of forest objects in the current forest time location
            //
            List<ForestObjects> forestObjectsInBlackForestTimeLocation = _blackForest.GetForestObjectsByBlackForestTimeLocationId(_gameTrainee.BlackForestTimeLocationID);

            if (forestObjectsInBlackForestTimeLocation.Count > 0)
            {
                DisplayGamePlayScreen("Look at a Objects", Text.ListAllForestObjects(forestObjectsInBlackForestTimeLocation), ActionMenu.MainMenu, "");

                while (!validForestObjectsId)
                {
                    //
                    // Get an interger fromthe player
                    //
                    GetInteger($"Enter the Id number of the object you wish to look at: ", 0, 0, out forestObjecstId);

                    //
                    // Validate integer as a calling game object is and in current location
                    //
                    if (_blackForest.IsValidForestObjectByLocationId(forestObjecstId, _gameTrainee.BlackForestTimeLocationID))
                    {
                        validForestObjectsId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered and invalid game object is, Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Look at a Object", "It appears there are no game objects here.", ActionMenu.MainMenu, "");
            }
            return forestObjecstId;
        }

        public int DisplayGetTraineeObjectToPickUp()
        {
            int forestObjectsId = 0;
            bool validForestObjectsId = false;

            //
            // Get a list of trainee objects in the current balck forest time location
            //
            List<TraineeObject> traineeObjectInBlackForestTimeLocation = _blackForest.GetTraineeObjectsByBlackForestTimeLocationId(_gameTrainee.BlackForestTimeLocationID);

            if (traineeObjectInBlackForestTimeLocation.Count > 0)
            {
                DisplayGamePlayScreen("Pick Up Lesson Object", Text.ForestObjectsChooseList(traineeObjectInBlackForestTimeLocation), ActionMenu.MainMenu, "");

                while (!validForestObjectsId)
                {
                    //
                    // Get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to add to your inventory: ", 0, 0, out forestObjectsId);

                    //
                    // Validate integer as a valid lesson object id and in current location
                    //
                    if (_blackForest.IsValidTraineeObjectByLocationId(forestObjectsId, _gameTrainee.BlackForestTimeLocationID))
                    {
                        TraineeObject traineeObject = _blackForest.GetForestObjectById(forestObjectsId) as TraineeObject;
                        if (traineeObject.CanInventory)
                        {
                            validForestObjectsId = true;
                        }
                        else
                        {
                            ClearInputBox();
                            DisplayInputErrorMessage("It appears you may not inventory that object. Please try again.");
                        }
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered an invalid lesson object id. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Lesson Object", "It appears there are no lesson objects here.", ActionMenu.MainMenu, "");
            }

            return forestObjectsId;
        }

        public int DisplayGetTraineeInventoryObjectToPutDown()
        {
            int traineeObjectId = 0;
            bool validTraineeInventoryObjectId = false;

            if (_gameTrainee.TraineeInventory.Count > 0)
            {
                DisplayGamePlayScreen("Put Down Game Object", Text.ForestObjectsChooseList(_gameTrainee.TraineeInventory), ActionMenu.MainMenu, "");

                while (!validTraineeInventoryObjectId)
                {
                    //
                    // get an integer from the player
                    //
                    GetInteger($"Enter the Id number of the object you wish to remove from your inventory: ", 0, 0, out traineeObjectId);

                    //
                    // find object in inventory
                    // note: LINQ used, but a foreach loop may also be used 
                    //
                    TraineeObject objectToPutDown = _gameTrainee.TraineeInventory.FirstOrDefault(o => o.Id == traineeObjectId);

                    //
                    // validate object in inventory
                    //
                    if (objectToPutDown != null)
                    {
                        validTraineeInventoryObjectId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you entered the Id of an object not in the inventory. Please try again.");
                    }
                }
            }
            else
            {
                DisplayGamePlayScreen("Pick Up Game Object", "It appears there are no objects currently in inventory.", ActionMenu.MainMenu, "");
            }

            return traineeObjectId;
        }

        public void DisplayLocationsVisited()
        {
            List<ForestTimeLocation> visitedBlackForestTimeLocations = new List<ForestTimeLocation>();
            foreach (int forestTimeLocationId in _gameTrainee.ForestTimeLocationsVisited)
            {
                visitedBlackForestTimeLocations.Add(_blackForest.GetBlackForestTimeLocationById(forestTimeLocationId));
            }

            DisplayGamePlayScreen("Forest Time Locations Visited", Text.VisitedLocations(visitedBlackForestTimeLocations), ActionMenu.MainMenu, "");
        }

        public int DisplayGetNextForestTimeLocation()
        {
            int forestTimeLocationId = 0;
            bool validForestTimeLocationId = false;

            DisplayGamePlayScreen("Travel to a New Black Forest Time Location", Text.Travel(_gameTrainee, _blackForest.ForestTimeLocations), ActionMenu.MainMenu, "");

            while (!validForestTimeLocationId)
            {
                //
                // Get an interger from the player
                //
                GetInteger($"Enter your new location {_gameTrainee.FirstName}: ", 1, _blackForest.GetMaxBlackForestTimeLocationId(), out forestTimeLocationId);

                //
                // Validate integer as a calid space-time locations id and determine accessibility
                //
                if (_blackForest.IsValidBlackForestTimeLocationId(forestTimeLocationId))
                {
                    if (_blackForest.IsAccessibleLocation(forestTimeLocationId))
                    {
                        validForestTimeLocationId = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("It appears you attempting to travel to an inaccessible location. Please try again.");
                    }
                }
                else
                {
                    DisplayInputErrorMessage("It appears you entered an invalid Black Forest-Time location id.  Please try again.");
                }
            }

            return forestTimeLocationId;
        }

        #endregion
        #endregion
    }
}
