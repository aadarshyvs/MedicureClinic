namespace Medicure_Mvc.Models
{
    public class Appointment_Log
    {
        public int Appointment_ID { get; set; }
        public int Patients_Id { get; set; }
        public int Physician_Id { get; set; }
        public string illness { get; set; }
        public string Date_of_visit { get; set; }
    }
}
