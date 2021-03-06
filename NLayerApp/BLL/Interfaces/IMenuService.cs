using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IMenuService
    {
        IEnumerable<DishDTO> GetMenu();

        DishDTO GetDish(int? id);

        void CreateDish(DishDTO dishDTO);

        void Dispose();
    }
}
