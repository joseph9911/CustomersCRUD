using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTarea1.Model;
using WebTarea1.Repository;

namespace WebTarea1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private CustomerRepository _customer = new CustomerRepository();

        public ActionResult Index()
        {
            return View(_customer.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _customer.Add(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _customer.GetById(id);
            if (customer == null) return RedirectToAction("Index");

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _customer.Update(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var customer = _customer.GetById(id);
            if (customer == null) return RedirectToAction("Index");

            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            _customer.Delete(customer);
            return RedirectToAction("Index");
        }

    }
}