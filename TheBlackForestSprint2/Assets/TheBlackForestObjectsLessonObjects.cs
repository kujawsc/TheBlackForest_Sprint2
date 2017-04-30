using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
    public static partial class BlackForestObjects
    {
        public static List<ForestObjects> forestObjects = new List<ForestObjects>()
        {
            new TraineeObject
            {
                Id = 1,
                Name = "Bag of  Protain",
                BlackForestLocationId = 2,
                Description = "A small leather pouch filled with meat that will increase your energy level.",
                ExperiencePoints = 10,
                Type = TraineeObjectType.Food,
                Value = 45,
                CanInventory = true,
                IsPoisonous = false,
                IsConsumable = true,
                IsVisible = true,
                HealthPoints = 50,
            },

            new TraineeObject
            {
                Id = 2,
                Name = "Daily Lessons",
                BlackForestLocationId = 3,
                Description = "This will be your next lesson that you will need to complete to pass your next level.",
                ExperiencePoints = 20,
                Type = TraineeObjectType.Lessons,
                Value = 45,
                CanInventory = true,
                IsPoisonous = false,
                IsConsumable = true,
                IsVisible = true,
                HealthPoints = 50,
            },

            new TraineeObject
            {
                Id = 3,
                Name = "Rotogenic Medicine",
                BlackForestLocationId = 3,
                Description = "A metal box containing a small vial filled with a red liquid that will heal you wondes.",
                ExperiencePoints = 2450,
                Type = TraineeObjectType.Medicine,
                Value = 45,
                CanInventory = true,
                IsPoisonous = false,
                IsConsumable = true,
                IsVisible = true,
                HealthPoints = 100,
            },

            new TraineeObject
            {
                Id = 4,
                Name = "Location Documents 1",
                BlackForestLocationId = 3,
                Description =
                    "Memo: Crystal Base" + "/n" +
                    "Forest Number Section: 378598" + "/n" +
                    "It appears like the Base sheild is runing 100%. The weather will be middle heat and a cold night./" +
                    ".",
                ExperiencePoints = 30,
                Type = TraineeObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsPoisonous = false,
                IsConsumable = true,
                IsVisible = true,
                HealthPoints = 0,
            },

            new TraineeObject
            {
                Id = 5,
                Name = "Magic Spell",
                BlackForestLocationId = 2,
                Description = "This is a spell that you can us to protect yourself or gain information on what is coming to you next.",
               ExperiencePoints = 56,
                Type = TraineeObjectType.MagicSpells,
                Value = 45,
                CanInventory = true,
                IsPoisonous = false,
                IsConsumable = true,
                IsVisible = true,
                HealthPoints = -100,
            },

            new TraineeObject
            {
                Id = 6,
                Name = "Water Pack",
                BlackForestLocationId = 3,
                Description ="This will lower you hunger and help you keep you alive through out the quest.",
                ExperiencePoints = 5,
                Type = TraineeObjectType.Water,
                Value = 0,
                CanInventory = true,
                IsPoisonous = false,
                IsConsumable = true,
                IsVisible = true,
                HealthPoints = 50,
            },

             new TraineeObject
            {
                Id = 7,
                Name = "Herblore",
                BlackForestLocationId = 3,
                Description ="Skill that allows players to make their own potions that serve various uses",
                ExperiencePoints = 70,
                Type = TraineeObjectType.Medicine,
                Value = 0,
                CanInventory = true,
                IsPoisonous = false,
                IsConsumable = true,
                IsVisible = true,
                HealthPoints = -50,
            },

              new TraineeObject
            {
                Id = 8,
                Name = "Tasks",
                BlackForestLocationId = 0,
                Description ="This are random  small challenges that players may complete in order to earn rewards.",
                ExperiencePoints = 50,
                Type = TraineeObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsPoisonous = false,
                IsConsumable = true,
                IsVisible = true,
                HealthPoints = 50,
            },

               new TraineeObject
            {
                Id = 9,
                Name = "Defence",
                BlackForestLocationId = 0,
                Description ="This is one of the primary combat skills that grants players protection in all forms of combat.",
                ExperiencePoints = 30,
                Type = TraineeObjectType.Skills,
                Value = 0,
                CanInventory = true,
                IsPoisonous = false,
                IsConsumable = true,
                IsVisible = true,
                HealthPoints = -50,
            },
 
                 new BlackForestTimeLocationObjects
            {
                Id = 5,
                Name = "Boldendorian Chest",
               BlackForestLocationId = 2,
                Description = "A large wooden chest adorned with potions.",
                IsDeadly = true,
                IsPoisonous = true,
                HealthPoints = -80
            },
               
            new BlackForestTimeLocationObjects
            {
                Id = 6,
                Name = "Silver Mirror",
                BlackForestLocationId = 2,
                Description = "A small silver mirror hanging on the wall next to a small window.",
                IsDeadly = true,
                IsPoisonous = true,
                HealthPoints = -80
            },
        };
    }
}
