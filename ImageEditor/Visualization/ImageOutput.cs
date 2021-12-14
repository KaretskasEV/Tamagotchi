using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageEditor
{
    public sealed class ImageOutput: IDisposable
    {
        public enum SaveCell { Save, NotSave, Remove }

        public event Action<Point, Color, SaveCell> OnCreateFillCell;
        public event Action<string> OnInformationOutput;
        public event Action<int, int, int> OnCreateNewGrid;
        public event Action OnCreateNewGridAdditionalAction;

        private const int Zero = 0;
        private const int ReferenceOfBeginNewPoint = 2;
        private const int InvalidCoordinate = -1;
        private const int ErrorsSizePictureBox = 2;

        private readonly int MaximumNumberOfColumns;
        private readonly int MaximumNumberOfRows;
        private readonly int _cellSize;
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

        public ImageOutput(PictureBox objectForDraw, int cellSize, int MaximumColumns, int MaximumRows)
        {
            const int oneColumnOrRows = 1;

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
            _cellSize = cellSize;
            _currentMaximumColumns = MaximumColumns - oneColumnOrRows;
            _currentMaximumRows = MaximumRows - oneColumnOrRows;
            MaximumNumberOfColumns = MaximumColumns;
            MaximumNumberOfRows = MaximumRows;
            _saveCell = SaveCell.NotSave;
            _arrayCells = new bool[MaximumColumns, MaximumRows];
        }

        public bool[,] ArrayCells { get => _arrayCells; }
        public int CurrentMaximumColumns { get => _currentMaximumColumns; }
        public int CurrentMaximumRows { get => _currentMaximumRows; }

        ~ImageOutput()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
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
                    if(OnCreateFillCell != null)
                    {
                        OnCreateFillCell.Invoke(coordinatePoint, colorRectangle, saveCell);
                    }
                }
                else if ((saveCell == SaveCell.Remove) & CheckFillCell(currentCell))
                {
                    RemoveCoordinate(currentCell);
                    if (OnCreateFillCell != null)
                    {
                        OnCreateFillCell.Invoke(coordinatePoint, colorRectangle, saveCell);
                    }
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
            if(OnInformationOutput != null)
            {
                OnInformationOutput.Invoke($"Save Cell: [{cell.X} : {cell.Y}];");
            }
        }

        private void RemoveCoordinate(Point cell)
        {
            _arrayCells[cell.X, cell.Y] = false;
            if (OnInformationOutput != null)
            {
                OnInformationOutput.Invoke($"Remove Cell: [{cell.X} : {cell.Y}];");
            }
        }

        public void CreateCursor(Point coordinatePoint, Color colorRectangle, Color backColor)
        {
            Point currentCell = CalculationNumberCell(coordinatePoint);
            
            if (currentCell.Equals(_previousCellOfCursor) == false)
            {
                ClearPreviousCellOfCursor();
                _clearCellOfCursor = false;

                coordinatePoint = CalculationOfStartingCoordinate(coordinatePoint);

                DrawHatchCell(currentCell, coordinatePoint, colorRectangle, backColor);

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

        private void DrawHatchCell(Point currentCell, Point coordinatePoint, Color colorRectangle, Color backColor)
        {
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
        }

        private Color DefineCellColor(Point coordinatePoint)
        {
            return _bitmap.GetPixel(coordinatePoint.X, coordinatePoint.Y);
        }

        public static Color InvertColor(Color color)
        {
            return Color.FromArgb(color.A, 0xFF - color.R, 0xFF - color.G, 0xFF - color.B);
        }

        private Point CalculationNumberCell(Point coordinatePoint)
        {
            coordinatePoint.X /= _cellSize;
            coordinatePoint.Y /= _cellSize;

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
            coordinatePoint.X = cell.X * _cellSize + ReferenceOfBeginNewPoint;
            coordinatePoint.Y = cell.Y * _cellSize + ReferenceOfBeginNewPoint;

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
            const int firstColumnOfRow = 1;

            if ((columns > MaximumNumberOfColumns & columns < minimumNumberOfColumnsOrRows) |
                (rows > MaximumNumberOfRows & rows < minimumNumberOfColumnsOrRows))
            {
                throw new Exception($"Columns must be from { firstColumnOfRow } to " +
                    $"{MaximumNumberOfColumns}. Rows must be from {firstColumnOfRow} " +
                    $"to {MaximumNumberOfRows}");
            }

            _arrayCells = new bool[columns, rows];
            _currentMaximumColumns = _arrayCells.GetUpperBound(firstDimensionOfArray);
            _currentMaximumRows = _arrayCells.GetUpperBound(secondDimensionOfArray);
            
            int maximumWidthOfColumns = _cellSize * columns;
            int maximumHeightOfRows = _cellSize * rows;

            _graphics.Clear(Color.White);
            using var pen = new Pen(colorGrid, widthPen);
            pen.Color = colorGrid;

            for (int stepColumns = _cellSize; stepColumns < maximumWidthOfColumns; stepColumns += _cellSize)
            {
                _graphics.DrawLine(pen, stepColumns, Zero, stepColumns, maximumHeightOfRows);
            }

            for (int stepRows = _cellSize; stepRows < maximumHeightOfRows; stepRows += _cellSize)
            {
                _graphics.DrawLine(pen, Zero, stepRows, maximumWidthOfColumns, stepRows);
            }

            if(OnCreateNewGrid != null)
            {
                OnCreateNewGrid.Invoke(columns, rows, _cellSize);
            }

            if(OnCreateNewGridAdditionalAction != null)
            {
                OnCreateNewGridAdditionalAction.Invoke();
            }

            _pictureForDraw.Image = _bitmap;
        }

        public void ShowAllFillCells(Color colorCell, bool[,] arrayCells)
        {
            const int firstDimensionOfArray = 0;
            const int secondDimensionOfArray = 1;
            Color invertColorCell = InvertColor(colorCell);
            var currentCoordinate = new Point();

            if((arrayCells.GetUpperBound(firstDimensionOfArray) != _currentMaximumColumns) | 
               (arrayCells.GetUpperBound(secondDimensionOfArray) != _currentMaximumRows))
            {
                MessageBox.Show("Array 'arrayCells' isn't equal to grid.", "Error!!!");
                return;
            }

            for (int columns = Zero; columns <= _currentMaximumColumns; columns++)
            {
                for(int rows = Zero; rows <= _currentMaximumRows; rows++)
                {
                    currentCoordinate.X = columns * _cellSize;
                    currentCoordinate.Y = rows * _cellSize;
                    currentCoordinate = CalculationOfStartingCoordinate(currentCoordinate);

                    if(arrayCells[columns, rows])
                    {
                        DrawSquare(currentCoordinate, colorCell, colorCell, HatchStyle.WideUpwardDiagonal);
                    }
                    else
                    {
                        DrawSquare(currentCoordinate, invertColorCell, invertColorCell, HatchStyle.WideUpwardDiagonal);
                    }
                }
            }

            CopyArrayCells(arrayCells);
            _saveCell = SaveCell.NotSave;
            _previousFillCell = new Point(InvalidCoordinate, InvalidCoordinate);
        }

        private void CopyArrayCells(bool[,] arrayCells)
        {
            const int firstDimensionOfArray = 0;
            const int secondDimensionOfArray = 1;

            _currentMaximumColumns = arrayCells.GetUpperBound(firstDimensionOfArray);
            _currentMaximumRows = arrayCells.GetUpperBound(secondDimensionOfArray);

            _arrayCells = (bool[,])arrayCells.Clone();
        }

        public void ClearGrid(Color colorClearCell)
        {
            var currentCoordinate = new Point();

            for (int columns = Zero; columns <= _currentMaximumColumns; columns++)
            {
                for (int rows = Zero; rows <= _currentMaximumRows; rows++)
                {
                    currentCoordinate.X = columns * _cellSize;
                    currentCoordinate.Y = rows * _cellSize;
                    currentCoordinate = CalculationOfStartingCoordinate(currentCoordinate);

                    DrawSquare(currentCoordinate, colorClearCell, colorClearCell, HatchStyle.WideUpwardDiagonal);
                    _arrayCells[columns, rows] = false;
                }
            }
        }
    }
}
