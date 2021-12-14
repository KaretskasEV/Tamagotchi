using System;
using System.Windows.Forms;

namespace ImageEditor
{
    sealed public class ManagingOfNumericUpDown
    {
        private readonly NumericUpDown _numericUpDownColumns;
        private readonly NumericUpDown _numericUpDownRows;

        public ManagingOfNumericUpDown(FormMain formMain)
        {
            try
            {
                if (formMain == null)
                {
                    throw new NullReferenceException("formMain is null.");
                }

                _numericUpDownColumns = formMain.NumericUpDownColumns;
                _numericUpDownRows = formMain.NumericUpDownRows;
            }
            catch (NullReferenceException error)
            {
                LogFile.SaveErrorMessage(error);
            }
        }

        public int Columns
        {
            get
            {
                int number = 1;

                try
                {
                    number = (int)_numericUpDownColumns.Value;
                }
                catch (NullReferenceException error)
                {
                    LogFile.SaveErrorMessage(error);
                }

                return number;
            }

            set
            {
                try
                {
                    if (value.GetTypeCode() == TypeCode.Int32)
                    {
                        _numericUpDownColumns.Value = value;
                    }
                    else
                    {
                        throw new Exception("The assigned value is less than the Minimum property value.\r\n " +
                                            "- or - The assigned value is greater than the Maximum property value.");
                    }
                }
                catch (ArgumentOutOfRangeException error)
                {
                    LogFile.SaveErrorMessage(error);
                }
                catch (Exception error)
                {
                    LogFile.SaveErrorMessage(error);
                }
            }
        }

        public int Rows
        {
            get
            {
                int number = 1;

                try
                {
                    number = (int)_numericUpDownRows.Value;
                }
                catch (NullReferenceException error)
                {
                    LogFile.SaveErrorMessage(error);
                }

                return number;
            }

            set
            {
                try
                {
                    if (value.GetTypeCode() == TypeCode.Int32)
                    {
                        _numericUpDownRows.Value = value;
                    }
                    else
                    {
                        throw new Exception("The assigned value is less than the Minimum property value.\r\n " +
                                            "- or - The assigned value is greater than the Maximum property value.");
                    }
                }
                catch (ArgumentOutOfRangeException error)
                {
                    LogFile.SaveErrorMessage(error);
                }
                catch (Exception error)
                {
                    LogFile.SaveErrorMessage(error);
                }
            }
        }
    }
}