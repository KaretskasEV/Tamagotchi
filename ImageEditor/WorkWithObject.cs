using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    public static class WorkWithObject
    {
        public static void ChangeSizePictureBox(PictureBox pictureBox, int columns, int rows, int cellSize)
        {
            const int error = 3;

            pictureBox.Width = columns * cellSize + error;
            pictureBox.Height = rows * cellSize + error;
        }

        public static void ShowPictureBoxInTheCentreGroupBox(PictureBox pictureBox)
        {
            GroupBox groupBox;
            object objectParent = pictureBox.Parent;
            if (objectParent is GroupBox)
            { 
                groupBox = objectParent as GroupBox;
            
                int halfOfWidthGroupBox = groupBox.Width / 2;
                int halfOfHeightGroupBox = groupBox.Height / 2;
                int halfOfWidthPictureBox = pictureBox.Width / 2;
                int halfOfHeightPictureBox = pictureBox.Height / 2;
                Point point = new Point();

                point.X = halfOfWidthGroupBox - halfOfWidthPictureBox;
                point.Y = halfOfHeightGroupBox - halfOfHeightPictureBox;

                pictureBox.Location = point;
            }
            else
            {
                MessageBox.Show(@"PictureBox isn't inside the GroupBox", @"Error!!!");
                return;
            }
        }
    }
}
