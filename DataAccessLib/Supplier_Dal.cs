using Medicure_Entity;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib
{
    public class Supplier_Dal :Base_Dal
    {
        public Supplier SupplierLogin(string username, string password)
        {
            Supplier s = new Supplier();
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"select Supplier_Id from Supplier where Username='{username}' and Password='{password}'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            Physician p = new Physician();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                s.SupplierId = dr.GetInt32(0);
                            

            }

            cn.Close();
            cn.Dispose();
            return s;
        }

        
       
        
    }
}
