using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
    /// <summary>
    /// This is the static class to hold in the game Black Forest.
    /// </summary>
        public static partial class BlackForestObjects
        {
            public static List<ForestTimeLocation> ForestTimeLocation = new List<ForestTimeLocation>()
        {
            new ForestTimeLocation
            {
                CommonName = "Crystal Base",
                BlackForestLocationID = 1,
                ForestDate = 574535,
                ForestLocation = "Unknown",
                Description = "The Crystal Home Base is located in the middle of the Black Forest" +
                "This base will provide the trainee with everything they need to survive in there lesson/quests" +
                "Joanie.\n",
                GeneralContents = "The base has a large tree in the middle of a clear area that is surrounded by the Black Forest."+
                "There is a house that was built in the tree, around the house there is a garden, training area, small patio and a small lake with crystal water." +
                "The base is surrounded by a sheld that will stop any creature to enter the Crytal Base.\n",
                Accessable = true,
                ExperiencePoints = 10
            },

            new ForestTimeLocation
            {
                CommonName = "The Crying Trees",
                BlackForestLocationID = 2,
                ForestDate = 88885,
                ForestLocation = "Somewhere close to the Crystal Base",
                Description = "The Crying Tress is where the oldest trees of The Black Forest go to leave their few year" +
                "they have left. It is a depressing location of the forest that could drive someone insane. The cries of the tree can do this" +
                "but the magical creature here is the one the rules the area.\n",
                GeneralContents ="They are millions of tree in this location, it is dark and it smells of decaying trees. The tree will talk and move"+
                "if they wish to. The creature that lives here is the one controlling the trees with it black magic skill.\n",
                Accessable = true,
                ExperiencePoints = 10
            },

            new ForestTimeLocation
            {
                CommonName = "The Black Rose Gardens",
                BlackForestLocationID = 3,
                ForestDate = 676767,
                ForestLocation = "Unknow",
                Description = "This garden was created by the Queen of Dimon's after her mother death."+
                "This place is taking care by Elf from the far side of The Black Forest. Roses are not the only things that are leaving in here" +
                "but a few other rare magical creature.\n",
                GeneralContents ="The garden is bigger than the Crystal Base, but it changes it design daily. The roses are deathly and poisonous.\n",
                Accessable = true,
                ExperiencePoints = 30
            },

            new ForestTimeLocation
            {
               CommonName = "The Wiches Headquarters",
                BlackForestLocationID = 4,
                ForestDate = 386759,
                ForestLocation = "Faraway from the Crying Trees",
                Description = "The Witches Headquarters is located away from the crying tress because they heat the noise."+
                 "This is where the witches race leaders are posted at. This headquarters doors" +
                  "is open to any race to come and work and visit, but with Lords acceptance.\n",
                GeneralContents =" This is a village with many houses that is in The Black Forest. This Headquarters"+
                "was establish here many centuries by the upper Goddess.\n",
                Accessable = true,
                ExperiencePoints = 20
            },

            new ForestTimeLocation
            {
                CommonName = "The Elf Headquarters",
                BlackForestLocationID = 5,
                ForestDate = 5766,
                ForestLocation = "Away from the Wiches",
                Description = "The Elf Headquarters is located away from the Wiches Headquarters.\n",
                GeneralContents ="Unknow Content.\n",
                Accessable = false,
                ExperiencePoints = 20
            },

            new ForestTimeLocation
            {
                CommonName = "The Crytal Waters",
                BlackForestLocationID = 6,
                ForestDate = 5734857,
                ForestLocation = "Unknow",
                Description = "This is located in a cave the goes underground where the Crytal Water are.\n",
                GeneralContents ="The waters are touch bless by the Gods and Goddess many years ago. The cave"+
                "'are made of diamonds and even gold. But there is a dangers creature leaving here.\n",
                Accessable = false,
                ExperiencePoints = 40
            },

            new ForestTimeLocation
            {
                 CommonName = "The Doors",
                BlackForestLocationID = 7,
                ForestDate = 836393,
                ForestLocation = "Unknow",
                Description = "These doors were made to stop some things, but not sure from where...maybe from the Underworld.\n",
                GeneralContents ="Great place to gain strength and magic skill. The doors releases an energy that heals and give strength.\n",
                Accessable = false,
                ExperiencePoints = 100
            },

            new ForestTimeLocation
            {
                CommonName = "The Black Forest",
                BlackForestLocationID = 8,
                ForestDate = 000000,
                ForestLocation = "Unknow",
                Description = "This is where the wild side of The Black Forest. Where creature don't have rules and rulers, they are wild and unpractical.\n",
                GeneralContents ="The contents is unknow.\n",
                Accessable = false,
                ExperiencePoints = 100
            },
        };
        }
    }
