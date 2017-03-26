using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
        /// <summary>
        /// class to store static and to generate dynamic text for the message and input boxes
        /// </summary>
        public static class Text
        {
            public static List<string> HeaderText = new List<string>() { "The Black Forest" };
            public static List<string> FooterText = new List<string>() { "The Magical Coporation, 2020" };

            #region INTITIAL GAME SETUP
            public static string MissionIntro()
            {
                string messageBoxText =
                "You are on the last level of your training to become a top bodyguard for" +
                "the Magical Corporation. Your mission is to test your limits, education and your serving skills" +
                "by passing the lessons and quests that are giving you by the top Lords. Your progress will be" +
                "mentored every minute. You will be sent to the Black Forst, location of this forest in unknown" +
                "because of your safety. Your goal is to make sure to pass every lesson and quest that is giving to you.\n" +
                " \n" +
                "Press the Esc key to exit the game at any point.\n" +
                " \n" +
                "Your mission begins now.\n" +
                " \n" +
                "\tYour first task will be to set up the initial parameters of your mission.\n" +
                " \n" +
                "\tPress any key to begin the Mission Initialization Process.\n";

                return messageBoxText;
            }

            public static string CurrentLocationInfo()
            {
                string messageBoxText =
                "You are now going to be transferred through a portal that will take you to the Black Forest. " +
                "This portal will not give you any knowledge where you will be located in this world." +
                "The location that you will be taking to will be your Home Base that you will call home " +
                "for a wild. This is where you will get your lessons/quests, where you can sleep and rest and" +
                "gets meals, this will be your safety zone in this last level of your training." +
                " \n" +
                "\tChoose from the menu options to proceed.\n";

                return messageBoxText;
            }

            #region Initialize Mission Text

            public static string InitializeMissionIntro()
            {
                string messageBoxText =
                    "Before you begin your mission we much gather your background data.\n" +
                    " \n" +
                    "You will be prompted for the required information. Please enter the information below.\n" +
                    " \n" +
                    "\tPress any key to begin.";

                return messageBoxText;
            }

            public static string InitializeMissionGetTraineeFirstName()
            {
                string messageBoxText =
                    "Enter your name trainee.\n" +
                    " \n" +
                    "Please use the name you wish to be referred during your mission.";

                return messageBoxText;
            }



            public static string InitializeMissionGetTraineeAge(Trainee gameTraveler)
            {
                string messageBoxText =
                    $"Very good then, we will call you {gameTraveler.FirstName} {gameTraveler.LastName} on this mission.\n" +
                    " \n" +
                    "Enter your age below.\n" +
                    " \n" +
                    "Please use the standard year as your reference.";

                return messageBoxText;
            }

            public static string InitializeMissionGetTraineeRace(Trainee gameTraveler)
            {
                string messageBoxText =
                    $"{gameTraveler.FirstName}{gameTraveler.LastName}, it will be important for us to know your race on this mission.\n" +
                    " \n" +
                    "Enter your race below.\n" +
                    " \n" +
                    "Please use the universal race classifications below." +
                    " \n";

                string raceList = null;

                foreach (Character.RaceType race in Enum.GetValues(typeof(Character.RaceType)))
                {
                    if (race != Character.RaceType.None)
                    {
                        raceList += $"\t{race}\n";
                    }
                }

                messageBoxText += raceList;

                return messageBoxText;
            }

            public static string InitializeMissionGetTranieeLastName(Trainee gameTrainee)
            {
                string messageBoxText =
                    "Please enter your last name.\n" +
                    "\n" +
                    "Please use the last name you wish to be referred during your mission.";
                return messageBoxText;
            }

            public static string InitializeMissionGetTraineeLanguage(Trainee gameTraveler)
            {
                string messageBoxText =
                    $"{gameTraveler.FirstName}{gameTraveler.LastName}, it will be important for us to know your language on this mission.\n" +
                    " \n" +
                    "Enter your language below.\n" +
                    " \n" +
                    "Please use the universal language classifications below." +
                    " \n";

                string languageList = null;

                foreach (Trainee.LanguageType language in Enum.GetValues(typeof(Trainee.LanguageType)))
                {
                    if (language != Trainee.LanguageType.None)
                    {
                        languageList += $"\t{language}\n";
                    }
                }

                messageBoxText += languageList;

                return messageBoxText;
            }

            /*public static string InitializeMissionGetIsImmortal(Trainee gameTrainer)
            {
                string messageBoxText =
                    "Are you immortal?\n" +
                    "\n" +
                    "Please answer the question for mission records.";
                return messageBoxText;
            }*/

            public static string InitializeMissionEchoTraineeInfo(Trainee gameTrainee)
            {
                string messageBoxText =
                    $"Very good then {gameTrainee.FirstName}.\n" +
                    " \n" +
                    "It appears we have all the necessary data to begin your mission. You will find it" +
                    " listed below.\n" +
                    " \n" +
                    $"\tTrainee FirstName: {gameTrainee.FirstName}\n" +
                    $"\tTrainee LastName: {gameTrainee.LastName}\n" +
                    $"\tTrainee Age: {gameTrainee.Age}\n" +
                    $"\tTrainee Race: {gameTrainee.Race}\n" +
                    $"\tTrainee Language: {gameTrainee.Language}\n" +
                    /*$"\tTrainee is immortal: {gameTrainee.IsImmortal}\n" + */
                    " \n" +
                    "Press any key to begin your mission.";

                return messageBoxText;
            }

            #endregion

            #endregion

            #region MAIN MENU ACTION SCREENS

            public static string TraineeInfo(Trainee gameTrainee)
            {
                string messageBoxText =
                    $"\tTraveler Name: {gameTrainee.FirstName}\n" +
                    $"\tTraveler Name: {gameTrainee.LastName}\n" +
                    $"\tTraveler Age: {gameTrainee.Age}\n" +
                    $"\tTraveler Race: {gameTrainee.Race}\n" +
                    " \n";

                return messageBoxText;
            }

            public static List<string> StatusBox(Trainee trainee, BlackForest blackForest)
            {
                List<string> statusBoxText = new List<string>();

                statusBoxText.Add($"Experience Points: {trainee.ExperiencePoints}\n");
                statusBoxText.Add($"Health: {trainee.Health}\n");
                statusBoxText.Add($"Lives: {trainee.Lives}\n");


                return statusBoxText;
            }

            public static string ListBlackForestLocations(IEnumerable<ForestTimeLocation> forestTimeLocations)
            {
                string messaBoxText =
                    "Forest Time Locations\n" +
                    "\n" +

                    //
                    // Display table header
                    //
                    "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                    "---".PadRight(10) + "-----------------------------".PadRight(30) + "\n";
                //
                // Display all locations
                //
                string forestTimeLocationList = null;
                foreach (ForestTimeLocation forestTimeLocation in forestTimeLocations)
                {
                    forestTimeLocationList +=
                        $"{forestTimeLocation.BlackForestLocationID}".PadRight(10) +
                        $"{forestTimeLocation.CommonName}".PadRight(30) +
                        Environment.NewLine;
                }

                messaBoxText += forestTimeLocationList;

                return messaBoxText;
            }

            public static string LookAround(ForestTimeLocation _forestTimeLocation)
            {
                string messageBoxText =
                    $"Current Location: {_forestTimeLocation.CommonName}\n" +
                    "\n" +
                    _forestTimeLocation.GeneralContents;

                return messageBoxText;
            }

            public static string Travel(Trainee gametrainee, List<ForestTimeLocation> forestTimeLocations)
            {
                string messageBoxText =
                    $"{gametrainee},  Black Forest will need to know the name of the name of the new location. \n" +
                    "\n" +

                    //
                    // Display table header
                    //
                    "ID".PadRight(10) + "Name".PadRight(30) + "Accessible".PadRight(10) + "\n" +
                    "---".PadRight(10) + "----------------------------".PadRight(30) + "--------".PadRight(10) + "\n";

                //
                // Display all locations except the current location
                //
                string forestTimeLocationsList = null;
                foreach (ForestTimeLocation forestTimeLocation in forestTimeLocations)
                {
                    if (forestTimeLocation.BlackForestLocationID != gametrainee.BlackForestTimeLocationID)
                    {
                        forestTimeLocationsList +=
                            $"{forestTimeLocation.BlackForestLocationID}".PadRight(10) +
                            $"{forestTimeLocation.CommonName}".PadRight(30) +
                            $"{forestTimeLocation.Accessable}".PadRight(10) +
                            Environment.NewLine;
                    }
                }

                messageBoxText += forestTimeLocationsList;

                return messageBoxText;
            }

            public static string CurrentLocationInfo(ForestTimeLocation forestTimeLocation)
            {
                string messageBoxText =
                    $"Current Location: {forestTimeLocation.CommonName}\n" +
                    "\n" +
                    forestTimeLocation.Description;

                return messageBoxText;
            }

            public static string VisitedLocations(IEnumerable<ForestTimeLocation> forestTimeLocations)
            {
                string messageBoxText =
                    "Black Forest -Time Locations Visited\n" +
                    "\n" +

                    //
                    // Display Table header
                    //
                    "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
                    "---".PadRight(10) + "----------------------------".PadRight(30) + "\n";

                //
                // Display all locations
                //
                string forestTimeLocationList = null;
                foreach (ForestTimeLocation forestTimeLocation in forestTimeLocations)
                {
                    forestTimeLocationList +=
                        $"{forestTimeLocation.BlackForestLocationID}".PadRight(10) +
                        $"{forestTimeLocation.CommonName}".PadRight(30) +
                        Environment.NewLine;
                }

                messageBoxText += forestTimeLocationList;

                return messageBoxText;
            }
            #endregion

            public static List<string> StatusBox(Trainee trainee)
            {
                List<string> statusBoxText = new List<string>();

                statusBoxText.Add($"Trainee's Age: {trainee.Age}\n");

                return statusBoxText;
            }
        }
    }