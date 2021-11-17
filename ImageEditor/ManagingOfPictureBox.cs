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

        public static event Action ModifiedOfPicture;

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

        private static void ModifiedTrue()
        {
            if(ModifiedOfPicture != null)
            {
                ModifiedOfPicture.Invoke();
            }
        }

        public static void CreateNewGridInPictureBox(int columns, int rows)
        {
            _imageOutputPictureBox.CreateGrid(columns, rows, Color.Black);
            ModifiedTrue();
        }

        public static void ClearGridInPictureBox()
        {
            _imageOutputPictureBox.ClearGrid(Color.White);
            ModifiedTrue();
        }

        public static void MouseMoveInPictureBox(MouseEventArgs mouseEventArgs)
        {
            if (_pressButtonMouse == false)
            {
                _imageOutputPictureBox.CreateCursor(mouseEventArgs.Location, Color.Black, Color.White);
            }
            else
            {
                PressMouseOfButton(mouseEventArgs);
            }
        }

        public static void MouseDownInPictureBox(MouseEventArgs mouseEventArgs)
        {
            PressMouseOfButton(mouseEventArgs);
            
            _pressButtonMouse = true;
        }

        private static void PressMouseOfButton(MouseEventArgs mouseEventArgs)
        {
            if (MouseButtons.Left == mouseEventArgs.Button)
            {
                _imageOutputPictureBox.CreateSquareFillCell(mouseEventArgs.Location, Color.Black, ImageOutput.SaveCell.Save);
                ModifiedTrue();
            }
            else if (MouseButtons.Right == mouseEventArgs.Button)
            {
                _imageOutputPictureBox.CreateSquareFillCell(mouseEventArgs.Location, Color.White, ImageOutput.SaveCell.Remove);
                ModifiedTrue();
            }
        }

        public static void MouseUpInPictureBox(bool mouseUp)
        {
            _pressButtonMouse = mouseUp;
        }

        public static void ChangeSizePictureBox(int columns, int rows, int cellSize)
        {
            const int error = 3;
            const int zero = 0;

            if (_pictureBoxImange == null)
            {
                throw new NullReferenceException();
            }

            if ((columns == zero) | (rows == zero) | (cellSize == zero))
            {
                MessageBox.Show(@"Columns or rows or cellSize in method 'ChangeSizePictureBox' is 0", @"Error!");
            }

            _pictureBoxImange.Width = columns * cellSize + error;
            _pictureBoxImange.Height = rows * cellSize + error;
        }

        public static void ShowPictureBoxInTheCentreGroupBox()
        {
            if(_pictureBoxImange == null)
            {
                throw new NullReferenceException();
            }

            object objectParent = _pictureBoxImange.Parent;
            if (objectParent is GroupBox)
            {
                GroupBox groupBox = objectParent as GroupBox;

                int halfOfWidthGroupBox = groupBox.Width / 2;
                int halfOfHeightGroupBox = groupBox.Height / 2;
                int halfOfWidthPictureBox = _pictureBoxImange.Width / 2;
                int halfOfHeightPictureBox = _pictureBoxImange.Height / 2;
                var point = new Point
                {
                    X = halfOfWidthGroupBox - halfOfWidthPictureBox,
                    Y = halfOfHeightGroupBox - halfOfHeightPictureBox
                };

                _pictureBoxImange.Location = point;
            }
            else
            {
                MessageBox.Show(@"PictureBox isn't inside the GroupBox", @"Error!!!");
            }
        }

        public static void SaveInStack(Point coordinatePoint, Color colorRectangle, ImageOutput.SaveCell saveCell)
        {
            if (ManagingOfButtons.UndoIsPress == false)
            {
                HistoryOfDraw.CreateSquareFillCell(coordinatePoint, colorRectangle, saveCell);
            }
        }
    }
}
