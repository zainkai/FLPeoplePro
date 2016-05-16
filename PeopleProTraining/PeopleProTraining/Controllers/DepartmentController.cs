using PeopleProTraining.Dal.Infrastructure;
using PeopleProTraining.Dal.Interfaces;
using PeopleProTraining.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeopleProTraining.Controllers
{
    public class DepartmentController : Controller
    {
        #region datasetup (allows access to SQL data base)
        private IPeopleProRepo m_repo;
        public DepartmentController(): this(new PeopleProRepo())
        {
        }
        public DepartmentController(IPeopleProRepo repo)
        {
            m_repo = repo;
        }
        #endregion

        // GET: Department
        public ActionResult Index()
        {
            //creating an object filled with database info....
            IEnumerable<Department> Departments = m_repo.GetDepartments();
            if (Departments == null)
            {
                return RedirectToAction("Create");
            }
            else
            {
                return View(Departments);//TODO departments
            }
        }

        public ActionResult Create()
        {
            //for models that require other objects, like departments and employees you can add a select list to use for a dropdown:
            ViewBag.Departments = new SelectList(m_repo.GetDepartments(), "Id", "Name");
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult edit()
        {
            return View();
        }

    }
}