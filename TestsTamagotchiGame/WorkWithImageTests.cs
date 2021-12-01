using System;
using System.Windows.Forms;
using NUnit.Framework;

using TamagotchiGame;

namespace TestsTamagotchiGame
{
    sealed class WorkWithImageTests
    {
        [Test]
        public void ChangePictureBox_throw_NullReferenceException()
        {
            var currentPictureBox = new PictureBox();
            PictureBox[] pictureBoxArray = { currentPictureBox };
            var workWithImage = new WorkWithImage(pictureBoxArray);

            Assert.Throws(typeof(NullReferenceException), () =>
            {
                workWithImage.ChangePictureBox(null, MouseButtons.Left, 
                                                WorkWithImage.SelectIterator.ForButton);
            });
        }

        [Test]
        public void ChangePictureBox_return_location_for_Button()
        {
            var currentPictureBox = new PictureBox();
            PictureBox[] pictureBoxArray = {currentPictureBox};
            var workWithImage = new WorkWithImage(pictureBoxArray);

            workWithImage.ChangePictureBox(currentPictureBox, MouseButtons.Left, WorkWithImage.SelectIterator.ForButton);

            Assert.AreEqual(@"Image/Button/ButtonDown.png", currentPictureBox.ImageLocation);
        }

        [Test]
        public void ChangePictureBox_return_location_for_IconHappen()
        {
            var currentPictureBox = new PictureBox();
            PictureBox[] pictureBoxArray = { currentPictureBox };
            var workWithImage = new WorkWithImage(pictureBoxArray);

            workWithImage.ChangePictureBox(currentPictureBox, MouseButtons.Left, WorkWithImage.SelectIterator.ForIconHappen);

            Assert.AreEqual(@"Image/Icon/HappenAct.png", currentPictureBox.ImageLocation);
        }

        [Test]
        public void NextIcon_return_array_all_imageLocation_iconAct()
        {
            PictureBox[] pictureBoxArray =
            {
                new PictureBox(),
                new PictureBox(),
                new PictureBox(),
                new PictureBox(),
                new PictureBox(),
                new PictureBox(),
                new PictureBox()
            };
            
            string[] stringLocationIconActExpected =
            {
                @"Image/Icon/ЕatAct.png",
                @"Image/Icon/LightAct.png",
                @"Image/Icon/GameAct.png",
                @"Image/Icon/CureAct.png",
                @"Image/Icon/CleanAct.png",
                @"Image/Icon/InformationAct.png",
                @"Image/Icon/EducationAct.png"
            };
            string[] stringLocationIconActActual = new string[7];
            var workWithImage = new WorkWithImage(pictureBoxArray);

            for (int item = 0; item < pictureBoxArray.Length; item++)
            {
                workWithImage.NextIcon();

                if (pictureBoxArray[item].ImageLocation != "")
                {
                    stringLocationIconActActual[item] = pictureBoxArray[item].ImageLocation;
                }
            }

            CollectionAssert.AreEqual(stringLocationIconActExpected, stringLocationIconActActual);
        }

        [Test]
        public void NextIcon_return_array_all_imageLocation_iconBackGround()
        {
            PictureBox[] pictureBoxArray =
            {
                new PictureBox(),
                new PictureBox(),
                new PictureBox(),
                new PictureBox(),
                new PictureBox(),
                new PictureBox(),
                new PictureBox()
            };

            string[] stringLocationIconBackGroundExpected =
            {
                @"Image/Icon/ЕatBackGround.png",
                @"Image/Icon/LightBackGround.png",
                @"Image/Icon/GameBackGround.png",
                @"Image/Icon/CureBackGround.png",
                @"Image/Icon/CleanBackGround.png",
                @"Image/Icon/InformationBackGround.png",
                @"Image/Icon/EducationBackGround.png"
            };

            string[] stringLocationIconBackGrondActual = new string[7];
            var workWithImage = new WorkWithImage(pictureBoxArray);
            int previousItem;

            for (int item = 0; item <= pictureBoxArray.Length; item++)
            {
                previousItem = item - 1;
                if (previousItem == -1)
                {
                    previousItem = 6;
                }

                workWithImage.NextIcon();

                if (pictureBoxArray[previousItem].ImageLocation != "")
                {
                    stringLocationIconBackGrondActual[previousItem] = pictureBoxArray[previousItem].ImageLocation;
                }
            }

            CollectionAssert.AreEqual(stringLocationIconBackGroundExpected, stringLocationIconBackGrondActual);
        }
    }
}
