using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WordSearchService;
using WordSearchService.Entities;
using WordSearch;
using System.Reflection.Metadata.Ecma335;
using Xunit.Extensions;

namespace WordSearchService.Tests
{
    public class PlacementValidatorTests
    {
        //[Theory]
        //[MemberData(nameof(MaximumSizeWordScenarios))]
        //public void IsWordPlacementValid_MaximumSizeWordScenarios(char[,] grid, HiddenWord hiddenWord, bool expected)
        //{
        //    var result = PlacementValidator.IsWordPlacementValid(grid, hiddenWord);
        //    Assert.Equal(result, expected);
        //}

        [Theory]
        [InlineData(1, 1, "toobig", DirectionFlagsEnum.Down, false)]    // Too big to place down
        [InlineData(1, 1, "toobig", DirectionFlagsEnum.Right, false)]   // Too big to place right       
        [InlineData(5, 5, "toobig", DirectionFlagsEnum.Up, false)]    // Too big to place up   
        [InlineData(1, 5, "toobig", DirectionFlagsEnum.Left, false)]     // Too big to place left 
        [InlineData(3, 3, "word", DirectionFlagsEnum.Down, false)]  // Word fits in grid, but not start position going left
        [InlineData(3, 3, "word", DirectionFlagsEnum.Right, false)]  // Word fits in grid, but not start position going right
        [InlineData(3, 3, "word", DirectionFlagsEnum.Up, false)]  // Word fits in grid, but not start position going right
        [InlineData(3, 3, "word", DirectionFlagsEnum.Left, false)]   // Word fits in grid, but not start position going left 
        [InlineData(3, 3, "fit", DirectionFlagsEnum.Down, true)]  // Word fits in grid
        [InlineData(3, 3, "fit", DirectionFlagsEnum.Right, true)]  // Word fits in grid
        [InlineData(3, 3, "fit", DirectionFlagsEnum.Up, true)]  // Word fits in grid
        [InlineData(3, 3, "fit", DirectionFlagsEnum.Left, true)]   // Word fits in grid 

        //[InlineData(1, 1, "abcdefghijklmnopqrst", DirectionFlagsEnum.DownRight, true)] // Max size word fits in DownRight
        //[InlineData(1, 20, "abcdefghijklmnopqrst", DirectionFlagsEnum.DownLeft, true)] // Max size word fits in DownRight
        //[InlineData(20, 20, "abcdefghijklmnopqrst", DirectionFlagsEnum.UpLeft, true)] // Max size word fits in DownRight
        //[InlineData(20, 1, "abcdefghijklmnopqrst", DirectionFlagsEnum.UpRight, true)] // Max size word fits in DownRight
        public void IsPlacementValid_VariousWordsInGrid_Various(int row,
            int column,
            string word,
            DirectionFlagsEnum direction,
            bool expectedResult)
        {
            var grid = new char[5, 5];
            var hiddenWord = new HiddenWord()
            {
                Start = new GridLocation(row, column),
                Word = word,
                Direction = direction
            };                        
            var result = PlacementValidator.IsWordPlacementValid(grid, hiddenWord);
            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData(1, 1, "abcdefghijklmnopqrst", DirectionFlagsEnum.DownRight, true)] // Max size word fits in DownRight
        [InlineData(1, 20, "abcdefghijklmnopqrst", DirectionFlagsEnum.DownLeft, true)] // Max size word fits in DownRight
        [InlineData(20, 20, "abcdefghijklmnopqrst", DirectionFlagsEnum.UpLeft, true)] // Max size word fits in DownRight
        [InlineData(20, 1, "abcdefghijklmnopqrst", DirectionFlagsEnum.UpRight, true)] // Max size word fits in DownRight
        public void IsPlacementValid_MaxWordSize_Various(int row,
            int column,
            string word,
            DirectionFlagsEnum direction,
            bool expectedResult)
        {
            var grid = new char[20, 20];
            var hiddenWord = new HiddenWord()
            {
                Start = new GridLocation(row, column),
                Word = word,
                Direction = direction
            };
            var result = PlacementValidator.IsWordPlacementValid(grid, hiddenWord);
            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [MemberData(nameof(WordCrossesAnotherWordData))]
        public void IsPlacementValid_WordCrossesAnotherWord_Various(char[,] grid,
            int row,
            int column,
            string word,
            DirectionFlagsEnum direction,
            bool expectedResult)
        {
            var hiddenWord = new HiddenWord()
            {
                Start = new GridLocation(row, column),
                Word = word,
                Direction = direction
            };
            var result = PlacementValidator.IsWordPlacementValid(grid, hiddenWord);
            Assert.Equal(result, expectedResult);
        }

        public static IEnumerable<object[]> WordCrossesAnotherWordData
        {
            get
            {               
                yield return new object[] { GetGridWithWord(), 1, 4, "there", DirectionFlagsEnum.Right, true };
                yield return new object[] { GetGridWithWord(), 1, 4, "notworking", DirectionFlagsEnum.Right, false };
                // word crosses another going Up, Left and Down matching letter
                // word crosses another groing Left, Left and Down not matching letter                           
            }
        }

        private static char[,] GetGridWithWord()
        {
            var grid = new char[20, 20];
            grid[0, 4] = 'h';
            grid[1, 5] = 'e';
            grid[2, 6] = 'l';
            grid[3, 7] = 'l';
            grid[4, 8] = 'o';

            return grid;
        }        
    }
}
