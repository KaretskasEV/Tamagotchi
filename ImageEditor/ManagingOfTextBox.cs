using System;
using System.Windows.Forms;

namespace ImageEditor
{
    public static class ManagingOfTextBox
    {
        private const int ResetValue = -1;
        private static int _numberString = ResetValue;
        private static TextBox _textBoxImageInformation;
        private static ImageOutput _imageOutputPictureBox;

        public static ImageOutput ImageOutputPicture
        {
            set
            {
                if (value != null)
                {
                    _imageOutputPictureBox = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static TextBox TextBoxImageInformation
        {
            set
            {
                if (value != null)
                {
                    _textBoxImageInformation = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static void WriteTextInTextBox(string text)
        {
            if (_textBoxImageInformation == null)
            {
                throw new NullReferenceException();
            }

            if (string.IsNullOrEmpty(text))
            {
                throw new NullReferenceException();
            }

            _numberString++;
            _textBoxImageInformation.Text = Convert.ToString(_numberString) + ". " + 
                                            text + "\r\n" + _textBoxImageInformation.Text;
        }

        public static void DeleteLastStringOfTextBox()
        {
            if (_textBoxImageInformation == null)
            {
                throw new NullReferenceException();
            }

            const int notFindString = -1;
            const int notPreviousString = -1;

            int numberString = _numberString;
            string stringForFind = Convert.ToString(numberString) + ".";

            if (numberString == notPreviousString)
            {
                return;
            }

            int numberFindOfString = _textBoxImageInformation.Text.LastIndexOf(stringForFind, StringComparison.CurrentCulture);

            if (numberFindOfString != notFindString)
            {
                _textBoxImageInformation.Text = _textBoxImageInformation.Text.Remove(numberFindOfString);
            }
            else
            {
                return;
            }

            _numberString--;
        }

        public static void ClearTextInTextBox()
        {
            if (_textBoxImageInformation == null)
            {
                throw new NullReferenceException();
            }

            _textBoxImageInformation.Text = "";
            _numberString = ResetValue;
        }
    }
}
