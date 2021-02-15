using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordSearchService.Entities;
using WordSearchWeb.Models;
using WordSearchWeb.Properties;

namespace WordSearchWeb.Controllers
{
    public class WordSearchController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            // create empty list to hold words to hide            
            var wordSearchModel = new WordSearchIndexModel(Settings.Default.MaximumWords);

            // Test Data
            var words = new List<string>(new string[Settings.Default.MaximumWords]);
            words[0] = "Monday";
            words[1] = "Tuesday";
            words[2] = "Wednesday";

            wordSearchModel.Words = words;           
            //wordSearchModel.Words[1] = "Tuesday";
            //wordSearchModel.Words[1] = "Wednesday";
            //wordSearchModel.Words[1] = "Thursday";
            
            wordSearchModel.Title = "a title";
            wordSearchModel.Description = "a description";

            //wordSearchGrid.FillEmptySpaces();

            return View(wordSearchModel);
        }

        [HttpPost]
        public ActionResult Display(WordSearchIndexModel wordSearchIndexModel)
        {
            // ToDo - this should go in a service
            var wordSearchGrid = new WordSearchGrid(wordSearchIndexModel.Rows,
                wordSearchIndexModel.Columns);

            wordSearchIndexModel.Words
                .Where(w => !string.IsNullOrEmpty(w))
                .ToList()
                .ForEach(a => wordSearchGrid.AddHiddenWord(a));

            wordSearchGrid.FillEmptySpaces();

            var wordSearchDisplayModel = new WordSearchDisplayModel(wordSearchIndexModel);
            var grid = wordSearchGrid.Grid;
            var hiddenWords = wordSearchGrid.HiddenWords;
            wordSearchDisplayModel.Grid = grid;
            wordSearchDisplayModel.HiddenWords = hiddenWords;

            return View(wordSearchDisplayModel);
        }
            
        public JsonResult GenerateWordSearchGrid(List<String> words, int row, int col)
        {
            var wordSearchGrid = new WordSearchGrid(row, col);

            foreach (var word in words)
            {
                wordSearchGrid.AddHiddenWord(word);
            }
        
            wordSearchGrid.FillEmptySpaces();

            var wordSearchModel = new WordSearchIndexModel(Settings.Default.MaximumWords)
            {
                // To do - uncomment Grid, HiddenWords
                // Grid = wordSearchGrid.Grid,
                Rows = wordSearchGrid.Rows,
                Columns = wordSearchGrid.Columns,
                // HiddenWords = wordSearchGrid.HiddenWords
            };

            return Json(wordSearchModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void PassNumber(int val)
        {
            int i = val;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}