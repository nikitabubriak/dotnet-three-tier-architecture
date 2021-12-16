using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.DTO;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class DishController : Controller
    {

        IMenuService menuService;

        MapperConfiguration dishConfig = new MapperConfiguration(c => c.CreateMap<DishDTO, DishViewModel>());

        public DishController(IMenuService menuService)
        {
            this.menuService = menuService;
        }

        // GET: DishController
        public IActionResult Index()
        {
            var menu = menuService.GetMenu();
            if (menu == null)
            {
                return Error();
            }
            var mapper = new Mapper(dishConfig);
            var dishViewModel = mapper.Map<IEnumerable<DishDTO>, IEnumerable<DishViewModel>>(menu);
            return View(dishViewModel);
        }

        // GET: DishController/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return Error();
            }
            var dish = menuService.GetDish(id);

            if (dish == null)
            {
                return Error();
            }

            var mapper = new Mapper(dishConfig);
            var dishViewModel = mapper.Map<DishDTO, DishViewModel>(dish);
            return View(dishViewModel);
        }

        // GET: DishController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DishController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DishController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: DishController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DishController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: DishController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
