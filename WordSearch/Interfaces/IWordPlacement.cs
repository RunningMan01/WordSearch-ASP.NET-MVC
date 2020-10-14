using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSearchService.Entities;

namespace WordSearchService.Interfaces
{
    public interface IWordPlacementService
    {
        HiddenWord GetWordPlacement(char[,] grid, string word);      

        bool PlaceWordInGrid(char[,] grid, HiddenWord hiddenWord);

    }
}
