using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Assignment_5.Models;


namespace Assignment_5.Controllers {
    public class SpellsController : Controller {

        private static SpellsModel allSpells = new SpellsModel();

        // GET: /<controller>/
        public IActionResult Index() {
            return View(allSpells);
        }


        [HttpPost]
        public IActionResult Delete() {
            if (Request.HasFormContentType) {
                int id;
                var spell = Request.Form.Get("spellIndex");

                if (spell != null && int.TryParse(spell, out id)) {
                    allSpells.ALL.RemoveAt(id);
                }
            }

            return RedirectToAction("index");
        }

        
        [HttpPost]
        public IActionResult AddSpell(string newSpellName) {
            if (newSpellName != null) {
                allSpells.ALL.Add(new SpellModel() {
                    Name = newSpellName
                });
            }

            return RedirectToAction("index");
        }
        


    }
}
