using BO;
using ProjetModule5TP2.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetModule5TP2.Controllers
{
    public class ArmeController : Controller
    {

        ArmeDal armeDal = new ArmeDal();
        SamouraiDal samouraiDal = new SamouraiDal();

        // GET: Arme
        public ActionResult Index()
        {
            List<Arme> listArme = armeDal.getAll();
            return View(listArme);
        }

        // GET: Arme/Details/5
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Arme arme = armeDal.getOne(id.Value);
                return View(arme);
            }
            return RedirectToAction("Index");
        }

        // GET: Arme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arme/Create
        [HttpPost]
        public ActionResult Create(Arme arme)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    armeDal.create(arme);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Une erreur est survenue lors de la soumission du formulaire");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Arme/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                Arme arme = armeDal.getOne(id.Value);
                return View(arme);
            }
            return RedirectToAction("Index");
        }

        // POST: Arme/Edit/5
        [HttpPost]
        public ActionResult Edit(Arme arme)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (armeDal.update(arme) != null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "La modification a échoué");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Une erreur est survenue lors de la soumission du formulaire");
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Arme/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                return View(armeDal.getOne(id.Value));
            }
            return RedirectToAction("Index");
        }

        // POST: Arme/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Samourai samourai = samouraiDal.getAll().FirstOrDefault(x => x.Arme.Id == id);

                if(samourai == null)
                {
                    if (armeDal.delete(id))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Impossible de supprimer cette arme");
                        return View(armeDal.getOne(id));
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Impossible de supprimer cette arme. Elle est encore utilisée !");
                    return View(armeDal.getOne(id));
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
