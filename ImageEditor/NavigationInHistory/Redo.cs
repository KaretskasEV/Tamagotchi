using System;
using System.Drawing;
using System.Collections.Generic;

namespace ImageEditor
{
    public sealed class Redo
    {
        public event Action<bool[,]> OnClearImage;
        public event Action<int, int, bool[,]> OnCreateNewGrid;

        const int EmptyStack = 0;

        private readonly ManagingOfNumericUpDown _managingOfNumericUpDown;
        private readonly ManagingOfPictureBox _managingOfPictureBox;
        private readonly ManagingOfTextBox _managingOfTextBox;
        private readonly ImageOutput _imageOutput;
        private readonly Stack<Action> _redoStack;

        public Redo(FormMain formMain)
        {
            try
            {
                if (formMain == null)
                {
                    throw new NullReferenceException("formMain is null.");
                }

                _managingOfNumericUpDown = formMain.ManagingOfNumericUpDown;
                _managingOfPictureBox = formMain.ManagingPictureBox;
                _managingOfTextBox = formMain.ManagingOfTextBox;
                _imageOutput = formMain.ImageOutput;
                _redoStack = new Stack<Action>();
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }

        public bool StackRedoEmpty
        {
            get => _redoStack.Count != EmptyStack;
        }

        public void RedoCreateSquareFillCell(Point coordinatePoint, Color colorRectangle,
                                             ImageOutput.SaveCell saveCell)
        {
            Action writeAction = () =>
            {
                _imageOutput.CreateSquareFillCell(coordinatePoint, colorRectangle, saveCell);
            };

            _redoStack.Push(writeAction);
        }

        public void RedoClearImage()
        {
            Action writeAction = () =>
            {
                if(OnClearImage != null)
                {
                    OnClearImage.Invoke(_imageOutput.ArrayCells);
                }
                //UndoClearImage(_imageOutput.ArrayCells);
                _managingOfTextBox.WriteTextInTextBox($"Clear the grid;");
                _managingOfPictureBox.ClearGridInPictureBox();
            };

            _redoStack.Push(writeAction);
        }

        public void RedoCreateNewGrid(int columns, int rows)
        {
            Action writeAction = () =>
            {
                const int oneColumnOrRow = 1;

                bool[,] array = _imageOutput.ArrayCells;

                if (OnCreateNewGrid != null)
                {
                    OnCreateNewGrid.Invoke(_imageOutput.CurrentMaximumColumns + oneColumnOrRow,
                                           _imageOutput.CurrentMaximumRows + oneColumnOrRow, array);
                }
                //UndoCreateNewGrid(_imageOutput.CurrentMaximumColumns + oneColumnOrRow,
                //                                _imageOutput.CurrentMaximumRows + oneColumnOrRow, array);
                _managingOfTextBox.WriteTextInTextBox($"Create a new grid: {columns} x {rows};");

                _managingOfNumericUpDown.Columns = columns;
                _managingOfNumericUpDown.Rows = rows;
                _managingOfPictureBox.CreateNewGridInPictureBox(columns, rows);
            };

            _redoStack.Push(writeAction);
        }

        public void RedoAction()
        {
            if (_redoStack.Count > EmptyStack)
            {
                Action action = _redoStack.Pop();

                if (action != null)
                {
                    action.Invoke();
                }
            }
        }

        public void RedoClearStack()
        {
            _redoStack.Clear();
        }
    }
}
