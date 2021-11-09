
namespace ImageEditor
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCreateNewGrid = new System.Windows.Forms.Button();
            this.openFileDialogFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogFile = new System.Windows.Forms.SaveFileDialog();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.numericUpDownColumns = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.groupBoxCreatePixelsTable = new System.Windows.Forms.GroupBox();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.groupBoxEditImage = new System.Windows.Forms.GroupBox();
            this.buttonRedo = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxImageInformation = new System.Windows.Forms.GroupBox();
            this.textBoxImageInformation = new System.Windows.Forms.TextBox();
            this.groupBoxForFile = new System.Windows.Forms.GroupBox();
            this.groupBoxForImage = new System.Windows.Forms.GroupBox();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            this.groupBoxCreatePixelsTable.SuspendLayout();
            this.groupBoxEditImage.SuspendLayout();
            this.groupBoxImageInformation.SuspendLayout();
            this.groupBoxForFile.SuspendLayout();
            this.groupBoxForImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateNewGrid
            // 
            this.buttonCreateNewGrid.Location = new System.Drawing.Point(8, 71);
            this.buttonCreateNewGrid.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreateNewGrid.Name = "buttonCreateNewGrid";
            this.buttonCreateNewGrid.Size = new System.Drawing.Size(138, 33);
            this.buttonCreateNewGrid.TabIndex = 1;
            this.buttonCreateNewGrid.Text = "Create new grid";
            this.buttonCreateNewGrid.UseVisualStyleBackColor = true;
            this.buttonCreateNewGrid.Click += new System.EventHandler(this.ButtonCreateNewImage_Click);
            this.buttonCreateNewGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonCreateNewImage_MouseMove);
            // 
            // openFileDialogFile
            // 
            this.openFileDialogFile.DefaultExt = "txt";
            this.openFileDialogFile.FileName = "openFileDialog1";
            this.openFileDialogFile.Filter = "Текстовые файлы(*.txt)|*.txt";
            this.openFileDialogFile.Title = "Open file";
            // 
            // saveFileDialogFile
            // 
            this.saveFileDialogFile.CheckFileExists = true;
            this.saveFileDialogFile.DefaultExt = "txt";
            this.saveFileDialogFile.Filter = "Текстовые файлы(*.txt)|*.txt";
            this.saveFileDialogFile.Title = "Save file";
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Location = new System.Drawing.Point(7, 70);
            this.buttonSaveImage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(138, 33);
            this.buttonSaveImage.TabIndex = 2;
            this.buttonSaveImage.Text = "Save Image";
            this.buttonSaveImage.UseVisualStyleBackColor = true;
            this.buttonSaveImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonSaveImage_MouseMove);
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(7, 27);
            this.buttonLoadImage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(138, 33);
            this.buttonLoadImage.TabIndex = 3;
            this.buttonLoadImage.Text = "Load Image";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonLoadImage_MouseMove);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Enabled = false;
            this.buttonUndo.Location = new System.Drawing.Point(7, 27);
            this.buttonUndo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(62, 33);
            this.buttonUndo.TabIndex = 4;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonUndo_MouseMove);
            // 
            // numericUpDownColumns
            // 
            this.numericUpDownColumns.Location = new System.Drawing.Point(70, 18);
            this.numericUpDownColumns.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownColumns.Maximum = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.numericUpDownColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownColumns.Name = "numericUpDownColumns";
            this.numericUpDownColumns.Size = new System.Drawing.Size(76, 23);
            this.numericUpDownColumns.TabIndex = 5;
            this.numericUpDownColumns.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownColumns.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.numericUpDownColumns.ValueChanged += new System.EventHandler(this.NumericUpDownColumns_ValueChanged);
            this.numericUpDownColumns.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NumericUpDownColumns_MouseMove);
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Location = new System.Drawing.Point(70, 44);
            this.numericUpDownRows.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownRows.Maximum = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(76, 23);
            this.numericUpDownRows.TabIndex = 6;
            this.numericUpDownRows.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownRows.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.numericUpDownRows.ValueChanged += new System.EventHandler(this.NumericUpDownRows_ValueChanged);
            this.numericUpDownRows.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NumericUpDownRows_MouseMove);
            // 
            // groupBoxCreatePixelsTable
            // 
            this.groupBoxCreatePixelsTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBoxCreatePixelsTable.Controls.Add(this.numericUpDownRows);
            this.groupBoxCreatePixelsTable.Controls.Add(this.labelX);
            this.groupBoxCreatePixelsTable.Controls.Add(this.labelY);
            this.groupBoxCreatePixelsTable.Controls.Add(this.numericUpDownColumns);
            this.groupBoxCreatePixelsTable.Controls.Add(this.buttonCreateNewGrid);
            this.groupBoxCreatePixelsTable.Location = new System.Drawing.Point(13, 413);
            this.groupBoxCreatePixelsTable.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxCreatePixelsTable.Name = "groupBoxCreatePixelsTable";
            this.groupBoxCreatePixelsTable.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxCreatePixelsTable.Size = new System.Drawing.Size(153, 111);
            this.groupBoxCreatePixelsTable.TabIndex = 7;
            this.groupBoxCreatePixelsTable.TabStop = false;
            this.groupBoxCreatePixelsTable.Text = "Create pixels table:";
            this.groupBoxCreatePixelsTable.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupBoxCreatePixelsTable_MouseMove);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(4, 20);
            this.labelX.Margin = new System.Windows.Forms.Padding(0);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(66, 16);
            this.labelX.TabIndex = 8;
            this.labelX.Text = "Columns:";
            this.labelX.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabelX_MouseMove);
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(25, 46);
            this.labelY.Margin = new System.Windows.Forms.Padding(0);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(45, 16);
            this.labelY.TabIndex = 9;
            this.labelY.Text = "Rows:";
            this.labelY.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabelY_MouseMove);
            // 
            // groupBoxEditImage
            // 
            this.groupBoxEditImage.Controls.Add(this.buttonRedo);
            this.groupBoxEditImage.Controls.Add(this.buttonClear);
            this.groupBoxEditImage.Controls.Add(this.buttonUndo);
            this.groupBoxEditImage.Location = new System.Drawing.Point(174, 413);
            this.groupBoxEditImage.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxEditImage.Name = "groupBoxEditImage";
            this.groupBoxEditImage.Size = new System.Drawing.Size(155, 111);
            this.groupBoxEditImage.TabIndex = 8;
            this.groupBoxEditImage.TabStop = false;
            this.groupBoxEditImage.Text = "Operation with Image";
            this.groupBoxEditImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupBoxEditImage_MouseMove);
            // 
            // buttonRedo
            // 
            this.buttonRedo.Enabled = false;
            this.buttonRedo.Location = new System.Drawing.Point(87, 27);
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Size = new System.Drawing.Size(62, 33);
            this.buttonRedo.TabIndex = 9;
            this.buttonRedo.Text = "Redo";
            this.buttonRedo.UseVisualStyleBackColor = true;
            this.buttonRedo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonRedo_MouseMove);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(7, 72);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(142, 33);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            this.buttonClear.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonClear_MouseMove);
            // 
            // groupBoxImageInformation
            // 
            this.groupBoxImageInformation.Controls.Add(this.textBoxImageInformation);
            this.groupBoxImageInformation.Location = new System.Drawing.Point(336, 413);
            this.groupBoxImageInformation.Name = "groupBoxImageInformation";
            this.groupBoxImageInformation.Size = new System.Drawing.Size(278, 111);
            this.groupBoxImageInformation.TabIndex = 9;
            this.groupBoxImageInformation.TabStop = false;
            this.groupBoxImageInformation.Text = "Image information";
            this.groupBoxImageInformation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupBoxImageInformation_MouseMove);
            // 
            // textBoxImageInformation
            // 
            this.textBoxImageInformation.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxImageInformation.Location = new System.Drawing.Point(6, 27);
            this.textBoxImageInformation.Multiline = true;
            this.textBoxImageInformation.Name = "textBoxImageInformation";
            this.textBoxImageInformation.ReadOnly = true;
            this.textBoxImageInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxImageInformation.Size = new System.Drawing.Size(266, 76);
            this.textBoxImageInformation.TabIndex = 10;
            this.textBoxImageInformation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TextBoxImageInformation_MouseMove);
            // 
            // groupBoxForFile
            // 
            this.groupBoxForFile.Controls.Add(this.buttonSaveImage);
            this.groupBoxForFile.Controls.Add(this.buttonLoadImage);
            this.groupBoxForFile.Location = new System.Drawing.Point(620, 413);
            this.groupBoxForFile.Name = "groupBoxForFile";
            this.groupBoxForFile.Size = new System.Drawing.Size(152, 111);
            this.groupBoxForFile.TabIndex = 10;
            this.groupBoxForFile.TabStop = false;
            this.groupBoxForFile.Text = "File";
            this.groupBoxForFile.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupBoxForFile_MouseMove);
            // 
            // groupBoxForImage
            // 
            this.groupBoxForImage.Controls.Add(this.pictureBoxImage);
            this.groupBoxForImage.Location = new System.Drawing.Point(12, 12);
            this.groupBoxForImage.Name = "groupBoxForImage";
            this.groupBoxForImage.Size = new System.Drawing.Size(760, 394);
            this.groupBoxForImage.TabIndex = 11;
            this.groupBoxForImage.TabStop = false;
            this.groupBoxForImage.Text = "Image";
            this.groupBoxForImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupBoxForImage_MouseMove);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.White;
            this.pictureBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxImage.Location = new System.Drawing.Point(10, 21);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(741, 363);
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxImage_MouseDown);
            this.pictureBoxImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxImage_MouseMove);
            this.pictureBoxImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxImage_MouseUp);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 535);
            this.Controls.Add(this.groupBoxForImage);
            this.Controls.Add(this.groupBoxForFile);
            this.Controls.Add(this.groupBoxImageInformation);
            this.Controls.Add(this.groupBoxEditImage);
            this.Controls.Add(this.groupBoxCreatePixelsTable);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Editor";
            this.Deactivate += new System.EventHandler(this.FormMain_Deactivate);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            this.groupBoxCreatePixelsTable.ResumeLayout(false);
            this.groupBoxCreatePixelsTable.PerformLayout();
            this.groupBoxEditImage.ResumeLayout(false);
            this.groupBoxImageInformation.ResumeLayout(false);
            this.groupBoxImageInformation.PerformLayout();
            this.groupBoxForFile.ResumeLayout(false);
            this.groupBoxForImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialogFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialogFile;
        private System.Windows.Forms.Button buttonCreateNewGrid;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonRedo;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.NumericUpDown numericUpDownColumns;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox textBoxImageInformation;
        private System.Windows.Forms.GroupBox groupBoxEditImage;
        private System.Windows.Forms.GroupBox groupBoxImageInformation;
        private System.Windows.Forms.GroupBox groupBoxCreatePixelsTable;
        private System.Windows.Forms.GroupBox groupBoxForFile;
        private System.Windows.Forms.GroupBox groupBoxForImage;
        private System.Windows.Forms.PictureBox pictureBoxImage;
    }
}

