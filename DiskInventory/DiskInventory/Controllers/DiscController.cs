using DiskInventory.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiskInventory.Controllers
{
    
    public class DiscController : Controller
    {
        private disk_inventoryAAContext context { get; set; }

        public DiscController(disk_inventoryAAContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            var discs = context.Discs.ToList();
            return View(discs);
        }
    }
}
