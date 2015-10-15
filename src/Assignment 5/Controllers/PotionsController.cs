using System;
using System.Linq;
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
        
        
        private string GetRandStr(string firstWord, string secondWord) {
            StringBuilder finalStr = new StringBuilder();
            var rand = new Random();
            var fArr = firstWord.ToCharArray();
            var sArr = secondWord.ToCharArray();
            var fLength = fArr.Count();
            var sLength = sArr.Count();
            int fIndex = 0, sIndex = 0;
            
            for (var i = 0; i < fLength + sLength; i++) {
                var selector = rand.Next(0, 2);
                if ((selector == 0 || sIndex >= sLength) && fIndex < fLength) {
                    finalStr.Append(fArr[fIndex]);
                    fIndex++;
                } else {
                    finalStr.Append(sArr[sIndex]);
                    sIndex++;
                }
            }
            
            return finalStr.ToString();
        }


        [HttpPost]
        public IActionResult Mix() {
            if (Request.HasFormContentType) {
                var ingredients = Request.Form.GetValues("ingredients");

                if (ingredients != null && ingredients.Count == 2) {
                    allIngredients.ALL.Add(new IngredientModel() {
                        Name = GetRandStr(ingredients[0], ingredients[1])
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
