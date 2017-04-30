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
        ObjectMenu,
        NpcMenu,
        TraineeMenu,
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
                    {'1', TraineeAction.LookAround },
                    {'2', TraineeAction.Travel},
                    {'3', TraineeAction.ObjectMenu},
                    {'4', TraineeAction.NonplayerCharacterMenu},
                    {'5', TraineeAction.TraineeMenu},
                    {'6', TraineeAction.AdminMenu },
                    {'0', TraineeAction.Exit }
                }
        };

        public static Menu TraineeMenu = new Menu()
        {
            MenuName = "TraineeMenu",
            MenuTitle = "Trainee Menu",
            MenuChoices = new Dictionary<char, TraineeAction>()
            {
                    {'1', TraineeAction.TraineeInfo },
                    {'2', TraineeAction.TraineeInventory},
                    {'3', TraineeAction.TraineeLocationVisited},
                    {'0', TraineeAction.ReturnToMainMenu }
            }
        };

        public static Menu ObjectMenu = new Menu()
        {
            MenuName = "ObjectMenu",
            MenuTitle = "Object Menu",
            MenuChoices = new Dictionary<char, TraineeAction>()
            {
                    {'1', TraineeAction.LookAt},
                    {'2', TraineeAction.PickUp},
                    {'3', TraineeAction.PutDown},
                    {'0', TraineeAction.ReturnToMainMenu }
            }
        };

        public static Menu NpcMenu = new Menu()
        {
            MenuName = "NpcMenu",
            MenuTitle = "NPC Menu",
            MenuChoices = new Dictionary<char, TraineeAction>()
            {
                    {'1', TraineeAction.TalkTo},
                    {'0', TraineeAction.ReturnToMainMenu }
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
                    { '3', TraineeAction.ListNonplayerTrainee },
                    { '0', TraineeAction.ReturnToMainMenu }
                }
        };
    }
}
