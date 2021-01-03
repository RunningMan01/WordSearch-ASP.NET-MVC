using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordSearchService.Entities;

namespace WordSearchTestHarness
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreateGrid_Click(object sender, EventArgs e)
        {
            var wordSearchGrid = new WordSearchGrid(20, 20);
            wordSearchGrid.AddHiddenWord("word");
            wordSearchGrid.AddHiddenWord("search");
            wordSearchGrid.AddHiddenWord("reallylongword");
            wordSearchGrid.AddHiddenWord("anotherlongone");
            wordSearchGrid.AddHiddenWord("today");
            wordSearchGrid.AddHiddenWord("yesterday");

            var grid = wordSearchGrid.Grid;
            var hiddenWords = wordSearchGrid.HiddenWords;

            var rows = grid.GetUpperBound(0);   // 0 based
            var cols = grid.GetUpperBound(1);

            // wordSearchGrid.FillEmptySpaces();
            labelGrid.Text = wordSearchGrid.ToString();          
        }
    }
}
