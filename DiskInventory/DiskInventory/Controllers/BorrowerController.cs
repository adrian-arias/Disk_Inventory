using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DiskInventory.Models;

namespace DiskInventory.Controllers
{
    public class BorrowerController : Controller
    {
        private disk_inventoryAAContext context { get; set; }

        public BorrowerController(disk_inventoryAAContext ctx)
        {
            context = ctx;
        }
        //table sorting by name
        public IActionResult Index()
        {
            var borrowers = context.Borrowers.OrderBy(b => b.Lname).ToList();
            return View(borrowers);
        }
        //add borrowers
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Borrower());
        }
        //edit borrowers
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var borrower = context.Borrowers.Find(id);
            return View(borrower);
        }
        [HttpPost]
        public IActionResult Edit (Borrower borrower)
        {
            if (ModelState.IsValid)
            {
                if (borrower.BorrowerId == 0)
                    //context.Borrowers.Add(borrower);
                context.Database.ExecuteSqlRaw("execute sp_ins_borrower @p0, @p1, @p2", parameters: new[] {borrower.Fname, borrower.Lname, borrower.PhoneNum.ToString() });
                else
                    //context.Borrowers.Update(borrower);
                context.Database.ExecuteSqlRaw("execute sp_upd_borrower @p0, @p1, @p2, @p3", parameters: new[] { borrower.BorrowerId.ToString(), borrower.Fname,
                    borrower.Lname, borrower.PhoneNum.ToString() });
                //context.SaveChanges();
                return RedirectToAction("Index", "Borrower");
            }
            else
            {
                ViewBag.Action = (borrower.BorrowerId == 0) ? "Add" : "Edit";
                return View(borrower);
            }
        }
        //delete borrowers
        [HttpGet]
        public IActionResult Delete (int id)
        {
            var borrower = context.Borrowers.Find(id);
            return View(borrower);
        }
        [HttpPost]
        public IActionResult Delete (Borrower borrower)
        {
            //context.Borrowers.Remove(borrower);
            //context.SaveChanges();
            context.Database.ExecuteSqlRaw("execute sp_del_borrower @p0", parameters: new[] { borrower.BorrowerId.ToString() });
            return RedirectToAction("Index", "Borrower");
        }
    }
}
