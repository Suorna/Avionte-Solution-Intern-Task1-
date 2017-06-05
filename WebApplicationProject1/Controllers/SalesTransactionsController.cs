using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationProject1.Models;

namespace WebApplicationProject1.Controllers
{
    public class SalesTransactionsController : Controller
    {
        private TEST1DBEntities db = new TEST1DBEntities();

        // GET: SalesTransactions
        public ActionResult Index()
        {
            var salesTransactions = db.SalesTransactions.Include(s => s.Customer).Include(s => s.Invoice).Include(s => s.Product);
            return View(salesTransactions.ToList());
        }

        // GET: SalesTransactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesTransaction salesTransaction = db.SalesTransactions.Find(id);
            if (salesTransaction == null)
            {
                return HttpNotFound();
            }
            return View(salesTransaction);
        }

        // GET: SalesTransactions/Create
        public ActionResult Create()
        {
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_Name");
            ViewBag.Invoice_No = new SelectList(db.Invoices, "Invoice_No", "Invoice_No");
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Product_Name");
            return View();
        }

        // POST: SalesTransactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product_ID,Customer_ID,Invoice_No,Quantity,Rate,Total,Transaction_ID")] SalesTransaction salesTransaction)
        {
            if (ModelState.IsValid)
            {
                db.SalesTransactions.Add(salesTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_Name", salesTransaction.Customer_ID);
            ViewBag.Invoice_No = new SelectList(db.Invoices, "Invoice_No", "Invoice_No", salesTransaction.Invoice_No);
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Product_Name", salesTransaction.Product_ID);
            return View(salesTransaction);
        }

        // GET: SalesTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesTransaction salesTransaction = db.SalesTransactions.Find(id);
            if (salesTransaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_Name", salesTransaction.Customer_ID);
            ViewBag.Invoice_No = new SelectList(db.Invoices, "Invoice_No", "Invoice_No", salesTransaction.Invoice_No);
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Product_Name", salesTransaction.Product_ID);
            return View(salesTransaction);
        }

        // POST: SalesTransactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product_ID,Customer_ID,Invoice_No,Quantity,Rate,Total,Transaction_ID")] SalesTransaction salesTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_ID = new SelectList(db.Customers, "Customer_ID", "Customer_Name", salesTransaction.Customer_ID);
            ViewBag.Invoice_No = new SelectList(db.Invoices, "Invoice_No", "Invoice_No", salesTransaction.Invoice_No);
            ViewBag.Product_ID = new SelectList(db.Products, "Product_ID", "Product_Name", salesTransaction.Product_ID);
            return View(salesTransaction);
        }

        // GET: SalesTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesTransaction salesTransaction = db.SalesTransactions.Find(id);
            if (salesTransaction == null)
            {
                return HttpNotFound();
            }
            return View(salesTransaction);
        }

        // POST: SalesTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesTransaction salesTransaction = db.SalesTransactions.Find(id);
            db.SalesTransactions.Remove(salesTransaction);
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
    }
}
