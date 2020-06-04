using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class ImmagineFilmsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ImmagineFilms
        public ActionResult Index()
        {
            return View(db.immagineFilms.ToList());
        }

        // GET: ImmagineFilms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ImmagineFilm immagineFilm = db.immagineFilms.Find(id);
            if (immagineFilm == null)
            {
                return HttpNotFound();
            }
            return View(immagineFilm);
        }

        // GET: ImmagineFilms/Create
        public ActionResult Carica()
        {
            return View();
        }

        // POST: ImmagineFilms/Create
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Carica(HttpPostedFileBase[] files)
        {
            bool allValid = true;
            string inValidFiles = "";
            
            db.Database.Log = sql => Trace.WriteLine(sql);
            //check the user has entered a file
            if (files[0] != null)
            {
                //if the user has entered less than ten files
                if (files.Length <= 10)
                {
                    foreach (var file in files)
                    {
                        if (!ValidateFile(file))
                        {
                            allValid = false;
                            inValidFiles += ", " + file.FileName;
                        }
                    }
                    //if they are all valid then try to save them to disk
                    if (allValid)
                    {
                        foreach (var file in files)
                        {
                            try
                            {
                                SaveFileToDisk(file);
                            }
                            catch (Exception)
                            {
                                ModelState.AddModelError("NomeFile", "Errore durante il caricamento dei files, provare di nuovo");
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("NomeFile", "Tutti i files devono essere gif, png, jpeg o jpg e non superiori ai 2MB.I files seguenti:" + inValidFiles + " non sono validi");
                    }
                }
                            //the user has entered more than 10 files
                else
                {
                    ModelState.AddModelError("NomeFile", "Caricare 10 files per volta");
                }
            }
            else
            {
                //if the user has not entered a file return an error message
                ModelState.AddModelError("NomeFile", "Scegliere un file");
            }

            if (ModelState.IsValid)
            {
                bool duplicates = false;
                bool otherDbError = false;
                string duplicateFiles = "";

                foreach (var file in files)
                {
                    //try and save each file
                    var productToAdd = new ImmagineFilm { NomeFile = file.FileName };
                    //try
                    //{
                        if(db.immagineFilms.Any(f=>f.NomeFile == file.FileName))
                        {
                            duplicateFiles += ", " + file.FileName;
                            duplicates = true;
                            db.Entry(productToAdd).State = EntityState.Detached;
                        }
                        else
                        {
                            db.immagineFilms.Add(productToAdd);

                        }
                        
                        //db.SaveChanges();
                    //}
                    //if there is an exception check if it is caused by a duplicate file
                    //catch (DbUpdateException ex)
                    //{
                       
                    //    SqlException innerException = ex.InnerException.InnerException as SqlException;
                    //    if (innerException != null && innerException.Number == 2601)
                    //    {
                    //        duplicateFiles += ", " + file.FileName;
                    //        duplicates = true;
                    //        db.Entry(productToAdd).State = EntityState.Detached;
                    //    }
                    //    else
                    //    {
                    //        otherDbError = true;
                    //    }
                    //}
                }

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    otherDbError = true;
                }
                

                if (duplicates)
                {
                    ModelState.AddModelError("NomeFile", "Tutti i files sono stati caricati ad eccezione di: " +
                    duplicateFiles + ", che già esistono nel sistema.");
                    
                    return View();
                }
                else if (otherDbError)
                {
                    ModelState.AddModelError("FileName", "Errore durante il salvataggio dei files, riprovare");
                    
                    return View();
                }

                return RedirectToAction("Index");
            }

           return View();
        }

            // GET: ImmagineFilms/Edit/5
            public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImmagineFilm immagineFilm = db.immagineFilms.Find(id);
            if (immagineFilm == null)
            {
                return HttpNotFound();
            }
            return View(immagineFilm);
        }

        // POST: ImmagineFilms/Edit/5
        // Per proteggere da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per ulteriori dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NomeFile")] ImmagineFilm immagineFilm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(immagineFilm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(immagineFilm);
        }

        // GET: ImmagineFilms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImmagineFilm immagineFilm = db.immagineFilms.Find(id);
            if (immagineFilm == null)
            {
                return HttpNotFound();
            }
            return View(immagineFilm);
        }

        // POST: ImmagineFilms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImmagineFilm immagineFilm = db.immagineFilms.Find(id);
            db.immagineFilms.Remove(immagineFilm);
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

        private bool ValidateFile(HttpPostedFileBase file)
        {
            string fileExtension =Path.GetExtension(file.FileName).ToLower();
            string[] allowedFileTypes = { ".gif", ".png", ".jpeg", ".jpg" };
            if ((file.ContentLength > 0 && file.ContentLength < 2097152) &&
            allowedFileTypes.Contains(fileExtension))
            {
                return true;
            }
            return false;
        }

        private void SaveFileToDisk(HttpPostedFileBase file)
        {
            WebImage img = new WebImage(file.InputStream);
            if (img.Width > 190)
            {
                img.Resize(190, img.Height);
            }
            img.Save(Costanti.IndirizzoImmagineProdotto + file.FileName);
            if (img.Width > 100)
            {
                img.Resize(100, img.Height);
            }
            img.Save(Costanti.ProductThumbnailPath + file.FileName);
        }
    }
}
