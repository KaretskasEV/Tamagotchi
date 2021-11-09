using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    public static class ManagingOfPictureBox
    {
        private static bool _pressButtonMouse;
        private static ImageOutput _imageOutputPictureBox;
        private static PictureBox _pictureBoxImange;

        public static ImageOutput ImageOutputPicture
        {
            set
            {
                if (value != null)
                {
                    _imageOutputPictureBox = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static PictureBox PictureBoxImage
        {
            get => _pictureBoxImange;

            set
            {
                if (value != null)
                {
                    _pictureBoxImange = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static void CreateNewGridInPictureBox(int columns, int rows)
        {
            _imageOutputPictureBox.CreateGrid(columns, rows, Color.Black);
        }

        public static void MouseMoveInPictureBox(MouseEventArgs mouseEventArgs)
        {
            if (_pressButtonMouse == false)
            {
                _imageOutputPictureBox.CreateCursor(mouseEventArgs.Location, Color.Black, Color.White);
            }
            else
            {
                if (MouseButtons.Left == mouseEventArgs.Button)
                {
                    _imageOutputPictureBox.CreateSquareFillCell(mouseEventArgs.Location, Color.Black, ImageOutput.SaveCell.Save);
                }
                else if (MouseButtons.Right == mouseEventArgs.Button)
                {
                    _imageOutputPictureBox.CreateSquareFillCell(mouseEventArgs.Location, Color.White, ImageOutput.SaveCell.Remove);
                }
            }
        }

        public static void MouseDownInPictureBox(MouseEventArgs mouseEventArgs)
        {
            if (MouseButtons.Left == mouseEventArgs.Button)
            {
                _imageOutputPictureBox.CreateSquareFillCell(mouseEventArgs.Location, Color.Black, ImageOutput.SaveCell.Save);
            }
            else if (MouseButtons.Right == mouseEventArgs.Button)
            {
                _imageOutputPictureBox.CreateSquareFillCell(mouseEventArgs.Location, Color.White, ImageOutput.SaveCell.Remove);
            }
            
            _pressButtonMouse = true;
        }

        public static void MouseUpInPictureBox(bool mouseUp)
        {
            _pressButtonMouse = mouseUp;
        }

        public static void ChangeSizePictureBox(PictureBox pictureBox, int columns, int rows, int cellSize)
        {
            const int error = 3;
            const int zero = 0;

            if (pictureBox == null)
            {
                throw new NullReferenceException();
            }

            if ((columns == zero) | (rows == zero) | (cellSize == zero))
            {
                MessageBox.Show(@"Columns or rows or cellSize in method 'ChangeSizePictureBox' is 0", @"Error!");
            }

            pictureBox.Width = columns * cellSize + error;
            pictureBox.Height = rows * cellSize + error;
        }

        public static void ShowPictureBoxInTheCentreGroupBox(PictureBox pictureBox)
        {
            if (pictureBox == null)
            {
                throw new NullReferenceException();
            }

            object objectParent = pictureBox.Parent;
            if (objectParent is GroupBox)
            {
                GroupBox groupBox = objectParent as GroupBox;

                int halfOfWidthGroupBox = groupBox.Width / 2;
                int halfOfHeightGroupBox = groupBox.Height / 2;
                int halfOfWidthPictureBox = pictureBox.Width / 2;
                int halfOfHeightPictureBox = pictureBox.Height / 2;
                var point = new Point
                {
                    X = halfOfWidthGroupBox - halfOfWidthPictureBox,
                    Y = halfOfHeightGroupBox - halfOfHeightPictureBox
                };

                pictureBox.Location = point;
            }
            else
            {
                MessageBox.Show(@"PictureBox isn't inside the GroupBox", @"Error!!!");
            }
        }
    }
}
