using System;
using System.IO;
using System.Windows.Forms;
using ProtoBuf;

namespace ImageEditor
{
    public sealed class DeserializeOfArray
    {
        private readonly OpenFileDialog _openFileDialog;

        public DeserializeOfArray(FormMain formMain)
        {
            try
            {
                if (formMain == null)
                {
                    throw new NullReferenceException("formMain is null.");
                }

                _openFileDialog = formMain.OpenFileDialog;
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }
        public bool[,] ReadFile()
        {
            bool[,] ArrayResult = null;

            try
            {
                if (_openFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    LogFile.SaveSimpleMessage("Action", "Read the file has been canceled.", LogFile.DataRetention.NotSaveQuickly);
                    return ArrayResult;
                }

                string fileName = _openFileDialog.FileName;
                if (fileName == string.Empty)
                {
                    throw new NullReferenceException("fileName is empty");
                }

                using (FileStream fileStream = File.OpenRead(fileName))
                {
                    Pixel[] pixels = Serializer.Deserialize<Pixel[]>(fileStream);
                    ArrayResult = ArrayTransoformation.PixelsInArray(pixels);
                }
            }
            catch (ArgumentNullException error)
            {
                LogFile.SaveErrorMessage(error);
            }
            catch (PathTooLongException error)
            {
                LogFile.SaveErrorMessage(error);
            }
            catch (DirectoryNotFoundException error)
            {
                LogFile.SaveErrorMessage(error);
            }
            catch (UnauthorizedAccessException error)
            {
                LogFile.SaveErrorMessage(error);
            }
            catch (FileNotFoundException error)
            {
                LogFile.SaveErrorMessage(error);
            }
            catch (NotSupportedException error)
            {
                LogFile.SaveErrorMessage(error);
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
            catch (Exception error)
            {
                LogFile.SaveErrorMessage(error);
            }

            return ArrayResult;
        }
    }
}
