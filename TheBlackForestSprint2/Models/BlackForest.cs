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
        private List<LessonObject> _lessonObject;

        public List<ForestTimeLocation> ForestTimeLocations
        {
            get { return _forestTimeLocations; }
            set { _forestTimeLocations = value; }
        }

        public List<LessonObject> LessonObject
        {
            get { return _lessonObject; }
            set { _lessonObject = value; }
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
            _lessonObject = BlackForestObjects.lessonObject;
        }

        #endregion

        #region ***** define methods to return game element objects and information *****

        /// <summary>
        /// determine if the Black Forest-Time Location Id is valid
        /// </summary>
        /// <param name="forestTimeLocationId">true if Black Forest-Time Location exists</param>
        /// <returns></returns>
        public bool IsValidForestTimeLocationId(int forestTImeLocationId)
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
        /// determine if a location is accessible to the player
        /// </summary>
        /// <param name="forestTimeLocationId"></param>
        /// <returns>accessible</returns>
        public bool IsAccessibleLocation(int forestTimeLocationId)
        {
            ForestTimeLocation forestTimeLocation = GetForestTimeLocationById(forestTimeLocationId);
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
        public int GetMaxForestTimeLocationId()
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
        public ForestTimeLocation GetForestTimeLocationById(int Id)
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

        public bool IsVaidLessonObjectByLocationId (int lessonObjectId, int currentForestTimeLocation)
        {
            List<int> lessonObjectIds = new List<int>();

            //
            // Create a list of lesson object ids in current space-time location
            //
            foreach (LessonObject lessonObect in _lessonObject)
            {
                if (lessonObect.BlackForestLocationId == currentForestTimeLocation)
                {
                    lessonObjectIds.Add(lessonObect.Id);
                }
            }

            //
            // Determine if the lesson object id is a valid if and return the result
            //
            if (lessonObjectIds.Contains(lessonObjectId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsValidTraineeObjectByLocationId(int traineeObjectId, int currentBlackForestTimeLocation)
        {
            List<int> traineeObjectIds = new List<int>();

            //
            // create a list of trainee object ids in current black forest time location
            //
            foreach (LessonObject lessonObject in _lessonObject)
            {
                if (lessonObject.BlackForestLocationId == currentBlackForestTimeLocation && lessonObject is TraineeObject)
                {
                    traineeObjectIds.Add(lessonObject.Id);
                }

            }

            //
            // determine if the lesson object id is a valid id and return the result
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
        public LessonObject GetLessonObjectById(int Id)
        {
            LessonObject lessonObjectToReturn = null;

            //
            // Run through the game object list and grab the correct one
            //
            foreach (LessonObject lessonObject in _lessonObject)
            {
                if (lessonObject.Id == Id)
                {
                    lessonObjectToReturn = lessonObject;
                }
            }

            //
            // The specified ID was not found in the universe
            // throw and exception
            //
            if (lessonObjectToReturn == null)
            {
                string feedbackMessage = $"The Lesson Object ID {Id} does not exist in the current Black Forest.";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return lessonObjectToReturn;
        }

        public List<LessonObject> GetLessonObjectsByForestTimeLocationId(int forestTimeLocationId)
        {
            List<LessonObject> lessonObjects = new List<LessonObject>();

            //
            // Run through the game object list and grab all that are in the current space-time location
            //
            foreach (LessonObject lessonObject in _lessonObject)
            {
                if (lessonObject.BlackForestLocationId == forestTimeLocationId)
                {
                    lessonObjects.Add(lessonObject);
                }
            }
            return lessonObjects;
        }

        public List<TraineeObject> GetTraineeObjectsByBlackForestTimeLocationId(int blackForestTimeLocationId)
        {
            List<TraineeObject> traineeObjects = new List<TraineeObject>();

            //
            // Run through the object list and grab all that are in the current balck forest time location
            //
            foreach (LessonObject lessonObject in _lessonObject)
            {
                if (lessonObject.BlackForestLocationId == blackForestTimeLocationId && lessonObject is TraineeObject)
                {
                    traineeObjects.Add(lessonObject as TraineeObject);
                }
            }

            return traineeObjects;
        }
        #endregion
    }
}