using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSearchService;
using WordSearchService.Entities;

namespace WordSearch
{
    public static class PlacementValidator
    {
        public static bool IsWordPlacementValid(char[,] grid, HiddenWord hiddenWord)
        {
            if (hiddenWord != null)
            {
                var gridLocation = new GridLocation(hiddenWord.Start);
                foreach (var letter in hiddenWord.Word)
                {
                    if (!LetterValidator.CanLetterBePlaced(letter, gridLocation, grid)) return false;
                    gridLocation = GridLocation.GetNextLetterGridLocation(gridLocation, hiddenWord.Direction);
                }
            }

            return true;
        }
    }
}
