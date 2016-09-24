using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Lotto_Helper
{
    public class NumberAndProcentage
    {
        public int ColumnIndex { get; set; }
        public int RowIndex { get; set; }
        public int Number { get; set; }
        public float Procentage { get; set; }
        public SolidColorBrush Color
        {
            get
            {
                return Procentage == 0 ? new SolidColorBrush(Colors.DarkRed) : 
                       Procentage < 5 ? new SolidColorBrush(Colors.Red) : 
                       Procentage < 10 ? new SolidColorBrush(Colors.OrangeRed) :
                       Procentage < 15 ? new SolidColorBrush(Colors.Orange) :
                       Procentage < 20 ? new SolidColorBrush(Colors.Yellow) :
                       Procentage < 25 ? new SolidColorBrush(Colors.YellowGreen) :
                       new SolidColorBrush(Colors.Green);
            }
        }

        public NumberAndProcentage()
        {

        }

        public NumberAndProcentage(int num, float procentage)
        {
            Number = num+1;
            Procentage = procentage;
            RowIndex = num / 7;
            ColumnIndex = (num - RowIndex*7) % 7;
        }
    }
}
