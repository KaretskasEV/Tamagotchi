using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tamagotchi_Game
{
    sealed class Iterator : IEnumerator
    {
        private string[] arrayForIterator;
        private int item;

        public Iterator(string[] arrayForIterator)
        {
            if (arrayForIterator == null)
            {
                MessageBox.Show(@"arrayForIterator is null", @"Error");
                throw new NullReferenceException();
            }

            this.arrayForIterator = arrayForIterator;
            item = -1;
        }

        public void Reset()
        {
            item = -1;
        }

        public bool MoveNext()
        {
            item++;
            return (item < arrayForIterator.Length);
        }

        public bool MovePrevious()
        {
            if (item == -1 | item == 0)
            {
                return false;
            }

            item--;
            return (item >= 0);
        }

        object IEnumerator.Current
        {
            get => Current;
        }

        public string Current
        {
            get => arrayForIterator[item];
        }
    }
}
