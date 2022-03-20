using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Machine> model = _db.Machines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
      .Include(m => m.JoinEntities)
      .ThenInclude(m => m.Engineer)
      .FirstOrDefault(m => m.MachineId == id);
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      var thisMachine= _db.Machines.FirstOrDefault(m => m.MachineId == id);
      return View(thisMachine);
    }

      [HttpPost]
      public ActionResult Edit(Machine machine)
      {
        _db.Entry(machine).State = EntityState.Modified;
        _db.SaveChanges();     
        return RedirectToAction("Index");
      }

      public ActionResult Delete(int id)
      {
        var thisMachine = _db.Machines.FirstOrDefault(m => m.MachineId == id);
        return View(thisMachine);
      }

      [HttpPost, ActionName("Delete")]
      public ActionResult DeleteConfirmed(int id)
      {
        var thisMachine = _db.Machines.FirstOrDefault(m => m.MachineId == id);
        _db.Machines.Remove(thisMachine);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }   

            public ActionResult AddEngineer(int id)
      {
        var engMachEntries = _db.EngineerMachine.Where(m => m.MachineId == id);        
        List<Engineer> engineerList = _db.Engineers.ToList();
        List<Engineer> engineers = _db.Engineers.ToList();     
        foreach(EngineerMachine em in engMachEntries )
        {
          foreach(Engineer eng in engineers)
          {
            if(eng.EngineerId== em.EngineerId)
            {
              engineerList.Remove(eng);
            }
          }
        }
        ViewBag.EngineerId = new SelectList(engineerList, "EngineerId", "EngineerName");
        ViewBag.engineerList = engineerList.Count;
        var thisMachine = _db.Machines.FirstOrDefault(m => m.MachineId == id);
        return View(thisMachine);
      }

      [HttpPost]
      public ActionResult AddEngineer(Machine machine,int EngineerId)
      {
        if(EngineerId!=0)
        {
          _db.EngineerMachine.Add(new EngineerMachine{ EngineerId = EngineerId,MachineId = machine.MachineId});
          _db.SaveChanges();
        }    
        return RedirectToAction("Index");
      }  
      [HttpPost]
      public ActionResult DeleteEngineer(int joinId)
      {
        //This function deletes only the engineer from this particular machine.ie.it deltes entry from EngineerMachine  table
        //This does not delete the engineer from the engineer table
          var joinEntry = _db.EngineerMachine.FirstOrDefault(m => m.EngineerMachineId == joinId);
          _db.EngineerMachine.Remove(joinEntry);
          _db.SaveChanges();
          return RedirectToAction("Index");
      }           
  }
}