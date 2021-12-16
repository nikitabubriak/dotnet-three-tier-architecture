using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.DTO;
using AutoMapper;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        IMenuService menuService;

        MapperConfiguration dishConfig = new MapperConfiguration(c => c.CreateMap<DishDTO, DishViewModel>());

        public HomeController(ILogger<HomeController> logger, IMenuService menuService)
        {
            _logger = logger;
            this.menuService = menuService;
        }

        public IActionResult Index()
        {
            var menu = menuService.GetMenu();
            var mapper = new Mapper(dishConfig);
            var dishViewModel = mapper.Map<IEnumerable<DishDTO>, IEnumerable<DishViewModel>>(menu);
            return View(dishViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
