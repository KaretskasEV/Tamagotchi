using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TamagotchiGame
{
    public partial class FormEgg : Form
    {
        private int _mouseX;
        private int _mouseY;
        private readonly WorkWithImage _changeImage;
        private readonly PictureBox[] _arrayPictureBoxIcons  = new PictureBox[7];

        public FormEgg()
        {
            InitializeComponent();
            
            _arrayPictureBoxIcons[0] = pictureBoxEat;
            _arrayPictureBoxIcons[1] = pictureBoxLight;
            _arrayPictureBoxIcons[2] = pictureBoxGame;
            _arrayPictureBoxIcons[3] = pictureBoxCure;
            _arrayPictureBoxIcons[4] = pictureBoxClear;
            _arrayPictureBoxIcons[5] = pictureBoxInformation;
            _arrayPictureBoxIcons[6] = pictureBoxEducation;

            _changeImage = new WorkWithImage(_arrayPictureBoxIcons);
        }

        private void Form_Egg_Load(object sender, EventArgs e)
        {
            var formPath = new GraphicsPath();
            formPath.AddArc(0, 100, this.Width, this.Height-200, (float)0.0, (float)180.0);
            formPath.AddArc(0, 0, this.Width, this.Height, (float)0.0, (float)-180.0);
            var formRegion = new Region(formPath);
            this.Region = formRegion;
        }

        private void Form_Egg_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseX = e.X;
            _mouseY = e.Y;
        }

        private void Form_Egg_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + (e.X - _mouseX), this.Location.Y + (e.Y - _mouseY));
            }
        }

        private void PictureBoxButtonSelect_MouseDown(object sender, MouseEventArgs e)
        {
            _changeImage.ChangePictureBox(sender, e.Button, WorkWithImage.SelectIterator.ForButton);
        }

        private void PictureBoxButtonSelect_MouseUp(object sender, MouseEventArgs e)
        {
            _changeImage.ChangePictureBox(sender, e.Button, WorkWithImage.SelectIterator.ForButton);
            _changeImage.NextIcon();
        }

        private void PictureBoxButtonDecide_MouseDown(object sender, MouseEventArgs e)
        {
            _changeImage.ChangePictureBox(sender, e.Button, WorkWithImage.SelectIterator.ForButton);
        }

        private void PictureBoxButtonDecide_MouseUp(object sender, MouseEventArgs e)
        {
            _changeImage.ChangePictureBox(sender, e.Button, WorkWithImage.SelectIterator.ForButton);
        }

        private void PictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
        {
            _changeImage.ChangePictureBox(sender, e.Button, WorkWithImage.SelectIterator.ForButton);
        }

        private void PictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
        {
            _changeImage.ChangePictureBox(sender, e.Button, WorkWithImage.SelectIterator.ForButton);
        }

        private void PictureBoxButtonReset_MouseDown(object sender, MouseEventArgs e)
        {
            _changeImage.ChangePictureBox(sender, e.Button, WorkWithImage.SelectIterator.ForButton);
        }

        private void PictureBoxButtonReset_MouseUp(object sender, MouseEventArgs e)
        {
            _changeImage.ChangePictureBox(sender, e.Button, WorkWithImage.SelectIterator.ForButton);
        }

        private void PictureBoxButtonExit_MouseDown(object sender, MouseEventArgs e)
        {
            _changeImage.ChangePictureBox(sender, e.Button, WorkWithImage.SelectIterator.ForButton);
        }

        private void PictureBoxButtonExit_MouseUp(object sender, MouseEventArgs e)
        {
            _changeImage.ChangePictureBox(sender, e.Button, WorkWithImage.SelectIterator.ForButton);

            this.Close();
        }
    }
}
