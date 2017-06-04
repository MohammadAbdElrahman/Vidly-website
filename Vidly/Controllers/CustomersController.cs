using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes =membershipTypes
            };
            return View("CustomerForm",viewModel);
        }
        //Create: Customer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);

            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerDB = _context.Customers.Single(c => c.Id == customer.Id);
                customerDB.Name = customer.Name;
                customerDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerDB.BirthDate = customer.BirthDate;
                customerDB.MembershipTypeId = customer.MembershipTypeId;

            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            
            return RedirectToAction("Index","Customers");
        }
        // GET: Customers
        public ViewResult Index()
        {
            if (MemoryCache.Default["Genres"]==null)
            {
                MemoryCache.Default["Genres"] = _context.Genres.ToList();
            }
            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;
            //var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            return View();
        }
        // Customer Details

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer==null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        //Edit Customer
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer==null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}