using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tamagotchi_Game
{
    sealed class DownloadImage
    {
        private enum move
        {
            next,
            previous
        }

        private Iterator iteratorButton;
        private Iterator iteratorIcon;
        private string[] stringLocation = new string[2];
        private string[] stringLocationIcon = new string[16];

        public DownloadImage()
        {
            stringLocation[0] = @"Image/Button/ButtonDown.png";
            stringLocation[1] = @"Image/Button/ButtonUp.png";

            stringLocationIcon[0] = @"Image/Icon/EatAct.png";
            stringLocationIcon[1] = @"Image/Icon/EatBackGround.png";
            stringLocationIcon[2] = @"Image/Icon/LightAct.png";
            stringLocationIcon[3] = @"Image/Icon/LightBackGround.png";
            stringLocationIcon[4] = @"Image/Icon/GameAct.png";
            stringLocationIcon[5] = @"Image/Icon/GameBackGround.png";
            stringLocationIcon[6] = @"Image/Icon/CureAct.png";
            stringLocationIcon[7] = @"Image/Icon/CureBackGround.png";
            stringLocationIcon[8] = @"Image/Icon/CleanAct.png";
            stringLocationIcon[9] = @"Image/Icon/CleanBackGround.png";
            stringLocationIcon[10] = @"Image/Icon/InformationAct.png";
            stringLocationIcon[11] = @"Image/Icon/InformationBackGround.png";
            stringLocationIcon[12] = @"Image/Icon/EducationAct.png";
            stringLocationIcon[13] = @"Image/Icon/EducationBackGround.png";
            stringLocationIcon[14] = @"Image/Icon/HappenAct.png";
            stringLocationIcon[15] = @"Image/Icon/HappenBackGround.png";

            move

            iteratorButton = new Iterator(stringLocation);
            iteratorIcon = new Iterator(stringLocationIcon);
        }

        private object MoveItem(IEnumerator newItem, )
        {
            if (newItem.MoveNext() == false)
            {
                newItem.Reset();
                newItem.MoveNext();
            }

            return newItem.Current;
        } 

        public void ChangeImageButton(MouseButtons leftButton, PictureBox pictureButton)
        {
            if (pictureButton == null)
            {
                MessageBox.Show(@"Reference pictureButton = null", @"Error");
                return;
            }

            if (MouseButtons.Left != leftButton)
            {
                return;
            }

            string locationFile = (string) MoveItem(iteratorButton);
            
            try
            {
                pictureButton.Load(locationFile);
            }
            catch(InvalidOperationException error)
            {
                MessageBox.Show(@"ImageLocation is null", @"Error");
            }
        }

        public void changeImageIcon(MouseButtons leftButton, PictureBox[] pictureIcon)
        {
            if (MouseButtons.Left != leftButton)
            {
                return;
            }

            MoveItem(iteratorIcon);

            try
            {
                
            }
            catch (NullReferenceException error)
            {
                MessageBox.Show(@"Array PictureIcon is null", @"Error");
            }
        }
    }
}