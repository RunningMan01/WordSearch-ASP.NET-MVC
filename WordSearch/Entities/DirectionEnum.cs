using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearchService.Entities
{
    [Flags]
    public enum DirectionFlagsEnum
    {
        Up = 0x1,
        Down = 0x2,
        Left = 0x4,
        Right = 0x8,
        UpLeft = Up | Left,
        UpRight = Up | Right,
        DownLeft = Down | Left,
        DownRight = Down | Right
    }

    //public static class DirectionFlagsEnumExtensions
    //{
    //    public static int ColumnIncrement(this DirectionFlagsEnum direction)
    //    {
    //        if ((direction & DirectionFlagsEnum.Left) != 0)
    //        {
    //            return -1;
    //        }
    //        else if ((direction & DirectionFlagsEnum.Right) != 0)
    //        {
    //            return 1;
    //        }

    //        return 0;
    //    }

    //    public static int RowIncrement(this DirectionFlagsEnum direction)
    //    {
    //        if ((direction & DirectionFlagsEnum.Up) != 0)
    //        {
    //            return -1;
    //        }
    //        else if ((direction & DirectionFlagsEnum.Down) != 0)
    //        {
    //            return 1;
    //        }

    //        return 0;
    //    }

    //}
}
