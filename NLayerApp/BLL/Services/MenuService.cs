using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.Entities;
using BLL.DTO;
using BLL.Interfaces;
using AutoMapper;

namespace BLL.Services
{

    public class MenuService : IMenuService
    {
        IUnitOfWork Database { get; set; }

        MapperConfiguration dishConfig = new MapperConfiguration(cfg => cfg.CreateMap<Dish, DishDTO>());

        public MenuService(string connection)
        {
            Database = new UnitOfWork(connection);
        }

        public IEnumerable<DishDTO> GetMenu()
        {
            var mapper = new Mapper(dishConfig);
            return mapper.Map<IEnumerable<Dish>, IEnumerable<DishDTO>>(Database.Dishes.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
