using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
namespace ProjectName.Controllers
{
  public class HomeController : Controller
  {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
  [Route("/favorite_photos")]
  public ActionResult FavoritePhotos()
  {
    return View();
  }
  }
}