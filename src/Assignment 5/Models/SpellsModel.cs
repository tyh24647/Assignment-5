using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_5.Models {

    public class SpellModel {
        public string Name { set; get; }
    }

    public class SpellsModel {
        public List<SpellModel> ALL { get; set; }

        public SpellsModel() {
            ALL = new List<SpellModel>() {
                new SpellModel() { Name = "Expecto Patronum" },
                new SpellModel() { Name = "Wingardium Leviosa" },
                new SpellModel() { Name = "Alohamora" },
                new SpellModel() { Name = "Expeliarmus" },
                new SpellModel() { Name = "Stupify" },
                new SpellModel() { Name = "Avada Kadavera" }
            };
        }
    }
}
