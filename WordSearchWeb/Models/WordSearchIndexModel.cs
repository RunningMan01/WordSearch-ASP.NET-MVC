using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordSearchService.Entities;

namespace WordSearchWeb.Models
{
    public class WordSearchIndexModel :  WordSearchBaseModel
    {
        public WordSearchIndexModel(int numWords) : base(numWords) { }
        public WordSearchIndexModel() : base() { }
    }
}