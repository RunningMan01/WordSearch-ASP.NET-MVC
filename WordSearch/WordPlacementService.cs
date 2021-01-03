using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSearch.Interfaces;
using WordSearchService.Entities;
using WordSearchService.Interfaces;
using WordSearchService.Extensions;

// ToDo - This doesn't have to be defined as an interface ?
namespace WordSearch
{
    public class WordPlacementService : IWordPlacementService
    {
        private readonly IRandomNumberService _randomNumberService;
        private readonly DirectionFlagsEnum[] _allDirections;

        public WordPlacementService(IRandomNumberService randomNumberService)
        {
            _randomNumberService = randomNumberService;
            _allDirections = (DirectionFlagsEnum[])Enum.GetValues(typeof(DirectionFlagsEnum));
        }

        public HiddenWord GetWordPlacement(char[,] grid, string word)
        {
            var positionFound = false;
            var backToStart = false;
            HiddenWord hiddenWord = null;

            var initialGridLocation = GridLocation.GetRandomGridLocation(_randomNumberService, grid);
            var gridLocation = new GridLocation(initialGridLocation);


            Random rnd = new Random();
            // DirectionFlagsEnum[]
            var allDirectionsRnd = _allDirections.OrderBy(x => rnd.Next()).ToArray();

            // move right and down, checking if word can fit into any direction. if so add it
            do
            {
                // check word can be placed in any of the directions
                // ToDo - start off with random direction
                // ToDo - are we using row, column or starte              
                foreach (var direction in allDirectionsRnd)
                {
                    hiddenWord = new HiddenWord()
                    {
                        //Column = gridLocation.Column,
                        //Row = gridLocation.Row,
                        Direction = direction,
                        Word = word,
                        Start = gridLocation
                    };

                    positionFound = PlacementValidator.IsWordPlacementValid(grid, hiddenWord);
                    if (positionFound) break;
                }
              
                if (!positionFound)
                {
                    // Move to next position
                    gridLocation = GridLocation.GetNextGridLocation(gridLocation, grid);
                    backToStart = gridLocation.Equals(initialGridLocation);
                }
            }
            while (!positionFound && !backToStart);

            return positionFound ? hiddenWord : null;
        }
      
        public bool PlaceWordInGrid(char[,] grid, HiddenWord hiddenWord)
        {
            if (PlacementValidator.IsWordPlacementValid(grid, hiddenWord))
            {                                                     
                var gridLocation = new GridLocation(hiddenWord.Start);
                foreach (var letter in hiddenWord.Word)
                {
                    grid[gridLocation.Row-1, gridLocation.Column-1] = letter;
                    gridLocation = GridLocation.GetNextLetterGridLocation(gridLocation, hiddenWord.Direction);
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
