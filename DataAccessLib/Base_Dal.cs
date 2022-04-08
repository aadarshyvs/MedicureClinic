using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib
{
    public class Base_Dal
    {
        public static string CnString;
        
        public Base_Dal()
        {
            CnString = "Data Source=DESKTOP-5HFRN07\\SQLEXPRESS;Initial Catalog=Medicure;Integrated Security=True;TrustServerCertificate=true;trusted_connection=true;";

        }
    }
}
