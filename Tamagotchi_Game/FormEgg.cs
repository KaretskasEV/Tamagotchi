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

namespace Tamagotchi_Game
{
    public partial class form_Egg : Form
    {
        private int mouseX = 0;
        private int mouseY = 0;

        public form_Egg()
        {
            InitializeComponent();
        }

        private void Form_Egg_Load(object sender, EventArgs e)
        {

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

        private void form_Egg_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            GraphicsPath formPath = new GraphicsPath();
            formPath.AddArc(0, 100, this.Width, this.Height-200, (float)0.0, (float)180.0);
            formPath.AddArc(0, 0, this.Width, this.Height, (float)0.0, (float)-180.0);
            Region formRegion = new Region(formPath);
            this.Region = formRegion;

            GraphicsPath buttonPath = new GraphicsPath();
            buttonPath.AddEllipse(2, 1, 30, 27);
            Region buttonRegion = new Region(buttonPath);
            this.buttonSelect.Region = buttonRegion;
            this.buttonDecide.Region = buttonRegion;
            this.buttonCancel.Region = buttonRegion;
            this.buttonReset.Region = buttonRegion;
            this.buttonExit.Region = buttonRegion;
        }
    }
}
