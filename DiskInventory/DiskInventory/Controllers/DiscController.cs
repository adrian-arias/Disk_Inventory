using DiskInventory.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DiskInventory.Controllers
{
    
    public class DiscController : Controller
    {
        private disk_inventoryAAContext context { get; set; }

        public DiscController(disk_inventoryAAContext ctx)
        {
            context = ctx;
        }
        //sort disc by name and status
        public IActionResult Index()
        {
            var discs = context.Discs.OrderBy(d => d.DiscName).ThenBy(s => s.StatusId).ToList();
            return View(discs);
        }
        //add disc
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Description).ToList();
            ViewBag.Statuses = context.Statuses.OrderBy(s => s.Description).ToList();
            ViewBag.DiscTypes = context.DiscTypes.OrderBy(dt => dt.Description).ToList();
            return View("Edit", new Disc());
        }
        //edit disc
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(g => g.Description).ToList();
            ViewBag.Statuses = context.Statuses.OrderBy(s => s.Description).ToList();
            ViewBag.DiscTypes = context.DiscTypes.OrderBy(dt => dt.Description).ToList();
            var disc = context.Discs.Find(id);
            return View(disc);
        }
        
        [HttpPost]
        public IActionResult Edit(Disc disc)
        {
            if (ModelState.IsValid)
            {
                if(disc.DiscId == 0)
                {
                    //context.Discs.Add(disc);
                    context.Database.ExecuteSqlRaw("execute sp_ins_disc @p0, @p1, @p2, @p3, @p4", parameters: new[] { disc.DiscName, disc.ReleaseDate.ToString(),
                        disc.GenreId.ToString(), disc.StatusId.ToString(), disc.DiscTypeId.ToString() });
                }
                else
                {
                    //context.Discs.Update(disc);
                    context.Database.ExecuteSqlRaw("execute sp_upd_disc @p0, @p1, @p2, @p3, @p4, @p5", parameters: new[] { disc.DiscId.ToString(), disc.DiscName, disc.ReleaseDate.ToString(),
                        disc.GenreId.ToString(), disc.StatusId.ToString(), disc.DiscTypeId.ToString() });
                }
                //context.SaveChanges();
                return RedirectToAction("Index", "Disc");
            }
            else
            {
                ViewBag.Action = (disc.DiscId == 0) ? "Add" : "Edit";
                ViewBag.Genres = context.Genres.OrderBy(g => g.Description).ToList();
                ViewBag.Statuses = context.Statuses.OrderBy(s => s.Description).ToList();
                ViewBag.DiscTypes = context.DiscTypes.OrderBy(dt => dt.Description).ToList();
                return View(disc);
            }
        }
        //delete disc
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var disc = context.Discs.Find(id);
            return View(disc);
        }

        [HttpPost]
        public IActionResult Delete(Disc disc)
        {
            //context.Discs.Remove(disc);
            //context.SaveChanges();
            context.Database.ExecuteSqlRaw("execute sp_del_disc @p0", parameters: new[] { disc.DiscId.ToString() });
            return RedirectToAction("Index", "Disc");
        }





    }
}
