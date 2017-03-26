using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlackForest
{
    /// <summary>
    /// class for the game map locations
    /// </summary>
    public class ForestTimeLocation
    {
        #region FIELDS

        private string _commonName;
        private int _blackForestLocationID;
        private int _forestDate;
        private string _forestLocation;
        private string _description;
        private string _generalContents;
        private bool _accessable;
        private int _experiencePoints;

        #endregion

        #region PROPERTIES

        public string CommonName
        {
            get { return _commonName; }
            set { _commonName = value; }
        }

        public int BlackForestLocationID
        {
            get { return _blackForestLocationID; }
            set { _blackForestLocationID = value; }
        }

        public int ForestDate
        {
            get { return _forestDate; }
            set { _forestDate = value; }
        }

        public string ForestLocation
        {
            get { return _forestLocation; }
            set { _forestLocation = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string GeneralContents
        {
            get { return _generalContents; }
            set { _generalContents = value; }
        }

        public bool Accessable
        {
            get { return _accessable; }
            set { _accessable = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        #endregion

        #region CONSTRUCTORS



        #endregion


        #region METHODS



        #endregion


    }
}
