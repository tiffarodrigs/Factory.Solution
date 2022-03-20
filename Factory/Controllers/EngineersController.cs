using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }
      
      public ActionResult Index()
      {
        List<Engineer> model = _db.Engineers.ToList();
        return View(model);
      }

      public ActionResult Create()
      {
        ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
        return View();
      }

      [HttpPost]
      public ActionResult Create(Engineer engineer ,int MachineId)
      {
        _db.Engineers.Add(engineer);
        _db.SaveChanges();
        if(MachineId!=0)
        {
          _db.EngineerMachine.Add(new EngineerMachine{ MachineId = MachineId,EngineerId = engineer.EngineerId});
          _db.SaveChanges();
        }
        return RedirectToAction("Index");
      }

      public ActionResult Details(int id)
      {
        var thisEngineer = _db.Engineers
        .Include(m => m.JoinEntities)
        .ThenInclude(m => m.Machine)
        .FirstOrDefault(m => m.EngineerId == id);
        return View(thisEngineer);
      }

      public ActionResult Edit(int id)
      {
        var thisEngineer = _db.Engineers.FirstOrDefault(m => m.EngineerId == id);
        ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
        return View(thisEngineer);
      }

      [HttpPost]
      public ActionResult Edit(Engineer engineer,int MachineId)
      {
        if(MachineId!=0)
        {
          _db.EngineerMachine.Add(new EngineerMachine{ MachineId = MachineId,EngineerId = engineer.EngineerId});
          _db.SaveChanges();
        }        
        _db.Entry(engineer).State = EntityState.Modified;
        _db.SaveChanges();     
        return RedirectToAction("Index");
      }

      public ActionResult Delete(int id)
      {
        var thisEngineer = _db.Engineers.FirstOrDefault(m => m.EngineerId == id);
        return View(thisEngineer);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfirmed(int id)
      {
        var thisEngineer = _db.Engineers.FirstOrDefault(m => m.EngineerId == id);
        _db.Engineers.Remove(thisEngineer);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }  

      public ActionResult AddMachine(int id)
      {
        var engMachEntries = _db.EngineerMachine.Where(m => m.EngineerId == id);        
        List<Machine> machineList = _db.Machines.ToList();
        List<Machine> machines = _db.Machines.ToList();     
        foreach(EngineerMachine em in engMachEntries )
        {
          foreach(Machine mach in machines)
          {
            if(mach.MachineId== em.MachineId)
            {
              machineList.Remove(mach);
            }
          }
        }
        ViewBag.MachineId = new SelectList(machineList, "MachineId", "MachineName");
        ViewBag.machineList = machineList.Count;
        var thisEngineer = _db.Engineers.FirstOrDefault(m => m.EngineerId == id);
        return View(thisEngineer);
      }

      [HttpPost]
      public ActionResult AddMachine(Engineer engineer,int MachineId)
      {
        if(MachineId!=0)
        {
          _db.EngineerMachine.Add(new EngineerMachine{ MachineId = MachineId,EngineerId = engineer.EngineerId});
          _db.SaveChanges();
        }    
        return RedirectToAction("Index");
      }  
      [HttpPost]
      public ActionResult DeleteMachine(int joinId)
      {
        //This function deletes only the machine from this particular engineer.ie.it deltes entry from EngineerMachine  table
        //This does not delete the machine from the machine table
          var joinEntry = _db.EngineerMachine.FirstOrDefault(m => m.EngineerMachineId == joinId);
          _db.EngineerMachine.Remove(joinEntry);
          _db.SaveChanges();
          return RedirectToAction("Index");
      }    
  }
    
} 