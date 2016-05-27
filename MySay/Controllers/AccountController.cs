using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySay.Controllers
{
  public class AccountController : Controller
  {
    [HttpGet]
    public ActionResult Register()
    {
      return View();
    }
  }
}