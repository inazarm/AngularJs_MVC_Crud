using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularProject.Models;

namespace AngularProject.Controllers
{
    public class TestController : Controller
    {
        MvcCRUDDBEntities entities;
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCustomers()
        {
            entities = new MvcCRUDDBEntities();
            return Json(entities.Customers);
        }

        [HttpPost]
        public JsonResult InsertCustomer(Customer customer)
        {
            using (entities = new MvcCRUDDBEntities())
            {
                entities.Customers.Add(customer);
                entities.SaveChanges();
            }

            return Json(customer);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            using (entities = new MvcCRUDDBEntities())
            {
                Customer updatedCustomer = (from c in entities.Customers
                                            where c.CustomerId == customer.CustomerId
                                            select c).FirstOrDefault();
                updatedCustomer.Name = customer.Name;
                updatedCustomer.Country = customer.Country;
                entities.SaveChanges();
            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int customerId)
        {
            using (entities = new MvcCRUDDBEntities())
            {
                Customer customer = (from c in entities.Customers
                                     where c.CustomerId == customerId
                                     select c).FirstOrDefault();
                entities.Customers.Remove(customer);
                entities.SaveChanges();
            }
            return new EmptyResult();
        }
    }
}