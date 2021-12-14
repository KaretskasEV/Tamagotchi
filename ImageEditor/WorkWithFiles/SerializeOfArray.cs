using System;
using System.IO;
using System.Security;
using System.Windows.Forms;
using ProtoBuf;

namespace ImageEditor
{
    public sealed class SerializeOfArray
    {
        private readonly SaveFileDialog _saveFileDialog;

        public SerializeOfArray(FormMain formMain)
        {
            try
            {
                if (formMain == null)
                {
                    throw new NullReferenceException("formMain is null.");
                }

                _saveFileDialog = formMain.SaveFileDialog;
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }

        public void SaveFile(bool[,] arrayCells)
        {
            try
            {
                if (arrayCells == null)
                {
                    throw new NullReferenceException("arrayCells is null");
                }

                if (_saveFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    LogFile.SaveSimpleMessage("Action", "Saving the file has been canceled.", LogFile.DataRetention.NotSaveQuickly);
                    return;
                }

                string fileName = _saveFileDialog.FileName;
                if (fileName == string.Empty)
                {
                    throw new NullReferenceException("fileName is empty");
                }

                using (FileStream fileStream = File.Open(fileName, FileMode.OpenOrCreate))
                {
                    Pixel[] pixels = ArrayTransoformation.ArrayInPixels(arrayCells);
                    Serializer.Serialize(fileStream, pixels);
                }
            }
            catch (ArgumentNullException error)
            {
                LogFile.SaveErrorMessage(error);
            }
            catch (ArgumentOutOfRangeException error)
            {
                LogFile.SaveErrorMessage(error);
            }
            catch (ArgumentException error)
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
            catch (FileNotFoundException error)
            {
                LogFile.SaveErrorMessage(error);
            }
            catch (IOException error)
            {
                LogFile.SaveErrorMessage(error);
            }
            catch (UnauthorizedAccessException error)
            {
                LogFile.SaveErrorMessage(error);
            }
            catch (NotSupportedException error)
            {
                LogFile.SaveErrorMessage(error);
            }
            catch (SecurityException error)
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
        }
    }
}
