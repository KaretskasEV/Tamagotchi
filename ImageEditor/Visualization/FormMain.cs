using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class FormMain : Form
    {
        private readonly SerializeOfArray _serializeOfArray;
        private readonly DeserializeOfArray _deserializeOfArray;
        private readonly ManagingOfNumericUpDown _managingOfNumericUpDown;
        private readonly ManagingOfPictureBox _managingOfPictureBox;
        private readonly ManagingOfButtons _managingOfButtons;
        private readonly ManagingOfTextBox _managingOfTextBox;
        private readonly Undo _undo;
        private readonly Redo _redo;
        private readonly ImageOutput _imageOutput;

        public SerializeOfArray SerializeOfArray { get => _serializeOfArray; }
        public DeserializeOfArray DeserializeOfArray { get => _deserializeOfArray; }
        public ManagingOfNumericUpDown ManagingOfNumericUpDown { get => _managingOfNumericUpDown; }
        public ManagingOfPictureBox ManagingPictureBox { get => _managingOfPictureBox; }
        public ManagingOfButtons ManagingOfButtons { get => _managingOfButtons; }
        public ManagingOfTextBox ManagingOfTextBox { get => _managingOfTextBox; }
        public Undo Undo { get => _undo; }
        public Redo Redo { get => _redo; }
        public ImageOutput ImageOutput { get => _imageOutput; }

        
        public PictureBox PictureBoxImage { get => pictureBoxImage; }
        public TextBox TextBoxImageInformation { get => textBoxImageInformation;}
        public NumericUpDown NumericUpDownColumns { get => numericUpDownColumns; }
        public NumericUpDown NumericUpDownRows { get => numericUpDownRows; }
        public OpenFileDialog OpenFileDialog { get => openFileDialog; }
        public SaveFileDialog SaveFileDialog { get => saveFileDialog; }
        public Button ButtonCreateNewGrid { get => buttonCreateNewGrid; }
        public Button ButtonLoadImage { get => buttonLoadImage; }
        public Button ButtonSaveImage { get => buttonSaveImage; }
        public Button ButtonClear { get => buttonClear; }
        public Button ButtonUndo { get => buttonUndo; }
        public Button ButtonRedo { get => buttonRedo;}

        public FormMain()
        {
            const int MaximumColumns = 35;
            const int MaximunRows = 17;
            const int SizeCell = 21;

            InitializeComponent();

            string dateTime = DateTime.Now.ToString("dd.MM.yyyy%-HH%.mm%.ss");
            LogFile.CreateFileLog($"Log_File-{dateTime}.txt");

            _imageOutput = new ImageOutput(pictureBoxImage, SizeCell, MaximumColumns, MaximunRows);
            _serializeOfArray = new SerializeOfArray(this);
            _deserializeOfArray = new DeserializeOfArray(this);
            _managingOfNumericUpDown = new ManagingOfNumericUpDown(this);
            _managingOfPictureBox = new ManagingOfPictureBox(this);
            _managingOfTextBox = new ManagingOfTextBox(this);
            _redo = new Redo(this);
            _undo = new Undo(this);
            _managingOfButtons = new ManagingOfButtons(this);

            _imageOutput.OnCreateNewGrid += _managingOfPictureBox.ChangeSizePictureBox;
            _imageOutput.OnCreateNewGridAdditionalAction += _managingOfPictureBox.ShowPictureBoxInTheCentreGroupBox;
            _redo.OnClearImage += _undo.UndoClearImage;
            _redo.OnCreateNewGrid += _undo.UndoCreateNewGrid;
            _undo.OnUndoStackEmpty += _managingOfButtons.UndoEnableTrue;
            _undo.OnChangeOfPicture += () =>
            {
                if(_managingOfButtons.RedoIsPress == false)
                {
                    _managingOfButtons.RedoEnableFalse();
                }
            };
            _imageOutput.OnCreateFillCell += (Point coordinatePoint, Color colorRectangle, ImageOutput.SaveCell saveCell) =>
            {
                if (_managingOfButtons.UndoIsPress == false)
                {
                    _undo.UndoCreateSquareFillCell(coordinatePoint, colorRectangle, saveCell);
                }
            };
            _imageOutput.OnInformationOutput += (string text) =>
            {
                if(_managingOfButtons.UndoIsPress == false)
                {
                    _managingOfTextBox.WriteTextInTextBox(text);
                }
            };

            int columns = (int) numericUpDownColumns.Value;
            int rows = (int) numericUpDownRows.Value;
            _managingOfPictureBox.CreateNewGridInPictureBox(columns, rows);
        }

        private void NumericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            _managingOfNumericUpDown.Rows = (int) numericUpDownRows.Value;
        }

        private void NumericUpDownColumns_ValueChanged(object sender, EventArgs e)
        {
            _managingOfNumericUpDown.Columns = (int) numericUpDownColumns.Value;
        }

        private void PictureBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            _managingOfPictureBox.MouseMoveInPictureBox(e);
        }

        private void PictureBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            _managingOfPictureBox.MouseDownInPictureBox(e);
        }

        private void PictureBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            _managingOfPictureBox.MouseUpInPictureBox(false);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            _managingOfButtons.ClearImage();
        }

        private void ButtonCreateNewImage_Click(object sender, EventArgs e)
        {
            int columns = _managingOfNumericUpDown.Columns;
            int rows = _managingOfNumericUpDown.Rows;

            _managingOfButtons.CreateNewGrid(columns, rows);
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
            _managingOfButtons.UndoAction();
        }

        private void ButtonRedo_Click(object sender, EventArgs e)
        {
            _managingOfButtons.RedoAction();
        }
        private void ButtonSaveImage_Click(object sender, EventArgs e)
        {
            _managingOfButtons.SaveImage(_imageOutput.ArrayCells);
        }

        private void ButtonLoadImage_Click(object sender, EventArgs e)
        {
            _managingOfButtons.LoadImage();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            LogFile.SaveSimpleMessage("Action", "Application is closed.", LogFile.DataRetention.SaveQuickly);
        }
    }
}
