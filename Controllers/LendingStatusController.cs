using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GaoXiao_Final.Models;

namespace GaoXiao_Final.Controllers
{
    public class LendingStatusController : Controller
    {
        private LibraryModels db = new LibraryModels();

        // GET: LendingStatus
        public ActionResult Index()
        {
            var lendingStatus = db.LendingStatus.Include(l => l.DiscussionRoomStatu).Include(l => l.Librarian).Include(l => l.User);
            return View(lendingStatus.ToList());
        }

        // GET: LendingStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LendingStatu lendingStatu = db.LendingStatus.Find(id);
            if (lendingStatu == null)
            {
                return HttpNotFound();
            }
            return View(lendingStatu);
        }

        // GET: LendingStatus/Create
        public ActionResult Create()
        {
            ViewBag.DiscussionRoom = new SelectList(db.DiscussionRoomStatus, "RoomNumber", "RoomType");
            ViewBag.PersonInCharge = new SelectList(db.Librarians, "Lid", "Name");
            ViewBag.UserID = new SelectList(db.Users, "Uid", "Name");
            return View();
        }

        // POST: LendingStatus/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LendingID,UserID,DiscussionRoom,StartTime,EndTime,NumberOfPeople,PersonInCharge")] LendingStatu lendingStatu)
        {
            if (ModelState.IsValid)
            {
                db.LendingStatus.Add(lendingStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiscussionRoom = new SelectList(db.DiscussionRoomStatus, "RoomNumber", "RoomType", lendingStatu.DiscussionRoom);
            ViewBag.PersonInCharge = new SelectList(db.Librarians, "Lid", "Name", lendingStatu.PersonInCharge);
            ViewBag.UserID = new SelectList(db.Users, "Uid", "Name", lendingStatu.UserID);
            return View(lendingStatu);
        }

        // GET: LendingStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LendingStatu lendingStatu = db.LendingStatus.Find(id);
            if (lendingStatu == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiscussionRoom = new SelectList(db.DiscussionRoomStatus, "RoomNumber", "RoomType", lendingStatu.DiscussionRoom);
            ViewBag.PersonInCharge = new SelectList(db.Librarians, "Lid", "Name", lendingStatu.PersonInCharge);
            ViewBag.UserID = new SelectList(db.Users, "Uid", "Name", lendingStatu.UserID);
            return View(lendingStatu);
        }

        // POST: LendingStatus/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LendingID,UserID,DiscussionRoom,StartTime,EndTime,NumberOfPeople,PersonInCharge")] LendingStatu lendingStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lendingStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiscussionRoom = new SelectList(db.DiscussionRoomStatus, "RoomNumber", "RoomType", lendingStatu.DiscussionRoom);
            ViewBag.PersonInCharge = new SelectList(db.Librarians, "Lid", "Name", lendingStatu.PersonInCharge);
            ViewBag.UserID = new SelectList(db.Users, "Uid", "Name", lendingStatu.UserID);
            return View(lendingStatu);
        }

        // GET: LendingStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LendingStatu lendingStatu = db.LendingStatus.Find(id);
            if (lendingStatu == null)
            {
                return HttpNotFound();
            }
            return View(lendingStatu);
        }

        // POST: LendingStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LendingStatu lendingStatu = db.LendingStatus.Find(id);
            db.LendingStatus.Remove(lendingStatu);
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

        public JsonResult getResult()
        {
            var result = db.LendingStatus.ToList();
            return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}
