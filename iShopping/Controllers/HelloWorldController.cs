using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using iShopping.Models;
using System.Text.Encodings.Web;

namespace iShopping.Controllers
{
    public class HelloworldController : Controller
    {
        private readonly ILogger<HelloworldController> _logger;

        public HelloworldController(ILogger<HelloworldController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes=1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            //return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
            //return "This is the Welcome action method...";
            return View();
        }

    }
}
