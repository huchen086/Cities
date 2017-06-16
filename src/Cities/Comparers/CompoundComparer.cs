using System;
using System.Collections.Generic;
using System.Text;

namespace Cities.Comparers
{
    class CompoundComparer : IComparer<City>
    {
        public IList<IComparer<City>> Comparers { get; set; } = new List<IComparer<City>>();

        public int Compare (City x, City y)
        {
            /*
            if (Comparers[0].Compare(x, y) == 0)
            {
                return Comparers[1].Compare(x, y);
            }
            else
            {
                return Comparers[0].Compare(x, y);
            }
            */

            int i = 0;
            int result =0;
            while (i < Comparers.Count)
            {
                result = Comparers[i].Compare(x, y);
                if (result != 0)
                {
                    break;
                }
                else
                {
                    i++;
                    result = Comparers[i].Compare(x, y);
                }
            }
            return result;
        }

    }
}
