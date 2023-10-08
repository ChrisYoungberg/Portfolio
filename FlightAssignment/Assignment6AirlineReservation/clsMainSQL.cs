using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    public class clsMainSQL
    {
        public string GetFlights()
        {
            try
            {
                return "SELECT Flight_ID, Flight_Number, Aircraft_Type FROM FLIGHT";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        public string GetPassengers(string flight)
        {
            try
            {
                return "SELECT PASSENGER.Passenger_ID, First_Name, Last_Name, FLIGHT.Flight_ID, Seat_Number FROM FLIGHT_PASSENGER_LINK, FLIGHT, PASSENGER WHERE FLIGHT.FLIGHT_ID = FLIGHT_PASSENGER_LINK.FLIGHT_ID AND FLIGHT_PASSENGER_LINK.PASSENGER_ID = PASSENGER.PASSENGER_ID AND FLIGHT.FLIGHT_ID = " + flight;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public string GetPassID(string flight, string seat)
        {
            try
            {
                return "SELECT Passenger_ID FROM FLIGHT_PASSENGER_LINK WHERE Flight_ID = " + flight + " AND Seat_Number = " + seat;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public string GetPassSeat(string flight, string ID)
        {
            try
            {
                return "SELECT Seat_Number FROM FLIGHT_PASSENGER_LINK WHERE Flight_ID = " + flight + " AND Passenger_ID = " + ID;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public string AddPass(string fname, string lname)
        {
            try
            {
                return "INSERT INTO PASSENGER(First_Name, Last_Name) VALUES('" + fname + "', '" + lname + "')";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public string AddLink(string flight, string pas, string seat)
        {
            try
            {
                return "INSERT INTO Flight_Passenger_Link(Flight_ID, Passenger_ID, Seat_Number) VALUES( '" + flight + "' , '" + pas + "' , '" + seat + "')";
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public string DeleteLink(string flight, string pas)
        {
            try
            {
                return "Delete FROM FLIGHT_PASSENGER_LINK WHERE FLIGHT_ID = " + flight + " AND PASSENGER_ID = " + pas;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public string DeletePassenger(string pas)
        {
            try
            {
                return "Delete FROM PASSENGER WHERE PASSENGER_ID = " + pas;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public string ChangeSeat(string newseat, string flight, string pas)
        {
            try
            {
                return "UPDATE FLIGHT_PASSENGER_LINK SET Seat_Number = '" + newseat + "' WHERE FLIGHT_ID = " + flight + " AND PASSENGER_ID = " + pas;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public string GetPassIDPass(string fname, string lname)
        {
            return "SELECT Passenger_ID from Passenger where First_Name = '" + fname + "' AND Last_Name = '" + lname + "'";
        }

    }
}
