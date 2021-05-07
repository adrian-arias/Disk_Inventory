using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiskInventory.Models;

namespace DiskInventory.Controllers
{
    public class ArtistController : Controller
    {
        private disk_inventoryAAContext context { get; set; }

        public ArtistController(disk_inventoryAAContext ctx)
        {
            context = ctx;
        }
        //sort artist by first and last name
        public IActionResult Index()
        {
            var artists = context.Artists.OrderBy(a => a.Lname).ThenBy(a => a.Fname).ToList();
            return View(artists);
        }
        //add artist
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.ArtistTypes = context.ArtistTypes.OrderBy(t => t.Description).ToList();
            return View("Edit", new Artist());
        }
        //edit artist
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.ArtistTypes = context.ArtistTypes.OrderBy(t => t.Description).ToList();
            var artist = context.Artists.Find(id);
            return View(artist);
        }
        [HttpPost]
        public IActionResult Edit(Artist theartist)
        {
            if (ModelState.IsValid)
            {
                if(theartist.ArtistId == 0)
                {
                    //context.Artists.Add(theartist);
                    context.Database.ExecuteSqlRaw("execute sp_ins_artist @p0, @p1, @p2", parameters: new[] {theartist.Fname, theartist.Lname, theartist.ArtistTypeId.ToString() });
                }
                else
                {
                    //CREATE PROC sp_upd_artist @artist_id int, @fname nvarchar(60), @lname nvarchar(60), @artist_type_id int
                    //context.Artists.Update(theartist);
                    context.Database.ExecuteSqlRaw("execute sp_upd_artist @p0, @p1, @p2, @p3", parameters: new[] {theartist.ArtistId.ToString(), theartist.Fname,
                        theartist.Lname, theartist.ArtistTypeId.ToString() });
                }
                //context.SaveChanges();
                return RedirectToAction("Index", "Artist");
            }
            else
            {
                ViewBag.Action = (theartist.ArtistId == 0) ? "Add" : "Edit";
                ViewBag.ArtistTypes = context.ArtistTypes.OrderBy(t => t.Description).ToList();            
                return View(theartist);
            }
        }
        //delete artist
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var artist = context.Artists.Find(id);
            return View(artist);
        }
        [HttpPost]
        public IActionResult Delete(Artist artist)
        {
            //CREATE PROC sp_del_artist @artist_id int
            //context.Artists.Remove(artist);
            //context.SaveChanges();
            context.Database.ExecuteSqlRaw("execute sp_del_artist @p0", parameters: new[] {artist.ArtistId.ToString()  });
            return RedirectToAction("Index", "Artist");
        }
    }
}
