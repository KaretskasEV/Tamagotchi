using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImageEditor
{
    public static class HistoryOfDraw
    {
        const int EmptyStack = 0;
        private static Stack<Action> UndoStack = new Stack<Action>();
        private static Stack<Action> RedoStack = new Stack<Action>();
        private static ImageOutput _imageOutputPictureBox;

        public static event Action OnChangeOfPicture;

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

        public static bool StackUndoEmpty
        {
            get => UndoStack.Count != EmptyStack;
        }

        public static bool StackRedoEmpty
        {
            get => RedoStack.Count != EmptyStack;
        }

        private static void ShowAllCells(bool[,] arrayCells)
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
                ManagingOfPictureBox.ShowAllFillCells(array);
            };

            AddUndoActionInStack(writeAction);
        }

        public static void UndoClearImage(bool[,] arrayCells)
        {
            Action writeAction = () =>
            {
                RedoClearImage();

                ManagingOfButtons.ClearImage();
                ManagingOfTextBox.DeleteLastStringOfTextBox();
            };

            ShowAllCells(arrayCells);
            AddUndoActionInStack(writeAction);
        }

        public static void UndoCreateNewGrid(int columns, int rows, bool[,] arrayCells)
        {
            Action writeAction = () =>
            {
                const int oneColumnOrRow = 1;
                int redoColumns = _imageOutputPictureBox.CurrentMaximumColumns + oneColumnOrRow;
                int redoRows = _imageOutputPictureBox.CurrentMaximumRows + oneColumnOrRow;
                RedoCreateNewGrid(redoColumns, redoRows);

                ManagingOfButtons.CreateNewGrid(columns, rows);
                ManagingOfTextBox.DeleteLastStringOfTextBox();
            };

            ShowAllCells(arrayCells);
            AddUndoActionInStack(writeAction);
        }

        public static void UndoCreateSquareFillCell(Point coordinatePoint, Color colorRectangle, 
            ImageOutput.SaveCell saveCell)
        {
            Action writeAction = () =>
            {
                RedoCreateSquareFillCell(coordinatePoint, colorRectangle, saveCell);

                colorRectangle = ImageOutput.InvertColor(colorRectangle);
                saveCell = (saveCell == ImageOutput.SaveCell.Save) ? ImageOutput.SaveCell.Remove : ImageOutput.SaveCell.Save;
                _imageOutputPictureBox.CreateSquareFillCell(coordinatePoint, colorRectangle, saveCell);
                ManagingOfTextBox.DeleteLastStringOfTextBox();
            };

            AddUndoActionInStack(writeAction);
        }

        private static void AddUndoActionInStack(Action writeAction)
        {
            UndoStack.Push(writeAction);

            if (UndoStack.Count > EmptyStack)
            {
                ManagingOfButtons.UndoEnableTrue();
            }

            if ((OnChangeOfPicture != null) & (ManagingOfButtons.RedoIsPress == false))
            {
                OnChangeOfPicture.Invoke();
            }
        }

        public static void UndoAction() 
        {
            const int firstItemStack = 0;
            const int maximumNumberOfCycles = 2;
            const string nameAnonymousMethod = "<ShowAllCells>b__0";
            Action action;

            for(int item = firstItemStack; item < maximumNumberOfCycles; item++)
            {
                if(UndoStack.Count == EmptyStack)
                {
                    break;
                }

                action = UndoStack.Pop();

                if (action != null)
                {
                    action.Invoke();
                }

                if(UndoStack.Count == EmptyStack)
                {
                    break;
                }
                else if (UndoStack.Peek().Method.Name != nameAnonymousMethod)
                {
                    break;
                }
            }
        }

        public static void UndoClearStack()
        {
            UndoStack.Clear();
        }
        
        private static void RedoCreateSquareFillCell(Point coordinatePoint, Color colorRectangle, 
            ImageOutput.SaveCell saveCell)
        {
            Action writeAction = () =>
            {
                _imageOutputPictureBox.CreateSquareFillCell(coordinatePoint, colorRectangle, saveCell);
            };

            RedoStack.Push(writeAction);
        }

        private static void RedoClearImage()
        {
            Action writeAction = () =>
            {
                ManagingOfButtons.ClearImage();
            };

            RedoStack.Push(writeAction);
        }

        private static void RedoCreateNewGrid(int columns, int rows)
        {
            Action writeAction = () =>
            {
                ManagingOfButtons.CreateNewGrid(columns, rows);
            };

            RedoStack.Push(writeAction);
        }

        public static void RedoAction()
        {
            if(RedoStack.Count > EmptyStack)
            {
                Action action = RedoStack.Pop();

                if (action != null)
                {
                    action.Invoke();
                }
            }
        }

        public static void RedoClearStack()
        {
            RedoStack.Clear();
        }
    }
}