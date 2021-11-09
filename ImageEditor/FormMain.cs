﻿using System;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class FormMain : Form
    {
        private readonly ImageOutput _imageOutput;

        public FormMain()
        {
            InitializeComponent();

            _imageOutput = new ImageOutput(pictureBoxImage);
            ManagingOfPictureBox.ImageOutputPicture = _imageOutput;
            ManagingOfGroupBoxes.ImageOutputPicture = _imageOutput;
            ManagingOfTextBox.ImageOutputPicture = _imageOutput;

            ManagingOfPictureBox.PictureBoxImage = pictureBoxImage;
            ManagingOfNumericUpDown.NumericUpDownColumns = numericUpDownColumns;
            ManagingOfNumericUpDown.NumericUpDownRows = numericUpDownRows;
            ManagingOfTextBox.TextBoxImageInformation = textBoxImageInformation;
            ManagingOfGroupBoxes.GroupBoxCreatePixelsTable = groupBoxCreatePixelsTable;
            ManagingOfGroupBoxes.GroupBoxEditImage= groupBoxEditImage;
            ManagingOfGroupBoxes.GroupBoxForFile= groupBoxForFile;
            ManagingOfGroupBoxes.GroupBoxForImage= groupBoxForImage;
            ManagingOfGroupBoxes.GroupBoxImageInformation = groupBoxImageInformation;
            ManagingOfButtons.ButtonCreateNewGrid = buttonCreateNewGrid;
            ManagingOfButtons.ButtonUndo = buttonUndo;
            ManagingOfButtons.ButtonRedo = buttonRedo;
            ManagingOfButtons.ButtonClear = buttonClear;
            ManagingOfButtons.ButtonLoadImage = buttonLoadImage;
            ManagingOfButtons.ButtonSaveImage = buttonSaveImage;

            int columns = (int)numericUpDownColumns.Value;
            int rows = (int) numericUpDownRows.Value;
            ManagingOfPictureBox.CreateNewGridInPictureBox(columns, rows);
        }

        private void NumericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            ManagingOfNumericUpDown.Rows = (int)numericUpDownRows.Value;
        }

        private void NumericUpDownColumns_ValueChanged(object sender, EventArgs e)
        {
            ManagingOfNumericUpDown.Columns = (int)numericUpDownColumns.Value;
        }

        private void PictureBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            ManagingOfPictureBox.MouseMoveInPictureBox(e);
        }

        private void PictureBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            ManagingOfPictureBox.MouseDownInPictureBox(e);
        }

        private void PictureBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            ManagingOfPictureBox.MouseUpInPictureBox(false);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ManagingOfButtons.ClearImage();
        }

        private void ButtonCreateNewImage_Click(object sender, EventArgs e)
        {
            ManagingOfButtons.CreateNewGrid();
        }

        private void GroupBoxForImage_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void GroupBoxCreatePixelsTable_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void GroupBoxEditImage_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void GroupBoxImageInformation_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void GroupBoxForFile_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void LabelX_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void LabelY_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void ButtonCreateNewImage_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void ButtonUndo_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void ButtonRedo_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void ButtonClear_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void ButtonLoadImage_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void ButtonSaveImage_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void TextBoxImageInformation_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void NumericUpDownColumns_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void NumericUpDownRows_MouseMove(object sender, MouseEventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            _imageOutput.ClearPreviousCellOfCursor();
        }
    }
}
