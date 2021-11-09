using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    public sealed class HistoryOfEdit
    {
        private (int, int) SizeGrid;
        
        private delegate void ActionImage(int columns, int rows);

        private Stack fd = new Stack();


        public void ClearImage(int columns, int rows)
        {
            fd.Push(new ActionImage(ManagingOfPictureBox.CreateNewGridInPictureBox));
        }

        public void CreateNewGrid(int columns, int rows)
        {

        }
    }
}
