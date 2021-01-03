using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordSearchService.Entities;

namespace WordSearchWeb.Models
{
    public class WordSearchModel
    {
        public char[,] Grid { get; set; } = null;
        public int Rows { get; set; }
        public int Columns { get; set; }
        public List<HiddenWord> HiddenWords { get; set; } = new List<HiddenWord>();
        public List<string> Words { get; set; } = new List<string>();
    }
}