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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private float length; // Value inputted by user, the length of the room
        private float width;  // Value inputted by user, the width of the room
        private float height; // Value inputted by user, the height of the room

        public MainWindow()
        {
            InitializeComponent();
        }

        // The main method which the logic runs off, does the following:
        // 1 - Calls the methods which get the values for length, width & height, inputted by the user.
        // 2 - Calls the method which checks these values for validity.
        // 3 - Calls the methods which calculate the values for area, volume and paint required & set 
        //     the text boxes to display these values.
        private void btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            width = GetWidth();
            length = GetLength();
            height = GetHeight();

            if (!CheckForBadInput(width, length, height))
            {
                Area.Text = CalculateArea(width, length);
                Volume.Text = CalculateVolume(width, length, height);
                PaintReq.Text = CalculatePaintReq(width, length, height);
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

        // Calculates the area of the room and returns value as string
        private string CalculateArea(float w, float l)
        {
            float a = w * l;
            return a.ToString();
        }

        // Calculates the volume of the room and returns value as string
        private string CalculateVolume(float w, float l, float h)
        {
            float v = w * l * h;
            return v.ToString();
        }

        // Calculates the amount of paint required and returns value as string
        private string CalculatePaintReq(float w, float l, float h)
        {
            float wallArea = (w * h * 2) + (l * h * 2);
            float metresSquaredPerLitre = 10;
            float pr = wallArea / metresSquaredPerLitre;
            return pr.ToString();
        }
    }
}
