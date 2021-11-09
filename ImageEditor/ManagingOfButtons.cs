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
            int columns = ManagingOfNumericUpDown.Columns;
            int rows = ManagingOfNumericUpDown.Rows;

            ManagingOfTextBox.WriteTextInTextBox("Clear Image;");
            ManagingOfPictureBox.CreateNewGridInPictureBox(columns, rows);
        }

        public static void CreateNewGrid()
        {
            int columns = ManagingOfNumericUpDown.Columns;
            int rows = ManagingOfNumericUpDown.Rows;

            ManagingOfTextBox.ClearTextInTextBox();
            ManagingOfTextBox.WriteTextInTextBox($"Create new grid: {columns} - {rows}");
            ManagingOfPictureBox.CreateNewGridInPictureBox(columns, rows);
        }
    }
}
