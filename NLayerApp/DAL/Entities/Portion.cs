namespace DAL.Entities
{
    public class Portion
    {
        public int ID { get; set; }
        public int ServingSize { get; set; } //grams
        public decimal Price { get; set; }
        public int DishID { get; set; }
        public Dish Dish { get; set; }
    }
}
