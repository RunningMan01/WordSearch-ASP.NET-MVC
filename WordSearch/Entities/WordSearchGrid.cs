using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using WordSearch;
using WordSearch.Interfaces;
using WordSearchService.Interfaces;

namespace WordSearchService.Entities
{
    public class WordSearchGrid
    {
        private readonly IWordPlacementService _wordPlacement;
        private readonly IRandomNumberService _randomNumberService;

        public WordSearchGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            Grid = new char[rows, columns];
            _randomNumberService = new RandomNumberService();            
            _wordPlacement = new WordPlacementService(_randomNumberService);
        }

        public WordSearchGrid()
        {
        }

        public char[,] Grid { get; set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public List<HiddenWord> HiddenWords { get; set; } = new List<HiddenWord>();

        // ToDo - Add method to add all hidden words, orderd largest first
        public bool AddHiddenWord(string word)
        {
            var result = false;
            word = word.ToUpper();
            var hiddenWord = _wordPlacement.GetWordPlacement(Grid, word);
            if (hiddenWord != null) {
                result = _wordPlacement.PlaceWordInGrid(Grid, hiddenWord);

                if (result)
                {
                    HiddenWords.Add(hiddenWord);
                }
            }

            return result;             
        }

        public override string ToString()
        {
            var str = string.Empty;
            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Columns; col++)
                {
                    var ch = Grid[row, col];
                    str += ch == '\0' ? ' ' : ch;
                }
                str += Environment.NewLine;
            }

            return str;
        }

        public void FillEmptySpaces()
        {
            var upperCaseA = Convert.ToInt32('A');
            var upperCaseZ = Convert.ToInt32('Z');

            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Columns; col++)
                {
                    var ch = Grid[row, col];
                    Grid[row, col] = ch == '\0' ?
                        Convert.ToChar(_randomNumberService.GetRandomNumber(upperCaseA, upperCaseZ + 1)) : ch;                    
                }
            }
        }
    }
}
