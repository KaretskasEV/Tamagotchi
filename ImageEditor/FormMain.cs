using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class FormMain : Form
    {
        private DrawInImage _drawInInImage;
        private int _columns, _rows;

        public FormMain()
        {
            InitializeComponent();
            
            _drawInInImage = new DrawInImage(pictureBoxImage);
            _columns = (int)numericUpDownColumns.Value;
            _rows = (int)numericUpDownRows.Value;

            _drawInInImage.CreateGrid(_columns, _rows, Color.Red);
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            _rows = (int)numericUpDownRows.Value;
            _drawInInImage.CreateGrid(_columns, _rows, Color.Red);
        }

        private void numericUpDownColumns_ValueChanged(object sender, EventArgs e)
        {
            _columns = (int)numericUpDownColumns.Value;
            _drawInInImage.CreateGrid(_columns, _rows, Color.Red);
        }

        private void pictureBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            _drawInInImage.CreateSquareWithHatch(e.Location, Color.Black, Color.White);
        }

        private void pictureBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            _drawInInImage.CreateSquareFill(e.Location, Color.Black, true);
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            object obj = pictureBoxImage.Parent;
            GroupBox groupBox = (GroupBox)obj;

            textBoxImageInformation.Text = groupBox.Text;
        }
    }
}
