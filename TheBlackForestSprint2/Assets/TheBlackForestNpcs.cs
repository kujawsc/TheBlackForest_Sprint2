using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
    /// <summary>
    /// Static class to hold all npc objects
    /// </summary>
    public static partial class BlackForestObjects
    {
        public static List<Npc> Npcs = new List<Npc>()
        {
            new BFCivilian
            {
                 Id = 1,
                FirstName = "Leo (The Talking Tree)",
                BlackForestTimeLocationID = 2,
                Description = "The oldes tree in the Black Forest - he knows and sees everything.",
                Messages = new List<string>
                {
                    "Greetings trainee. I can see that you are ready for this unproditebal forest.",
                    "I will be the one that will relize the next lessons that are giveing my the gods.",
                    "I have seeing many of you fail and go insane in this forest. Just be sure to watch out for the witches ."
                },
                IsVisible = true,
                Language = Trainee.LanguageType.German,
            },

            new BFCivilian
            {
                Id = 2,
                FirstName = "The Looking Mirror",
                BlackForestTimeLocationID = 1,
                Description = "This mirror connects the trainee to the outside world or it can be a watchful eye for the godess.",
                Messages = new List<string>
                {
                    "....",
                    "I can let you see, but you need to learn how I work.",
                    "The gods are intersted people...making you train to protect one of their kids."
                },
                IsVisible = true,
                Language = Trainee.LanguageType.German,
            },

            new BFCivilian
            {
                Id = 3,
                FirstName = "Syfire Portal",
                BlackForestTimeLocationID = 2,
                Description = "This portal will take you back home, this is located on the south side of Crystal Base.",
                Messages = new List<string>
                {
                    "I am so sorry, but you need to finish you lessons before I can take you home.",
                },
                IsVisible = true,
                Language = Trainee.LanguageType.Spanish,

            },

             new BFCivilian
            {
                Id = 4,
                FirstName = "The Gardner",
                BlackForestTimeLocationID = 6,
                Description = "This is the man that takes care of The Black Rose Gardens.",
                Messages = new List<string>
                {
                    "Oh here we go again. Newbies are just the worse",
                    "I will recommend to not touch any of the roses...they will eat you.",
                    "Your lesson here is to make sure to talk to the only red roses in this garden. I want to say good luck, but that never works.",
                    "I have been looking over this roses for a ling time. I wish sometimes they can eat me so I can never takecare of them!"

                },
                IsVisible = true,
                Language = Trainee.LanguageType.Portuguese,

            },

              new BFCivilian
            {
                Id = 5,
                FirstName = "Mrs. White the Witch ",
                BlackForestTimeLocationID = 6,
                Description = "Mrs. White is the main office manager of the The Wiches Headquarters.",
                Messages = new List<string>
                {
                    "Oh dear! We have a newbie... I sorry, I wanted to say welcome",
                    "I will need you to understand the rules when you are in the headquarters because if you don't you will find yourself in trouble.",
                },
                IsVisible = true,
                Language = Trainee.LanguageType.German,
            },

               new BFCivilian
            {
                Id = 6,
                FirstName = "Mr. Door",
                BlackForestTimeLocationID = 6,
                Description = "This is a unique door that will open the The Doors location.",
                Messages = new List<string>
                {
                    "You want to hear a joke....I am a door that can talk!",
                    "I am Mr. Door that can open The Doors location hehe, you get! I am Mr. Door that can of more doors!",
                },
                IsVisible = true,
                Language = Trainee.LanguageType.English,

            },
        };
    }
}
