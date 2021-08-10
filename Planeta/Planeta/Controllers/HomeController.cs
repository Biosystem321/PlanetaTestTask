using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planeta.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Planeta.Controllers
{
    public class HomeController : Controller
    {

        IUserRepository repository;
        public HomeController(IUserRepository r)
        {
            repository = r;
        }
        public ActionResult Index()
        {
            return View(repository.GetUsers());
        }

        public ActionResult Details(int id)
        {
            User user = repository.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }

        IEnumerable<string> sexes = new List<string>
        {
            "Мужской",
            "Женский"
        };

        public ActionResult Create()
        {
            ViewBag.Sexes = new SelectList(sexes);

            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {        
            if(ModelState.IsValid)
            {
                repository.Create(user);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Sexes = new SelectList(sexes);            
            User user = repository.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                repository.Update(user);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit");
            }
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            User user = repository.Get(id);
            if (user != null)
                return View(user);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
