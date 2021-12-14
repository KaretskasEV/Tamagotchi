using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    sealed public class ManagingOfPictureBox
    {
        private readonly PictureBox _pictureBoxImage;
        private readonly ImageOutput _imageOutput;

        private bool _pressButtonMouse;

        public ManagingOfPictureBox(FormMain formMain)
        {
            try
            {
                if (formMain == null)
                {
                    throw new NullReferenceException("formMain is null.");
                }

                _pictureBoxImage = formMain.PictureBoxImage;
                _imageOutput = formMain.ImageOutput;
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }

        public void ShowAllFillCells(bool[,] arrayCells)
        {
            try
            {
                if(arrayCells == null)
                {
                    throw new NullReferenceException("arrayCells is null.");
                }

                _imageOutput.ShowAllFillCells(Color.Black, arrayCells);
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }

        public void CreateNewGridInPictureBox(int columns, int rows)
        {
            _imageOutput.CreateGrid(columns, rows, Color.Black);
        }

        public void ClearGridInPictureBox()
        {
            _imageOutput.ClearGrid(Color.White);
        }

        public void MouseMoveInPictureBox(MouseEventArgs mouseEventArgs)
        {
            if (_pressButtonMouse == false)
            {
                _imageOutput.CreateCursor(mouseEventArgs.Location, Color.Black, Color.White);
            }
            else
            {
                PressMouseOfButton(mouseEventArgs);
            }
        }

        public void MouseDownInPictureBox(MouseEventArgs mouseEventArgs)
        {
            PressMouseOfButton(mouseEventArgs);
            
            _pressButtonMouse = true;
        }

        private void PressMouseOfButton(MouseEventArgs mouseEventArgs)
        {
            if (MouseButtons.Left == mouseEventArgs.Button)
            {
                _imageOutput.CreateSquareFillCell(mouseEventArgs.Location, Color.Black, ImageOutput.SaveCell.Save);
            }
            else if (MouseButtons.Right == mouseEventArgs.Button)
            {
                _imageOutput.CreateSquareFillCell(mouseEventArgs.Location, Color.White, ImageOutput.SaveCell.Remove);
            }
        }

        public void MouseUpInPictureBox(bool mouseUp)
        {
            _pressButtonMouse = mouseUp;
        }

        public void ChangeSizePictureBox(int columns, int rows, int cellSize)
        {
            const int fault = 3;
            const int zero = 0;

            try
            {
                if (_pictureBoxImage == null)
                {
                    throw new NullReferenceException("_pictureBoxImage is null.");
                }

                if(columns < zero)
                {
                    throw new ArgumentOutOfRangeException("\"Columns\" specified an invalid value.");
                }else if(rows < zero)
                {
                    throw new ArgumentOutOfRangeException("\"Rows\" specified an invalid value.");
                }else if (cellSize < zero)
                {
                    throw new ArgumentOutOfRangeException("\"cellSize\" specified an invalid value.");
                }

                _pictureBoxImage.Width = columns * cellSize + fault;
                _pictureBoxImage.Height = rows * cellSize + fault;
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
            catch (ArgumentOutOfRangeException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }

        public void ShowPictureBoxInTheCentreGroupBox()
        {
            try
            {
                if (_pictureBoxImage == null)
                {
                    throw new NullReferenceException("_pictureBoxImage is null.");
                }

                object objectParent = _pictureBoxImage.Parent;
                if (objectParent is GroupBox)
                {
                    GroupBox groupBox = objectParent as GroupBox;

                    int halfOfWidthGroupBox = groupBox.Width / 2;
                    int halfOfHeightGroupBox = groupBox.Height / 2;
                    int halfOfWidthPictureBox = _pictureBoxImage.Width / 2;
                    int halfOfHeightPictureBox = _pictureBoxImage.Height / 2;
                    var point = new Point
                    {
                        X = halfOfWidthGroupBox - halfOfWidthPictureBox,
                        Y = halfOfHeightGroupBox - halfOfHeightPictureBox
                    };

                    _pictureBoxImage.Location = point;
                }
                else
                {
                    throw new NullReferenceException("objectParent is null.");
                }
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }
    }
}
