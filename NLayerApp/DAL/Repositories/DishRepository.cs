using DAL.Entities;
using DAL.Interfaces;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DishRepository : IRepository<Dish>
    {
        private RestaurantContext db;

        public DishRepository(RestaurantContext context)
        {
            db = context;
        }

        public IEnumerable<Dish> GetAll()
        {
            return db.Dishes;//.Include(d => d.Ingredients);//.SelectMany(ing => ing.Name));
        }

        public Dish Get(int id)
        {
            return db.Dishes.Find(id);
        }

        public void Create(Dish dish)
        {
            db.Dishes.Add(dish);
        }

        public void Update(Dish dish)
        {
            db.Entry(dish).State = EntityState.Modified;
        }

        public IEnumerable<Dish> Find(Func<Dish, Boolean> predicate)
        {
            return db.Dishes;//.Include(d => d.Ingredients).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Dish dish = db.Dishes.Find(id);
            if (dish != null)
                db.Dishes.Remove(dish);
        }
    }
}
