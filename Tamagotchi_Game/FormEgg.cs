using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace Tamagotchi_Game
{
    public partial class form_Egg : Form
    {
        private int mouseX;
        private int mouseY;
        private DownloadImage changeImage;
        private PictureBox[] arrayPictureBox;

        public form_Egg()
        {
            InitializeComponent();

            changeImage = new DownloadImage();

            arrayPictureBox = new PictureBox[7]
            {
                this.pictureBoxEat,
                this.pictureBoxLight,
                this.pictureBoxGame,
                this.pictureBoxCure,
                this.pictureBoxClear,
                this.pictureBoxInformation,
                this.pictureBoxEducation
            };
        }

        private void Form_Egg_Load(object sender, EventArgs e)
        {
            GraphicsPath formPath = new GraphicsPath();
            formPath.AddArc(0, 100, this.Width, this.Height-200, (float)0.0, (float)180.0);
            formPath.AddArc(0, 0, this.Width, this.Height, (float)0.0, (float)-180.0);
            Region formRegion = new Region(formPath);
            this.Region = formRegion;
        }

        private void Form_Egg_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void Form_Egg_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - mouseX), this.Location.Y + (e.Y - mouseY));
            }
        }

        private void pictureBoxButtonSelect_MouseDown(object sender, MouseEventArgs e)
        {
            changeImage.ChangeImageButton(e.Button, pictureBoxButtonSelect);
        }

        private void pictureBoxButtonSelect_MouseUp(object sender, MouseEventArgs e)
        {
            changeImage.ChangeImageButton(e.Button, pictureBoxButtonSelect);

            changeImage.changeImageIcon(e.Button, arrayPictureBox);
        }

        private void pictureBoxButtonDecide_MouseDown(object sender, MouseEventArgs e)
        {
            changeImage.ChangeImageButton(e.Button, pictureBoxButtonDecide);
        }

        private void pictureBoxButtonDecide_MouseUp(object sender, MouseEventArgs e)
        {
            changeImage.ChangeImageButton(e.Button, pictureBoxButtonDecide);
        }

        private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
        {
            changeImage.ChangeImageButton(e.Button, pictureBoxButtonCancel);
        }

        private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
        {
            changeImage.ChangeImageButton(e.Button, pictureBoxButtonCancel);
        }

        private void pictureBoxButtonReset_MouseDown(object sender, MouseEventArgs e)
        {
            changeImage.ChangeImageButton(e.Button, pictureBoxButtonReset);
        }

        private void pictureBoxButtonReset_MouseUp(object sender, MouseEventArgs e)
        {
            changeImage.ChangeImageButton(e.Button, pictureBoxButtonReset);
        }

        private void pictureBoxButtonExit_MouseDown(object sender, MouseEventArgs e)
        {
            changeImage.ChangeImageButton(e.Button, pictureBoxButtonExit);
        }

        private void pictureBoxButtonExit_MouseUp(object sender, MouseEventArgs e)
        {
            changeImage.ChangeImageButton(e.Button, pictureBoxButtonExit);
        }
    }
}
