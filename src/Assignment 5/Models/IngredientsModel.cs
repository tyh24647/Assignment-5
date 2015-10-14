using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Assignment_5.Models {

    public class IngredientModel {
        public string Name { get; set; }
    }

    public class IngredientsModel {
        public List<IngredientModel> ALL { get; set; }
        
        public IngredientsModel() {
            ALL = new List<IngredientModel>() {
                new IngredientModel() { Name = "Fairy Wings" },
                new IngredientModel() { Name = "Mandrake Root"},
                new IngredientModel() { Name = "Unicorn Blood" },
                new IngredientModel() { Name = "Wormwood" },
                new IngredientModel() { Name = "Doxy egg" }
            };
        }
    }
}
