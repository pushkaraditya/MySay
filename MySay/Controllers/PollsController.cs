using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySay.DB;
using MySay.Models;

namespace MySay.Controllers
{
  public class PollsController : Controller
  {
    /*
     * What we need
     * Current Polls
     * Popular polls
     * 
     * create polls
     * invite others to join/vote and remind
     * using google contacts
     * using facebook contacts
     * using facebook/google share
     * simple polls
     * order or finding priority polls
     * 
     * Create Account
     * using facebook
     * using google
     * share poll results using FB, Google, Twitter
     * */
    public ActionResult Index()
    {
      return View(new Poll());
    }

    public readonly PollRepository repository = new PollRepository();

    [HttpGet]
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Poll poll)
    {
      if (ModelState.IsValid)
      {
        repository.Create(poll);
        return RedirectToAction("Index");
      }
      else
        return View(poll);
    }

    public ActionResult GetPopularPolls()
    {
      var polls = repository.GetPolls();
      return View("ListPolls",polls);
    }

    public ActionResult GetCurrentPolls()
    {
      var polls = repository.GetPolls();
      return View(polls);
    }
  }
}