using System;
using System.Windows.Forms;

namespace ImageEditor
{
    public static class ManagingOfTextBox
    {
        private const int ResetValue = -1;
        private static int _numberString = ResetValue;
        private static TextBox _textBoxImageInformation;

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

            string stringOfInformation = Convert.ToString(_numberString) + ". " + text + "\r\n";

            _textBoxImageInformation.Text = stringOfInformation + _textBoxImageInformation.Text;
        }

        public static void DeleteLastStringOfTextBox()
        {
            if (_textBoxImageInformation == null)
            {
                throw new NullReferenceException();
            }

            const int notFindString = -1;
            const int notPreviousString = -1;
            const int minusOneNumber = 1;
            const int startIndexText = 0;

            int previousNumberString = _numberString - minusOneNumber;

            if(previousNumberString == notPreviousString)
            {
                _numberString = notPreviousString;
                ClearTextInTextBox();
                return;
            }

            string stringForFind = Convert.ToString(previousNumberString) + ".";
            int numberFindOfString = _textBoxImageInformation.Text.IndexOf(stringForFind, StringComparison.CurrentCulture);

            if (numberFindOfString != notFindString)
            {
                _textBoxImageInformation.Text = _textBoxImageInformation.Text.Remove(startIndexText, numberFindOfString);
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

        public static void CheckForRecord(string text)
        {
            if (ManagingOfButtons.UndoIsPress == false)
            {
                WriteTextInTextBox(text);
            }
        }
    }
}
