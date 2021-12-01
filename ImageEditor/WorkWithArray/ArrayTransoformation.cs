

namespace ImageEditor
{
    public static class ArrayTransoformation
    {
        const int firstDimensionOfArray = 0;
        const int secondDimensionOfArray = 1;

        static private int firstDimension;
        static private int secondDimension;

        public static Pixel[] ArrayInPixels(bool[,] array)
        {
            const int firstItem = 0;
            firstDimension = array.GetLength(firstDimensionOfArray);
            secondDimension = array.GetLength(secondDimensionOfArray);
            Pixel[] pixels = new Pixel[firstDimension * secondDimension];
            int item = firstItem;

            for(int itemFirstDimension = firstItem; itemFirstDimension < firstDimension; itemFirstDimension++)
            {
                for(int itemSecondDimension = firstItem; itemSecondDimension < secondDimension; itemSecondDimension++)
                {
                    pixels[item].X = itemFirstDimension;
                    pixels[item].Y = itemSecondDimension;
                    pixels[item].Value = array[itemFirstDimension, itemSecondDimension];
                    item++;
                }
            }

            return pixels;
        }

        public static bool[,] PixelsInArray(Pixel[] pixels)
        {
            const int oneItem = 1;

            firstDimension = pixels[pixels.Length - oneItem].X;
            secondDimension = pixels[pixels.Length - oneItem].Y;
            bool[,] array = new bool[firstDimension + oneItem, secondDimension + oneItem];

            foreach(Pixel pixel in pixels)
            {
                array[pixel.X, pixel.Y] = pixel.Value;
            }

            return array;
        }
    }
}
