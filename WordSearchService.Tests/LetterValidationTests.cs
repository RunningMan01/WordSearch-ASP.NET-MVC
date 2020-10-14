using System;
using Xunit;
using WordSearchService;
using WordSearchService.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace WordSearchService.Tests
{
    public class LetterValidationTests
    {
        [Theory]
        [MemberData(nameof(Scenarios))]
        public void CanLetterBePlaced_VariousScenarios(char ch,
            GridLocation gridLocation,
            char [,] grid,
            bool expected)
        {         
            var result = LetterValidator.CanLetterBePlaced(ch, gridLocation, grid);

            Assert.Equal(result, expected);
        }

        public static IEnumerable<object[]> Scenarios => new List<object[]>
        {
            // Row lower than allowed bounds
            new object[] { 'a', new GridLocation(0, 1), new char[20, 20], false },
            // Row higher than allowed bounds
            new object[] { 'a', new GridLocation(21, 1), new char[20, 20], false },
            // Column lower than allowed bounds
            new object[] { 'a', new GridLocation(1, 0), new char[20, 20], false },
            // Column higher than allowed bounds
            new object[] { 'a', new GridLocation(1, 21), new char[20, 20], false },
            // Letter can be placed in empty grid
            new object[] { 'a', new GridLocation(1, 1), GetEmptyGrid(20, 20), true },
            // Letter can be placed in grid location with same letter
            new object[] { 'a', new GridLocation(1, 1), GetGridWithLetter(20,20, 1, 1, 'a'), true },
            // Letter cant be placed in a grid location that contains a different letter
            new object[] { 'a', new GridLocation(1, 1), GetGridWithLetter(20,20, 1, 1, 'b'), false }
        };

        private static char[,] GetGridWithLetter(int rows, int columns, int row, int column, char letter)
        {
            var grid = new char[rows, columns];
            grid[row-1, column-1] = letter;

            return grid;
        }

        private static char[,] GetEmptyGrid(int rows, int columns)
        {
            return new char[rows, columns];
        }
    }
}
