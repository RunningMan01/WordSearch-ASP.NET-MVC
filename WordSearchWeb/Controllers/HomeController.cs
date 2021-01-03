using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordSearchService.Entities;
using WordSearchWeb.Models;

namespace WordSearchWeb.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            // create empty list to hold words to hide
            var wordSearchModel = new WordSearchModel();
            wordSearchModel.Words.Add("Monday");
            wordSearchModel.Words.Add("Tuesday");

            //var wordSearchGrid = new WordSearchGrid(20, 20);
            //wordSearchGrid.AddHiddenWord("Monday");
            //wordSearchGrid.AddHiddenWord("Tuesday");
            //wordSearchGrid.AddHiddenWord("Wednesday");
            //wordSearchGrid.AddHiddenWord("Thursday");
            //wordSearchGrid.AddHiddenWord("Friday");
            //wordSearchGrid.AddHiddenWord("Saturday");
            //wordSearchGrid.AddHiddenWord("Sunday");

            //wordSearchGrid.FillEmptySpaces();

            return View(wordSearchModel);
        }

        [HttpPost]
        public ActionResult Index(WordSearchModel wordSearchModel)
        {
            var wordSearchGrid = new WordSearchGrid(20, 20);

            foreach (var word in wordSearchModel.Words) {
                wordSearchGrid.AddHiddenWord(word);
            }

            wordSearchGrid.FillEmptySpaces();

            wordSearchModel.Grid = wordSearchGrid.Grid;
            wordSearchModel.HiddenWords = wordSearchModel.HiddenWords;            

            return View(wordSearchModel);
        }
            
        public JsonResult GenerateWordSearchGrid(List<String> words, int row, int col)
        {
            var wordSearchGrid = new WordSearchGrid(row, col);

            foreach (var word in words)
            {
                wordSearchGrid.AddHiddenWord(word);
            }
        
            wordSearchGrid.FillEmptySpaces();

            var wordSearchModel = new WordSearchModel()
            {
                Grid = wordSearchGrid.Grid,
                Rows = wordSearchGrid.Rows,
                Columns = wordSearchGrid.Columns,
                HiddenWords = wordSearchGrid.HiddenWords
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