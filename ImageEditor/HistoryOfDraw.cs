using System;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    public static class HistoryOfDraw
    {
        private static Stack<Action> UndoStack = new Stack<Action>();
        private static Stack<Action> RedoStack = new Stack<Action>();
        private static ImageOutput _imageOutputPictureBox;

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
            get => (UndoStack.Count == 1) ? false : true;
        }

        public static bool StackRedoEmpty
        {
            get => (RedoStack.Count == 1) ? false : true;
        }

        private static void ShowAllCells(bool[,] arrayCells)
        {
            bool[,] array = (bool[,])arrayCells.Clone();

            Action writeAction = () =>
            {
                _imageOutputPictureBox.ShowAllFillCells(Color.Black, array);
            };

            AddActionInStack(writeAction);
        }

        public static void ClearImage(bool[,] arrayCells)
        {
            Action writeAction = () =>
            {
                ManagingOfButtons.ClearImage();
                ManagingOfTextBox.DeleteLastStringOfTextBox();
            };

            ShowAllCells(arrayCells);
            AddActionInStack(writeAction);
        }

        public static void CreateNewGrid(int columns, int rows, bool[,] arrayCells)
        {
            bool[,] array = (bool[,])arrayCells.Clone();

            Action writeAction = () =>
            {
                ManagingOfNumericUpDown.Columns = columns;
                ManagingOfNumericUpDown.Rows = rows;
                ManagingOfButtons.CreateNewGrid(columns, rows);
                _imageOutputPictureBox.ShowAllFillCells(Color.Black, array);
                ManagingOfTextBox.DeleteLastStringOfTextBox();
            };

            AddActionInStack(writeAction);
        }

        public static void CreateSquareFillCell(Point coordinatePoint, Color colorRectangle, 
            ImageOutput.SaveCell saveCell)
        {
            Action writeAction = () =>
            {
                colorRectangle = ImageOutput.InvertColor(colorRectangle);
                saveCell = (saveCell == ImageOutput.SaveCell.Save) ? ImageOutput.SaveCell.Remove : ImageOutput.SaveCell.Save;
                _imageOutputPictureBox.CreateSquareFillCell(coordinatePoint, colorRectangle, saveCell);
                ManagingOfTextBox.DeleteLastStringOfTextBox();
            };

            AddActionInStack(writeAction);
        }

        private static void AddActionInStack(Action writeAction)
        {
            UndoStack.Push(writeAction);

            if (UndoStack.Count > 1)
            {
                ManagingOfButtons.UndoEnableTrue();
            }
        }

        public static void ReturnAndActivatedMethod() 
        {
            if (UndoStack.Count > 0)
            {
                Action action = UndoStack.Pop();

                if(action != null)
                {
                    action.Invoke();
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////
        
        
    }
}