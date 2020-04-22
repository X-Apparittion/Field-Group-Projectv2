using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Finalv2.Models;

namespace Finalv2.Controllers
{
    public class UserController : Controller
    {
        private Final_DBEntities db = new Final_DBEntities();

        // GET: User
        public async Task<ActionResult> Index()
        {
            return View(await db.Users_Stud.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users_Stud users_Stud = await db.Users_Stud.FindAsync(id);
            if (users_Stud == null)
            {
                return HttpNotFound();
            }
            return View(users_Stud);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "User_ID,Username,Email,Password,DateJoined,CurrentYr")] Users_Stud users_Stud)
        {
            if (ModelState.IsValid)
            {
                db.Users_Stud.Add(users_Stud);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(users_Stud);
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users_Stud users_Stud = await db.Users_Stud.FindAsync(id);
            if (users_Stud == null)
            {
                return HttpNotFound();
            }
            return View(users_Stud);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "User_ID,Username,Email,Password,DateJoined,CurrentYr")] Users_Stud users_Stud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users_Stud).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(users_Stud);
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users_Stud users_Stud = await db.Users_Stud.FindAsync(id);
            if (users_Stud == null)
            {
                return HttpNotFound();
            }
            return View(users_Stud);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Users_Stud users_Stud = await db.Users_Stud.FindAsync(id);
            db.Users_Stud.Remove(users_Stud);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
