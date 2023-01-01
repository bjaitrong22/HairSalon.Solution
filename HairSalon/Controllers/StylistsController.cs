using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class StylistsController: Controller
  {
    private readonly HairSalonContext _db;

    public StylistsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylist> model = _db.Stylists.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      if (stylist.FirstName != null && stylist.LastName != null && stylist.PhoneNumber != null && stylist.Specialty != null)
      {
        _db.Stylists.Add(stylist);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      else
      {
        ViewBag.ErrorMessage = "Please fill in all fields!";
        return View();
      }
    }

    public ActionResult Details(int id)
    {
      Stylist thisStylist = _db.Stylists.Include(stylist => stylist.Clients).FirstOrDefault(stylist => stylist.StylistId == id);

      return View(thisStylist);
    }

    public ActionResult Edit(int id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault( stylist => stylist.StylistId == id);
      return View(thisStylist);
    } 

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
      if (stylist.FirstName != null && stylist.LastName != null && stylist.PhoneNumber != null && stylist.Specialty != null)
      {
        _db.Stylists.Update(stylist);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      else
      {
        ViewBag.ErrorMessage = "Please fill in all fields!";
        return View();
      }    
    }

    public ActionResult Delete(int id) 
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      return View(thisStylist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Stylist thisStylist = _db.Stylists.FirstOrDefault( stylist => stylist.StylistId == id);
      _db.Stylists.Remove(thisStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");

    }
  }
}