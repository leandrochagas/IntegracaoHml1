using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IntegracaoPsP.Domain.Entities.Log;
using IntegracaoPsP.Web.Models;

namespace IntegracaoPsP.Web.Controllers
{
    public class LogMessageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LogMessage
        public ActionResult Index()
        {
            return View(db.LogMensagens.ToList());
        }

        // GET: LogMessage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogMessage logMessage = db.LogMensagens.Find(id);
            if (logMessage == null)
            {
                return HttpNotFound();
            }
            return View(logMessage);
        }

        // GET: LogMessage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogMessage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Linha,NomeEntidade,Data,Message,MessageSystem")] LogMessage logMessage)
        {
            if (ModelState.IsValid)
            {
                db.LogMensagens.Add(logMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logMessage);
        }

        // GET: LogMessage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogMessage logMessage = db.LogMensagens.Find(id);
            if (logMessage == null)
            {
                return HttpNotFound();
            }
            return View(logMessage);
        }

        // POST: LogMessage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Linha,NomeEntidade,Data,Message,MessageSystem")] LogMessage logMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logMessage);
        }

        // GET: LogMessage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogMessage logMessage = db.LogMensagens.Find(id);
            if (logMessage == null)
            {
                return HttpNotFound();
            }
            return View(logMessage);
        }

        // POST: LogMessage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogMessage logMessage = db.LogMensagens.Find(id);
            db.LogMensagens.Remove(logMessage);
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
