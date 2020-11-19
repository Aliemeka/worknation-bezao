using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationBoard.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error/404")]
        public IActionResult Error404()
        {
            return View("error404");
        }

        [Route("error/{code:int}")]
        public IActionResult ErrorPage(int code)
        {
            ViewBag.ErrorMessage = "Error " + code; 
            return View("ErrorPage");
        }
    }
}
