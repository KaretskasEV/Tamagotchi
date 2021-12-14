using System;
using System.Windows.Forms;

namespace ImageEditor
{
    sealed public class ManagingOfTextBox
    {
        private const int ResetValue = -1;

        private readonly TextBox _textBoxImageInformation;

        private int _numberString = ResetValue;

        public ManagingOfTextBox(FormMain formMain)
        {
            try
            {
                if (formMain == null)
                {
                    throw new NullReferenceException("formMain is null.");
                }

                _textBoxImageInformation = formMain.TextBoxImageInformation;
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }

        public void WriteTextInTextBox(string text)
        {
            try
            {
                if (_textBoxImageInformation == null)
                {
                    throw new NullReferenceException("_textBoxImageInformation is null.");
                }

                if (string.IsNullOrEmpty(text))
                {
                    throw new NullReferenceException("text is null or empty");
                }

                _numberString++;

                string stringOfInformation = Convert.ToString(_numberString) + ". " + text;

                LogFile.SaveSimpleMessage("Action", stringOfInformation, LogFile.DataRetention.NotSaveQuickly);

                _textBoxImageInformation.Text = stringOfInformation + "\r\n" + _textBoxImageInformation.Text;
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }

        public void DeleteLastStringOfTextBox() 
        {
            const int notFindString = -1;
            const int notPreviousString = -1;
            const int minusOneNumber = 1;
            const int startIndexText = 0;

            try
            {
                if (_textBoxImageInformation == null)
                {
                    throw new NullReferenceException("_textBoxImageInformation is null or \"\"");
                }

                string text = _textBoxImageInformation.Text;
                int endString = text.IndexOf("\r\n", StringComparison.CurrentCulture);
                text = text.Remove(endString, text.Length - endString);
                LogFile.SaveSimpleMessage("Cancel", text, LogFile.DataRetention.NotSaveQuickly);

                int previousNumberString = _numberString - minusOneNumber;

                if (previousNumberString == notPreviousString)
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
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }

        public void ClearTextInTextBox()
        {
            try
            {
                if (_textBoxImageInformation == null)
                {
                    throw new NullReferenceException("_textBoxImageInformation is null or \"\"");
                }

                _textBoxImageInformation.Text = string.Empty;
                _numberString = ResetValue;
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }
    }
}
