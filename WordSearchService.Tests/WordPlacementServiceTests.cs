using System;
using System.Collections.Generic;
using System.Text;
using WordSearch;
using WordSearch.Interfaces;
using WordSearchService.Entities;
using Xunit;

namespace WordSearchService.Tests
{
    public class WordPlacementServiceTests
    {
        // GetWordPlacement
        [Fact]
        public void GetWordPlacement ()
        {
            IRandomNumberService randomNumberService = new RandomNumberService();
            var wordPlacementService = new WordPlacementService(randomNumberService);
        }

        // PlaceWordInGrid
        [Fact]
        public void PlaceWordInGrid_ValidWordDownwards_Success()
        {
            IRandomNumberService randomNumberService = new RandomNumberService();
            var wordPlacementService = new WordPlacementService(randomNumberService);
            var grid = new char[20, 20];
            var hiddenWord = new HiddenWord()
            {
                Start = new GridLocation(10, 10),
                Word = "hello",
                Direction = DirectionFlagsEnum.Down
            };
            var result = wordPlacementService.PlaceWordInGrid(grid, hiddenWord);

            Assert.True(result);
            Assert.Equal('h', grid[9, 9]);  // grid id 0 based
            Assert.Equal('e', grid[10, 9]);
            Assert.Equal('l', grid[11, 9]);
            Assert.Equal('l', grid[12, 9]);
            Assert.Equal('o', grid[13, 9]);
        }

        [Fact]
        public void PlaceWordInGrid_ValidWordUpwards_Success()
        {
            IRandomNumberService randomNumberService = new RandomNumberService();
            var wordPlacementService = new WordPlacementService(randomNumberService);

            var grid = new char[20, 20];
            var hiddenWord = new HiddenWord()
            {
                Start = new GridLocation(10, 10),
                Word = "hello",
                Direction = DirectionFlagsEnum.Up
            };
            var result = wordPlacementService.PlaceWordInGrid(grid, hiddenWord);

            Assert.True(result);
            Assert.Equal('h', grid[9, 9]);  // grid id 0 based
            Assert.Equal('e', grid[8, 9]);
            Assert.Equal('l', grid[7, 9]);
            Assert.Equal('l', grid[6, 9]);
            Assert.Equal('o', grid[5, 9]);
        }

        // PlaceWordInGrid_ValidWordLeft_Success()
        // PlaceWordInGrid_ValidWordRight_Success()
        // PlaceWordInGrid_ValidWordUpwardsLeft_Success()
        // etc..
    }
}
