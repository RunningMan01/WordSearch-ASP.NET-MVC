using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSearchService.Entities;

namespace WordSearchService
{
    public static class LetterValidator
    {
        /// <summary>
        /// Checks if the letter can be placed at the given Grid Location. Reasons the letter cant be placed
        /// are 1) location is already filled, 2) location is outside bounds of the grid
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="gridLocation"></param>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static bool CanLetterBePlaced(char letter, GridLocation gridLocation, char [,] grid)
        {
            if (gridLocation.OutsideBounds(grid))
            {
                return false;
            }

            var gridLetter = grid[gridLocation.Row-1, gridLocation.Column-1];
            return !char.IsLetter(gridLetter) || letter == gridLetter;
        }
   }
}
