using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Library.DAL
{
    public class Books
    {

        private Database db;

        public Books()
        {
            this.db = DatabaseFactory.CreateDatabase();
        }

        public Books(int Book_Id)
        {
            this.db = DatabaseFactory.CreateDatabase();
            this.Book_Id = Book_Id;
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

        public int CreatedBy
        {
            get; set;
        }


        public DateTime CreatedOn
        {
            get; set;
        }

        public int ModifiedBy
        {
            get; set;
        }


        public DateTime ModifiedOn
        {
            get; set;
        }

        [Required]
        public string Publisher_Name
        {
            get; set;
        }

        [Required]
        public string Category_Name
        {
            get; set;
        }

        [Required]
        public int? categoryid
        {
            get; set;
        }

        public String MCategories
        {
            get; set;
        }

        public String MPublishers
        {
            get; set;
        }

        [Required]
        public int? publisherid
        {
            get; set;
        }

        public int? pagenumber
        {
            get; set;
        }

        public int? rowofpages
        {
            get; set;
        }


        public int TotalRecords
        {
            get; set;
        }

        public int RowNumbers
        {
            get; set;
        }


        public bool Load()
        {
            // List<Books> book = new List<Books>();
            try
            {
                if (this.Book_Id != 0)
                {
                    DbCommand com = this.db.GetStoredProcCommand("BooksGetDetails");
                    this.db.AddInParameter(com, "Book_Id", DbType.Int32, this.Book_Id);
                    DataSet ds = this.db.ExecuteDataSet(com);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        //    {
                        //        book.Add(new Books()
                        //        {
                        this.Book_Id = Convert.ToInt32(ds.Tables[0].Rows[0]["Book_Id"]);
                        this.Book_Name = ds.Tables[0].Rows[0]["Book_Name"].ToString();
                        this.Book_Pages = Convert.ToInt32(ds.Tables[0].Rows[0]["Book_Pages"]);
                        this.Book_Price = Convert.ToInt32(ds.Tables[0].Rows[0]["Book_Price"]);
                        this.publisherid = Convert.ToInt32(ds.Tables[0].Rows[0]["Publisher_Id"].ToString());
                        this.categoryid = Convert.ToInt32(ds.Tables[0].Rows[0]["Category_Id"].ToString());
                        this.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"].ToString());
                        this.Publisher_Name= ds.Tables[0].Rows[0]["Publisher_Name"].ToString();
                        this.Category_Name=ds.Tables[0].Rows[0]["Category_Name"].ToString();
                        //    });
                        //}

                        return true;
                    }
                }


            }
            catch (Exception ex)
            {
                //return false;
            }
            return false;
        }



        public bool Save()
        {
            if (this.Book_Id == 0)
            {
                return this.Insert();
            }
            else
            {
                if (this.Book_Id > 0)
                {
                    return this.Update();
                }
                else
                {
                    this.Book_Id = 0;
                    return false;
                }
            }
        }


        public bool Insert()
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("BooksInsert");
                this.db.AddOutParameter(com, "Book_Id", DbType.Int32, 1024);
                if (!String.IsNullOrEmpty(Book_Name))
                {
                    this.db.AddInParameter(com, "Book_Name", DbType.String, Book_Name);
                }
                else
                {
                    this.db.AddInParameter(com, "Book_Name", DbType.String, DBNull.Value);
                }

                if (Book_Price > 0)
                {
                    this.db.AddInParameter(com, "Book_Price", DbType.Int32, Book_Price);
                }
                else
                {
                    this.db.AddInParameter(com, "Book_Price", DbType.Int32, DBNull.Value);
                }



                if (Book_Pages > 0)
                {
                    this.db.AddInParameter(com, "Book_Pages", DbType.Int32, Book_Pages);
                }
                else
                {
                    this.db.AddInParameter(com, "Book_Pages", DbType.Int32, DBNull.Value);
                }


                this.db.AddInParameter(com, "IsActive", DbType.Boolean, this.IsActive);
                if (this.CreatedBy > 0)
                {
                    this.db.AddInParameter(com, "CreatedBy", DbType.Int32, this.CreatedBy);
                }
                else
                {
                    this.db.AddInParameter(com, "CreatedBy", DbType.Int32, DBNull.Value);
                }
                if (this.CreatedOn > DateTime.MinValue)
                {
                    this.db.AddInParameter(com, "CreatedOn", DbType.DateTime, this.CreatedOn);
                }
                else
                {
                    this.db.AddInParameter(com, "CreatedOn", DbType.DateTime, DBNull.Value);
                }
                if (this.ModifiedBy > 0)
                {
                    this.db.AddInParameter(com, "ModifiedBy", DbType.Int32, this.ModifiedBy);
                }
                else
                {
                    this.db.AddInParameter(com, "ModifiedBy", DbType.Int32, DBNull.Value);
                }
                if (this.ModifiedOn > DateTime.MinValue)
                {
                    this.db.AddInParameter(com, "ModifiedOn", DbType.DateTime, this.ModifiedOn);
                }
                else
                {
                    this.db.AddInParameter(com, "ModifiedOn", DbType.DateTime, DBNull.Value);
                }


                if (categoryid > 0)
                {
                    db.AddInParameter(com, "categoryid", DbType.Int32, categoryid);
                }
                else
                {
                    db.AddInParameter(com, "categoryid", DbType.Int32, DBNull.Value);
                }

                if (publisherid > 0)
                {
                    db.AddInParameter(com, "publisherid", DbType.Int32, publisherid);
                }
                else
                {
                    db.AddInParameter(com, "publisherid", DbType.Int32, DBNull.Value);
                }




                this.db.ExecuteNonQuery(com);
                this.Book_Id = Convert.ToInt32(this.db.GetParameterValue(com, "Book_Id"));      // Read in the output parameter value
            }
            catch (Exception ex)
            {
                //return false;
            }

            return Book_Id > 0; // Return whether ID was returned
        }


        public bool Update()
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("BooksUpdate");
                this.db.AddInParameter(com, "Book_Id", DbType.Int32, this.Book_Id);
                if (!String.IsNullOrEmpty(this.Book_Name))
                {
                    this.db.AddInParameter(com, "Book_Name", DbType.String, this.Book_Name);
                }
                else
                {
                    this.db.AddInParameter(com, "Book_Name", DbType.String, DBNull.Value);
                }

                if (Book_Pages > 0)
                {
                    this.db.AddInParameter(com, "Book_Pages", DbType.Int32, Book_Pages);
                }
                else
                {
                    this.db.AddInParameter(com, "Book_Pages", DbType.Int32, DBNull.Value);
                }

                if (Book_Price > 0)
                {
                    this.db.AddInParameter(com, "Book_Price", DbType.Int32, Book_Price);
                }
                else
                {
                    this.db.AddInParameter(com, "Book_Price", DbType.Int32, DBNull.Value);
                }


                this.db.AddInParameter(com, "IsActive", DbType.Boolean, this.IsActive);


                if (this.ModifiedBy > 0)
                {
                    this.db.AddInParameter(com, "ModifiedBy", DbType.Int32, this.ModifiedBy);
                }
                else
                {
                    this.db.AddInParameter(com, "ModifiedBy", DbType.Int32, DBNull.Value);
                }
                if (this.ModifiedOn > DateTime.MinValue)
                {
                    this.db.AddInParameter(com, "ModifiedOn", DbType.DateTime, this.ModifiedOn);
                }
                else
                {
                    this.db.AddInParameter(com, "ModifiedOn", DbType.DateTime, DBNull.Value);
                }


                if (publisherid > 0)
                {
                    db.AddInParameter(com, "publisherid", DbType.Int32, publisherid);
                }
                else
                {
                    db.AddInParameter(com, "publisherid", DbType.Int32, DBNull.Value);
                }


                if (categoryid > 0)
                {
                    db.AddInParameter(com, "categoryid", DbType.Int32, categoryid);
                }
                else
                {
                    db.AddInParameter(com, "categoryid", DbType.Int32, DBNull.Value);
                }


                this.db.ExecuteNonQuery(com);

            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public bool Delete()
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("BooksDelete");
                this.db.AddInParameter(com, "Book_Id", DbType.Int32, this.Book_Id);
                this.db.ExecuteNonQuery(com);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        public List<Books> GetList()
        {
            List<Books> book = new List<Books>();
            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("BooksGetList");

                if (!String.IsNullOrEmpty(Book_Name))
                {
                    db.AddInParameter(com, "Book_Name", DbType.String, Book_Name);
                }
                else
                {
                    db.AddInParameter(com, "Book_Name", DbType.String, DBNull.Value);
                }

                if (MCategories != null)
                {
                    db.AddInParameter(com, "categoryid", DbType.String, MCategories);
                }
                else
                {
                    db.AddInParameter(com, "categoryid", DbType.String, DBNull.Value);
                }

                if (MPublishers != null)
                {
                    db.AddInParameter(com, "publisherid", DbType.String, MPublishers);
                }
                else
                {
                    db.AddInParameter(com, "publisherid", DbType.String, DBNull.Value);
                }


                if (pagenumber > 0)
                {
                    db.AddInParameter(com, "pagenumber", DbType.Int32, pagenumber);
                }
                else
                {
                    db.AddInParameter(com, "pagenumber", DbType.Int32, DBNull.Value);
                }

                if (rowofpages > 0)
                {
                    db.AddInParameter(com, "rowofpages", DbType.Int32, rowofpages);
                }
                else
                {
                    db.AddInParameter(com, "rowofpages", DbType.Int32, DBNull.Value);
                }



                ds = db.ExecuteDataSet(com);



                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    book.Add(new Books()
                    {
                        Book_Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Book_Id"]),
                        Book_Name = ds.Tables[0].Rows[i]["Book_Name"].ToString(),
                        Book_Pages = Convert.ToInt32(ds.Tables[0].Rows[i]["Book_Pages"]),
                        Book_Price = Convert.ToInt32(ds.Tables[0].Rows[i]["Book_Price"]),
                        Publisher_Name = ds.Tables[0].Rows[i]["Publisher_Name"].ToString(),
                        Category_Name = ds.Tables[0].Rows[i]["Category_Name"].ToString(),
                        TotalRecords = Convert.ToInt32(ds.Tables[0].Rows[i]["TotalRecords"]),
                        RowNumbers = Convert.ToInt32(ds.Tables[0].Rows[i]["Rownumber"])                      
                    });
                }

    
            }

            catch (Exception ex)
            {
                //To Do: Handle Exception
            }

            return book;
        }




    }
}