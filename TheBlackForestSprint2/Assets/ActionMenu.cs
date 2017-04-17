using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
    public static class ActionMenu
    { 
    public enum CurrentMenu
    {
        MissionIntro,
        InitializeMission,
        MainMenu,
        AdminMenu
    }

    public static CurrentMenu currentMenu = CurrentMenu.MainMenu;

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
                    {'3', TraineeAction.LookAt },
                    {'4', TraineeAction.PickUp },
                    {'5', TraineeAction.PutDown },
                    {'6', TraineeAction.TraineeInventory },
                    {'7', TraineeAction.Travel},
                    {'8', TraineeAction.TraineeLocationVisited},
                    {'9', TraineeAction.AdminMenu },
                    {'0', TraineeAction.Exit }
                }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, TraineeAction>()
                {
                    { '1', TraineeAction.ListOfBlackForestLocations},
                    { '2', TraineeAction.ListForestObjects},
                    { '0', TraineeAction.ReturnToMainMenu }
                }
        };
    }
}
