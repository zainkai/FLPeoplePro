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
            //creating an object filled with database info....
            IEnumerable<Employee> employees = m_repo.GetEmployees();
            if (employees == null)//TODO Check for object equivalent of .IsNullOrEmpty()
            {
                return RedirectToAction("Create");
            }
            else
            {
                return View(employees);
            }
        }
        public ActionResult Create()
        {
            ViewBag.Employees = new SelectList(m_repo.GetEmployees(), "Id", "Name");
            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (employee == null)
            {
                return RedirectToAction("Create");
            }
            else if (ModelState.IsValid)
            {
                m_repo.SaveEmployee(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult Details(int id)
        {
            Employee employee = m_repo.GetEmployee(id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }

        public ActionResult Delete(int id)
        {
            Employee employee = m_repo.GetEmployee(id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = m_repo.GetEmployee(id);
            m_repo.DeleteEmployee(employee);
            return RedirectToAction("Index");
        }

        public ActionResult edit(int id)
        {
            Employee employee = m_repo.GetEmployee(id);
            if (employee == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirmed(Employee employee)
        {
            if (ModelState.IsValid)
            {
                m_repo.SaveEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

    }
}