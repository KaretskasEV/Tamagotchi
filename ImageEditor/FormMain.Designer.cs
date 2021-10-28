
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
            this.buttonCreateNewImage = new System.Windows.Forms.Button();
            this.openFileDialogFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogFile = new System.Windows.Forms.SaveFileDialog();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.groupBoxCreatePixelsTable = new System.Windows.Forms.GroupBox();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.groupBoxEditImage = new System.Windows.Forms.GroupBox();
            this.buttonRedo = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.groupBoxImageInformation = new System.Windows.Forms.GroupBox();
            this.textBoxImageInformation = new System.Windows.Forms.TextBox();
            this.groupBoxFile = new System.Windows.Forms.GroupBox();
            this.groupBoxImage = new System.Windows.Forms.GroupBox();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            this.groupBoxCreatePixelsTable.SuspendLayout();
            this.groupBoxEditImage.SuspendLayout();
            this.groupBoxImageInformation.SuspendLayout();
            this.groupBoxFile.SuspendLayout();
            this.groupBoxImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateNewImage
            // 
            this.buttonCreateNewImage.Location = new System.Drawing.Point(8, 71);
            this.buttonCreateNewImage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreateNewImage.Name = "buttonCreateNewImage";
            this.buttonCreateNewImage.Size = new System.Drawing.Size(138, 33);
            this.buttonCreateNewImage.TabIndex = 1;
            this.buttonCreateNewImage.Text = "Create new Image";
            this.buttonCreateNewImage.UseVisualStyleBackColor = true;
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
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(7, 27);
            this.buttonUndo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(62, 33);
            this.buttonUndo.TabIndex = 4;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Location = new System.Drawing.Point(31, 34);
            this.numericUpDownX.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownX.Maximum = new decimal(new int[] {
            35,
            0,
            0,
            0});
            this.numericUpDownX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(37, 23);
            this.numericUpDownX.TabIndex = 5;
            this.numericUpDownX.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Location = new System.Drawing.Point(100, 34);
            this.numericUpDownY.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownY.Maximum = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.numericUpDownY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(37, 23);
            this.numericUpDownY.TabIndex = 6;
            this.numericUpDownY.Value = new decimal(new int[] {
            17,
            0,
            0,
            0});
            // 
            // groupBoxCreatePixelsTable
            // 
            this.groupBoxCreatePixelsTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupBoxCreatePixelsTable.Controls.Add(this.labelY);
            this.groupBoxCreatePixelsTable.Controls.Add(this.numericUpDownY);
            this.groupBoxCreatePixelsTable.Controls.Add(this.labelX);
            this.groupBoxCreatePixelsTable.Controls.Add(this.numericUpDownX);
            this.groupBoxCreatePixelsTable.Controls.Add(this.buttonCreateNewImage);
            this.groupBoxCreatePixelsTable.Location = new System.Drawing.Point(13, 413);
            this.groupBoxCreatePixelsTable.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxCreatePixelsTable.Name = "groupBoxCreatePixelsTable";
            this.groupBoxCreatePixelsTable.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxCreatePixelsTable.Size = new System.Drawing.Size(153, 111);
            this.groupBoxCreatePixelsTable.TabIndex = 7;
            this.groupBoxCreatePixelsTable.TabStop = false;
            this.groupBoxCreatePixelsTable.Text = "Create pixels table:";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(68, 36);
            this.labelY.Margin = new System.Windows.Forms.Padding(0);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(32, 16);
            this.labelY.TabIndex = 9;
            this.labelY.Text = " - Y:";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(12, 36);
            this.labelX.Margin = new System.Windows.Forms.Padding(0);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(19, 16);
            this.labelX.TabIndex = 8;
            this.labelX.Text = "X:";
            // 
            // groupBoxEditImage
            // 
            this.groupBoxEditImage.Controls.Add(this.buttonRedo);
            this.groupBoxEditImage.Controls.Add(this.buttonClear);
            this.groupBoxEditImage.Controls.Add(this.buttonUndo);
            this.groupBoxEditImage.Location = new System.Drawing.Point(173, 413);
            this.groupBoxEditImage.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxEditImage.Name = "groupBoxEditImage";
            this.groupBoxEditImage.Size = new System.Drawing.Size(150, 111);
            this.groupBoxEditImage.TabIndex = 8;
            this.groupBoxEditImage.TabStop = false;
            this.groupBoxEditImage.Text = "Edit Image";
            // 
            // buttonRedo
            // 
            this.buttonRedo.Location = new System.Drawing.Point(82, 27);
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Size = new System.Drawing.Size(62, 33);
            this.buttonRedo.TabIndex = 9;
            this.buttonRedo.Text = "Redo";
            this.buttonRedo.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(7, 72);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(138, 33);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // groupBoxImageInformation
            // 
            this.groupBoxImageInformation.Controls.Add(this.textBoxImageInformation);
            this.groupBoxImageInformation.Location = new System.Drawing.Point(329, 413);
            this.groupBoxImageInformation.Name = "groupBoxImageInformation";
            this.groupBoxImageInformation.Size = new System.Drawing.Size(285, 111);
            this.groupBoxImageInformation.TabIndex = 9;
            this.groupBoxImageInformation.TabStop = false;
            this.groupBoxImageInformation.Text = "Image information";
            // 
            // textBoxImageInformation
            // 
            this.textBoxImageInformation.Location = new System.Drawing.Point(6, 27);
            this.textBoxImageInformation.Multiline = true;
            this.textBoxImageInformation.Name = "textBoxImageInformation";
            this.textBoxImageInformation.ReadOnly = true;
            this.textBoxImageInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxImageInformation.Size = new System.Drawing.Size(273, 76);
            this.textBoxImageInformation.TabIndex = 10;
            this.textBoxImageInformation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxFile
            // 
            this.groupBoxFile.Controls.Add(this.buttonSaveImage);
            this.groupBoxFile.Controls.Add(this.buttonLoadImage);
            this.groupBoxFile.Location = new System.Drawing.Point(620, 413);
            this.groupBoxFile.Name = "groupBoxFile";
            this.groupBoxFile.Size = new System.Drawing.Size(152, 111);
            this.groupBoxFile.TabIndex = 10;
            this.groupBoxFile.TabStop = false;
            this.groupBoxFile.Text = "File";
            // 
            // groupBoxImage
            // 
            this.groupBoxImage.Controls.Add(this.pictureBoxImage);
            this.groupBoxImage.Location = new System.Drawing.Point(12, 12);
            this.groupBoxImage.Name = "groupBoxImage";
            this.groupBoxImage.Size = new System.Drawing.Size(760, 394);
            this.groupBoxImage.TabIndex = 11;
            this.groupBoxImage.TabStop = false;
            this.groupBoxImage.Text = "Image";
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(11, 22);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(738, 360);
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 535);
            this.Controls.Add(this.groupBoxImage);
            this.Controls.Add(this.groupBoxFile);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            this.groupBoxCreatePixelsTable.ResumeLayout(false);
            this.groupBoxCreatePixelsTable.PerformLayout();
            this.groupBoxEditImage.ResumeLayout(false);
            this.groupBoxImageInformation.ResumeLayout(false);
            this.groupBoxImageInformation.PerformLayout();
            this.groupBoxFile.ResumeLayout(false);
            this.groupBoxImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonCreateNewImage;
        private System.Windows.Forms.OpenFileDialog openFileDialogFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialogFile;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.GroupBox groupBoxCreatePixelsTable;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.GroupBox groupBoxEditImage;
        private System.Windows.Forms.Button buttonRedo;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.GroupBox groupBoxImageInformation;
        private System.Windows.Forms.TextBox textBoxImageInformation;
        private System.Windows.Forms.GroupBox groupBoxFile;
        private System.Windows.Forms.GroupBox groupBoxImage;
        private System.Windows.Forms.PictureBox pictureBoxImage;
    }
}

