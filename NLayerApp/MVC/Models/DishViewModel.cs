using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class DishViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<string> Ingredients { get; set; }
    }
}
