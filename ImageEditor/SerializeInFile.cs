using System;
using System.Windows.Forms;
using System.IO;
using System.Security;
using ProtoBuf;

namespace ImageEditor
{
    public static class SerializeInFile
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
                    Pixel[] pixels = Transoformation.ArrayInPixels(arrayCells);
                    Serializer.Serialize(fileStream, pixels);
                }
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Path have mean null.");
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException("mode specifies an invalid value.");
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("String is empty string.");
            }
            catch (PathTooLongException)
            {
                throw new PathTooLongException("The specified path, file name, or both exceed " +
                    "the maximum length specified by the system.");
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("Path is invalid.");
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The file specified by the path parameter was not found.");
            }
            catch (IOException)
            {
                throw new IOException("An I/O error occurred while opening the file.");
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("The caller does not have the required permission.");
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("Path was specified in an invalid format.");
            }
            catch (SecurityException)
            {
                throw new SecurityException("The caller does not have the required permission.");
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while opening the file.");
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
                    ArrayResult = Transoformation.PixelsInArray(pixels);
                }
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("Path have mean null.");
            }
            catch (PathTooLongException)
            {
                throw new PathTooLongException("The specified path, file name, or both exceed " +
                    "the maximum length specified by the system.");
            }
            catch(DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException("Path is invalid.");
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("The caller does not have the required permission.");
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The file specified by the path parameter was not found.");
            }
            catch (NotSupportedException)
            {
                throw new NotSupportedException("Path was specified in an invalid format.");
            }
            catch (Exception)
            {
                throw new Exception("An error occurred while opening the file.");
            }

            return ArrayResult;
        }
    }
}
