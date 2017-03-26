using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
        public static class ActionMenu
        {
            public static Menu MissionIntro = new Menu()
            {
                MenuName = "MissionIntro",
                MenuTitle = "",
                MenuChoices = new Dictionary<char, TraineeAction>()
                    {
                        { ' ', TraineeAction.None }
                    }
            };

            public static Menu InitializeMission = new Menu()
            {
                MenuName = "InitializeMission",
                MenuTitle = "Initialize Mission",
                MenuChoices = new Dictionary<char, TraineeAction>()
                {
                    { '1', TraineeAction.Exit }
                }
            };

            public static Menu MainMenu = new Menu()
            {
                MenuName = "MainMenu",
                MenuTitle = "Main Menu",
                MenuChoices = new Dictionary<char, TraineeAction>()
                {
                    { '1', TraineeAction.TraineeInfo },
                    {'2', TraineeAction.LookAround },
                    {'3', TraineeAction.Travel},
                    {'4', TraineeAction.TraineeLocationVisited},
                    {'5', TraineeAction.TraineeInventory },
                    {'6', TraineeAction.ListBlackForestLocations },
                    {'7', TraineeAction.ListItems },
                    { '0', TraineeAction.Exit }
                }
            };
        }
    }
