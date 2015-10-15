using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Assignment_5.Models;
using System.Text;

namespace Assignment_5.Controllers {
    public class PotionsController : Controller {

        private static IngredientsModel allIngredients = new IngredientsModel();

        // GET: /<controller>/
        public IActionResult Index() {
            return View(allIngredients);
        }


        private string FormatStr(string word) {
            if (word != null && word.Length > 1) {
                return word.Replace(" ", string.Empty);
            }
            return null;
        }

        
        private string GetRandStr(string firstWord, string secondWord) {
            StringBuilder finalStr = new StringBuilder();

            var fLength = firstWord.Length;
            var sLength = secondWord.Length;

            var rand = new Random();

            var fArr = firstWord.ToCharArray();
            var sArr = secondWord.ToCharArray();

            int fIndex = 0;
            int sIndex = 0;
            
            
            for (var i = 0; i < fLength + sLength; i++) {
                var tmp = rand.Next(0, 2);

                if (fIndex + sIndex == fLength + sLength) {
                    break;
                } else if (tmp == 0 && fIndex < fLength) {
                    if (fArr[fIndex] == ' ') {
                        fIndex++;
                        continue;
                    }
                    finalStr.Append(fArr[fIndex].ToString());
                    fIndex++;
                } else if (tmp == 1 && sIndex < sLength) {
                    if (sArr[sIndex] == ' ') {
                        sIndex++;
                        continue;
                    }
                    finalStr.Append(sArr[sIndex].ToString());
                    sIndex++;
                }
            }
                       
            return finalStr.ToString();
        }
        


        [HttpPost]
        public IActionResult Mix() {
            if (Request.HasFormContentType) {
                var ingredients = Request.Form.GetValues("ingredients");
                var i1 = ingredients[0];
                var i2 = ingredients[1];

                if (ingredients != null && ingredients.Count == 2) {
                    allIngredients.ALL.Add(new IngredientModel() {
                        Name = GetRandStr(i1, i2)
                    });
                }
            }

            return RedirectToAction("index");
        }


        public IActionResult Ingredient(int id) {
            if (id >= 0 && id < allIngredients.ALL.Count) {
                ViewBag.ingredientName = allIngredients.ALL[id].Name;
                ViewBag.ingredientIndex = id;
                return View();
            }

            return RedirectToAction("index");
        }
    }
}
