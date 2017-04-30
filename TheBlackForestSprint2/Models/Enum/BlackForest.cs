using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
    /// <summary>
    /// class of the game map
    /// </summary>
    public class BlackForest
    {
        #region ***** define all lists to be maintained by the Black Forest object *****

        //
        // List of all baclforest time location, game, and NPC objects
        //
        private List<ForestTimeLocation> _forestTimeLocations;
        private List<ForestObjects> _forestObjects;
        private List<Npc> _npcs;

        public List<ForestTimeLocation> ForestTimeLocations
        {
            get { return _forestTimeLocations; }
            set { _forestTimeLocations = value; }
        }

        public List<ForestObjects> ForestObjects
        {
            get { return _forestObjects; }
            set { _forestObjects = value; }
        }

        public List<Npc> Npcs
        {
            get { return _npcs; }
            set { _npcs = value; }
        }

        #endregion

        #region ***** constructor *****

        //
        // default Black Forest constructor
        //
        public BlackForest()
        {
            //
            // add all of the forest objects to the game
            // 
            IntializeBlackForest();
        }

        #endregion

        #region ***** define methods to initialize all game elements *****

        /// <summary>
        /// initialize the black forest with all of the Black forest-time locations
        /// </summary>
        private void IntializeBlackForest()
        {
            _forestTimeLocations = BlackForestObjects.ForestTimeLocation;
            _forestObjects = BlackForestObjects.forestObjects;
            _npcs = BlackForestObjects.Npcs;
        }

        #endregion

        #region ***** define methods to return game element objects and information *****

        /// <summary>
        /// determine if the Black Forest-Time Location Id is valid
        /// </summary>
        /// <param name="forestTimeLocationId">true if Black Forest-Time Location exists</param>
        /// <returns></returns>
        public bool IsValidBlackForestTimeLocationId(int forestTImeLocationId)
        {
            List<int> forestTimeLocationsIds = new List<int>();

            //
            //create a list of Black Forest-Time Location ids
            //
            foreach (ForestTimeLocation stl in _forestTimeLocations)
            {
                forestTimeLocationsIds.Add(stl.BlackForestLocationID);
            }

            //
            //determine if the Black Forest-Time Location id is a valid id and return the result
            //
            if (forestTimeLocationsIds.Contains(forestTImeLocationId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// validate traveler object id number in current location
        /// </summary>
        /// <param name="travelerObjectId"></param>
        /// <returns>is Id valid</returns>
        public bool IsValidForestObjectByLocationId(int forestObjectId, int currentBlackForestTimeLocation)
        {
            List<int> forestObjectIds = new List<int>();

            //
            // create a list of traveler object ids in current space-time location
            //
            foreach (ForestObjects forestObject in _forestObjects)
            {
                if (forestObject.BlackForestLocationId == currentBlackForestTimeLocation && forestObject is TraineeObject)
                {
                    forestObjectIds.Add(forestObject.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (forestObjectIds.Contains(forestObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// validate traveler object id number in current location
        /// </summary>
        /// <param name="travelerObjectId"></param>
        /// <returns>is Id valid</returns>
        public bool IsValidTraineeObjectByLocationId(int traineeObjectId, int currentBlackForestTimeLocation)
        {
            List<int> traineeObjectIds = new List<int>();

            //
            // create a list of traveler object ids in current space-time location
            //
            foreach (ForestObjects forestObject in _forestObjects)
            {
                if (forestObject.BlackForestLocationId == currentBlackForestTimeLocation && forestObject is TraineeObject)
                {
                    traineeObjectIds.Add(forestObject.Id);
                }

            }

            //
            // determine if the game object id is a valid id and return the result
            //
            if (traineeObjectIds.Contains(traineeObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// determine if a location is accessible to the player
        /// </summary>
        /// <param name="forestTimeLocationId"></param>
        /// <returns>accessible</returns>
        public bool IsAccessibleLocation(int forestTimeLocationId)
        {
            ForestTimeLocation forestTimeLocation = GetBlackForestTimeLocationById(forestTimeLocationId);
            if (forestTimeLocation.Accessable == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        ///<summary>
        /// Validate NPC objects id number in current location
        /// </summary>
        /// <returns> is Id valid</returns>
        public bool IsValidNpcByLocationId(int npcsId, int currentBlackForestTimeLocation)
        {
            List<int> npcIds = new List<int>();

            //
            // Create a list of NPC ids in current black forest time location
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.BlackForestTimeLocationID == currentBlackForestTimeLocation)
                {
                    npcIds.Add(npc.Id);
                }
            }

            //
            // Determine of the game object id is a valid id and return the result
            //
            if (npcIds.Contains(npcsId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// return the next available ID for a Black Forest-Time Location object
        /// </summary>
        /// <returns>next Black Forest-Time LocationObjectID </returns>
        public int GetMaxBlackForestTimeLocationId()
        {
            int MaxId = 0;

            foreach (ForestTimeLocation forestTimeLocation in _forestTimeLocations)
            {
                if (forestTimeLocation.BlackForestLocationID > MaxId)
                {
                    MaxId = forestTimeLocation.BlackForestLocationID;
                }
            }

            return MaxId;
        }

        /// <summary>
        /// get a Black Forest-Time Location object using an Id
        /// </summary>
        /// <param name="Id">Black Forest-Time Location ID</param>
        /// <returns>requested Black Forest-Time Location</returns>
        public ForestTimeLocation GetBlackForestTimeLocationById(int Id)
        {
            ForestTimeLocation forestTimeLocation = null;

            //
            // run through the Black Forest-Time Location list and grab the correct one
            //
            foreach (ForestTimeLocation location in _forestTimeLocations)
            {
                if (location.BlackForestLocationID == Id)
                {
                    forestTimeLocation = location;
                }
            }

            //
            // The specified ID was not found in the Black Forest
            // throw and exception
            //
            if (forestTimeLocation == null)
            {
                string feedbackMessage = $"The Black Forest Time Location ID {Id} does not exist in the current Black Forest.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }
            return forestTimeLocation;
        }

        /// <summary>
        /// return the maximum ID for a GameObject object
        /// </summary>
        /// <returns>max GameObjectID </returns>
        public int GetMaxForestObjectId()
        {
            int MaxId = 0;

            foreach (ForestObjects forestObject in _forestObjects)
            {
                if (forestObject.Id > MaxId)
                {
                    MaxId = forestObject.Id;
                }
            }

            return MaxId;
        }

        /// <summary>
        /// get a game object using an Id
        /// </summary>
        /// <param name="Id">game object Id</param>
        /// <returns>requested game object</returns>
        public ForestObjects GetForestObjectById(int Id)
        {
            ForestObjects forestObjectToReturn = null;

            //
            // run through the game object list and grab the correct one
            //
            foreach (ForestObjects forestObject in _forestObjects)
            {
                if (forestObject.Id == Id)
                {
                    forestObjectToReturn = forestObject;
                }
            }

            //
            // the specified ID was not found in the universe
            // throw and exception
            //
            if (forestObjectToReturn == null)
            {
                string feedbackMessage = $"The Forest Object ID {Id} does not exist in the current Universe.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return forestObjectToReturn;
        }

        /// <summary>
        /// Get a Npc object using an Id
        /// </summary>
        /// <param name="Id">game object Id</param>
        /// <returns>requested game object</returns>
        public Npc GetNpcById (int Id)
        {
            Npc npcToReturn = null;

            //
            // Run through the NPC objects list and grab the correct one
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.Id == Id)
                {
                    npcToReturn = npc;
                }
            }

            //
            // The speciafied ID was not found in the black forest
            // Throw and exception
            //
            if (npcToReturn == null)
            {
                string feebackMessage = $"The NPC ID {Id} does not exist in the current Universe.";
                throw new ArgumentException(Id.ToString(), feebackMessage);
            }

            return npcToReturn;
        }

        /// <summary>
        ///  Get all the forest object in a location
        /// </summary>
        /// <param name="balckForestTimeLocationId"></param>
        /// <returns></returns>
        public List<ForestObjects> GetForestObjectsByBlackForestTimeLocationId(int balckForestTimeLocationId)
        {
            List<ForestObjects> forestObjects = new List<ForestObjects>();

            //
            // run through the game object list and grab all that are in the current space-time location
            //
            foreach (ForestObjects forestObject in _forestObjects)
            {
                if (forestObject.BlackForestLocationId == balckForestTimeLocationId)
                {
                    forestObjects.Add(forestObject);
                }
            }

            return forestObjects;
        }

        /// <summary>
        /// Get all trainee objects in a location
        /// </summary>
        /// <param name="blackForestTimeLocationId"></param>
        /// <returns></returns>
        public List<TraineeObject> GetTraineeObjectsByBlackForestTimeLocationId(int blackForestTimeLocationId)
        {
            List<TraineeObject> traineeObjects = new List<TraineeObject>();

            //
            // Run through the object list and grab all that are in the current balck forest time location
            //
            foreach (ForestObjects forestObjects in _forestObjects)
            {
                if (forestObjects.BlackForestLocationId == blackForestTimeLocationId && forestObjects is TraineeObject)
                {
                    traineeObjects.Add(forestObjects as TraineeObject);
                }
            }

            return traineeObjects;
        }

        /// <summary>
        /// Get all NPC balc forest objecy in a location
        /// </summary>
        /// <param name="blackForestTimeLocationId"></param>
        /// <returns></returns>
        public List<Npc> GetNpcsByBlackForestLocationId(int blackForestTimeLocationId)
        {
            List<Npc> npcs = new List<Npc>();

            //
            // Run through the NPC object list and grab all that are in the current black forest time location
            //
            foreach (Npc npc in _npcs)
            {
                if (npc.BlackForestTimeLocationID == blackForestTimeLocationId)
                {
                    npcs.Add(npc);
                }
            }

            return npcs;
        }

        public void UpdateGameObjectLocationID(int forestObjectID, int newLocationId)
        {
            ForestObjects forestObjectToUpdate;
            forestObjectToUpdate = GetForestObjectById(forestObjectID);
            forestObjectToUpdate.BlackForestLocationId = newLocationId;
        }

        /// <summary>
        /// resets the forest objects to their starting locations for resetting the game
        /// </summary>
        public void ResetGameObjectsAll()
        {
            UpdateGameObjectLocationID(1, 1);
            UpdateGameObjectLocationID(2, 2);
            UpdateGameObjectLocationID(3, 8);
            UpdateGameObjectLocationID(4, 5);
            UpdateGameObjectLocationID(5, 3);
            UpdateGameObjectLocationID(6, 1);
            UpdateGameObjectLocationID(7, 3);
        }

        public void UpdateBalckForestLocationAccessible(int blackForestLocationId, bool accessible)
        {
            ForestTimeLocation blackForestLocationToUpdate;
            blackForestLocationToUpdate = GetBlackForestTimeLocationById(blackForestLocationId);
            blackForestLocationToUpdate.Accessable = accessible;
        }

        /// <summary>
        /// resets the castle locations to their starting accessibility for resetting the game
        /// </summary>
        public void LocationAccessResetToGameStartAll()
        {
            UpdateBalckForestLocationAccessible(1, true);
            UpdateBalckForestLocationAccessible(2, true);
            UpdateBalckForestLocationAccessible(3, true);
            UpdateBalckForestLocationAccessible(4, true);
            UpdateBalckForestLocationAccessible(5, false);
            UpdateBalckForestLocationAccessible(6, false);
            UpdateBalckForestLocationAccessible(7, false);
            UpdateBalckForestLocationAccessible(8, false);
        }

        /// <summary>
        /// unlock all rooms
        /// </summary>
        public void LocationAccessUnlockAll()
        {
            UpdateBalckForestLocationAccessible(1, true);
            UpdateBalckForestLocationAccessible(2, true);
            UpdateBalckForestLocationAccessible(3, true);
            UpdateBalckForestLocationAccessible(4, true);
            UpdateBalckForestLocationAccessible(5, true);
            UpdateBalckForestLocationAccessible(6, true);
            UpdateBalckForestLocationAccessible(7, true);
            UpdateBalckForestLocationAccessible(8, true);
        }

        #endregion
    }
}