using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSearch.Interfaces;
using WordSearchService.Extensions;

namespace WordSearchService.Entities
{
    public class GridLocation : IEquatable<GridLocation>
    {
        public GridLocation() { }

        public GridLocation(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public GridLocation(GridLocation gridLocation)
        {
            Row = gridLocation.Row;
            Column = gridLocation.Column;
        }             

        public static GridLocation GetRandomGridLocation(IRandomNumberService randomNumberService, char[,] grid)
        {
            // 1b
            //var row = randomNumberService.GetRandomNumber(0, grid.GetLength(0));
            //var column = randomNumberService.GetRandomNumber(0, grid.GetLength(1));

            var row = randomNumberService.GetRandomNumber(1, grid.GetLength(0)+1);
            var column = randomNumberService.GetRandomNumber(1, grid.GetLength(1)+1);

            return new GridLocation(row, column);
        }

        public static GridLocation GetNextGridLocation(GridLocation gridLocation, char[,] grid)
        {
            // 1b
            // var row = gridLocation.Row++ % grid.GetLength(0);
            // var column = gridLocation.Column++ % grid.GetLength(1);

            var row = gridLocation.Row++;
            var column = gridLocation.Column;
            if (row > grid.GetLength(0))
            {
                row = 1;
                if (++column > grid.GetLength(1))
                {
                    column = 1;
                }
            }

            return new GridLocation(row, column);
        }

        public static GridLocation GetNextLetterGridLocation(GridLocation gridLocation, DirectionFlagsEnum direction)
        {
            var newRow = gridLocation.Row + direction.RowIncrement();
            var newColumn = gridLocation.Column + direction.ColumnIncrement();

            return new GridLocation(newRow, newColumn);
        }

        public bool Equals(GridLocation other)
        {
            return (this.Row == other.Row) && (this.Column == other.Column);
        }

        // ToDo - Row Column maybe should be 1 based
        // ToDo - factory class methods in separate class
        public bool OutsideBounds(char[,] grid)
        {
            var maxRows = grid.GetLength(0);
            var maxColumns = grid.GetLength(1);

            // Row and Column are 0 based (or should be!)
            // 1b
            //if (Row >= maxRows || Row < 0) return true;
            //if (Column >= maxColumns || Column < 0) return true;
            if (Row > maxRows || Row < 1) return true;
            if (Column > maxColumns || Column < 1) return true;

            return false;
        }

        public int Row { get; set; }        
        public int Column { get; set; }        
    }
}
