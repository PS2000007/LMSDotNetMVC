using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Library.Models;
using Library.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Library.Models
{
    public class IssuedBooksModel
    {

        private Database db;

        public IssuedBooksModel()
        {
            this.db = DatabaseFactory.CreateDatabase();
        }



        public int UserId
        {
            get;set;
        }
        public List<Books> booklist { get; set; }

        public int[] IssueBook_Quantity
        {
            get; set;
        }
        public int[] IssueBook_Id
        {
            get; set;
        }

        public DateTime IssueDate
        {
            get;set;
        }

        public string IssueBook_Name
        {
            get; set;
        }

        public int IssueBook_Pages
        {
            get; set;
        }

        public int IssueBook_Price
        {
            get; set;
        }


        public bool IssueIsActive
        {
            get; set;
        }

        public int IssueCreatedBy
        {
            get; set;
        }


        public DateTime IssueCreatedOn
        {
            get; set;
        }

        public int IssueModifiedBy
        {
            get; set;
        }


        public DateTime IssueModifiedOn
        {
            get; set;
        }

        public String IssuePublisher_Name
        {
            get; set;
        }

        public String IssueCategory_Name
        {
            get; set;
        }
        public int? Issuecategoryid
        {
            get; set;
        }

        public String IssueMCategories
        {
            get; set;
        }

        public String IssueMPublishers
        {
            get; set;
        }

        public int? Issuepublisherid
        {
            get; set;
        }

        public int? Issuepagenumber
        {
            get; set;
        }

        public int? Issuerowofpages
        {
            get; set;
        }


        public int IssueTotalRecords
        {
            get; set;
        }

        public int IssueRowNumbers
        {
            get; set;
        }



        public bool Insert()
        {
           for(int i=0; i<=IssueBook_Id.Length;i++)
            {

                try
                {
                    DbCommand com = this.db.GetStoredProcCommand("IBI");

                if (IssueBook_Id[i] > 0)
                {
                    this.db.AddInParameter(com, "IssueBook_Id", DbType.Int32, IssueBook_Id[i]);
                }
                else
                {
                    this.db.AddInParameter(com, "IssueBook_Id", DbType.Int32, DBNull.Value);
                }

                if (UserId > 0)
                {
                    this.db.AddInParameter(com, "UserId", DbType.Int32, UserId);
                }
                else
                {
                    this.db.AddInParameter(com, "UserId", DbType.Int32, DBNull.Value);
                }

                if (IssueBook_Quantity[i] > 0)
                {
                    this.db.AddInParameter(com, "IssueBook_Quantity", DbType.Int32, IssueBook_Quantity[i]);
                }
                else
                {
                    this.db.AddInParameter(com, "IssueBook_Quantity", DbType.Int32, DBNull.Value);
                }
                    // if (IssueDate != null)
                    //{
                    //    this.db.AddInParameter(com, "IssueDate", DbType.String, IssueDate);
                    //}
                    //else
                    //{
                    //    this.db.AddInParameter(com, "IssueDate", DbType.String, DBNull.Value);
                    //}
                 this.db.ExecuteNonQuery(com);
                   
                }
                catch (Exception ex)
                {
                    //return false;
                }
            }
            return UserId > 0;
        }

    }
}