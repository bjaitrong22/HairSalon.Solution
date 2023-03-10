using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class ClientsController: Controller
  {
    private readonly HairSalonContext _db;
    public ClientsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Client> model = _db.Clients.Include(client => client.Stylist).ToList();
      
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "LastName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Client client)
    {
      if (client.StylistId == 0)
      {
        ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "FirstName");
        ViewBag.AddStylistMessage = "As a reminder, a stylist needs to be added before a you can add a client.";

        return View();
      }
      else if(client.FirstName != null && client.LastName != null && client.PhoneNumber != null && client.Description != null)
      {
        _db.Clients.Add(client);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      else
      {
        ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "FirstName");
        ViewBag.ErrorMessage = "Please fill in all fields!";
        return View();
      }
    }

    public ActionResult Details(int id)
    {
      Client thisClient = _db.Clients.Include(client => client.Stylist).FirstOrDefault(client => client.ClientId == id);
      return View(thisClient);
    }

    public ActionResult Edit(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId","LastName");
      return View(thisClient);
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
      if (client.FirstName != null && client.LastName != null && client.PhoneNumber != null && client.Description != null)
      {
        _db.Clients.Update(client);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      else
      {
        ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "FirstName");
        ViewBag.ErrorMessage = "Please fill in all fields!";
        return View();
      }    
    }

    public ActionResult Delete(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault( client => client.ClientId == id);
      return View(thisClient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      _db.Clients.Remove(thisClient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}