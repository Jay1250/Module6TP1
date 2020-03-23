using BO;
using ProjetModule5TP2.Models.DAL;
using Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetModule5TP2.Controllers
{
    public class SamouraiController : Controller
    {
        SamouraiDal samouraiDal = new SamouraiDal();
        ArmeDal armeDal = new ArmeDal();

        // GET: Samourai
        public ActionResult Index()
        {
            List<Samourai> listSamourai = samouraiDal.getAll();
            return View(listSamourai);
        }

        // GET: Samourai/Details/5
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Samourai samourai = samouraiDal.getOne(id.Value);
                return View(samourai);
            }
            return RedirectToAction("Index");
        }

        // GET: Samourai/Create
        public ActionResult Create()
        {
            SamouraiVM vm = new SamouraiVM();
            vm.Armes = transformArmesToSelectedListItem();
            return View(vm);
        }

        // POST: Samourai/Create
        [HttpPost]
        public ActionResult Create(SamouraiVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Samourai samourai = vm.Samourai;
                    if (vm.IdArme.HasValue)
                    {
                        samourai.Arme = armeDal.getOne(vm.IdArme.Value);
                    }
                    samouraiDal.create(samourai);
                    return RedirectToAction("Index");
                }
                else
                {
                    vm.Armes = transformArmesToSelectedListItem();
                    ModelState.AddModelError("", "Une erreur est survenue lors de la soumission du formulaire");
                    return View(vm);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Samourai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                SamouraiVM vm = new SamouraiVM();
                vm.Armes = transformArmesToSelectedListItem();
                Samourai sam = samouraiDal.getOne(id.Value);
                vm.Samourai = sam;
                if(sam.Arme != null)
                {
                    vm.IdArme = sam.Arme.Id;
                }
                return View(vm);
            }
            return RedirectToAction("Index");
        }

        // POST: Samourai/Edit/5
        [HttpPost]
        public ActionResult Edit(SamouraiVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Samourai samourai = vm.Samourai;
                    if (vm.IdArme.HasValue)
                    {
                        samourai.Arme = armeDal.getOne(vm.IdArme.Value);
                    }
                   
                    if (samouraiDal.update(samourai) != null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Create");
                    }
                }
                else
                {
                    vm.Armes = transformArmesToSelectedListItem();
                    ModelState.AddModelError("", "Une erreur est survenue lors de la soumission du formulaire");
                    return View(vm);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Samourai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                return View(samouraiDal.getOne(id.Value));
            }
            return RedirectToAction("Index");
        }
        
        // POST: Samourai/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (samouraiDal.delete(id))
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Impossible de supprimer ce samourai");
                    return View(samouraiDal.getOne(id));
                }
            }
            catch
            {
                return View();
            }
        }

        private List<SelectListItem> transformArmesToSelectedListItem()
        {
            return armeDal.getAll().Select(
                x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() })
                .ToList();
        }
    }
}
