using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC2.DAL;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class FormBoardsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: FormBoards
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: FormBoards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormBoard formBoard = db.Students.Find(id);
            if (formBoard == null)
            {
                return HttpNotFound();
            }
            return View(formBoard);
        }

        // GET: FormBoards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormBoards/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormID,FormNo,Subject")] FormBoard formBoard)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(formBoard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formBoard);
        }

        // GET: FormBoards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormBoard formBoard = db.Students.Find(id);
            if (formBoard == null)
            {
                return HttpNotFound();
            }
            return View(formBoard);
        }

        // POST: FormBoards/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormID,FormNo,Subject")] FormBoard formBoard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formBoard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formBoard);
        }

        // GET: FormBoards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormBoard formBoard = db.Students.Find(id);
            if (formBoard == null)
            {
                return HttpNotFound();
            }
            return View(formBoard);
        }

        // POST: FormBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormBoard formBoard = db.Students.Find(id);
            //db.Students.Remove(formBoard);
            formBoard.Subject = "-1";
            db.SaveChanges();
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
