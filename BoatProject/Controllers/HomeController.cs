using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BoatProject.Models;
using BoatProject.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using BoatProject.ViewModels;

namespace BoatProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        private readonly IWebHostEnvironment WebHostEnvironment;

        public HomeController(ILogger<HomeController> logger, DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _context = context;
            WebHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var boatdetail = _context.Boats.ToList();
            return View(boatdetail);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BoatViewModel vm)
        {
            string stringFileName = UploadFile(vm);
            var boat = new BoatDetail
            {
                BoatName = vm.BoatName,
                BoatRate = vm.BoatRate,
                BoatImage = stringFileName
            };

            _context.Boats.Add(boat);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditRent(int id)
        {
            var model = _context.Boats.Where(x => x.Id == id).FirstOrDefault();
            return View("RentDetail", model);
        }

        [HttpPost]
        public IActionResult EditRent(BoatDetail vm)
        {
            var Model = _context.Boats.FirstOrDefault(m => m.Id == vm.Id);
            Model.CustomerName = vm.CustomerName;
            Model.IsRented = vm.IsRented;
            Model.RentStart= DateTime.Now;

            _context.Boats.Update(Model);
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EditReturn(int id)
        {
            var model = _context.Boats.Where(x => x.Id == id).FirstOrDefault();
            return View("EditReturn", model);
        }

        [HttpPost]
        public IActionResult EditReturn(BoatDetail vm)
        {
            var Model = _context.Boats.FirstOrDefault(m => m.Id == vm.Id);
            Model.IsRented = !vm.IsReturned;
            Model.IsReturned = vm.IsReturned;
            Model.RentEnd = DateTime.Now;

            int time = Convert.ToInt32(Model.RentEnd.Subtract(Model.RentStart).TotalHours);
            Model.RentTime = time;

            _context.Boats.Update(Model);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boat = _context.Boats
                .FirstOrDefault(m => m.Id == id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        [HttpPost]
        public IActionResult Delete(BoatDetail model)
        {
            _context.Boats.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        private string UploadFile(BoatViewModel vm)
        {
            string fileName = null;
            if (vm.BoatImage != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + '-' + vm.BoatImage.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vm.BoatImage.CopyTo(fileStream);
                }
            }
            return fileName;
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
