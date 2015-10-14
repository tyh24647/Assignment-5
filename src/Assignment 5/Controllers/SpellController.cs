using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Assignment_5.Models;


namespace Assignment_5.Controllers {
    public class SpellController : Controller {

        private static SpellsModel allSpells = new SpellsModel();

        // GET: /<controller>/
        public IActionResult Index() {
            return View(allSpells);
        }

        
        public IActionResult ViewSpell(int id) {
            if (id < 0 || id >= allSpells.ALL.Count) {
                ViewBag.spellName = allSpells.ALL[id].Name;
                ViewBag.spellName = id;
                return View();
            }

            return RedirectToAction("index");
        }

        
        [HttpPost]
        public IActionResult Add() {
            if (Request.HasFormContentType) {
                var spell = Request.Form.GetValues("spellName");

                if (spell != null) {
                    allSpells.ALL.Add(new SpellModel() {
                        Name = spell[0]
                    });
                }
            }

            return RedirectToAction("index");
        }


        /*
        [HttpPost]
        public IActionResult Add([FromBody]SpellModel newQuery) {
            if (newQuery != null) {
                allSpells.ALL.Add(newQuery);
            }

            return RedirectToAction("index");
        }
        */


        /*
        [HttpPost]
        public IActionResult AddSpell(string newSpellName) {
            if (newSpellName != null) {
                allSpells.ALL.Add(new SpellModel() {
                    Name = newSpellName
                });
            }

            return RedirectToAction("index");
        }
        */


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

        


    }
}
