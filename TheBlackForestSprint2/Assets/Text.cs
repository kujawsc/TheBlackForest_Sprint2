﻿using System;
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

            /// <summary>
            /// Intialize the Mission Intro
            /// </summary>
            /// <returns>Intialize</returns>
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

        /// <summary>
        /// Initialize to get the trainee name
        /// </summary>
        /// <returns></returns>
            public static string InitializeMissionGetTraineeFirstName()
            {
                string messageBoxText =
                    "Enter your name trainee.\n" +
                    " \n" +
                    "Please use the name you wish to be referred during your mission.";

                return messageBoxText;
            }

        /// <summary>
        /// Get trainee age
        /// </summary>
        /// <param name="gameTrainee"></param>
        /// <returns></returns>
            public static string InitializeMissionGetTraineeAge(Trainee gameTrainee)
            {
                string messageBoxText =
                    $"Very good then, we will call you {gameTrainee.FirstName} {gameTrainee.LastName} on this mission.\n" +
                    " \n" +
                    "Enter your age below.\n" +
                    " \n" +
                    "Please use the standard year as your reference.";

                return messageBoxText;
            }
        
        /// <summary>
        /// Get trainee race
        /// </summary>
        /// <param name="gameTrainee"></param>
        /// <returns></returns>
            public static string InitializeMissionGetTraineeRace(Trainee gameTrainee)
            {
                string messageBoxText =
                    $"{gameTrainee.FirstName}{gameTrainee.LastName}, it will be important for us to know your race on this mission.\n" +
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

        /// <summary>
        /// Get trainee last name
        /// </summary>
        /// <param name="gameTrainee"></param>
        /// <returns></returns>
            public static string InitializeMissionGetTranieeLastName(Trainee gameTrainee)
            {
                string messageBoxText =
                    "Please enter your last name.\n" +
                    "\n" +
                    "Please use the last name you wish to be referred during your mission.";
                return messageBoxText;
            }

        /// <summary>
        /// Get trainee languge
        /// </summary>
        /// <param name="gameTrainee"></param>
        /// <returns></returns>
            public static string InitializeMissionGetTraineeLanguage(Trainee gameTrainee)
            {
                string messageBoxText =
                    $"{gameTrainee.FirstName}{gameTrainee.LastName}, it will be important for us to know your language for you background, but the mission will still be in English.\n" +
                    " \n" +
                    "Enter your background language below.\n" +
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

        /// <summary>
        /// Getting the Echo trainee info
        /// </summary>
        /// <param name="gameTrainee"></param>
        /// <returns></returns>
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
                    " \n" +
                    "Press any key to begin your mission.";

                return messageBoxText;
            }

            #endregion

            #endregion

            #region MAIN MENU ACTION SCREENS

        /// <summary>
        /// Trainee Info
        /// </summary>
        /// <param name="gameTrainee"></param>
        /// <param name="currentLocation"></param>
        /// <returns></returns>
            public static string TraineeInfo(Trainee gameTrainee, ForestTimeLocation currentLocation)
            {
            string messageBoxText =
                $"\tTraveler Name: {gameTrainee.FirstName}\n" +
                $"\tTraveler Name: {gameTrainee.LastName}\n" +
                $"\tTraveler Age: {gameTrainee.Age}\n" +
                $"\tTraveler Race: {gameTrainee.Race}\n" +
                " \n" +
                $"\tCurrent Location: {currentLocation.CommonName}\n" +
                "\n";

                return messageBoxText;
            }

        /// <summary>
        /// The list for the black forest location
        /// </summary>
        /// <param name="forestTimeLocations"></param>
        /// <returns></returns>
            public static string ListAllBlackForestLocations(IEnumerable<ForestTimeLocation> forestTimeLocations)
            {
            string messageBoxText =
             "Black Forest Time Locations\n" +
             " \n" +

             //
             // Display table header
             //
             "ID".PadRight(10) + "Name".PadRight(30) + "\n" +
             "---".PadRight(10) + "----------------------".PadRight(30) + "\n";

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

        /// <summary>
        /// The current look around 
        /// </summary>
        /// <param name="forestTimeLocation"></param>
        /// <returns></returns>
        public static string LookAround(ForestTimeLocation forestTimeLocation)
            {
                string messageBoxText =
                    $"Current Location: {forestTimeLocation.CommonName}\n" +
                    "\n" +
                    forestTimeLocation.Description;

                return messageBoxText;
            }

        /// <summary>
        /// Trainee traveling options
        /// </summary>
        /// <param name="gametrainee"></param>
        /// <param name="forestTimeLocations"></param>
        /// <returns></returns>
            public static string Travel(Trainee gametrainee, List<ForestTimeLocation> forestTimeLocations)
            {
                string messageBoxText =
                    $"{gametrainee},  Black Forest will need to know the name of the name of the new location. \n" +
                    "\n" +
                    "Enter the ID number of your desired location from the table below.\n" +
                " \n" +

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

        /// <summary>
        /// Status box list for the trainee
        /// </summary>
        /// <param name="trainee"></param>
        /// <returns></returns>
        public static List<string> StatusBox(Trainee trainee)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Trainee's Age: {trainee.Age}\n");

            return statusBoxText;
        }

        /// <summary>
        /// The main current location when is the trainee 
        /// </summary>
        /// <param name="forestTimeLocation"></param>
        /// <returns></returns>
        public static string CurrentLocationInfo(ForestTimeLocation forestTimeLocation)
            {
                string messageBoxText =
                    $"Current Location: {forestTimeLocation.CommonName}\n" +
                    "\n" +
                    forestTimeLocation.Description;

                return messageBoxText;
            }

        /// <summary>
        /// Trainee visited location
        /// </summary>
        /// <param name="forestTimeLocations"></param>
        /// <returns></returns>
            public static string VisitedLocations(IEnumerable<ForestTimeLocation> forestTimeLocations)
            {
                string messageBoxText =
                    "Black Forest Time Locations Visited\n" +
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

        /// <summary>
        /// The forest lsit of objects
        /// </summary>
        /// <param name="forestObjects"></param>
        /// <returns></returns>
        public static string ListAllForestObjects(IEnumerable<ForestObjects> forestObjects)
        {
            //
            // Display table name and colum Headers
            //
            string messageBoxText =
                "Forest Objects\n" +
                "\n" +

                //
                // Display Table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Balck Forest Time Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "---------------------------".PadRight(30) +
                "---------------------------".PadRight(10) + "\n";

            //
            // Display all trainee objects in rows
            //
            string forestObjectRows = null;
            foreach (ForestObjects forestObject in forestObjects)
            {
                forestObjectRows +=
                    $"{forestObject.Id}".PadRight(10) +
                    $"{forestObject.Name}".PadRight(30) +
                    $"{forestObject.BlackForestLocationId}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += forestObjectRows;

            return messageBoxText;
        }

        /// <summary>
        /// List Black Forest Location Objects By Black Forest Time  Location
        /// </summary>
        /// <param name="blackForestTimeLocationId"></param>
        /// <param name="forestObjects"></param>
        /// <returns></returns>
        public static string ListBlackForestLocationObjectsByBlackForestTimeLocation(int blackForestTimeLocationId, IEnumerable<ForestObjects> forestObjects)
        {
            //
            // generate a list of traveler objects from the game object list with the current space-time location id
            //
            List<BlackForestTimeLocationObjects> blackForestTimeLocationObjects = new List<BlackForestTimeLocationObjects>();
            foreach (var forestObject in forestObjects)
            {
                if (forestObject is TraineeObject && forestObject.BlackForestLocationId == blackForestTimeLocationId)
                {
                    blackForestTimeLocationObjects.Add(forestObject as BlackForestTimeLocationObjects);
                }
            }

            //
            // display table name and column headers
            //
            string messageBoxText =
                "Space-Time Location Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) + "Name".PadRight(30) + "Type".PadRight(20) + "\n" +
                "---".PadRight(10) + "----------------------".PadRight(30) +
                "----------------------".PadRight(20) + "\n";

            //
            // display all traveler objects in rows
            //
            string blackForrestTimeLocationObjectRows = null;
            foreach (BlackForestTimeLocationObjects blackForestTimeLocationObject in blackForestTimeLocationObjects)
            {
                blackForrestTimeLocationObjectRows +=
                    $"{blackForestTimeLocationObject.Id}".PadRight(10) +
                    $"{blackForestTimeLocationObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += blackForrestTimeLocationObjectRows;

            return messageBoxText;
        }

        /// <summary>
        /// The list of what the trainee is looking
        /// </summary>
        /// <param name="forestObjects"></param>
        /// <returns></returns>
        public static string LookAt(ForestObjects forestObjects)
        {
            string messageBoxText = "";

            messageBoxText =
                $"{forestObjects.Name}\n" +
                "/n" +
                forestObjects.Description + "\n" +
                "\n";

            if (forestObjects is TraineeObject)
            {
                TraineeObject traineeObject = forestObjects as TraineeObject;

                messageBoxText += $"The {traineeObject.Name} has a value of {traineeObject.Value} and ";

                if (traineeObject.CanInventory)
                {
                    messageBoxText += "may be added to your inventory.";
                }
                else
                {
                    messageBoxText += "may not be added to your inventory.";
                }
            }
            else
            {
                messageBoxText += $"The {forestObjects.Name} may not be added to your inventory.";
            }
            return messageBoxText;
        }

        /// <summary>
        /// The choose list for the forest 
        /// </summary>
        /// <param name="forestObjects"></param>
        /// <returns></returns>
        public static string ForestObjectsChooseList(IEnumerable<ForestObjects> forestObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "Forest Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) + "\n";

            //
            // display all trainee lesson in rows
            //
            string forestObjecstRows = null;
            foreach (ForestObjects forestObject in forestObjects)
            {
                forestObjecstRows +=
                    $"{forestObject.Id}".PadRight(10) +
                    $"{forestObject.Name}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += forestObjecstRows;

            return messageBoxText;
        }

        /// <summary>
        /// The current invetory the trainee has
        /// </summary>
        /// <param name="traineeInventory"></param>
        /// <returns></returns>
        public static string CurrentInventory (IEnumerable<TraineeObject> traineeInventory)
        {
            string messageBoxText = "";

            //
            // Display table header
            //
            messageBoxText =
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Type".PadRight(10) +
                "\n" +
                "---".PadRight(10) +
                "----------------------------".PadRight(30) +
                "----------------------".PadRight(10) +
                "\n";

            //
            // Display all trainee objects in rows
            //
            string traineeInventoryObjectsRows = null;
            foreach (TraineeObject traineeInventoryObject in traineeInventory )
            {
                traineeInventoryObjectsRows +=
                    $"{traineeInventoryObject.Id}".PadRight(10) +
                    $"{traineeInventoryObject.Name}".PadRight(30) +
                    $"{traineeInventoryObject.Type}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += traineeInventoryObjectsRows;

            return messageBoxText;

        }

        /// <summary>
        /// The trainee inventory list
        /// </summary>
        /// <param name="traineeInventory"></param>
        /// <returns></returns>
        public static string CurrentTraineeInventory(IEnumerable<TraineeObject> traineeInventory)
        {
            string messageBoxText = "";

            //
            // display table header
            //
            messageBoxText =
            "ID".PadRight(10) +
            "Name".PadRight(30) +
            "Type".PadRight(10) +
            "\n" +
            "---".PadRight(10) +
            "----------------------------".PadRight(30) +
            "----------------------".PadRight(10) +
            "\n";

            //
            // display all traveler objects in rows
            //
            string traineeInventoryObjectRows = null;
            foreach (TraineeObject traineeInventoryObject in traineeInventory)
            {
                traineeInventoryObjectRows +=
                    $"{traineeInventoryObject.Id}".PadRight(10) +
                    $"{traineeInventoryObject.Name}".PadRight(30) +
                    $"{traineeInventoryObject.Type}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += traineeInventoryObjectRows;

            return messageBoxText;
        }

        /// <summary>
        /// The lsit of all NPC
        /// </summary>
        /// <param name="npcObjects"></param>
        /// <returns></returns>
        public static string ListAllNpcObjects(IEnumerable<Npc> npcObjects)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "NPC Objects\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) +
                "Black Forest Time Location Id".PadRight(10) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) +
                "----------------------".PadRight(10) + "\n";

            //
            // display all npc objects in rows
            //
            string npcObjectRows = null;
            foreach (Npc npcObject in npcObjects)
            {
                npcObjectRows +=
                    $"{npcObject.Id}".PadRight(10) +
                    $"{npcObject.FirstName}".PadRight(30) +
                    $"{npcObject.BlackForestTimeLocationID}".PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += npcObjectRows;

            return messageBoxText;
        }

        /// <summary>
        /// Choose list of NPC
        /// </summary>
        /// <param name="npcs"></param>
        /// <returns></returns>
        public static string NpcsChooseList(IEnumerable<Npc> npcs)
        {
            //
            // display table name and column headers
            //
            string messageBoxText =
                "NPCs\n" +
                " \n" +

                //
                // display table header
                //
                "ID".PadRight(10) +
                "Name".PadRight(30) + "\n" +
                "---".PadRight(10) +
                "----------------------".PadRight(30) + "\n";

            //
            // display all NPCs in rows
            //
            string npcRows = null;
            foreach (Npc npc in npcs)
            {
                npcRows +=
                    $"{npc.Id}".PadRight(10) +
                    $"{npc.FirstName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += npcRows;

            return messageBoxText;
        }


        #endregion

        /// <summary>
        /// Status box tex
        /// </summary>
        /// <param name="trainee"></param>
        /// <param name="blackForest"></param>
        /// <returns></returns>
        public static List<string> StatusBox(Trainee trainee, BlackForest blackForest)
        {
            List<string> statusBoxText = new List<string>();

            statusBoxText.Add($"Experience Points: {trainee.ExperiencePoints}\n");
            statusBoxText.Add($"Health: {trainee.Health}\n");
            statusBoxText.Add($"Lives: {trainee.Lives}\n");


            return statusBoxText;
        }
    }
}