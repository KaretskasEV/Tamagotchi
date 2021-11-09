using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageEditor
{
    public sealed class ImageOutput: IDisposable
    {
        public enum SaveCell { Save, NotSave, Remove }
        private const int CellSize = 21;
        private const int Zero = 0;
        private const int MaximumNumberOfColumns = 35;
        private const int MaximumNumberOfRows = 17;
        private const int ReferenceOfBeginNewPoint = 2;
        private const int InvalidCoordinate = -1;
        private const int ErrorsSizePictureBox = 2;

        private readonly Bitmap _bitmap;
        private readonly PictureBox _pictureForDraw;
        private readonly Graphics _graphics;
        private Color _colorFillCell, _invertColor;
        private Point _previousCellOfCursor, _previousCalculationCoordinateOfCursor;
        private Point _previousFillCell;
        private SaveCell _saveCell;
        private bool[,] _arrayCells;
        private int _currentMaximumColumns, _currentMaximumRows;
        private bool _invertCell;
        private bool _modifiedCell;
        private bool _disposed;
        private bool _clearCellOfCursor;

        public ImageOutput(PictureBox objectForDraw)
        {
            if (objectForDraw == null)
            {
                throw new NullReferenceException();
            }

            _bitmap = new Bitmap(objectForDraw.Width, objectForDraw.Height);
            _pictureForDraw = objectForDraw;
            _graphics = Graphics.FromImage(_bitmap);
            _previousCellOfCursor = new Point(InvalidCoordinate, InvalidCoordinate);
            _previousFillCell = new Point(InvalidCoordinate, InvalidCoordinate);
            _previousCalculationCoordinateOfCursor = new Point(InvalidCoordinate, InvalidCoordinate);
            _saveCell = SaveCell.NotSave;
        }

        ~ImageOutput()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //managed resources
                }
                //unmanaged resources
                _bitmap.Dispose();
                _graphics.Dispose();
                _pictureForDraw.Dispose();
                
                _disposed = false;
            }
        }

        public void CreateSquareFillCell(Point coordinatePoint, Color colorRectangle, SaveCell saveCell)
        {
            Point currentCell = CalculationNumberCell(coordinatePoint);
            
            _modifiedCell = !currentCell.Equals(_previousFillCell) | (_saveCell != saveCell);
            bool cursorInsideThePicture = (coordinatePoint.X >= Zero) & (coordinatePoint.Y >= Zero) &
                                          (coordinatePoint.X <= _pictureForDraw.Width - ErrorsSizePictureBox) &
                                          (coordinatePoint.Y <= _pictureForDraw.Height - ErrorsSizePictureBox);

            if ((_modifiedCell | _invertCell) & cursorInsideThePicture)
            {
                if ((saveCell == SaveCell.Save) & (CheckFillCell(currentCell) == false))
                {
                    SaveCoordinate(currentCell);
                }
                else if ((saveCell == SaveCell.Remove) & CheckFillCell(currentCell))
                {
                    RemoveCoordinate(currentCell);
                }

                coordinatePoint = CalculationOfStartingCoordinate(coordinatePoint);

                DrawSquare(coordinatePoint, colorRectangle, colorRectangle, HatchStyle.WideUpwardDiagonal);

                _previousFillCell = currentCell;
                _modifiedCell = false;
                _invertCell = false;
                _saveCell = saveCell;
            }
        }

        private void SaveCoordinate(Point cell)
        {
            _arrayCells[cell.X, cell.Y] = true;
            ManagingOfTextBox.WriteTextInTextBox($"Save Cell: [{cell.X} : {cell.Y}];");
        }

        private void RemoveCoordinate(Point cell)
        {
            _arrayCells[cell.X, cell.Y] = false;
            ManagingOfTextBox.WriteTextInTextBox($"Remove Cell: [{cell.X} : {cell.Y}];");
        }

        public void CreateCursor(Point coordinatePoint, Color colorRectangle, Color backColor)
        {
            Point currentCell = CalculationNumberCell(coordinatePoint);
            
            if ((currentCell.Equals(_previousCellOfCursor) == false))
            {
                ClearPreviousCellOfCursor();
                _clearCellOfCursor = false;

                coordinatePoint = CalculationOfStartingCoordinate(coordinatePoint);

                if (CheckFillCell(currentCell))
                {
                    _colorFillCell = DefineCellColor(coordinatePoint);
                    _invertColor = InvertColor(_colorFillCell);
                    DrawSquare(coordinatePoint, _invertColor, colorRectangle, HatchStyle.WideUpwardDiagonal);
                }
                else
                {
                    DrawSquare(coordinatePoint, colorRectangle, backColor, HatchStyle.WideUpwardDiagonal);
                }

                _previousCellOfCursor = currentCell;
                _previousCalculationCoordinateOfCursor = coordinatePoint;
            }
        }

        public void ClearPreviousCellOfCursor()
        {
            if (_clearCellOfCursor)
            {
                return;
            }

            if (CheckFillCell(_previousCellOfCursor))
            {
                _invertCell = true;
                CreateSquareFillCell(_previousCalculationCoordinateOfCursor, _colorFillCell, SaveCell.NotSave);
            }
            else
            {
                DrawSquare(_previousCalculationCoordinateOfCursor, _pictureForDraw.BackColor, _pictureForDraw.BackColor,
                    HatchStyle.LightUpwardDiagonal);
            }

            _clearCellOfCursor = true;
        }

        private Color DefineCellColor(Point coordinatePoint)
        {
            return _bitmap.GetPixel(coordinatePoint.X, coordinatePoint.Y);
        }

        private static Color InvertColor(Color color)
        {
            return Color.FromArgb(color.A, 0xFF - color.R, 0xFF - color.G, 0xFF - color.B);
        }

        private Point CalculationNumberCell(Point coordinatePoint)
        {
            coordinatePoint.X /= CellSize;
            coordinatePoint.Y /= CellSize;

            if (coordinatePoint.X > _currentMaximumColumns)
            {
                coordinatePoint.X = _currentMaximumColumns;
            }

            if (coordinatePoint.Y > _currentMaximumRows)
            {
                coordinatePoint.Y = _currentMaximumRows;
            }

            if (coordinatePoint.X < Zero)
            {
                coordinatePoint.X = Zero;
            }

            if(coordinatePoint.Y < Zero)
            {
                coordinatePoint.Y = Zero;
            }

            return coordinatePoint;
        }

        private Point CalculationOfStartingCoordinate(Point coordinatePoint)
        {
            Point cell = CalculationNumberCell(coordinatePoint);
            coordinatePoint.X = cell.X * CellSize + ReferenceOfBeginNewPoint;
            coordinatePoint.Y = cell.Y * CellSize + ReferenceOfBeginNewPoint;

            return coordinatePoint;
        }

        private void DrawSquare(Point coordinatePoint, Color colorRectangle, Color backColor, HatchStyle hatchStyle)
        {
            const int sizeRectangle = 17;
            const int widthPen = 1;

            using var hatchBrush = new HatchBrush(hatchStyle, colorRectangle, backColor);
            using var pen = new Pen(colorRectangle, widthPen);
            _graphics.FillRectangle(hatchBrush, coordinatePoint.X, coordinatePoint.Y, sizeRectangle, sizeRectangle);
            _graphics.DrawRectangle(pen, coordinatePoint.X, coordinatePoint.Y, sizeRectangle, sizeRectangle);
            _pictureForDraw.Image = _bitmap;
        }

        private bool CheckFillCell(Point cell)
        {
            //Point cell = CalculationNumberCell(coordinatePoint);

            if (cell.X < Zero | cell.Y < Zero | cell.X > _currentMaximumColumns | cell.Y > _currentMaximumRows)
            {
                return false;
            }

            if (_arrayCells[cell.X, cell.Y])
            {
                return true;
            }

            return false;
        }

        public void CreateGrid(int columns, int rows, Color colorGrid)
        {
            const int minimumNumberOfColumnsOrRows = 1;
            const int firstDimensionOfArray = 0;
            const int secondDimensionOfArray = 1;
            const int widthPen = 1;

            if ((columns > MaximumNumberOfColumns & columns < minimumNumberOfColumnsOrRows) | 
                (rows > MaximumNumberOfRows & rows < minimumNumberOfColumnsOrRows))
            {
                MessageBox.Show(@"Columns must be from 1 to 35. Rows must be from 1 to 17", @"Error!!!");
                return;
            }

            _arrayCells = new bool[columns, rows];
            _currentMaximumColumns = _arrayCells.GetUpperBound(firstDimensionOfArray);
            _currentMaximumRows = _arrayCells.GetUpperBound(secondDimensionOfArray);
            
            int maximumWidthOfColumns = CellSize * columns;
            int maximumHeightOfRows = CellSize * rows;

            _graphics.Clear(Color.White);
            using var pen = new Pen(colorGrid, widthPen);
            pen.Color = colorGrid;

            for (int stepColumns = CellSize; stepColumns < maximumWidthOfColumns; stepColumns += CellSize)
            {
                _graphics.DrawLine(pen, stepColumns, Zero, stepColumns, maximumHeightOfRows);
            }

            for (int stepRows = CellSize; stepRows < maximumHeightOfRows; stepRows += CellSize)
            {
                _graphics.DrawLine(pen, Zero, stepRows, maximumWidthOfColumns, stepRows);
            }

            ManagingOfPictureBox.ChangeSizePictureBox(_pictureForDraw, columns, rows, CellSize);
            ManagingOfPictureBox.ShowPictureBoxInTheCentreGroupBox(_pictureForDraw);

            _pictureForDraw.Image = _bitmap;
        }
    }
}
