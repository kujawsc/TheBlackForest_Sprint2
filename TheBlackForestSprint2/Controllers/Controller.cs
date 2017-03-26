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
            // initialize the mission traveler
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _currentLocation = _gameBlackForest.GetForestTimeLocationById(_gameTrainee.BlackForestTimeLocationID);
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
                traineeActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);

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

                    case TraineeAction.ListBlackForestLocations:
                        _gameConsoleView.DisplayListOfForestTimeLocations();
                        break;

                    case TraineeAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;

                    case TraineeAction.Travel:
                        //
                        // Get new location choice and update the current location property
                        //
                        _gameTrainee.BlackForestTimeLocationID = _gameConsoleView.DisplayGetNextForestTimeLocation();
                        _currentLocation = _gameBlackForest.GetForestTimeLocationById(_gameTrainee.BlackForestTimeLocationID);

                        //
                        // Set the game play screen to the current location info format
                        //
                        _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");
                        break;

                    case TraineeAction.TraineeLocationVisited:
                        _gameConsoleView.DisplayLocationsVisited();
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

        #endregion
    }
}