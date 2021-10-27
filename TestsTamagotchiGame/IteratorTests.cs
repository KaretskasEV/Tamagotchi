using System;
using NUnit.Framework;
using TamagotchiGame;

namespace TestsTamagotchiGame
{
    sealed class IteratorTests
    {
        [Test]
        public void Reset_Throw_IndexOutOfRangeException_InCurrent()
        {
            int[] arrayInts = {0, 1, 2};
            var iteratorArrayInts = new Iterator<int>(arrayInts);

            iteratorArrayInts.Reset();

            Assert.Throws(typeof(IndexOutOfRangeException), () => { int current = iteratorArrayInts.Current; });
        }

        [Test]
        public void MoveNext_return_true()
        {
            bool result;
            int[] arrayInts = {0, 1, 2};
            var iteratorArrayInts = new Iterator<int>(arrayInts);
            
            result = iteratorArrayInts.MoveNext();
            
            Assert.AreEqual(true, result);
        }

        [Test]
        public void MoveNext_return_false()
        {
            bool result = false;
            int[] arrayInts = { 0, 1, 2 };
            var iteratorArrayInts = new Iterator<int>(arrayInts);

            for (int item = 0; item <= arrayInts.Length; item++)
            {
                result = iteratorArrayInts.MoveNext();
            }

            Assert.AreEqual(false, result);
        }

        [Test]
        public void MovePrevious_return_true()
        {
            bool result;
            int[] arrayInts = { 0, 1, 2 };
            var iteratorArrayInts = new Iterator<int>(arrayInts);

            iteratorArrayInts.MoveNext();
            iteratorArrayInts.MoveNext();
            result = iteratorArrayInts.MovePrevious();

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MovePrevious_return_false()
        {
            bool result;
            int[] arrayInts = { 0, 1, 2 };
            var iteratorArrayInts = new Iterator<int>(arrayInts);

            result = iteratorArrayInts.MovePrevious();

            Assert.AreEqual(false, result);
        }

        [Test]
        public void Current_return_0()
        {
            int[] arrayInts = {0, 1, 2};
            var iteratorArrayInts = new Iterator<int>(arrayInts);

            iteratorArrayInts.MoveNext();

            Assert.AreEqual(0, iteratorArrayInts.Current);
        }

        [Test]
        public void Current_throw_IndexOutOfRangeException()
        {
            int[] arrayInts = { 0, 1, 2 };
            var iteratorArrayInts = new Iterator<int>(arrayInts);

            Assert.Throws(typeof(IndexOutOfRangeException), () => { int current = iteratorArrayInts.Current; });
        }
    }
}