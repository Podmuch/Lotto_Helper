using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto_Helper
{
    public class Record
    {
        public List<int> numbersList;

        public Record(string[] numbers)
        {
            numbersList = new List<int>();
            for(int i = 0; i < numbers.Length;i++)
            {
                int tmp = -1;
                if(int.TryParse(numbers[i], out tmp))
                {
                    numbersList.Add(tmp);
                }
            }
        }
    }
}
