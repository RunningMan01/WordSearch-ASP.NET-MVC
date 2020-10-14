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

        public WordSearchGrid(int rows, int columns)
        {
            Grid = new char[rows, columns];
            IRandomNumberService randomNumberService = new RandomNumberService();
            _wordPlacement = new WordPlacementService(randomNumberService);
        }
        public char[,] Grid { get; set; }
        public List<HiddenWord> HiddenWords { get; set; } = new List<HiddenWord>();

        public bool AddHiddenWord(string word)
        {
            bool result = false;           
          
            var hiddenWord = _wordPlacement.GetWordPlacement(Grid, word);
           
            if (result == _wordPlacement.PlaceWordInGrid(Grid, hiddenWord))
            {
                HiddenWords.Add(hiddenWord);
            }

            return result;              
        }
    }
}
