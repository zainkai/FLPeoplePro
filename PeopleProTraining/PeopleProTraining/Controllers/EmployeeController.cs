using PeopleProTraining.Dal.Infrastructure;
using PeopleProTraining.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PeopleProTraining.Controllers
{
    public class EmployeeController : Controller
    {
        #region datasetup (allows access to SQL data base)
        private IPeopleProRepo m_repo;
        public EmployeeController(): this(new PeopleProRepo())
        {
        }
        public EmployeeController(IPeopleProRepo repo)
        {
            m_repo = repo;
        }
        #endregion



        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
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