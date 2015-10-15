using System.Collections.Generic;

namespace Assignment_5.Models {

    public class SpellModel {
        public string Name { set; get; }
    }

    public class SpellsModel {
        public List<SpellModel> ALL { get; set; }

        public SpellsModel() {
            ALL = new List<SpellModel>();
        }
    }
}
