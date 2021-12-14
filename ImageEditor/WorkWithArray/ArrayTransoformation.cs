using System;

namespace ImageEditor
{
    public static class ArrayTransoformation
    {
        private const int FirstDimensionOfArray = 0;
        private const int SecondDimensionOfArray = 1;

        private static int _firstDimension;
        private static int _secondDimension;

        public static Pixel[] ArrayInPixels(bool[,] array)
        {
            const int firstItem = 0;
            int item = firstItem;

            try
            {
                if (array == null)
                {
                    throw new NullReferenceException("array is null.");
                }

                _firstDimension = array.GetLength(FirstDimensionOfArray);
                _secondDimension = array.GetLength(SecondDimensionOfArray);
                Pixel[] pixels = new Pixel[_firstDimension * _secondDimension];

                for (int item_firstDimension = firstItem; item_firstDimension < _firstDimension; item_firstDimension++)
                {
                    for (int item_secondDimension = firstItem; item_secondDimension < _secondDimension; item_secondDimension++)
                    {
                        pixels[item].X = item_firstDimension;
                        pixels[item].Y = item_secondDimension;
                        pixels[item].Value = array[item_firstDimension, item_secondDimension];
                        item++;
                    }
                }

                return pixels;
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }

            return null;
        }

        public static bool[,] PixelsInArray(Pixel[] pixels)
        {
            const int oneItem = 1;

            try
            {
                if (pixels == null)
                {
                    throw new NullReferenceException("pixels is null.");
                }

                _firstDimension = pixels[pixels.Length - oneItem].X;
                _secondDimension = pixels[pixels.Length - oneItem].Y;
                bool[,] array = new bool[_firstDimension + oneItem, _secondDimension + oneItem];

                foreach (Pixel pixel in pixels)
                {
                    array[pixel.X, pixel.Y] = pixel.Value;
                }

                return array;
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }

            return null;
        }
    }
}
