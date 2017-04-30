using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Trainee : Character
    {
        #region ENUMERABLES
        public enum LanguageType
        {
            None,
            English,
            Spanish,
            Japanese,
            German,
            French,
            Portuguese
        }

        #endregion

        #region FIELDS

        private string _lastName;
        private LanguageType _language;
        private int _experiencePoints;
        private int _health;
        private int _lives;
        private List<int> _forestTimeLocationVisited;
        private List<TraineeObject> _traineeInventory;

        #endregion


        #region PROPERTIES

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public LanguageType Language
        {
            get { return _language; }
            set { _language = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public List<int> ForestTimeLocationsVisited
        {
            get { return _forestTimeLocationVisited; }
            set { _forestTimeLocationVisited = value; }
        }

        public List<TraineeObject> TraineeInventory
        {
            get { return _traineeInventory; }
            set { _traineeInventory = value; }
        }

        #endregion


        #region CONSTRUCTORS

        public Trainee()
        {
            _forestTimeLocationVisited = new List<int>();
            _traineeInventory = new List<TraineeObject>();
        }

        public Trainee(string lastname, RaceType race, int forestTimeLocationID) : base(lastname, race, forestTimeLocationID)
        {
            _forestTimeLocationVisited = new List<int>();
            _traineeInventory = new List<TraineeObject>();
        }

        #endregion


        #region METHODS
        public bool HasVisited(int _forestTimeLocationID)
        {
            if (ForestTimeLocationsVisited.Contains(_forestTimeLocationID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
