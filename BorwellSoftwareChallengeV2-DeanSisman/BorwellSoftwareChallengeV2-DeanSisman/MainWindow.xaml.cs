using System;
using System.Collections.Generic;
using System.Linq;
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

namespace BorwellSoftwareChallengeV2_DeanSisman
{
    /// <summary>
    /// Takes input from GUI, creates instance of Room using inputted values, then prints results to GUI
    /// </summary>
    public partial class MainWindow : Window
    {
        // Reference to the room, which stores all relevant data (width, height, length, area, volume, paint req)
        private Room room;

        public MainWindow()
        {
            InitializeComponent();
        }

        // The main method which the logic runs off:
        // 1 - Calls methods to get values for width, length and height
        // 2 - Calls method to check for invalid inputs
        // 3 - Creates instance of Room using inputted values
        // 4 - Calls method to print room area, volume and paint req to console
        private void btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            float width = GetWidth();
            float length = GetLength();
            float height = GetHeight();

            if (!CheckForBadInput(width, length, height))
            {
                room = new Room(width, length, height);
                PrintResults(room);
            }
        }


        // Returns the text entered into Width by the user as a float, returns 0 if invalid input given
        private float GetWidth()
        {
            float w;
            if (float.TryParse(Width.Text, out w))
            {
                return w;
            }
            else
            {
                return 0f;
            }
        }

        // Returns the text entered into Length by the user as a float, returns 0 if invalid input given
        private float GetLength()
        {
            float l;
            if (float.TryParse(Length.Text, out l))
            {
                return l;
            }
            else
            {
                return 0f;
            }
        }

        // Returns the text entered into Height by the user as a float, returns 0 if invalid input given
        private float GetHeight()
        {
            float h;
            if (float.TryParse(Height.Text, out h))
            {
                return h;
            }
            else
            {
                return 0f;
            }
        }

        // Checks if all inputs are valid numbers between 1 and 1000 and if there is an error returns true 
        // and displays error messages in results boxes (max value based off Boeing factory)
        private bool CheckForBadInput(float w, float l, float h)
        {
            if (w >= 1 && l >= 1 && h >= 1 &&
                w <= 1000 && l <= 1000 && h <= 1000)
            {
                return false;
            }
            else
            {
                Area.Text = "Error!";
                Volume.Text = "Error!";
                PaintReq.Text = "Error!";
                return true;
            }
        }

        // Prints the calculated values from the Room object to the GUI
        private void PrintResults(Room room)
        {
            Area.Text = $"{room.Area.ToString()}m²";
            Volume.Text = $"{room.Volume.ToString()}m³";
            PaintReq.Text = $"{room.PaintReq.ToString()}l";
        }
    }
}
