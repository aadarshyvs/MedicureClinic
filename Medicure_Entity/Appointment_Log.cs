using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicure_Entity
{
    public class Appointment_Log
    {
        public int Appointment_ID { get; set; }
        public int Patient_Id { get; set; }
        public int Physician_Id { get; set; }
        public string illness { get; set; }
        public string Date_of_visit { get; set; }
    }
}
