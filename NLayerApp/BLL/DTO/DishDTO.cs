using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class DishDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<string> Ingredients { get; set; }
    }
}
