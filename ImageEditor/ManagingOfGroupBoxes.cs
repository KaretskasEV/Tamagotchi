using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    public static class ManagingOfGroupBoxes
    {
        private static GroupBox _groupBoxCreatePixelsTable;
        private static GroupBox _groupBoxEditImage;
        private static GroupBox _groupBoxImageInformation;
        private static GroupBox _groupBoxForFile;
        private static GroupBox _groupBoxForImage;
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

        public static GroupBox GroupBoxCreatePixelsTable
        {
            set
            {
                if (value != null)
                {
                    _groupBoxCreatePixelsTable = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static GroupBox GroupBoxEditImage
        {
            set
            {
                if (value != null)
                {
                    _groupBoxEditImage = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static GroupBox GroupBoxImageInformation
        {
            set
            {
                if (value != null)
                {
                    _groupBoxImageInformation = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static GroupBox GroupBoxForFile
        {
            set
            {
                if (value != null)
                {
                    _groupBoxForFile = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static GroupBox GroupBoxForImage
        {
            set
            {
                if (value != null)
                {
                    _groupBoxForImage = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }
    }
}
