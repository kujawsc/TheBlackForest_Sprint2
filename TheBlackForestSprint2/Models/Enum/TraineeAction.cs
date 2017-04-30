using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
    public enum TraineeAction
    { 
        None,
        MissionSetup,
        LookAround,
        Travel,

        TraineeMenu,
        TraineeInfo,
        TraineeInventory,
        TraineeLocationVisited,

        ObjectMenu,
        LookAt,
        PickUp,
        PutDown,

        NonplayerCharacterMenu,
        TalkTo,

        AdminMenu,
        ListOfBlackForestLocations,
        ListForestObjects,
        ListNonplayerTrainee,

        ReturnToMainMenu,
        Exit
    }
}
