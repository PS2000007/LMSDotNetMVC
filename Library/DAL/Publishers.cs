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
    public class Publishers
    {

        private Database db;

        public Publishers()
        {
            this.db = DatabaseFactory.CreateDatabase();
        }

        public Publishers(int Publisher_Id)
        {
            this.db = DatabaseFactory.CreateDatabase();
            this.Publisher_Id = Publisher_Id;
        }

        public int Publisher_Id
        {
            get; set;
        }


        public string Publisher_Name
        {
            get; set;
        }


        public string Publisher_Contact
        {
            get; set;
        }

        public string Publisher_Office_Address
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
                if (this.Publisher_Id != 0)
                {
                    DbCommand com = this.db.GetStoredProcCommand("PublishersGetDetails");
                    this.db.AddInParameter(com, "Publisher_Id", DbType.Int32, this.Publisher_Id);
                    DataSet ds = this.db.ExecuteDataSet(com);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        this.Publisher_Id = Convert.ToInt32(dt.Rows[0]["Publisher_Id"]);
                        this.Publisher_Name = Convert.ToString(dt.Rows[0]["Publisher_Name"]);

                        this.Publisher_Contact = Convert.ToString(dt.Rows[0]["Publisher_Contact"]);
                        this.Publisher_Office_Address = Convert.ToString(dt.Rows[0]["Publisher_Office_Address"]);

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
            if (this.Publisher_Id == 0)
            {
                return this.Insert();
            }
            else
            {
                if (this.Publisher_Id > 0)
                {
                    return this.Update();
                }
                else
                {
                    this.Publisher_Id = 0;
                    return false;
                }
            }
        }


        private bool Insert()
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("PublishersInsert");
                this.db.AddOutParameter(com, "Publisher_Id", DbType.Int32, 1024);
                if (!String.IsNullOrEmpty(this.Publisher_Name))
                {
                    this.db.AddInParameter(com, "Publisher_Name", DbType.String, this.Publisher_Name);
                }
                else
                {
                    this.db.AddInParameter(com, "Publisher_Name", DbType.String, DBNull.Value);
                }




                if (!String.IsNullOrEmpty(this.Publisher_Contact))
                {
                    this.db.AddInParameter(com, "Publisher_Contact", DbType.String, this.Publisher_Contact);
                }
                else
                {
                    this.db.AddInParameter(com, "Publisher_Contact", DbType.String, DBNull.Value);
                }


                if (!String.IsNullOrEmpty(this.Publisher_Office_Address))
                {
                    this.db.AddInParameter(com, "Publisher_Office_Address", DbType.String, this.Publisher_Office_Address);
                }
                else
                {
                    this.db.AddInParameter(com, "Publisher_Office_Address", DbType.String, DBNull.Value);
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
                this.Publisher_Id = Convert.ToInt32(this.db.GetParameterValue(com, "Publisher_Id"));      // Read in the output parameter value
            }
            catch (Exception ex)
            {
                return false;
            }

            return this.Publisher_Id > 0; // Return whether ID was returned
        }


        private bool Update()
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("PublishersUpdate");
                this.db.AddInParameter(com, "Publisher_Id", DbType.Int32, this.Publisher_Id);
                if (!String.IsNullOrEmpty(this.Publisher_Name))
                {
                    this.db.AddInParameter(com, "Publisher_Name", DbType.String, this.Publisher_Name);
                }
                else
                {
                    this.db.AddInParameter(com, "Publisher_Id", DbType.String, DBNull.Value);
                }




                if (!String.IsNullOrEmpty(this.Publisher_Contact))
                {
                    this.db.AddInParameter(com, "Publisher_Contact", DbType.String, this.Publisher_Contact);
                }
                else
                {
                    this.db.AddInParameter(com, "Publisher_Contact", DbType.String, DBNull.Value);
                }


                if (!String.IsNullOrEmpty(this.Publisher_Office_Address))
                {
                    this.db.AddInParameter(com, "Publisher_Office_Address", DbType.String, this.Publisher_Office_Address);
                }
                else
                {
                    this.db.AddInParameter(com, "Publisher_Office_Address", DbType.String, DBNull.Value);
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
                DbCommand com = this.db.GetStoredProcCommand("PublishersDelete");
                this.db.AddInParameter(com, "Publisher_Id", DbType.Int32, this.Publisher_Id);
                this.db.ExecuteNonQuery(com);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }


        public List<Publishers> GetList()
        {
            List<Publishers> publisher = new List<Publishers>();
            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("PublishersGetList");
                ds = db.ExecuteDataSet(com);


                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    publisher.Add(new Publishers()
                    {
                        Publisher_Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Publisher_Id"]),
                        Publisher_Name = ds.Tables[0].Rows[i]["Publisher_Name"].ToString()
                    });
                }


            }
            catch (Exception ex)
            {
                //To Do: Handle Exception
            }

            return publisher;
        }




    }
}