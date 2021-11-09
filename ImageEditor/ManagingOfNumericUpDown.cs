using System;
using System.Windows.Forms;

namespace ImageEditor
{
    public static class ManagingOfNumericUpDown
    {
        private static NumericUpDown _numericUpDownColumns;
        private static NumericUpDown _numericUpDownRows;

        public static NumericUpDown NumericUpDownColumns
        {
            get => _numericUpDownColumns;

            set
            {
                if (value != null)
                {
                    _numericUpDownColumns = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static NumericUpDown NumericUpDownRows
        {
            get => _numericUpDownRows;

            set
            {
                if (value != null)
                {
                    _numericUpDownRows = value;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        public static int Columns
        {
            get => (int)_numericUpDownColumns.Value;

            set
            {
                if (value.GetTypeCode() == TypeCode.Int32)
                {
                    _numericUpDownColumns.Value = value;
                }
                else
                {
                    MessageBox.Show(@"Type isn't int.", @"Error!!!");
                }
            }
        }

        public static int Rows
        {
            get => (int)_numericUpDownRows.Value;

            set
            {
                if (value.GetTypeCode() == TypeCode.Int32)
                {
                    _numericUpDownRows.Value = value;
                }
                else
                {
                    MessageBox.Show(@"Type isn't int.", @"Error!!!");
                }
            }
        }
    }
}
