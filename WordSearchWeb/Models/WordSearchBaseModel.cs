using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordSearchService.Entities;

namespace WordSearchWeb.Models
{
    public abstract class WordSearchBaseModel
    {       
        public WordSearchBaseModel(int numWords)
        {
            Words = new List<string>(numWords);
        }

        public WordSearchBaseModel()
        {
            Words = new List<string>();
        }

        public int Rows { get; set; }
        public int Columns { get; set; }      
        public List<string> Words { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}