using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Library.DAL
{
    public class Categories
    {
        private Database db;

        public Categories()
        {
            this.db = DatabaseFactory.CreateDatabase();
        }

        public Categories(int Category_Id)
        {
            this.db = DatabaseFactory.CreateDatabase();
            this.Category_Id = Category_Id;
        }

        public int Category_Id
        {
            get; set;
        }


        public string Category_Name
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


        



        public bool Load()
        {
            try
            {
                if (this.Category_Id != 0)
                {
                    DbCommand com = this.db.GetStoredProcCommand("CategoriesGetDetails");
                    this.db.AddInParameter(com, "Category_Id", DbType.Int32, this.Category_Id);
                    DataSet ds = this.db.ExecuteDataSet(com);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        this.Category_Id = Convert.ToInt32(dt.Rows[0]["Category_Id"]);
                        this.Category_Name = Convert.ToString(dt.Rows[0]["Category_Name"]);
                        this.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                        this.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
                        this.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                        this.ModifiedBy = Convert.ToInt32(dt.Rows[0]["ModifiedBy"]);
                        this.ModifiedOn = Convert.ToDateTime(dt.Rows[0]["ModifiedOn"]);
                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool Save()
        {
            if (this.Category_Id == 0)
            {
                return this.Insert();
            }
            else
            {
                if (this.Category_Id > 0)
                {
                    return this.Update();
                }
                else
                {
                    this.Category_Id = 0;
                    return false;
                }
            }
        }


        private bool Insert()
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("CategoriesInsert");
                this.db.AddOutParameter(com, "Category_Id", DbType.Int32, 1024);
                if (!String.IsNullOrEmpty(this.Category_Name))
                {
                    this.db.AddInParameter(com, "Category_Name", DbType.String, this.Category_Name);
                }
                else
                {
                    this.db.AddInParameter(com, "Category_Name", DbType.String, DBNull.Value);
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
                this.db.ExecuteNonQuery(com);
                this.Category_Id = Convert.ToInt32(this.db.GetParameterValue(com, "Category_Id"));      // Read in the output parameter value
            }
            catch (Exception ex)
            {
                return false;
            }

            return this.Category_Id > 0; // Return whether ID was returned
        }


        private bool Update()
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("CategoriesUpdate");
                this.db.AddInParameter(com, "Category_Id", DbType.Int32, this.Category_Id);
                if (!String.IsNullOrEmpty(this.Category_Name))
                {
                    this.db.AddInParameter(com, "Category_Name", DbType.String, this.Category_Name);
                }
                else
                {
                    this.db.AddInParameter(com, "Category_Id", DbType.String, DBNull.Value);
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
                DbCommand com = this.db.GetStoredProcCommand("CategoriesDelete");
                this.db.AddInParameter(com, "Category_Id", DbType.Int32, this.Category_Id);
                this.db.ExecuteNonQuery(com);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        public List<Categories> GetList()
        {
            List<Categories> category = new List<Categories>();
            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("CategoriesGetList");
                ds = db.ExecuteDataSet(com);


                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    category.Add(new Categories()
                    {
                        Category_Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Category_Id"]),
                        Category_Name = ds.Tables[0].Rows[i]["Category_Name"].ToString()                      
                    });
                }
            }
            catch (Exception ex)
            {
                //To Do: Handle Exception
            }

            return category;
        }


    }
}