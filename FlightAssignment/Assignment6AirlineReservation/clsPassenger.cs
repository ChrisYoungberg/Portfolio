using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    public class clsPassenger
    {
        #region Attributes
        /// <summary>
        /// The Passengers ID
        /// </summary>
        private string sID;
        /// <summary>
        /// The Passengers First Name
        /// </summary>
        private string sFirstName;
        /// <summary>
        /// The Passengers Last Name
        /// </summary>
        private string sLastName;
        /// <summary>
        /// The Passengers Seat number
        /// </summary>
        private string sSeat;
        /// <summary>
        /// What flight the passenger is on
        /// </summary>
        private string sFlight;
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
        /// first name  getter and setter 
        /// </summary>
        public string FirstName
        {
            get { return sFirstName; }
            set { sFirstName = value; }

        }
        /// <summary>
        /// last name getter and setter 
        /// </summary>
        public string LastName
        {
            get { return sLastName; }
            set { sLastName = value; }

        }
        /// <summary>
        /// seat getter and setter 
        /// </summary>
        public string Seat
        {
            get { return sSeat; }
            set { sSeat = value; }

        }
        /// <summary>
        /// flight getter and setter 
        /// </summary>
        public string Flight
        {
            get { return sFlight; }
            set { sFlight = value; }

        }
        #endregion
        /// <summary>
        /// override the to string method 
        /// </summary>
        /// <returns>the passengers name</returns>
        public override string ToString()
        {
            return sID + " - " + sFirstName + " " + sLastName;
        }

    }
}
