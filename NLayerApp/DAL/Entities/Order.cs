using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        public ICollection<Dish> Dishes { get; set; }
    }
}
