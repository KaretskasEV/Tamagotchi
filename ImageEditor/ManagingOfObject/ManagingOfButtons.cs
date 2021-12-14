using System;
using System.Windows.Forms;

namespace ImageEditor
{
    sealed public class ManagingOfButtons
    {
        private readonly SerializeOfArray _serializeOfArray;
        private readonly DeserializeOfArray _deserializeOfArray;
        private readonly ManagingOfNumericUpDown _managingOfNumericUpDown; 
        private readonly ManagingOfPictureBox _managingOfPictureBox;
        private readonly ManagingOfTextBox _managingOfTextBox;
        private readonly Undo _undo;
        private readonly Redo _redo;
        private readonly ImageOutput _imageOutput;
        private readonly Button _buttonUndo;
        private readonly Button _buttonRedo;

        private bool _buttonUndoIsPress;
        private bool _buttonRedoIsPress;

        public bool UndoIsPress
        {
            get => _buttonUndoIsPress;
        }

        public bool RedoIsPress
        {
            get => _buttonRedoIsPress;
        }

        public ManagingOfButtons(FormMain formMain)
        {
            try
            {
                if (formMain == null)
                {
                    throw new NullReferenceException("formMain is null.");
                }

                _serializeOfArray = formMain.SerializeOfArray;
                _deserializeOfArray = formMain.DeserializeOfArray;
                _managingOfNumericUpDown = formMain.ManagingOfNumericUpDown;
                _managingOfPictureBox = formMain.ManagingPictureBox;
                _managingOfTextBox = formMain.ManagingOfTextBox;
                _undo = formMain.Undo;
                _redo = formMain.Redo;
                _imageOutput = formMain.ImageOutput;
                _buttonUndo = formMain.ButtonUndo;
                _buttonRedo = formMain.ButtonRedo;
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }

        public void ClearImage()
        {
            if (_buttonUndoIsPress == false)
            {
                _undo.UndoClearImage(_imageOutput.ArrayCells);
                _managingOfTextBox.WriteTextInTextBox($"Clear the grid;");
            }

            _managingOfPictureBox.ClearGridInPictureBox();
        }

        public void CreateNewGrid(int columns, int rows)
        {
            const int oneColumnOrRow = 1;

            bool[,] array = _imageOutput.ArrayCells;

            if (_buttonUndoIsPress == false)
            {
                _undo.UndoCreateNewGrid(_imageOutput.CurrentMaximumColumns + oneColumnOrRow,
                                            _imageOutput.CurrentMaximumRows + oneColumnOrRow, array);
                _managingOfTextBox.WriteTextInTextBox($"Create a new grid: {columns} x {rows};");
            }

            _managingOfNumericUpDown.Columns = columns;
            _managingOfNumericUpDown.Rows = rows;
            _managingOfPictureBox.CreateNewGridInPictureBox(columns, rows);
        }

        private static void ButtonEnable(Button button, bool enabled)
        {
            try
            {
                if (button == null)
                {
                    throw new NullReferenceException("button is null.");
                }

                if (enabled)
                {
                    button.Enabled = true;
                }
                else
                {
                    button.Enabled = false;
                }
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }

        public void UndoAction()
        {
            _buttonUndoIsPress = true;

            _undo.UndoAction();
            RedoEnableTrue();

            if(_undo.StackUndoEmpty == false)
            {
                UndoEnableFalse();
            }

            _buttonUndoIsPress = false;
        }

        public void RedoAction()
        {
            _buttonRedoIsPress = true;
            _redo.RedoAction();

            if(_redo.StackRedoEmpty == false)
            {
                RedoEnableFalse();
            }

            _buttonRedoIsPress= false;
        }

        public void UndoEnableFalse()
        {
            ButtonEnable(_buttonUndo, false);
            if (_buttonRedo.Enabled)
            {
                _buttonRedo.Select();
            }
        }

        public void UndoEnableTrue()
        {
            ButtonEnable(_buttonUndo, true);
        }

        public void RedoEnableFalse()
        {
            _redo.RedoClearStack();
            ButtonEnable(_buttonRedo, false);
            if (_buttonUndo.Enabled)
            {
                _buttonUndo.Select();
            }
        }

        public void RedoEnableTrue()
        {
            ButtonEnable(_buttonRedo, true);
        }

        public void SaveImage(bool[,] arrayCells)
        {
            try
            {
                if (arrayCells == null)
                {
                    throw new NullReferenceException("arrayCells is null.");
                }

                _serializeOfArray.SaveFile(arrayCells);
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }

        public void LoadImage()
        {
            const int firstDimensionOfArray = 0;
            const int secondDimensionOfArray = 1;
            int columns, rows;

            bool[,] arrayCells = _deserializeOfArray.ReadFile();

            try
            {
                if (arrayCells == null)
                {
                    throw new NullReferenceException("arrayCells is null.");
                }

                columns = arrayCells.GetLength(firstDimensionOfArray);
                rows = arrayCells.GetLength(secondDimensionOfArray);

                _managingOfTextBox.ClearTextInTextBox();
                CreateNewGrid(columns, rows);

                RedoEnableFalse();
                _undo.UndoClearStack();
                UndoEnableFalse();
                _managingOfTextBox.ClearTextInTextBox();

                _managingOfPictureBox.ShowAllFillCells(arrayCells);
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }
    }
}