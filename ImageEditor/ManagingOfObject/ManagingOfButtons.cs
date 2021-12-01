using System;
using System.Windows.Forms;

namespace ImageEditor
{
    public static class ManagingOfButtons
    {
        private static Button _buttonUndo;
        private static Button _buttonRedo;
        private static bool _buttonUndoIsPress;
        private static bool _buttonRedoIsPress;
        private static ImageOutput _imageOutputPictureBox;

        public static bool UndoIsPress
        {
            get => _buttonUndoIsPress;
        }

        public static bool RedoIsPress
        {
            get => _buttonRedoIsPress;
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

        public static void ClearImage()
        {
            if (_buttonUndoIsPress == false)
            {
                HistoryOfDraw.UndoClearImage(_imageOutputPictureBox.ArrayCells);
                ManagingOfTextBox.WriteTextInTextBox($"Clear the grid;");
            }

            ManagingOfPictureBox.ClearGridInPictureBox();
        }

        public static void CreateNewGrid(int columns, int rows)
        {
            const int oneColumnOrRow = 1;

            bool[,] array = _imageOutputPictureBox.ArrayCells;

            if (_buttonUndoIsPress == false)
            {
                HistoryOfDraw.UndoCreateNewGrid(_imageOutputPictureBox.CurrentMaximumColumns + oneColumnOrRow,
                                            _imageOutputPictureBox.CurrentMaximumRows + oneColumnOrRow, array);
                ManagingOfTextBox.WriteTextInTextBox($"Create a new grid: {columns} x {rows};");
            }

            ManagingOfNumericUpDown.Columns = columns;
            ManagingOfNumericUpDown.Rows = rows;
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

            HistoryOfDraw.UndoAction();
            RedoEnableTrue();

            if(HistoryOfDraw.StackUndoEmpty == false)
            {
                UndoEnableFalse();
            }

            _buttonUndoIsPress = false;
        }

        public static void RedoAction()
        {
            _buttonRedoIsPress = true;
            HistoryOfDraw.RedoAction();

            if(HistoryOfDraw.StackRedoEmpty == false)
            {
                RedoEnableFalse();
            }

            _buttonRedoIsPress= false;
        }

        public static void UndoEnableFalse()
        {
            ButtonEnable(_buttonUndo, false);
            if (_buttonRedo.Enabled)
            {
                _buttonRedo.Select();
            }
        }

        public static void UndoEnableTrue()
        {
            ButtonEnable (_buttonUndo, true);
        }

        public static void RedoEnableFalse()
        {
            HistoryOfDraw.RedoClearStack();
            ButtonEnable(_buttonRedo, false);
            if (_buttonUndo.Enabled)
            {
                _buttonUndo.Select();
            }
        }

        public static void RedoEnableTrue()
        {
            ButtonEnable(_buttonRedo, true);
        }

        public static void SaveImage(bool[,] arrayCells)
        {
            SerializeOfArrayInFile.SaveFile(arrayCells);
        }

        public static void LoadImage()
        {
            const int firstDimensionOfArray = 0;
            const int secondDimensionOfArray = 1;
            int columns, rows;

            bool[,] arrayCells = SerializeOfArrayInFile.ReadFile();

            if(arrayCells == null)
            {
                return;
            }

            columns=arrayCells.GetLength(firstDimensionOfArray);
            rows=arrayCells.GetLength(secondDimensionOfArray);

            ManagingOfTextBox.ClearTextInTextBox();
            CreateNewGrid(columns, rows);

            RedoEnableFalse();
            HistoryOfDraw.UndoClearStack();
            UndoEnableFalse();
            ManagingOfTextBox.ClearTextInTextBox();

            ManagingOfPictureBox.ShowAllFillCells(arrayCells);
        }
    }
}
