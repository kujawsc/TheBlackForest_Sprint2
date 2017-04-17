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
        // list of all forest-time location
        //
        private List<ForestTimeLocation> _forestTimeLocations;
        private List<ForestObjects> _forestObjects;

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

        #endregion
    }
}