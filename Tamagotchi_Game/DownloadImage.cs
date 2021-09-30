using System;
using System.Windows.Forms;

namespace Tamagotchi_Game
{
    sealed class DownloadImage
    {
        private readonly Iterator<PictureBox> _iteratorPictureBox;
        private readonly Iterator<string> _iteratorButton;
        private readonly Iterator<string> _iteratorIconAct;
        private readonly Iterator<string> _iteratorIconBackGround;
        private readonly string[] _stringLocation = new string[2];
        private readonly string[] _stringLocationIconAct= new string[7];
        private readonly string[] _stringLocationIconBackGround = new string[7];
        private readonly PictureBox[] _arrayPictureBoxIcons;
        private bool _lastItemIcon;

        public DownloadImage(PictureBox[] pictureBoxIcons)
        {
            _stringLocation[0] = @"Image/Button/ButtonDown.png";
            _stringLocation[1] = @"Image/Button/ButtonUp.png";

            _stringLocationIconAct[0] = @"Image/Icon/ЕatAct.png";
            _stringLocationIconAct[1] = @"Image/Icon/LightAct.png";
            _stringLocationIconAct[2] = @"Image/Icon/GameAct.png";
            _stringLocationIconAct[3] = @"Image/Icon/CureAct.png";
            _stringLocationIconAct[4] = @"Image/Icon/CleanAct.png";
            _stringLocationIconAct[5] = @"Image/Icon/InformationAct.png";
            _stringLocationIconAct[6] = @"Image/Icon/EducationAct.png";
            
            _stringLocationIconBackGround[0] = @"Image/Icon/ЕatBackGround.png";
            _stringLocationIconBackGround[1] = @"Image/Icon/LightBackGround.png";
            _stringLocationIconBackGround[2] = @"Image/Icon/GameBackGround.png";
            _stringLocationIconBackGround[3] = @"Image/Icon/CureBackGround.png";
            _stringLocationIconBackGround[4] = @"Image/Icon/CleanBackGround.png";
            _stringLocationIconBackGround[5] = @"Image/Icon/InformationBackGround.png";
            _stringLocationIconBackGround[6] = @"Image/Icon/EducationBackGround.png";
            //stringLocationIcon[14] = @"Image/Icon/HappenAct.png";
            //stringLocationIcon[15] = @"Image/Icon/HappenBackGround.png";

            _arrayPictureBoxIcons = pictureBoxIcons;

            _iteratorButton = new Iterator<string> (_stringLocation);
            _iteratorIconAct = new Iterator<string> (_stringLocationIconAct);
            _iteratorIconBackGround = new Iterator<string>(_stringLocationIconBackGround);
            _iteratorPictureBox = new Iterator<PictureBox>(pictureBoxIcons);
        }

        private string NextItem(Iterator<string> newItem, int amount)
        {
            for (int item = 0; item < amount; item++)
            {
                if (newItem.MoveNext() == false)
                {
                    newItem.Reset();
                    newItem.MoveNext();
                }
            }

            return newItem.Current;
        }

        private PictureBox NextItem(Iterator<PictureBox> newItem, int amount)
        {
            for (int item = 0; item < amount; item++)
            {
                if (newItem.MoveNext() == false)
                {
                    newItem.Reset();
                    newItem.MoveNext();
                }
            }

            return newItem.Current;
        }

        //private string PreviousItem(Iterator<string> newItem)
        //{
        //    if (newItem.MovePrevious() == false)
        //    {
        //        return NextItem(newItem, 1);
        //    }
            
        //    return newItem.Current;
        //}

        private PictureBox PreviousItem(Iterator<PictureBox> newItem)
        {
            if (newItem.MovePrevious() == false)
            {
                return NextItem(newItem, 1);
            }

            return newItem.Current;
        }

        public void ChangeImageButton(PictureBox pictureButton)
        {
            if (pictureButton == null)
            {
                MessageBox.Show(@"Reference pictureButton = null", @"Error");
                return;
            }

            string locationFile = NextItem(_iteratorButton, 1);
            
            try
            {
                pictureButton.Load(locationFile);
            }
            catch(InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
        }

        public void ChangeImageIcon()
        {
            PictureBox currentPictureBox = _arrayPictureBoxIcons[0];
            string location;

            try
            {
                if (_lastItemIcon == false)
                {
                    currentPictureBox = NextItem(_iteratorPictureBox, 1);
                    location = NextItem(_iteratorIconAct, 1);
                    currentPictureBox.Load(location);
                }
                
                if (currentPictureBox.Equals(_arrayPictureBoxIcons[0]) == false)
                {
                    currentPictureBox = PreviousItem(_iteratorPictureBox);
                    location = NextItem(_iteratorIconBackGround, 1);
                    currentPictureBox.Load(location);
                    currentPictureBox = NextItem(_iteratorPictureBox, 1);

                    if (currentPictureBox.Equals(_arrayPictureBoxIcons[6]))
                    {
                        _lastItemIcon = true;
                        NextItem(_iteratorPictureBox, 1);
                    }
                }
                else
                {
                    if (_lastItemIcon)
                    {
                        currentPictureBox = NextItem(_iteratorPictureBox, 6);
                        location = NextItem(_iteratorIconBackGround, 1);
                        currentPictureBox.Load(location);
                        _lastItemIcon = false;
                    }
                }

            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
        }
    }
}