using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishTest
{
    [Serializable]
    class TaskVariant
    {
        [NonSerialized]
        public static TaskVariant ActiveTask;

        public string Task1Text;
        public string Task2Text;
        public string Task3Text;
        public Image Task2Image;
        public Image Task3Image_1;
        public Image Task3Image_2;
    }
}
