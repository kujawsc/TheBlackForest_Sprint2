using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Trainee _gameTrainee;
        private BlackForest _gameBlackForest;
        private bool _playingGame;
        private ForestTimeLocation _currentLocation;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gameTrainee = new Trainee();
            _gameBlackForest = new BlackForest();
            _gameConsoleView = new ConsoleView(_gameTrainee, _gameBlackForest);
            _playingGame = true;

            //
            // Add initial items to the trainee inventory
            //
            _gameTrainee.TraineeInventory.Add(_gameBlackForest.GetForestObjectById(8) as TraineeObject);
            _gameTrainee.TraineeInventory.Add(_gameBlackForest.GetForestObjectById(9) as TraineeObject);

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            TraineeAction traineeActionChoice = TraineeAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySplashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission trainee
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _currentLocation = _gameBlackForest.GetBlackForestTimeLocationById(_gameTrainee.BlackForestTimeLocationID);
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(), ActionMenu.MainMenu, "");
            //
            // game loop
            //
            while (_playingGame)
            {
                // Process all flapgs, events, and stats
                //
                UpdateGameStatus();
                //
                // get next game action from player
                //
                traineeActionChoice = GetNextTraineeAction();
                if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.MainMenu)
                {
                    traineeActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                }
                else if (ActionMenu.currentMenu == ActionMenu.CurrentMenu.AdminMenu)
                {
                    traineeActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                }
                //
                // choose an action based on the player's menu choice
                //
                switch (traineeActionChoice)
                {
                    case TraineeAction.None:
                        break;

                    case TraineeAction.TraineeInfo:
                        _gameConsoleView.DisplayTraineeInfo();
                        break;

                    case TraineeAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case TraineeAction.Travel:
                        TraineAction();
                        break;

                    case TraineeAction.TraineeLocationVisited:
                        _gameConsoleView.DisplayLocationsVisited();
                        break;

                    case TraineeAction.LookAt:
                        LookAtAction();
                        break;

                    case TraineeAction.PickUp:
                        PickUpAction();
                        break;

                    case TraineeAction.PutDown:
                        PutDownAction();
                        break;

                    case TraineeAction.TalkTo:
                        TalkToAction();
                        break;

                    case TraineeAction.TraineeInventory:
                        _gameConsoleView.DisplayTraineeInventory();
                        break;

                    case TraineeAction.ListOfBlackForestLocations:
                        _gameConsoleView.DisplayListOfBlackForestTimeLocations();
                        break;

                    case TraineeAction.ListForestObjects:
                        _gameConsoleView.DisplayListOfAllForestObjects();
                        break;

                    case TraineeAction.TraineeMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.TraineeMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Trainee Menu", "Select an operation from the menu.", ActionMenu.TraineeMenu, "");
                        break;

                    case TraineeAction.ObjectMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.ObjectMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Object Menu", "Select an operation from the menu.", ActionMenu.ObjectMenu, "");
                        break;

                    case TraineeAction.NonplayerCharacterMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.NpcMenu;
                        _gameConsoleView.DisplayGamePlayScreen("NPC Menu", "Select an operation from the menu.", ActionMenu.NpcMenu, "");
                        break;

                    case TraineeAction.AdminMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.AdminMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Admin Menu", "Select an operation from the menu.", ActionMenu.AdminMenu, "");
                        break;

                    case TraineeAction.ReturnToMainMenu:
                        ActionMenu.currentMenu = ActionMenu.CurrentMenu.MainMenu;
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case TraineeAction.ListNonplayerTrainee:
                        _gameConsoleView.DisplayListOfAllNpcObjects();
                        break;

                    case TraineeAction.Exit:
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// Display the correct menu/sub-menu and get the next trainee action
        /// </summary>
        /// <returns>trainee action</returns>
        private TraineeAction GetNextTraineeAction()
        {
            TraineeAction traineeActionChoice = TraineeAction.None;

            switch (ActionMenu.currentMenu)
            {
                case ActionMenu.CurrentMenu.MainMenu:
                    traineeActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                    break;

                case ActionMenu.CurrentMenu.ObjectMenu:
                    traineeActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.ObjectMenu);
                    break;

                case ActionMenu.CurrentMenu.NpcMenu:
                    traineeActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.NpcMenu);
                    break;

                case ActionMenu.CurrentMenu.TraineeMenu:
                    traineeActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.TraineeMenu);
                    break;

                case ActionMenu.CurrentMenu.AdminMenu:
                    traineeActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.AdminMenu);
                    break;

                default:
                    break;
            }

            return traineeActionChoice;
        }
        private void InitializeMission()
        {
            Trainee trainee = _gameConsoleView.GetIntitialTraineeInfo();

            _gameTrainee.FirstName = trainee.FirstName;
            _gameTrainee.LastName = trainee.LastName;
            _gameTrainee.Age = trainee.Age;
            _gameTrainee.Race = trainee.Race;
            _gameTrainee.Language = trainee.Language;
            _gameTrainee.BlackForestTimeLocationID = 1;

            _gameTrainee.ExperiencePoints = 0;
            _gameTrainee.Health = 100;
            _gameTrainee.Lives = 3;
        }

        private void UpdateGameStatus()
        {
            if (!_gameTrainee.HasVisited(_currentLocation.BlackForestLocationID))
            {
                //
                // Add new location to the list of visited location if this is a first visit
                //
                _gameTrainee.ForestTimeLocationsVisited.Add(_currentLocation.BlackForestLocationID);

                //
                // Update experinces points from visiting location
                _gameTrainee.ExperiencePoints += _currentLocation.ExperiencePoints;
            }
        }

        private void PickUpAction()
        {
            //
            // display a list of trainee objects in balc forest time location and get a player choice
            //
            int traineeObjectToPickUpId = _gameConsoleView.DisplayGetTraineeObjectToPickUp();

            //
            // add the trainee object to trainee's inventory
            //
            if (traineeObjectToPickUpId != 0)
            {
                //
                // get the game object from the black forest
                //
                TraineeObject traineeObject = _gameBlackForest.GetForestObjectById(traineeObjectToPickUpId) as TraineeObject;

                //
                // note: trainee object is added to list and the balck forest time location is set to 0
                //
                _gameTrainee.TraineeInventory.Add(traineeObject);
                traineeObject.BlackForestLocationId = 0;

                //
                // display confirmation message
                //
                _gameConsoleView.DisplayConfirmTraineeObjectAddedToTraineeInventory(traineeObject);
            }
        }

        private void PutDownAction()
        {
            //
            // display a list of trainee objects in inventory and get a player choice
            //
            int traineeInventoryObjectToPutDownId = _gameConsoleView.DisplayGetTraineeInventoryObjectToPutDown();

            //
            // get the game object from the black forest
            //
            TraineeObject traineeObject = _gameBlackForest.GetForestObjectById(traineeInventoryObjectToPutDownId) as TraineeObject;

            //
            // remove the object from inventory and set the black forest time location to the current value
            //
            _gameTrainee.TraineeInventory.Remove(traineeObject);
            traineeObject.BlackForestLocationId = _gameTrainee.BlackForestTimeLocationID;

            //
            // display confirmation message
            //
            _gameConsoleView.DisplayConfirmTraineeObjectRemovedFromInventory(traineeObject);

        }

        /// <summary>
        /// process the Trainee action
        /// </summary>
        private void TraineAction()
        {
            //
            // get new location choice and update the current location property
            //                        
            _gameTrainee.BlackForestTimeLocationID = _gameConsoleView.DisplayGetNextForestTimeLocation();
            _currentLocation = _gameBlackForest.GetBlackForestTimeLocationById(_gameTrainee.BlackForestTimeLocationID);

            //
            // display the new balck forest time location info
            //
            _gameConsoleView.DisplayCurrentLocationInfo();
        }

        private void LookAtAction()
        {
            //
            // display a list of forest objects in black forest time location and get a player choice
            //
            int forestObjectsToLookAtId = _gameConsoleView.DisplayGetForestObjectsToLookAt();

            //
            // display game object info
            //
            if (forestObjectsToLookAtId != 0)
            {
                //
                // get the game object from the black forest
                //
                ForestObjects forestObjects = _gameBlackForest.GetForestObjectById(forestObjectsToLookAtId);

                //
                // display information for the object chosen
                //
                _gameConsoleView.DisplayGameObjectInfo(forestObjects);
            }
        }

            private void TalkToAction()
        {
            //
            // Display a list of NPCs in black forest location and get player chice
            //
            int npcToTalkToId = _gameConsoleView.DisplayGetNpcToTalkTo();

            //
            // Display NPCs message
            //
            if (npcToTalkToId != 0)
            {
                //
                // Get the NPC from the universe
                //
                Npc npc = _gameBlackForest.GetNpcById(npcToTalkToId);

                //
                // Display information for the object chosen
                //
                _gameConsoleView.DisplayTalkTo(npc);
            }
        }
        #endregion
    }
}