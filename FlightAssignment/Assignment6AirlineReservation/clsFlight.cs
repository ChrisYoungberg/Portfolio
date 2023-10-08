using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation

{
    public class clsFlight
    {
        #region Attributes
        /// <summary>
        /// The flight ID
        /// </summary>
        private string sID;
        /// <summary>
        /// The flights Number
        /// </summary>
        private string sNumber;
        /// <summary>
        /// The flights type
        /// </summary>
        private string sType;
        #endregion

        #region Getters Setters
        /// <summary>
        /// ID getter and setter 
        /// </summary>
        public string ID
        {
            get { return sID; }
            set { sID = value; }
        }
        /// <summary>
        /// number getter and setter 
        /// </summary>
        public string Number
        {
            get { return sNumber; }
            set { sNumber = value; }
        }
        /// <summary>
        /// type getter and setter 
        /// </summary>
        public string Type
        {
            get { return sType; }
            set { sType = value; }
        }
        #endregion
        /// <summary>
        /// Overrides the to string method
        /// </summary>
        /// <returns>the flight number - the flight type</returns>
        public override string ToString()
        {
            return sID;
        }
    }
}