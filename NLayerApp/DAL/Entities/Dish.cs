using System.Collections.Generic;

namespace DAL.Entities
{
    public class Dish
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Portion Portion { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
