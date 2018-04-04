using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using IntegracaoPsP.Domain.Entities.Xml;
using IntegracaoPsP.Web.Models;

namespace IntegracaoPsP.Web.Controllers
{
    public class IntegrationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Integrations
        public ActionResult Index()
        {
            return View(db.Integracoes.ToList());
        }

        // GET: Integrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integration integration = db.Integracoes.Find(id);
            if (integration == null)
            {
                return HttpNotFound();
            }
            return View(integration);
        }

        // GET: Integrations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Integrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IntegrationId,Entidade,DtEntrada,XmlRecebido,XmlAlterado,Situacao,NomeArquivo,DtProcessamento,DtRetorno")] Integration integration)
        {
            if (ModelState.IsValid)
            {
                db.Integracoes.Add(integration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(integration);
        }

        // GET: Integrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integration integration = db.Integracoes.Find(id);
            if (integration == null)
            {
                return HttpNotFound();
            }
            return View(integration);
        }

        // POST: Integrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IntegrationId,Entidade,DtEntrada,XmlRecebido,XmlAlterado,Situacao,NomeArquivo,DtProcessamento,DtRetorno")] Integration integration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(integration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(integration);
        }

        // GET: Integrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integration integration = db.Integracoes.Find(id);
            if (integration == null)
            {
                return HttpNotFound();
            }
            return View(integration);
        }

        // POST: Integrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Integration integration = db.Integracoes.Find(id);
            db.Integracoes.Remove(integration);
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
