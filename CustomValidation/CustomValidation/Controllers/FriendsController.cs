using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomValidation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomValidation.Controllers
{
    public class FriendsController : Controller
    {
        // GET: Friends
        public ActionResult Index()
        {
            return View();
        }

        // GET: Friends/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Friends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friends/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Friends/Edit/5
        public ActionResult Edit(Friend friend)
        {
            if (!User.Identity.IsAuthenticated)
            {
                ModelState.AddModelError("", "La operación no está permitida");
            }
            if (!_friendServices.IsValidAge(friend.Age)
            {
                ModelState.AddModelError("Age", "La edad no es válida");
            }
            if (!ModelState.IsValid)
                return View(friend);
        }

        // POST: Friends/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Friends/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Friends/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}