using Medicure_Entity;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib
{
    public class Physician_Dal : Base_Dal
    {
        public List<Appointment_Log> View_Appointment(int id)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"select Appointment_ID,Patient_Id,Physician_Id,illness,Date_of_visit from Appointment_Log where Physician_Id={id}";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            List<Appointment_Log> Appointments = new List<Appointment_Log>();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Appointment_Log a = new Appointment_Log();
                a.Appointment_ID = dr.GetInt32(0);
                a.Patient_Id = dr.GetInt32(1);
                a.Physician_Id = dr.GetInt32(2);
                a.illness = dr.GetString(3);
                a.Date_of_visit = dr.GetString(4);
                Appointments.Add(a);
            }
            dr.Close();
            cn.Close();
            cn.Dispose();
            return Appointments;

            
        }
        
        public Physician PhysicianLogin(string username, string password)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"select Id,Name,Specialization from Physician where Username='{username}' and Password='{password}'";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            Physician p = new Physician();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                p.Id = dr.GetInt32(0);
                p.Name = dr.GetString(1);
                p.Specialization = dr.GetString(2);

            }


            cn.Close();
            cn.Dispose();
            return p;
        }



    }
}
