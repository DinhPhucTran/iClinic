using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iClinic.Models;

namespace iClinic.Controllers
{
    public class DonTiepController : Controller
    {
        private Entities db = new Entities();
        private string msgType = "";
        private string msgContent = "";
        private string msgTitle = "";

        //
        // GET: /DonTiep/

        public ActionResult Index()
        {
            return View(db.DbSetBenhNhan.ToList());
        }

        //
        // GET: /DonTiep/Details/5

        public ActionResult Details(int id = 0)
        {
            BenhNhan benhnhan = db.DbSetBenhNhan.Find(id);
            if (benhnhan == null)
            {
                return HttpNotFound();
            }
            return View(benhnhan);
        }

        //
        // GET: /DonTiep/Create

        public ActionResult Create()
        {
            ViewBag.MsgType = "success";
            ViewBag.MsgTitle = "msgTitle";
            ViewBag.MsgContent = "msgContent";

            msgType = "";
            msgTitle = "";
            msgContent = "";
            return View();
        }

        //
        // POST: /DonTiep/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BenhNhan benhnhan)
        {
            benhnhan.NgayTiepNhan = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.DbSetBenhNhan.Add(benhnhan);
                db.SaveChanges();
                msgType = "success";
                msgTitle = "Thành công";
                msgContent = "Đã lưu thông tin bệnh nhân";
                return RedirectToAction("Create");
            }
            return View(benhnhan);
        }

        //
        // GET: /DonTiep/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BenhNhan benhnhan = db.DbSetBenhNhan.Find(id);
            if (benhnhan == null)
            {
                return HttpNotFound();
            }
            return View(benhnhan);
        }

        //
        // POST: /DonTiep/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BenhNhan benhnhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benhnhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(benhnhan);
        }

        //
        // GET: /DonTiep/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BenhNhan benhnhan = db.DbSetBenhNhan.Find(id);
            if (benhnhan == null)
            {
                return HttpNotFound();
            }
            return View(benhnhan);
        }

        //
        // POST: /DonTiep/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BenhNhan benhnhan = db.DbSetBenhNhan.Find(id);
            db.DbSetBenhNhan.Remove(benhnhan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }

    public class Message
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}