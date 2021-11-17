using System;
using System.Windows.Forms;

namespace ImageEditor
{
    public static class ManagingOfButtons
    {
        private static Button _buttonCreateNewGrid;
        private static Button _buttonUndo;
        private static Button _buttonRedo;
        private static Button _buttonClear;
        private static Button _buttonLoadImage;
        private static Button _buttonSaveImage;
        private static bool _buttonUndoIsPress;
        private static ImageOutput _imageOutputPictureBox;

        public static bool UndoIsPress
        {
            get => _buttonUndoIsPress;
        }

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

        public static Button ButtonCreateNewGrid
        {
            set
            {
                if (value != null)
                {
                    _buttonCreateNewGrid = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static Button ButtonUndo
        {
            set
            {
                if (value != null)
                {
                    _buttonUndo = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static Button ButtonRedo
        {
            set
            {
                if (value != null)
                {
                    _buttonRedo = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static Button ButtonClear
        {
            set
            {
                if (value != null)
                {
                    _buttonClear = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static Button ButtonLoadImage
        {
            set
            {
                if (value != null)
                {
                    _buttonLoadImage = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static Button ButtonSaveImage
        {
            set
            {
                if (value != null)
                {
                    _buttonSaveImage = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static void ClearImage()
        {
            if (_buttonUndoIsPress == false)
            {
                HistoryOfDraw.ClearImage(_imageOutputPictureBox.ArrayCells);
                ManagingOfTextBox.WriteTextInTextBox($"Clear a grid.");
            }

            ManagingOfPictureBox.ClearGridInPictureBox();
        }

        public static void CreateNewGrid(int columns, int rows)
        {
            const int oneColumnOrRow = 1;
            bool[,] array;

            if(_imageOutputPictureBox.ArrayCells == null)
            {
                array = new bool[columns, rows];
            }
            else
            {
                array = _imageOutputPictureBox.ArrayCells;
            }

            if (_buttonUndoIsPress == false)
            {
                HistoryOfDraw.CreateNewGrid(_imageOutputPictureBox.CurrentMaximumColumns + oneColumnOrRow,
                                            _imageOutputPictureBox.CurrentMaximumRows + oneColumnOrRow, array);
                ManagingOfTextBox.WriteTextInTextBox($"Create a new grid: {columns} - {rows}");
            }
            
            ManagingOfPictureBox.CreateNewGridInPictureBox(columns, rows);
        }

        private static void ButtonEnable(Button button, bool enabled)
        {
            if (enabled)
            {
                button.Enabled = true;
            }
            else
            {
                button.Enabled = false;
            }
        }

        public static void UndoAction()
        {
            _buttonUndoIsPress = true;

            HistoryOfDraw.ReturnAndActivatedMethod();

            if(HistoryOfDraw.StackUndoEmpty == false)
            {
                UndoEnableFalse();
            }

            _buttonUndoIsPress = false;
        }

        public static void RedoAction()
        {

        }

        public static void UndoEnableFalse()
        {
            ButtonEnable(_buttonUndo, false);
        }

        public static void UndoEnableTrue()
        {
            ButtonEnable (_buttonUndo, true);
        }

        public static void RedoEnabledFalse()
        {
            ButtonEnable(_buttonRedo, false);
        }

        public static void RedoEnabledTrue()
        {
            ButtonEnable(_buttonRedo, true);
        }
    }
}
