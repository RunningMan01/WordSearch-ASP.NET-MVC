using System;
using System.Linq;

namespace WordSearchService.Entities
{
    public class HiddenWord
    {
        public string Word { get; set; }
        public GridLocation Start { get; set; }
        // public GridLocation End { get; }
        //public int Row { get; set; }
        //public int Column { get; set; }
            
        public DirectionFlagsEnum Direction { get; set; }

        //public bool IsValidEndPosition(int rows, int columns)
        //{
        //    var endPosition = GetEndPosition();

        //    if (!Enumerable.Range(1, rows).Contains(endPosition.Row))
        //        return false;

        //    if (!Enumerable.Range(1, columns).Contains(endPosition.Column))
        //        return false;

        //    return true;
        //}

        //public Position GetEndPosition()
        //{
        //    var rowDelta = GetRowDelta();
        //    var columnDelta = GetColumnDelta();

        //    var endPosition = new Position()
        //    {
        //        Column = Start.Column + (GetColumnDelta() * (Word.Length - 1)),
        //        Row = Start.Row + (GetRowDelta() * (Word.Length - 1))
        //    };

        //    return endPosition;
        //}
      
        //public int GetRowDelta()
        //{
        //    var delta = 0;

        //    if ((Direction & DirectionFlagsEnum.Up) != 0)
        //    {
        //        delta = -1;
        //    }
        //    else if ((Direction & DirectionFlagsEnum.Down) != 0)
        //    {
        //        delta = 1;
        //    }

        //    return delta;
        //}

        //public int GetColumnDelta()
        //{
        //    var delta = 0;

        //    if ((Direction & DirectionFlagsEnum.Left) != 0)
        //    {
        //        delta = -1;
        //    }
        //    else if ((Direction & DirectionFlagsEnum.Right) != 0)
        //    {
        //        delta = 1;
        //    }

        //    return delta;
        //}
    }
}
