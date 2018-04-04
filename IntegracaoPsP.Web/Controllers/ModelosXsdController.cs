using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using IntegracaoPsP.Domain.Entities.Others;
using IntegracaoPsP.Web.Models;
using System.Web;
using System.IO;
using System;
using System.Text.RegularExpressions;

namespace IntegracaoPsP.Web.Controllers
{
    public class ModelosXsdController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ModelosXsd
        public ActionResult Index()
        {
            return View(db.ModelosXsd.ToList());
        }

        // GET: ModelosXsd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloXsd modeloXsd = db.ModelosXsd.Find(id);
            if (modeloXsd == null)
            {
                return HttpNotFound();
            }
            return View(modeloXsd);
        }

        // GET: ModelosXsd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelosXsd/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModeloXsdId,NomeArquivo,Versao,Modelo,StAtivo,Data,Usuario")] ModeloXsd modeloXsd, HttpPostedFile file)
        {
            string CaminhoValido = db.Parametros.Where(x => x.Nome == "ArquivosValidos").Select(x => x.Valor).FirstOrDefault();
            var caminhoDestino = Path.Combine(CaminhoValido, Path.GetFileName(file.FileName));
            string xmlString="";
            string[] arrayversaoArquivosTratado = Regex.Split(file.FileName, "_");
           
            string nomeArquivosTratado = arrayversaoArquivosTratado[0].ToString();
            string versaoArquivosTratado = arrayversaoArquivosTratado[1].ToString().Replace(".xsd", "");
            try
            {
                foreach (HttpPostedFile arquivo in Request.Files)
                {
                    //Save to a file
                    file.SaveAs(Path.Combine(caminhoDestino, Path.GetFileName(arquivo.FileName)));

                    xmlString = System.IO.File.ReadAllText(caminhoDestino);
                    // * OR *
                    //Use file.InputStream to access the uploaded file as a stream
                    //byte[] buffer = new byte[1024];
                    //int read = file.InputStream.Read(buffer, 0, buffer.Length);
                    //while (read > 0)
                    //{
                    //    //do stuff with the buffer
                    //    read = file.InputStream.Read(buffer, 0, buffer.Length);
                    //}
                }

                if (ModelState.IsValid)
                {
                    modeloXsd.Modelo = xmlString;
                    modeloXsd.Data = DateTime.Now;
                    modeloXsd.Usuario = "Adm";
                    modeloXsd.Versao = versaoArquivosTratado;
                    modeloXsd.NomeArquivo = nomeArquivosTratado;
                    db.ModelosXsd.Add(modeloXsd);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(modeloXsd);
                // return Json(new { Result = "Complete" });
            }
            catch (Exception)
            {
                return Json(new { Result = "Error" });
            }


           
        }

        // GET: ModelosXsd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloXsd modeloXsd = db.ModelosXsd.Find(id);
            if (modeloXsd == null)
            {
                return HttpNotFound();
            }
            return View(modeloXsd);
        }

        // POST: ModelosXsd/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModeloXsdId,NomeArquivo,Versao,Modelo,StAtivo,Data,Usuario")] ModeloXsd modeloXsd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modeloXsd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modeloXsd);
        }

        // GET: ModelosXsd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloXsd modeloXsd = db.ModelosXsd.Find(id);
            if (modeloXsd == null)
            {
                return HttpNotFound();
            }
            return View(modeloXsd);
        }

        // POST: ModelosXsd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModeloXsd modeloXsd = db.ModelosXsd.Find(id);
            db.ModelosXsd.Remove(modeloXsd);
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
