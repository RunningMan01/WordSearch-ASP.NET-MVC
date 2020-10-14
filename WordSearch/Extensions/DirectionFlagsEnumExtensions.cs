using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSearchService.Entities;

namespace WordSearchService.Extensions
{
    public static class DirectionFlagsEnumExtensions
    {
        public static int ColumnIncrement(this DirectionFlagsEnum direction)
        {
            if ((direction & DirectionFlagsEnum.Left) != 0)
            {
                return -1;
            }
            else if ((direction & DirectionFlagsEnum.Right) != 0)
            {
                return 1;
            }

            return 0;
        }

        public static int RowIncrement(this DirectionFlagsEnum direction)
        {
            if ((direction & DirectionFlagsEnum.Up) != 0)
            {
                return -1;
            }
            else if ((direction & DirectionFlagsEnum.Down) != 0)
            {
                return 1;
            }

            return 0;
        }
    }
}