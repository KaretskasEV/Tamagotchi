using System;
using System.IO;
using System.Windows.Forms;

namespace TamagotchiGame
{
    sealed public class WorkWithImage
    {
        public enum SelectIterator { ForButton, ForIconHappen }

        private readonly Iterator<PictureBox> _iteratorPictureBox;
        private readonly Iterator<string> _iteratorButton;
        private readonly Iterator<string> _iteratorIconAct;
        private readonly Iterator<string> _iteratorIconBackGround;
        private readonly Iterator<string> _iteratorIconHappen;
        private readonly string[] _stringLocationButton = new string[2];
        private readonly string[] _stringLocationIconHappen = new string[2];
        private readonly string[] _stringLocationIconAct= new string[7];
        private readonly string[] _stringLocationIconBackGround = new string[7];
        private readonly PictureBox[] _arrayPictureBoxIcons;
        private PictureBox _lastPictureBox;
        private bool _lastItemIcon;

        public WorkWithImage(PictureBox[] pictureBoxIcons)
        {
            if (pictureBoxIcons == null)
            {
                throw new NullReferenceException();
            }

            _stringLocationButton[0] = @"Image/Button/ButtonDown.png";
            _stringLocationButton[1] = @"Image/Button/ButtonUp.png";

            _stringLocationIconHappen[0] = @"Image/Icon/HappenAct.png";
            _stringLocationIconHappen[1] = @"Image/Icon/HappenBackGround.png";

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

            _arrayPictureBoxIcons = pictureBoxIcons;

            _iteratorButton = new Iterator<string>(_stringLocationButton);
            _iteratorIconHappen = new Iterator<string>(_stringLocationIconHappen);
            _iteratorIconAct = new Iterator<string>(_stringLocationIconAct);
            _iteratorIconBackGround = new Iterator<string>(_stringLocationIconBackGround);
            _iteratorPictureBox = new Iterator<PictureBox>(pictureBoxIcons);
        }

        public void ChangePictureBox(Object currentObject, MouseButtons leftButton, SelectIterator selectIterator)
        {
            Iterator<string> currentIterator;

            if (MouseButtons.Left == leftButton)
            {
                if (currentObject is PictureBox)
                {
                    PictureBox currentPictureBox = currentObject as PictureBox;
                    currentIterator = SelectIteratorFromEnum(selectIterator);
                    string locationFile = NextItem(currentIterator);
                    LoadPictureBox(locationFile, currentPictureBox);
                }
                else
                {
                    MessageBox.Show(@"currentObject is null or currentObject " + 
                                    @"isn't PictureBox", @"Error");
                    throw new NullReferenceException();
                }
            }
        }

        private Iterator<string> SelectIteratorFromEnum(SelectIterator selectIterator)
        {
            Iterator<string> currentIterator;

            switch (selectIterator)
            {
                case SelectIterator.ForIconHappen:
                {
                    currentIterator = _iteratorIconHappen;
                    break;
                }
                default:
                {
                    currentIterator = _iteratorButton;
                    break;
                }
            }

            return currentIterator;
        }

        private string NextItem(Iterator<string> newItem)
        {
            if (newItem.MoveNext() == false)
            {
                newItem.Reset();
                newItem.MoveNext();
            }

            return newItem.Current;
        }

        private PictureBox NextItem(Iterator<PictureBox> newItem)
        {
            if (newItem.MoveNext() == false)
            {
                newItem.Reset();
                newItem.MoveNext();
            }

            return newItem.Current;
        }

        private PictureBox PreviousItem(Iterator<PictureBox> newItem)
        {
            if (newItem.MovePrevious() == false)
            {
                NextItem(newItem);
            }

            return newItem.Current;
        }

        public void NextIcon()
        {
            PictureBox currentPictureBox = _arrayPictureBoxIcons[0];
            string locationFile;

            if (_lastItemIcon == false)
            {
                currentPictureBox = NextItem(_iteratorPictureBox);
                locationFile = NextItem(_iteratorIconAct);
                LoadPictureBox(locationFile, currentPictureBox);
            }
                
            if (currentPictureBox.Equals(_arrayPictureBoxIcons[0]) == false)
            {
                currentPictureBox = PreviousItem(_iteratorPictureBox);
                locationFile = NextItem(_iteratorIconBackGround);
                LoadPictureBox(locationFile, currentPictureBox);
                currentPictureBox = NextItem(_iteratorPictureBox);

                if (currentPictureBox.Equals(_arrayPictureBoxIcons[6]))
                {
                    _lastItemIcon = true;
                    _lastPictureBox = currentPictureBox;
                }
            }
            else
            {
                if (_lastItemIcon)
                {
                    currentPictureBox = _lastPictureBox;
                    locationFile = NextItem(_iteratorIconBackGround);
                    LoadPictureBox(locationFile, currentPictureBox);
                    _lastItemIcon = false;
                }
            }
        }

        private void LoadPictureBox(string locationFile, PictureBox currentPictureBox)
        {
            try
            {
                currentPictureBox.Load(locationFile);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException();
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException();
            }
        }
    }
}