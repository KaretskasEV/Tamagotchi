using System;
using System.Windows.Forms;
using System.IO;
using System.Security;
using ProtoBuf;

namespace ImageEditor
{
    public static class SerializeOfArrayInFile
    {
        private static OpenFileDialog _openFileDialog;
        private static SaveFileDialog _saveFileDialog;

        public static OpenFileDialog OpenFileDialog
        {
            set
            {
                if(value != null)
                {
                    _openFileDialog = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static SaveFileDialog SaveFileDialog
        {
            set
            {
                if( value != null)
                {
                    _saveFileDialog = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static void SaveFile(bool[,] arrayCells)
        {
            if(arrayCells == null) { return; }

            if(_saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            string fileName = _saveFileDialog.FileName;

            if(fileName == "")
            {
                MessageBox.Show("To save the image, write a name for the file.", "Notification!");
            }

            try
            {
                using(FileStream fileStream = File.Open(fileName, FileMode.OpenOrCreate))
                {
                    Pixel[] pixels = ArrayTransoformation.ArrayInPixels(arrayCells);
                    Serializer.Serialize(fileStream, pixels);
                }
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Path is null.");
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException("Mode specified an invalid value.");
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Path is a zero-length string, contains only white space, " +
                    "or contains one or more invalid characters.");
            }
            catch (PathTooLongException)
            {
                throw new PathTooLongException("The specified path, file name, or both " +
                    "exceed the system-defined maximum length.");
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("The specified path is invalid.");
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The file specified in path was not found.");
            }
            catch (IOException)
            {
                throw new IOException("An I/O error occurred while opening the file.");
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("Path specified a file that is read-only.\r\n" +
                    "-or- This operation is not supported on the current platform. \r\n" +
                    "-or- path specified a directory. \r\n" +
                    "-or- The caller does not have the required permission. \r\n" +
                    "-or- mode is Create and the specified file is a hidden file.");
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("Path is in an invalid format.");
            }
            catch (SecurityException)
            {
                throw new SecurityException("The caller does not have the required permission.");
            }
            catch (Exception error)
            {
                throw new Exception($"Message: {error.Message};\r\n\r\n Source: {error.Source};\r\n\r\n " +
                    $"StackTrace: {error.StackTrace};\r\n\r\n TargetSite: {error.TargetSite}.");
            }
        }

        public static bool[,] ReadFile()
        {
            bool[,] ArrayResult = null;

            if (_openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return ArrayResult;
            }

            string fileName = _openFileDialog.FileName;

            if (fileName == "")
            {
                MessageBox.Show("To save the image, write a name for the file.", "Notification!");
            }

            try
            {
                using (FileStream fileStream = File.OpenRead(fileName))
                {
                    Pixel[] pixels = Serializer.Deserialize<Pixel[]>(fileStream);
                    ArrayResult = ArrayTransoformation.PixelsInArray(pixels);
                }
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Path is null.");
            }
            catch (PathTooLongException)
            {
                throw new PathTooLongException("The specified path, file name, or both " +
                    "exceed the system-defined maximum length.");
            }
            catch(DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("The specified path is invalid.");
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("Path specified a file that is read-only.\r\n" +
                    "-or- This operation is not supported on the current platform. \r\n" +
                    "-or- path specified a directory. \r\n" +
                    "-or- The caller does not have the required permission. \r\n" +
                    "-or- mode is Create and the specified file is a hidden file.");
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The file specified in path was not found.");
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("Path is in an invalid format.");
            }
            catch (Exception error)
            {
                throw new Exception($"Message: {error.Message};\r\n\r\n Source: {error.Source};\r\n\r\n " +
                    $"StackTrace: {error.StackTrace};\r\n\r\n TargetSite: {error.TargetSite}.");
            }

            return ArrayResult;
        }
    }
}
