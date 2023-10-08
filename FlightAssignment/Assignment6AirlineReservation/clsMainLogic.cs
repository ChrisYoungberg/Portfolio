using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{ 
    public class clsMainLogic
    {
        private clsDataAccess clsData;
        private clsMainSQL clsSQL;
        private clsFlight Flight;
        public ObservableCollection<clsFlight> flights;
        public ObservableCollection<clsPassenger> passengers;
        private string sSelPassID;
        private string sSelFlightID;
        private string sFNameTemp;
        private string sLNameTemp;

        public clsMainLogic()
        {
            try
            {
                clsData = new clsDataAccess();
                clsSQL = new clsMainSQL();
                flights = new ObservableCollection<clsFlight>();
                passengers = new ObservableCollection<clsPassenger>();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public ObservableCollection<clsFlight> GetFlights()
        {
            try
            {
                DataSet ds = new DataSet();
                int iRet = 0;
                clsData = new clsDataAccess();

                try
                {
                    ds = clsData.ExecuteSQLStatement(clsSQL.GetFlights(), ref iRet);
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }

                for (int i = 0; i < iRet; i++)
                {
                    Flight = new clsFlight();
                    Flight.ID = ds.Tables[0].Rows[i][0].ToString();
                    Flight.Number = ds.Tables[0].Rows[i][1].ToString();
                    Flight.Type = ds.Tables[0].Rows[i][2].ToString();

                    flights.Add(Flight);
                }

                return flights;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public ObservableCollection<clsPassenger> GetPassengers(string sel)
        {
            try
            {
                int iRet = 0;
                DataSet ds = new DataSet();
                clsPassenger Passenger;
                passengers.Clear();

                try
                {
                    ds = clsData.ExecuteSQLStatement(clsSQL.GetPassengers(sel), ref iRet);
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }

                for (int i = 0; i < iRet; i++)
                {
                    Passenger = new clsPassenger();
                    Passenger.ID = ds.Tables[0].Rows[i][0].ToString();
                    Passenger.FirstName = ds.Tables[0].Rows[i]["First_Name"].ToString();
                    Passenger.LastName = ds.Tables[0].Rows[i]["Last_Name"].ToString();
                    Passenger.Flight = ds.Tables[0].Rows[i][3].ToString();
                    Passenger.Seat = ds.Tables[0].Rows[i][4].ToString();

                    passengers.Add(Passenger);
                }

                return passengers;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public ObservableCollection<clsPassenger> GetPassengers()
        {
            try
            {
                int iRet = 0;
                DataSet ds = new DataSet();
                clsPassenger Passenger;
                passengers.Clear();

                try
                {
                    ds = clsData.ExecuteSQLStatement(clsSQL.GetPassengers(sSelFlightID), ref iRet);
                }
                catch (Exception ex)
                {
                    throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
                }

                for (int i = 0; i < iRet; i++)
                {
                    Passenger = new clsPassenger();
                    Passenger.ID = ds.Tables[0].Rows[i][0].ToString();
                    Passenger.FirstName = ds.Tables[0].Rows[i]["First_Name"].ToString();
                    Passenger.LastName = ds.Tables[0].Rows[i]["Last_Name"].ToString();
                    Passenger.Flight = ds.Tables[0].Rows[i][3].ToString();
                    Passenger.Seat = ds.Tables[0].Rows[i][4].ToString();

                    passengers.Add(Passenger);
                }

                return passengers;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public string selectPass(string flight, string ID)
        {
            try
            {
                sSelPassID = ID;

                string sRet;
                sRet = clsData.ExecuteScalarSQL(clsSQL.GetPassSeat(flight, ID));

                return sRet;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public string SeatSelected(string Flight, string seat)
        {
            try
            {
                string sRet;
                sRet = clsData.ExecuteScalarSQL(clsSQL.GetPassID(Flight, seat));

                sSelPassID = sRet;

                return sSelPassID;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public void setFlight(string ID)
        {
            try
            {
                sSelFlightID = ID;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public void AddPass(string fname, string lname)
        {
            try
            {
                int iRet;
                iRet = clsData.ExecuteNonQuery(clsSQL.AddPass(fname, lname));
                sFNameTemp = fname;
                sLNameTemp = lname;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public void AddLink(string seat)
        {
            try
            {
                string sID = clsData.ExecuteScalarSQL(clsSQL.GetPassIDPass(sFNameTemp, sLNameTemp));
                int iRet;
                iRet = clsData.ExecuteNonQuery(clsSQL.AddLink(sSelFlightID, sID, seat));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public void DeletePassenger()
        {
            int iRet;
            try
            {
                iRet = clsData.ExecuteNonQuery(clsSQL.DeleteLink(sSelFlightID, sSelPassID));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            try
            {
                iRet = clsData.ExecuteNonQuery(clsSQL.DeletePassenger(sSelPassID));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public void ChangeSeat(string newseat)
        {
            try
            {
                int iRet;
                iRet = clsData.ExecuteNonQuery(clsSQL.ChangeSeat(newseat, sSelFlightID, sSelPassID));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}