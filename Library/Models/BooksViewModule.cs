using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Dynamic;
using Library.DAL;
using System.Collections.Generic;
using PagedList;
using PagedList.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{

    public class BooksViewModule
    {
        public List<Categories> categories { get; set; }
        public List<Publishers> publishers { get; set; }
        public List<Books> booklist { get; set; }

        public List<SelectListItem> pagenumbers = new List<SelectListItem>()
        {
            new SelectListItem{Text="1", Value="1"},
             new SelectListItem{Text="2", Value="3"},
              new SelectListItem{Text="3", Value="3"},
        };

        public List<SelectListItem> rownumbers = new List<SelectListItem>()
        {
            new SelectListItem{Text="3", Value="3"},
             new SelectListItem{Text="5", Value="5"},
              new SelectListItem{Text="10", Value="10"},
                new SelectListItem{Text="15", Value="15"},
                 
        };


        public DateTime IssueDate
        {
            get;set;
        }

        public int UserId
        {
            get; set;
        }
        public int Book_Id
        {
            get; set;
        }

        [Required]
        public string Book_Name
        {
            get; set;
        }

        [Required]
       
        public int Book_Pages
        {
            get; set;
        }

        [Required]
        public int Book_Price
        {
            get; set;
        }

        public bool IsActive
        {
            get; set;
        }

      
        [Required]
        public int? categoryid
        {
            get; set;
        }

        public String Category_Name
        {
            get; set;
        }

        [Required]
        public int? publisherid
        {
            get; set;
        }

        public String Publisher_Name
        {
            get; set;
        }
        public String MCategories
        {
            get;set;
        }

        public String MPublishers
        {
            get; set;
        }
        public int? rowofpages
        {
            get; set;
        }

     public int TotalRecords
        {
            get;
            set;
        }

        public int pagenumber
        {
            get; set;
        }


     }
}