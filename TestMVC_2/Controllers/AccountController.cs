using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;

namespace TestMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpPost]
        public ActionResult Account(LoginModel lm)
        {
            return View(lm);
        }
    }
    
}