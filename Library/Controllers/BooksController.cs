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

namespace Library.Controllers
{
    
    public class BooksController : Controller
    {
        BooksViewModule bm1 = new BooksViewModule();
        Books s1 = new Books();
        Categories s2 = new Categories();
        Publishers s3 = new Publishers();

        public ActionResult Index(BooksViewModule model)
        {
           
            BooksViewModule obj1 = (BooksViewModule)Session["Books"];
           

            if (obj1 != null)
            {
                bm1 = (BooksViewModule)Session["Books"];
            }
            else
            {
                bm1.pagenumber = 1;
                bm1.rowofpages = 3;
            }

           
            bm1.categories = new Categories().GetList();
            bm1.publishers = new Publishers().GetList();
            Session["Books"] = null;
            TempData["mydata"] = bm1;
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
            return PartialView("_BooksPartialView",bm1);
        }

        
        public ActionResult InsertBooks(int id = 0)
        {
            int BookId = id;
            bm1.categories = s2.GetList();
            bm1.publishers = s3.GetList();
            s1.Book_Id = BookId;
            s1.Load();
            bm1.Book_Id = s1.Book_Id;
            bm1.Book_Name = s1.Book_Name;
            bm1.Book_Pages = s1.Book_Pages;
            bm1.Book_Price = s1.Book_Price;
            bm1.categoryid = s1.categoryid;
            bm1.publisherid = s1.publisherid;
            bm1.Publisher_Name = s1.Publisher_Name;
            bm1.Category_Name = s1.Category_Name;
            bm1.IsActive = s1.IsActive;
            return Json(bm1, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult AddBook(Books b)
        {

            s1.Book_Id = Convert.ToInt32(b.Book_Id);
            s1.Book_Name = b.Book_Name;
            s1.Book_Pages = Convert.ToInt32(b.Book_Pages);
            s1.Book_Price = Convert.ToInt32(b.Book_Price);
            s1.IsActive = Convert.ToBoolean(b.IsActive);
            s1.categoryid = Convert.ToInt32(b.categoryid);
            s1.publisherid = Convert.ToInt32(b.publisherid);
            s1.Save();           
            return Json("Record Save",JsonRequestBehavior.AllowGet); 
        }


        public JsonResult deleteBook(int id)
        {
            s1.Book_Id = id;

            if(s1.Delete())
            {
                return Json("Deleted");
            }
            else
            {
                return Json("Not Deleted");
            }
        }


        public ActionResult ABC()
        {
            bm1.booklist = s1.GetList();
            return View(bm1);
        }


       
    }
}