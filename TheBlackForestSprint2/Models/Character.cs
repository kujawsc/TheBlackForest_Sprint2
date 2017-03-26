using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum RaceType
        {
            None,
            Human,
            Magician,
            Sorcerer,
            Sorceress,
            BlackWitch,
            WhiteWitch,
            Fairy,
            Angel,
            Demon,
            Undead,
            HalfAnimal,
            Shapeshifter,
            Oracle
        }

        #endregion

        #region FIELDS

        private string _firstName;
        private int _blackForestTimeLocationID;
        private int _age;
        private RaceType _race;

        #endregion

        #region PROPERTIES

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public int BlackForestTimeLocationID
        {
            get { return _blackForestTimeLocationID; }
            set { _blackForestTimeLocationID = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string firstName, RaceType race, int blackForestTimeLocationID)
        {
            _firstName = FirstName;
            _race = race;
            _blackForestTimeLocationID = blackForestTimeLocationID;
        }

        #endregion

        #region METHODS



        #endregion
    }
}

