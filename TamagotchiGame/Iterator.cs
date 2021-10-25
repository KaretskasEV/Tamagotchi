using System;
using System.Collections;
using System.Windows.Forms;

namespace TamagotchiGame
{
    sealed class Iterator<TTypeVariable> : IEnumerator
    {
        private readonly TTypeVariable[] _arrayForIterator;
        private int _item;

        public Iterator(TTypeVariable[] arrayForIterator)
        {
            if (arrayForIterator == null)
            {
                MessageBox.Show(@"_arrayForIterator is null", @"Error");
                throw new NullReferenceException();
            }

            _arrayForIterator = arrayForIterator;
            _item = -1;
        }

        public void Reset()
        {
            _item = -1;
        }

        public bool MoveNext()
        {
            _item++;
            return (_item < _arrayForIterator.Length);
        }

        public bool MovePrevious()
        {
            if (_item == -1)
            {
                return false;
            }

            _item--;
            return (_item >= 0);
        }

        object IEnumerator.Current
        {
            get => Current;
        }

        public TTypeVariable Current
        {
            get
            {
                try
                {
                    return _arrayForIterator[_item]; 
                }
                catch(InvalidOperationException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
