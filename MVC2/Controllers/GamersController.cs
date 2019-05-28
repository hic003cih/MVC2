using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC2.DAL;
using MVC2.Models;
using MVC2.ViewModels;
using PagedList;

namespace MVC2.Controllers
{
    public class GamersController : Controller
    {
        private OnlineGameContext db = new OnlineGameContext();

        // GET: Gamers
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Gamers.ToListAsync());
        //}

        //public ActionResult Index(string sortOrder, string searchString)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.DateSortParm = sortOrder == "GameMoney" ? "money_desc" : "money";
        //    var gamers = from s in db.Gamers
        //        select s;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        //gamers = gamers.Where(s => s.LastName.Contains(searchString)
        //        //                               || s.FirstMidName.Contains(searchString));

        //        string[] conditions = new string[] { searchString.Trim(), searchString.ToUpper().Trim() };

        //        gamers = gamers.Where(s => s.Name.Contains(searchString.Trim()) | s.Name.Contains(searchString.ToUpper().Trim()));

        //    }
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            gamers = gamers.OrderByDescending(s => s.Name);
        //            break;
        //        case "money":
        //            gamers = gamers.OrderBy(s => s.GameMoney);
        //            break;
        //        case "money_desc":
        //            gamers = gamers.OrderByDescending(s => s.GameMoney);
        //            break;
        //        default:
        //            gamers = gamers.OrderBy(s => s.Name);
        //            break;
        //    }

        //    return View(gamers.ToList());
        //}

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "GameMoney" ? "money_desc" : "money";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var gamers = from s in db.Gamers
                select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                //gamers = gamers.Where(s => s.LastName.Contains(searchString)
                //                               || s.FirstMidName.Contains(searchString));

                string[] conditions = new string[] { searchString.Trim(), searchString.ToUpper().Trim() };

                gamers = gamers.Where(s => s.Name.Contains(searchString.Trim()) | s.Name.Contains(searchString.ToUpper().Trim()));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    gamers = gamers.OrderByDescending(s => s.Name);
                    break;
                case "money":
                    gamers = gamers.OrderBy(s => s.GameMoney);
                    break;
                case "money_desc":
                    gamers = gamers.OrderByDescending(s => s.GameMoney);
                    break;
                default:
                    gamers = gamers.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(gamers.ToPagedList(pageNumber, pageSize));
        }
        // GET: Gamers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = await db.Gamers.FindAsync(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }

        // GET: Gamers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gamers/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Gender,Score,GameMoney")]
            Gamer gamer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Gamers.Add(gamer);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("",
                    "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }


            return View(gamer);
        }

        // GET: Gamers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamer gamer = await db.Gamers.FindAsync(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }

        // POST: Gamers/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Gender,Score,GameMoney")] Gamer gamer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(gamer).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(gamer);
        //}

        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditPost(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var ToUpdate = db.Gamers.Find(id);
        //    if (TryUpdateModel(ToUpdate, "",
        //        new string[] { "Id", "Name", "Gender", "Score", "GameMoney" }))
        //    {
        //        try
        //        {
        //            db.SaveChanges();

        //            return RedirectToAction("Index");
        //        }
        //        catch (DataException /* dex */)
        //        {
        //            //Log the error (uncomment dex variable name and add a line here to write a log.
        //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        //        }
        //    }
        //    return View(ToUpdate);
        //}

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ToUpdate = db.Gamers.Find(id);
            if (TryUpdateModel(ToUpdate, "",
                new string[] { "Id", "Name", "Gender", "Score", "GameMoney" }))
            {
                try
                {
                    await db.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(ToUpdate);
        }
        // GET: Gamers/Delete/5
        public async Task<ActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Gamer gamer = await db.Gamers.FindAsync(id);
            if (gamer == null)
            {
                return HttpNotFound();
            }
            return View(gamer);
        }

        // POST: Gamers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Gamer gamer = await db.Gamers.FindAsync(id);
        //    db.Gamers.Remove(gamer);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Gamer gamer = db.Gamers.Find(id);
                db.Gamers.Remove(gamer);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        //關閉資料庫連線
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult About()
        {
            IQueryable<Group> data = from student in db.Gamers
                group student by student.Gender into dateGroup
                select new Group()
                {
                    Gender = dateGroup.Key,
                    ScoreCount = dateGroup.Count()
                };
            return View(data.ToList());
        }
    }
}
