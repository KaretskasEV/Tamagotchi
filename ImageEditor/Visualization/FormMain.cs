using System;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class FormMain : Form
    {
        private readonly ImageOutput _imageOutput;
        

        public FormMain()
        {
            const int SizeCell = 21;
            const int MaximumColumns = 35;
            const int MaximunRows = 17;

            InitializeComponent();

            _imageOutput = new ImageOutput(pictureBoxImage, SizeCell, MaximumColumns, MaximunRows);
            ManagingOfPictureBox.ImageOutputPicture = _imageOutput;
            ManagingOfButtons.ImageOutputPicture = _imageOutput;
            HistoryOfDraw.ImageOutputPicture = _imageOutput;

            ManagingOfPictureBox.PictureBoxImage = pictureBoxImage;
            ManagingOfNumericUpDown.NumericUpDownColumns = numericUpDownColumns;
            ManagingOfNumericUpDown.NumericUpDownRows = numericUpDownRows;
            ManagingOfTextBox.TextBoxImageInformation = textBoxImageInformation;
            ManagingOfButtons.ButtonUndo = buttonUndo;
            ManagingOfButtons.ButtonRedo = buttonRedo;
            SerializeOfArrayInFile.OpenFileDialog = openFileDialog;
            SerializeOfArrayInFile.SaveFileDialog = saveFileDialog;

            _imageOutput.OnCreateFillCell += ManagingOfPictureBox.SaveInStack;
            _imageOutput.OnInformationOutput += ManagingOfTextBox.CheckForRecord;
            _imageOutput.OnCreateNewGrid += ManagingOfPictureBox.ChangeSizePictureBox;
            _imageOutput.OnCreateNewGridAdditionalAction += ManagingOfPictureBox.ShowPictureBoxInTheCentreGroupBox;
            HistoryOfDraw.OnChangeOfPicture += ManagingOfButtons.RedoEnableFalse;

            int columns = (int)numericUpDownColumns.Value;
            int rows = (int) numericUpDownRows.Value;
            ManagingOfPictureBox.CreateNewGridInPictureBox(columns, rows);

            LogFile.CreateFileLog("Log_File.txt");
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
            int columns = ManagingOfNumericUpDown.Columns;
            int rows = ManagingOfNumericUpDown.Rows;

            ManagingOfButtons.CreateNewGrid(columns, rows);
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

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            ManagingOfButtons.UndoAction();
        }

        private void ButtonRedo_Click(object sender, EventArgs e)
        {
            ManagingOfButtons.RedoAction();
        }
        private void ButtonSaveImage_Click(object sender, EventArgs e)
        {
            ManagingOfButtons.SaveImage(_imageOutput.ArrayCells);
        }

        private void ButtonLoadImage_Click(object sender, EventArgs e)
        {
            ManagingOfButtons.LoadImage();
        }
    }
}
