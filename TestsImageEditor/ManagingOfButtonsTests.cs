using System;
using System.Windows.Forms;
using NUnit.Framework;
using System.Drawing;

using ImageEditor;

namespace TestsImageEditor
{
    sealed class ManagingOfButtonsTests
    {
        const int cellSize = 21;
        const int maximumColumns = 35;
        const int maximumRows = 17;
        const int minimumColumnsOrRows = 1;
        const int maximumWidth = maximumColumns * cellSize;
        const int maximumHeight = maximumRows * cellSize;

        private static int X;
        private static int Y;

        //Point coordinatePoint;
        PictureBox pictureBox;
        Button buttonUndo;
        Button buttonRedo;
        TextBox textBox;
        ImageOutput imageOutput;
        NumericUpDown numericUpDownColumns;
        NumericUpDown numericUpDownRows;

        private Point coordinatePoint { get; set;}

        private void Initialization_Object()
        {
            coordinatePoint = new Point(X, Y);
            pictureBox = new PictureBox();
            buttonUndo = new Button();
            buttonRedo = new Button();
            textBox = new TextBox();
            numericUpDownColumns = new NumericUpDown();
            numericUpDownRows = new NumericUpDown();

            pictureBox.Width = 741;
            pictureBox.Height = 363;
            imageOutput = new ImageOutput(pictureBox, cellSize, maximumColumns, maximumRows);
            ManagingOfButtons.ImageOutputPicture = imageOutput;
            ManagingOfButtons.ButtonUndo = buttonUndo;
            ManagingOfButtons.ButtonRedo = buttonRedo;
            ManagingOfPictureBox.ImageOutputPicture = imageOutput;
            ManagingOfTextBox.TextBoxImageInformation = textBox;
            ManagingOfNumericUpDown.NumericUpDownColumns = numericUpDownColumns;
            ManagingOfNumericUpDown.NumericUpDownRows = numericUpDownRows;
            ManagingOfNumericUpDown.Columns = maximumColumns;
            ManagingOfNumericUpDown.Rows = maximumRows;
            numericUpDownColumns.Maximum = maximumColumns;
            numericUpDownColumns.Minimum = minimumColumnsOrRows;
            numericUpDownRows.Maximum = maximumRows;
            numericUpDownRows.Minimum = minimumColumnsOrRows;
        }

        [Test]
        public void ImageOutputPicture_throw_NullReferenceException()
        {
            Assert.Throws(typeof(NullReferenceException), () => 
            { ManagingOfButtons.ImageOutputPicture = null; });
        }

        [Test]
        public void ButtonUndo_throw_NullReferenceException()
        {
            Assert.Throws(typeof(NullReferenceException), () =>
            { ManagingOfButtons.ButtonUndo = null; });
        }

        [Test]
        public void ButtonRedo_throw_NullReferenceException()
        {
            Assert.Throws(typeof(NullReferenceException), () =>
            { ManagingOfButtons.ButtonRedo = null; });
        }

        [Test]
        public void ClearImage_return_false()
        {
            Initialization_Object();

            for(X = 0; X < maximumWidth; X++)
            {
                for(Y = 0; Y < maximumHeight; Y++)
                {
                    coordinatePoint = new Point(X, Y);
                    imageOutput.CreateSquareFillCell(coordinatePoint, 
                        Color.Black, ImageOutput.SaveCell.Save);
                }
            }

            foreach(bool cell in imageOutput.ArrayCells)
            {
                Assert.AreEqual(true, cell);
            }

            ManagingOfButtons.ClearImage();

            foreach(bool cell in imageOutput.ArrayCells)
            {
                Assert.AreEqual(false, cell);
            }
        }

        [Test]
        public void CreateNewGrid_return_all_size_grid_from_1x1_to_35x17()
        {
            Initialization_Object();

            for(int column = 1; column < maximumColumns; column++)
            {
                for(int row = 1; row < maximumRows; row++)
                {
                    ManagingOfButtons.CreateNewGrid(column, row);

                    Assert.AreEqual(column, imageOutput.CurrentMaximumColumns + 1);
                    Assert.AreEqual(row, imageOutput.CurrentMaximumRows + 1);
                }
            }
        }

        [Test]
        public void CreateNewGrid_throw_Exception()
        {
            Initialization_Object();

            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { ManagingOfButtons.CreateNewGrid(-1, 1); });
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { ManagingOfButtons.CreateNewGrid(1, -1); });
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { ManagingOfButtons.CreateNewGrid(maximumColumns + 1, 1); });
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { ManagingOfButtons.CreateNewGrid(1, maximumRows + 1); });
        }
    }
}