using System.Collections.Generic;

namespace DAL.Entities
{
    public class Ingredient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Dish> Dishes { get; set; }
    }
}
