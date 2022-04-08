using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib
{
    public class Prescription_Log_Dal :Base_Dal
    {
        
        public void newPrescription(Prescription_Log pl)
        {
            SqlConnection cn = new SqlConnection(CnString);
            string sql = $"insert into Prescription_Log values({pl.Appointment_ID},{pl.Drug_Id},{pl.Dosage});";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cn.Open();
            int i = cmd.ExecuteNonQuery();
            cn.Close();
            cn.Dispose();
            Drug_Dal d = new Drug_Dal();
            d.UpdateStock(pl.Drug_Id, pl.Dosage);
        }
    }
}
