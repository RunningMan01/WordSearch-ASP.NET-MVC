using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordSearchService.Entities;
using WordSearchWeb.Properties;

namespace WordSearchWeb.Models
{
    public class WordSearchDisplayModel : WordSearchBaseModel
    {
        // ToDo - parameterless constructor
        private WordSearchDisplayModel() : base(Settings.Default.MaximumWords) 
        {

        }
        public WordSearchDisplayModel(int numWords) : base(numWords)
        {

        }

        public WordSearchDisplayModel(WordSearchIndexModel wordSearchIndexModel)
        {
            // ToDo - Maybes have wordsearchindexmodel as the base class
            this.Rows = wordSearchIndexModel.Rows;
            this.Columns = wordSearchIndexModel.Columns;
            this.Words = wordSearchIndexModel.Words;
            this.Title = wordSearchIndexModel.Title;
            this.Description = wordSearchIndexModel.Description;
        }

        public char[,] Grid { get; set; } = null;
        public List<HiddenWord> HiddenWords { get; set; } = new List<HiddenWord>();
    }
}