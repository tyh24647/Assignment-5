using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Assignment_5.Models;


namespace Assignment_5.Controllers {
    public class PotionsController : Controller {

        private static IngredientsModel allIngredients = new IngredientsModel();
    
        // GET: /<controller>/
        public IActionResult Index() {
            return View(allIngredients);
        }


        [HttpPost]
        public IActionResult Mix() {
            if (Request.HasFormContentType) {
                var ingredients = Request.Form.GetValues("ingredients");

                if (ingredients != null && ingredients.Count == 2) {
                    allIngredients.ALL.Add(new IngredientModel() {
                        Name = ingredients[0] + ingredients[1]
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
