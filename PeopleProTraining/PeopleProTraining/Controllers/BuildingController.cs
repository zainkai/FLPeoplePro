using PeopleProTraining.Dal.Infrastructure;
using PeopleProTraining.Dal.Interfaces;
using PeopleProTraining.Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PeopleProTraining.Controllers
{
    public class BuildingController : Controller
    {
        #region datasetup (allows access to SQL data base)
        private IPeopleProRepo m_repo;
        public BuildingController() : this(new PeopleProRepo())
        {
        }
        public BuildingController(IPeopleProRepo repo)
        {
            m_repo = repo;
        }
        #endregion

        public ActionResult Index()
        {
            //creating an object filled with database info....
            IEnumerable<Building> buildings = m_repo.GetBuildings();
            if (buildings == null)//TODO Check for object equivalent of .IsNullOrEmpty()
            {
                return RedirectToAction("Create");
            }
            else
            {
                return View(buildings);
            }
        }

        [HttpPost]
        public void Post(string buildName, string buildAddress)
        {
            Building building = new Building();
            building.Name = buildName;
            building.Address = buildAddress;

            m_repo.SaveBuilding(building);
            //return RedirectToAction("Index");
        }


        public ActionResult Create()
        {
            //for models that require other objects, like departments and employees you can add a select list to use for a dropdown:
            ViewBag.Buildings = new SelectList(m_repo.GetBuildings(), "Id", "Name");
            return View();
        }


        //setting Create View to POST
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Building building)
        {
            if (building == null)
            {
                return RedirectToAction("Create");
            }
            else if (ModelState.IsValid)
            {
                m_repo.SaveBuilding(building);
                return RedirectToAction("Index");
            }

            return View(building);
        }

        public ActionResult Details(int id)
        {
            Building building = m_repo.GetBuilding(id);
            if (building == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(building);
            }
        }

        public ActionResult Delete(int id)
        {
            Building building = m_repo.GetBuilding(id);
            if (building == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(building);
            }
        }

        //similar to javascript eventlistener.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Building building = m_repo.GetBuilding(id);
            m_repo.DeleteBuilding(building);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            Building building = m_repo.GetBuilding(id);
            if (building == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(building);
            }
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirmed(Building building)
        {
            if (ModelState.IsValid)
            {
                m_repo.SaveBuilding(building);
                return RedirectToAction("Index");
            }
            return View(building);
        }

    }
}