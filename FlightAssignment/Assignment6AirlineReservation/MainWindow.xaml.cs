using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        clsMainLogic clsLogic;
        wndAddPassenger wndAddPass;
        ObservableCollection<clsPassenger> passengers;
        bool bAddingPass;
        bool bChangeSeat;

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                clsLogic = new clsMainLogic();
                bAddingPass = false;

                cbChooseFlight.ItemsSource = clsLogic.GetFlights();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void cbChooseFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selection = cbChooseFlight.SelectedItem.ToString();
                cbChoosePassenger.IsEnabled = true;
                gPassengerCommands.IsEnabled = true;

                passengers = clsLogic.GetPassengers(selection);
                clsLogic.setFlight(selection);
                cbChoosePassenger.ItemsSource = passengers;

                if (selection == "1")
                {
                    CanvasA380.Visibility = Visibility.Hidden;
                    Canvas767.Visibility = Visibility.Visible;

                    for (int i = 0; i < passengers.Count; i++)
                    {
                        string sSeat = passengers[i].Seat;

                        foreach (Label seat in c767_Seats.Children)
                        {
                            if (seat.Content.Equals(sSeat))
                            {
                                seat.Background = Brushes.Red;
                            }
                        }
                    }
                }
                else
                {
                    Canvas767.Visibility = Visibility.Hidden;
                    CanvasA380.Visibility = Visibility.Visible;

                    for (int i = 0; i < passengers.Count; i++)
                    {
                        string sSeat = passengers[i].Seat;

                        foreach (Label seat in cA380_Seats.Children)
                        {
                            if (seat.Content.Equals(sSeat))
                            {
                                seat.Background = Brushes.Red;
                            }
                        }
                    }
                }

                

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void cmdAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wndAddPass = new wndAddPassenger();
                wndAddPass.ShowDialog();
                SelSeatForAdd();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }

        private void cbChoosePassenger_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string sSel = cbChoosePassenger.SelectedItem.ToString();
                string sID = sSel.Substring(0, 1);
                string sSeat = clsLogic.selectPass(cbChooseFlight.SelectedItem.ToString(), sID);
                setSelectedBox(sSeat);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void SeatClicked(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;

                if (lbl.Background.Equals(Brushes.Green))
                {

                    string sID;
                    sID = clsLogic.SeatSelected(cbChooseFlight.SelectedItem.ToString(), lbl.Content.ToString());

                    foreach (ComboBoxItem pas in cbChoosePassenger.Items)
                    {
                        string sPasID = pas.Content.ToString().Substring(0, 1);

                        if (sPasID.Equals(sID))
                        {
                            pas.IsSelected = true;
                        }
                    }

                    setSelectedBox(lbl.Content.ToString());
                }

                if (lbl.Background.Equals(Brushes.Blue) && bAddingPass)
                {
                    clsLogic.AddLink(lbl.Content.ToString());
                    passengers = clsLogic.GetPassengers();
                    cbChoosePassenger.ItemsSource = passengers;
                    PassAndLinkAdded();
                    bAddingPass = false;
                }

                if (lbl.Background.Equals(Brushes.Blue) && bChangeSeat)
                {
                    clsLogic.ChangeSeat(lbl.Content.ToString());
                    bChangeSeat = false;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void setSelectedBox(string sel)
        {
            try
            {
                lblPassengersSeatNumber.Content = sel;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void SelSeatForAdd()
        {
            try
            {
                cmdChangeSeat.IsEnabled = false;
                cmdAddPassenger.IsEnabled = false;
                cmdDeletePassenger.IsEnabled = false;
                bAddingPass = true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void PassAndLinkAdded()
        {
            try
            {
                cmdChangeSeat.IsEnabled = true;
                cmdAddPassenger.IsEnabled = true;
                cmdDeletePassenger.IsEnabled = true;
                gbPassengerInformation.IsEnabled = true;
                gPassengerCommands.IsEnabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private void cmdDeletePassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clsLogic.DeletePassenger();
                clsLogic.GetPassengers();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void cmdChangeSeat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gbPassengerInformation.IsEnabled = false;
                gPassengerCommands.IsEnabled = false;
                bChangeSeat = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
    }
}
