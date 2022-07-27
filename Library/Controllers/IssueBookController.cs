using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
using System.Data.SqlClient;
using Library.DAL;
using System.Data;
using Library.Models;
using Newtonsoft.Json;
using PagedList;
using PagedList.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Routing;
using System.Net;
using System.IO;

namespace Library.Controllers
{
    public class IssueBookController : Controller
    {
        BooksViewModule bm1 = new BooksViewModule();
        Books s1 = new Books();
        Categories s2 = new Categories();
        Publishers s3 = new Publishers();
        IssuedBooksModel ibm = new IssuedBooksModel();

        // GET: IssueBook
        public ActionResult Issue(Books b)
        {
            bm1.categories = new Categories().GetList();
            bm1.publishers = new Publishers().GetList();
            bm1.IssueDate = DateTime.Now;
            return View(bm1);
        }

        [HttpPost]
        public ActionResult GetPaggedData(BooksViewModule b)
        {
            s1.Book_Name = b.Book_Name;
            s1.MCategories = b.MCategories;
            s1.MPublishers = b.MPublishers;
            s1.publisherid = Convert.ToInt32(b.publisherid);
            s1.pagenumber = Convert.ToInt32(b.pagenumber);
            s1.rowofpages = Convert.ToInt32(b.rowofpages);
            bm1.booklist = s1.GetList();
            bm1.pagenumber = Convert.ToInt32(b.pagenumber);
            Session["Books"] = b;
            return PartialView("_IssuePartialView", bm1);
        }

        public JsonResult InsertIssuedBooks(int UserId, int[] Book_Id, int[] quantity, DateTime IssueDate)
        {

           // ibm.booklist = Book_Id.ToList();

            var mapResult = new IssuedBooksModel()
            {
                UserId = UserId,
                IssueBook_Id = Book_Id,
                IssueBook_Quantity = quantity
            };

                
                ibm.UserId = UserId;
                ibm.IssueBook_Quantity = quantity;
                ibm.IssueBook_Id = Book_Id;
                ibm.IssueDate = IssueDate;
                ibm.Insert();
          

            return Json(ibm, JsonRequestBehavior.AllowGet);
        }

    }
}