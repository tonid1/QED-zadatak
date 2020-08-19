using Microsoft.AspNet.Identity;
using Qed.Models;
using Qed.Models.Data_Access;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Qed.Controllers
{
    [Authorize]
    public class KnjigaController : Controller
    {
        private AppDbContext db = new AppDbContext();
        // GET: Knjiga

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Knjige.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                knjiga.Uploader = User.Identity.GetUserName();
                db.Knjige.Add(knjiga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(knjiga);
        }

        [HttpGet]
        public ActionResult Booking(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Knjiga knjiga = db.Knjige.Find(id);
            if(knjiga == null)
            {
                return HttpNotFound();
            }

            return View(knjiga);
        }

        [HttpPost]
        public ActionResult Booking(Knjiga knjiga)
        {
            knjiga.Bookirana = true;
            Booking booking = new Booking();
            booking.PocetakBookinga = DateTime.Now;
            booking.KnjigaId = knjiga.Id;

            if (ModelState.IsValid)
            {
                
                db.Entry(knjiga).State = EntityState.Modified;
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(knjiga);
        }

        public ActionResult MojeKnjige(string username)
        {
            if(username == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(db.Knjige.Where(x => x.Uploader == username).ToList());            
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Knjiga knjiga = db.Knjige.Find(id);
            if(knjiga == null)
            {
                return HttpNotFound();
            }

            return View(knjiga);
        }

        [HttpPost]
        public ActionResult Edit(Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knjiga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MojeKnjige");
            }

            return View(knjiga);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Knjiga knjiga = db.Knjige.Find(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }

            return View(knjiga);
        }

        [HttpPost]
        public ActionResult Delete(Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                db.Knjige.Remove(knjiga);
                db.SaveChanges();
                return RedirectToAction("MojeKnjige");
            }

            return View(knjiga);
        }
    }
}