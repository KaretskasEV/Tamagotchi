using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageEditor
{
    sealed public class DrawInImage
    {
        public enum SaveCell { Save, NotSave }
        private const int CellSize = 21;
        private const int Zero = 0;
        private const int MaximumNumberOfColumns = 35;
        private const int MaximumNumberOfRows = 17;

        private Bitmap _bitmap;
        private PictureBox _objectForDraw;
        private Graphics _graphics;
        private Pen _pen;
        private HatchBrush _hatchBrush;
        private Point _previousPointOfRectangle;
        private Point[,] _arrayCells;

        public DrawInImage(PictureBox objectForDraw)
        {
            if (objectForDraw == null)
            {
                throw new NullReferenceException();
            }

            const int widthPen = 1;

            _bitmap = new Bitmap(objectForDraw.Width, objectForDraw.Height);
            _objectForDraw = objectForDraw;
            _graphics = Graphics.FromImage(_bitmap);
            _pen = new Pen(Color.Black, widthPen);
            _hatchBrush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Black);
            _previousPointOfRectangle = new Point();
        }

        public void CreateSquareFill(Point coordinatePoint, Color colorRectangle, bool saveCell)
        {
            if ((coordinatePoint.X % CellSize != Zero) & (coordinatePoint.Y % CellSize != Zero))
            {
                coordinatePoint = CalculationOfCoordinate(coordinatePoint);

                DrawSquare(coordinatePoint, colorRectangle, colorRectangle, HatchStyle.DarkUpwardDiagonal);
                SaveCoordinate(coordinatePoint, saveCell);
            }
        }

        private void SaveCoordinate(Point coordinatePoint, bool saveCell)
        {
            int numberOfCellsX = coordinatePoint.X / CellSize;
            int numberOfCellsY = coordinatePoint.Y / CellSize;

            if (saveCell)
            {
                _arrayCells[numberOfCellsX, numberOfCellsY] = coordinatePoint;
            }
        }

        public void CreateSquareWithHatch(Point coordinatePoint, Color colorRectangle, Color backColor)
        {
            DrawSquare(_previousPointOfRectangle, backColor, Color.White, HatchStyle.DarkUpwardDiagonal);

            if ((coordinatePoint.X % CellSize != Zero) & (coordinatePoint.Y % CellSize != Zero))
            {
                coordinatePoint = CalculationOfCoordinate(coordinatePoint);

                DrawSquare(coordinatePoint, colorRectangle, backColor, HatchStyle.DarkUpwardDiagonal);

                _previousPointOfRectangle = coordinatePoint;
            }
        }

        private Point CalculationOfCoordinate(Point coordinatePoint)
        {
            const int referenceOfPoint = 2;

            coordinatePoint.X = (coordinatePoint.X / CellSize)* CellSize + referenceOfPoint;
            coordinatePoint.Y = (coordinatePoint.Y / CellSize)* CellSize + referenceOfPoint;

            return coordinatePoint;
        }

        private void DrawSquare(Point coordinatePoint, Color colorRectangle, Color backColor, HatchStyle hatchStyle)
        {
            const int widthPen = 1;
            const int sizeRectangle = 17;

            _hatchBrush = new HatchBrush(hatchStyle, colorRectangle, backColor);
            _pen = new Pen(colorRectangle, widthPen);
            _graphics.FillRectangle(_hatchBrush, coordinatePoint.X, coordinatePoint.Y, sizeRectangle, sizeRectangle);
            _graphics.DrawRectangle(_pen, coordinatePoint.X, coordinatePoint.Y, sizeRectangle, sizeRectangle);
            _objectForDraw.Image = _bitmap;
        }

        public void CreateGrid(int columns, int rows, Color colorGrid)
        {
            const int minimumNumberOfColumnsOrRows = 1;

            if ((columns > MaximumNumberOfColumns & columns < minimumNumberOfColumnsOrRows) | 
                (rows > MaximumNumberOfRows & rows < minimumNumberOfColumnsOrRows))
            {
                MessageBox.Show(@"Columns must be from 1 to 35. Rows must be from 1 to 17", @"Error!!!");
                return;
            }

            _arrayCells = new Point[columns, rows];

            int maximumWidthOfColumns = CellSize * columns;
            int maximumHeightOfRows = CellSize * rows;

            _graphics.Clear(Color.White);
            _pen.Color = colorGrid;

            for (int stepColumns = CellSize; stepColumns < maximumWidthOfColumns; stepColumns += CellSize)
            {
                _graphics.DrawLine(_pen, stepColumns, Zero, stepColumns, maximumHeightOfRows);
            }

            for (int stepRows = CellSize; stepRows < maximumHeightOfRows; stepRows += CellSize)
            {
                _graphics.DrawLine(_pen, Zero, stepRows, maximumWidthOfColumns, stepRows);
            }

            WorkWithObject.ChangeSizePictureBox(_objectForDraw, columns, rows, CellSize);
            WorkWithObject.ShowPictureBoxInTheCentreGroupBox(_objectForDraw);

            _objectForDraw.Image = _bitmap;
        }
    }
}
