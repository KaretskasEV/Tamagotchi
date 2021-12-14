using System;
using System.Drawing;
using System.Collections.Generic;

namespace ImageEditor
{
    public sealed class Undo
    {
        public event Action OnChangeOfPicture;
        public event Action OnUndoStackEmpty;
        
        private const int EmptyStack = 0;

        private readonly ManagingOfNumericUpDown _managingOfNumericUpDown;
        private readonly ManagingOfPictureBox _managingOfPictureBox;
        private readonly ManagingOfTextBox _managingOfTextBox;
        private readonly ImageOutput _imageOutput;
        private readonly Redo _redo;
        private readonly Stack<Action> _undoStack;

        public Undo(FormMain formMain)
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
                _redo = formMain.Redo;
                _undoStack = new Stack<Action>();
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }

        public bool StackUndoEmpty
        {
            get => _undoStack.Count != EmptyStack;
        }

        private void ShowAllCells(bool[,] arrayCells)
        {
            if(arrayCells == null)
            {
                return;
            }

            bool cellExist = default;
            foreach(var cell in arrayCells)
            {
                if(cell == true)
                {
                    cellExist = true;
                    break;
                }
            }

            if(cellExist == false)
            {
                return;
            }

            bool[,] array = (bool[,])arrayCells.Clone();

            Action writeAction = () =>
            {
                _managingOfPictureBox.ShowAllFillCells(array);
            };

            AddUndoActionInStack(writeAction);
        }

        public void UndoClearImage(bool[,] arrayCells)
        {
            try
            {
                if (arrayCells == null)
                {
                    throw new NullReferenceException("arrayCells in null.");
                }

                Action writeAction = () =>
                {
                    _redo.RedoClearImage();

                    _managingOfPictureBox.ClearGridInPictureBox();
                    _managingOfTextBox.DeleteLastStringOfTextBox();
                };

                ShowAllCells(arrayCells);
                AddUndoActionInStack(writeAction);
            }
            catch(NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
                return;
            }
        }

        public void UndoCreateNewGrid(int columns, int rows, bool[,] arrayCells)
        {
            try
            {
                if (arrayCells == null)
                {
                    throw new NullReferenceException("arrayCells in null.");
                }

                Action writeAction = () =>
                {
                    const int oneColumnOrRow = 1;
                    int redoColumns = _imageOutput.CurrentMaximumColumns + oneColumnOrRow;
                    int redoRows = _imageOutput.CurrentMaximumRows + oneColumnOrRow;
                    _redo.RedoCreateNewGrid(redoColumns, redoRows);

                    _managingOfNumericUpDown.Columns = columns;
                    _managingOfNumericUpDown.Rows = rows;
                    _managingOfPictureBox.CreateNewGridInPictureBox(columns, rows);
                    _managingOfTextBox.DeleteLastStringOfTextBox();
                };

                ShowAllCells(arrayCells);
                AddUndoActionInStack(writeAction);
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
                return;
            }
        }

        public void UndoCreateSquareFillCell(Point coordinatePoint, Color colorRectangle, 
            ImageOutput.SaveCell saveCell)
        {
            Action writeAction = () =>
            {
                _redo.RedoCreateSquareFillCell(coordinatePoint, colorRectangle, saveCell);

                colorRectangle = ImageOutput.InvertColor(colorRectangle);
                saveCell = (saveCell == ImageOutput.SaveCell.Save) ? ImageOutput.SaveCell.Remove : ImageOutput.SaveCell.Save;
                _imageOutput.CreateSquareFillCell(coordinatePoint, colorRectangle, saveCell);
                _managingOfTextBox.DeleteLastStringOfTextBox();
            };

            AddUndoActionInStack(writeAction);
        }

        private void AddUndoActionInStack(Action writeAction)
        {
            _undoStack.Push(writeAction);

            if (_undoStack.Count > EmptyStack)
            {
                if(OnUndoStackEmpty != null)
                {
                    OnUndoStackEmpty.Invoke();
                }
            }

            if (OnChangeOfPicture != null)
            {
                OnChangeOfPicture.Invoke();
            }
        }

        public void UndoAction() 
        {
            const int firstItemStack = 0;
            const int maximumNumberOfCycles = 2;
            const string nameAnonymousMethod = "<ShowAllCells>b__0";
            Action action;

            for(int item = firstItemStack; item < maximumNumberOfCycles; item++)
            {
                if(_undoStack.Count == EmptyStack)
                {
                    break;
                }

                action = _undoStack.Pop();

                if (action != null)
                {
                    action.Invoke();
                }

                if(_undoStack.Count == EmptyStack)
                {
                    break;
                }
                else if (_undoStack.Peek().Method.Name != nameAnonymousMethod)
                {
                    break;
                }
            }
        }

        public void UndoClearStack()
        {
            _undoStack.Clear();
        }
    }
}