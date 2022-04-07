using Medicure_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace DataAccessLib
{
    public class Paitents_Dal
    {
        string CnString = "Data Source=DESKTOP-5HFRN07\\SQLEXPRESS;Initial Catalog=Medicure;Integrated Security=True";


        public void NewPaitents(Patients p)
        {

            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"insert into Patients(Name,MobileNo,DateOfReg,Username,Password)  values('{p.Name}','{p.MobileNo}','{p.DateOfReg}','{p.Username}','{p.Password}')";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int i =cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
        }

        public Patients GetPaitentById(int id)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"  Select Name,MobileNo,DateOfReg,Username,Password From Patients where id={id}";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            Patients p = new Patients();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                p.Name= dr[0].ToString();
                p.MobileNo= dr[1].ToString();
                p.DateOfReg= dr[2].ToString();
                p.Username= dr[3].ToString();
                p.Password = dr[4].ToString();
            }

            
            cn.Close();
            cn.Dispose();
            return p;
        }
        public Patients GetByUP(string username,string password)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"Select Id,Name,MobileNo,DateOfRegFrom Paitents where Username=={username} and Password=={password}";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            Patients p = new Patients();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                p.Id = Convert.ToInt32(dr[0]);
                p.Name = dr[1].ToString();
                p.MobileNo = dr[2].ToString();
                p.DateOfReg = dr[3].ToString();

            }


            cn.Close();
            cn.Dispose();
            return p;
        }


    }
}
