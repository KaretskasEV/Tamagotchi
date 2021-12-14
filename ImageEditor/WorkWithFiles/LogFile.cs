using System;
using System.IO;
using System.Windows.Forms;

namespace ImageEditor
{
    public static class LogFile
    {
        public enum DataRetention { SaveQuickly, NotSaveQuickly }

        private const int ResetValue = -1;
        private const int maximumNumberOfEntries = 100;

        private static readonly string[] _arrayLog = new string[maximumNumberOfEntries];
        private static string _path;
        private static int _itemOperation = ResetValue;
        private static int _itemArrayLog = ResetValue;

        public static void CreateFileLog(string fileName)
        {
            if((fileName == null) | (fileName == string.Empty))
            {
                MessageBox.Show("FileName is null or empty.");
                return;
            }
            else
            {
                if(!fileName.Contains(".txt", StringComparison.CurrentCulture))
                {
                    MessageBox.Show("The string has no file extension.");
                    return;
                }
            }

            _path = fileName;

            try
            {
                using (var createFile = new StreamWriter(File.Create(fileName)))
                {
                    createFile.WriteLine("----------------------------------- Log File -----------------------------------\r\n");
                    createFile.Close();
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("The caller does not have the required permission.\r\n" +
                    "-or- path specified a file that is read-only.\r\n" +
                    "-or- path specified a file that is hidden. \r\n" , "Error!!!");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Path is null.", "Error!!!");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Path is a zero-length string, contains only white space, " +
                    "or contains one or more invalid characters.", "Error!!!");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("The specified path, file name, or both " +
                    "exceed the system-defined maximum length.", "Error!!!");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("The specified path is invalid.", "Error!!!");
            }
            catch (IOException)
            {
                MessageBox.Show("An I/O error occurred while opening the file.", "Error!!!");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Path is in an invalid format.", "Error!!!");
            }
        }

        private static void SaveFile(string fileName, string[] text)
        {
            if(text == null)
            {
                MessageBox.Show("Array is null.");
                return;
            }

            try
            {
                using (var saveOfText = new StreamWriter(File.Open(fileName, FileMode.Append)))
                {
                    for (int item = 0; item < text.Length; item++)
                    {
                        if(string.IsNullOrEmpty(text[item]) == false)
                        {
                            saveOfText.WriteLine(text[item]);
                        }
                    }

                    saveOfText.Close();
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Path is null.", "Error!!!");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Mode specified an invalid value.", "Error!!!");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Path is a zero-length string, contains only white space, " +
                    "or contains one or more invalid characters.", "Error!!!");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("The specified path, file name, or both " +
                    "exceed the system-defined maximum length.", "Error!!!");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("The specified path is invalid.", "Error!!!");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file specified in path was not found.", "Error!!!");
            }
            catch (IOException)
            {
                MessageBox.Show("An I/O error occurred while opening the file.", "Error!!!");
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Path specified a file that is read-only.\r\n" +
                    "-or- This operation is not supported on the current platform. \r\n" +
                    "-or- path specified a directory. \r\n" +
                    "-or- The caller does not have the required permission. \r\n" +
                    "-or- mode is Create and the specified file is a hidden file.", "Error!!!");
            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Path is in an invalid format.", "Error!!!");
            }
            catch (Exception error)
            {
                MessageBox.Show($"Message: {error.Message};\r\n\r\n Source: {error.Source};\r\n\r\n " +
                    $"StackTrace: {error.StackTrace};\r\n\r\n TargetSite: {error.TargetSite}.", "Error!!!");
            }
        }

        public static void SaveSimpleMessage(string typeOfTransaction, string text, DataRetention dataProstration)
        {
            const int resetCount = 0;
            const int maximumCharactersInString = 15;

            string stringItemOperation, stringDateTime;

            if(text == null)
            {
                MessageBox.Show("'text' is null.", "Error!!!");
                return;
            }
            else if(typeOfTransaction == null)
            {
                MessageBox.Show("'typeOfTransaction' is null.", "Error!!!");
                return;
            }

            if (typeOfTransaction.Length >= maximumCharactersInString)
            {
                MessageBox.Show("'typeOfTransaction' is more than 15 characters.", "Error!!!");
                return;
            }

            _itemArrayLog++;
            _itemOperation++;

            if (_itemArrayLog == maximumNumberOfEntries)
            {
                _itemArrayLog = resetCount;
                SaveFile(_path, _arrayLog);
                Array.Clear(_arrayLog, resetCount, _arrayLog.Length);
            }
            
            stringDateTime = $"[{DateTime.Now}]--";
            stringItemOperation = _itemOperation.ToString() + ")";
            stringItemOperation = stringItemOperation.PadRight(maximumCharactersInString, '-');
            typeOfTransaction = typeOfTransaction.PadRight(maximumCharactersInString, '-');

            _arrayLog[_itemArrayLog] = stringItemOperation + stringDateTime + typeOfTransaction + text;

            if(dataProstration == DataRetention.SaveQuickly)
            {
                SaveFile(_path, _arrayLog);
                Array.Clear(_arrayLog, resetCount, _arrayLog.Length);
            }
        }

        public static void SaveErrorMessage(Exception objectError)
        {
            string errorMessage;

            errorMessage = "\r\nSource: " + objectError.Source + "\r\n";
            errorMessage += "Message: " + objectError.Message + "\r\n";
            errorMessage += "StackTrace: " + objectError.StackTrace + "\r\n";
            errorMessage += "TargetSite: " + objectError.TargetSite + "\r\n";

            SaveSimpleMessage("ERROR", errorMessage, DataRetention.SaveQuickly);
        }
    }
}
