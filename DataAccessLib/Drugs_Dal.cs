using Medicure_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib
{
    internal class Drugs_Dal
    {
        const string CnString = "Data Source=DESKTOP-5HFRN07\\SQLEXPRESS;Initial Catalog=;Integrated Security=True";
        public List<Drugs> GetAllDrugs()
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"Select Id,Name,Required_Qty,Instock_Qty,Price,Supplier_Id From Drugs ";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            List<Drugs> DrugsList = new List<Drugs>();
            SqlDataReader dr = cmd.ExecuteReader();
            
            if (dr.HasRows)
            {
                Drugs d = new Drugs();
                dr.Read();
                d.Id = Convert.ToInt32(dr[0]);
                d.Name = dr[1].ToString();
                d.Required_Qty = Convert.ToInt32(dr[2]);
                d.Instock_Qty = Convert.ToInt32(dr[3]);
                d.Price = Convert.ToInt64(dr[4]);
                d.Supplier_Id = Convert.ToInt32(dr[5]);
                DrugsList.Add(d);
            }

            cn.Close();
            cn.Dispose();
            return DrugsList;
        }
   
    }
}
