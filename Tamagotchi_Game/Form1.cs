using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tamagotchi_Game
{
    public partial class Form_Egg : Form
    {
        private int MouseX = 0;
        private int MouseY = 0;

        public Form_Egg()
        {
            InitializeComponent();
        }

        private void Form_Egg_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath Form_Path = new System.Drawing.Drawing2D.GraphicsPath();
            //Form_Path.AddArc();
            Form_Path.AddArc(0, 100, this.Width, this.Height-200, (float)0.0, (float)180.0);
            Form_Path.AddArc(0, 0, this.Width, this.Height, (float)0.0, (float)-180.0);
            Region Form_Region = new Region(Form_Path);
            this.Region = Form_Region;
        }

        private void Form_Egg_MouseDown(object sender, MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
        }

        private void Form_Egg_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - MouseX), this.Location.Y + (e.Y - MouseY));
            }
        }
    }
}
