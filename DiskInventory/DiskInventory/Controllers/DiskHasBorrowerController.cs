using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiskInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace DiskInventory.Controllers
{
    public class DiskHasBorrowerController : Controller
    {
        private disk_inventoryAAContext context { get; set; }
        public DiskHasBorrowerController (disk_inventoryAAContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var diskhasborrowers = context.DiscHasBorrowers.
            Include(d => d.Disc).OrderBy(d => d.Disc.DiscName).
            Include(b => b.Borrower).ToList();
            return View(diskhasborrowers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Discs = context.Discs.OrderBy(d => d.DiscName).ToList();
            ViewBag.Borrowers = context.Borrowers.OrderBy(b => b.Lname).ToList();
            DiscHasBorrower newdiskhasborrower = new DiscHasBorrower();
            newdiskhasborrower.BorrowedDate = DateTime.Today;
            newdiskhasborrower.DueDate = DateTime.Today; 
            return View("Edit", newdiskhasborrower);
            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Discs = context.Discs.OrderBy(d => d.DiscName).ToList();
            ViewBag.Borrowers = context.Borrowers.OrderBy(b => b.Lname).ToList();
            var diskhasborrower = context.DiscHasBorrowers.Find(id);
            return View(diskhasborrower);
            
        }
        [HttpPost]
        public IActionResult Edit(DiscHasBorrower discHasBorrower)
        {
            if (ModelState.IsValid)
            {
                if (discHasBorrower.DiscHasBorrowerId == 0)
                {
                    context.DiscHasBorrowers.Add(discHasBorrower);
                }
                else
                {
                    context.DiscHasBorrowers.Update(discHasBorrower);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "DiskHasBorrower");
            }
            else
            {
                ViewBag.Action = (discHasBorrower.DiscHasBorrowerId == 0) ? "Add" : "Edit";
                ViewBag.Discs = context.Discs.OrderBy(d => d.DiscName).ToList();
                ViewBag.Borrowers = context.Borrowers.OrderBy(b => b.Lname).ToList();
               
                return View(discHasBorrower);
            }          
        }
    }
}
