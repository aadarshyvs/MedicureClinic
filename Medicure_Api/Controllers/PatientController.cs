using DataAccessLib;
using Medicure_Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Medicure_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        Paitent_Dal pd;
        Appointment_Log_Dal ald;
        Drug_Dal dd;
        Physician_Dal pyd;
        public PatientController()
        {
            pd = new Paitent_Dal();
            ald = new Appointment_Log_Dal();
            dd = new Drug_Dal();
            pyd = new Physician_Dal();

        }

        [HttpPost("NewPaitents")]
        public IActionResult NewPaitents(Patient p)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                pd.NewPaitents(p);
                return Ok(p);
            }

        }
        [HttpPost("AllPhysician")]
        public IActionResult GetAllPhysician()
        {
            return Ok(pyd.GetAllPhysician());
        }

        [HttpPost("BookAppointment")]
        public IActionResult BookAppointment(Appointment_Log ap)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                ald.Book_Appointment(ap);
                return Ok(ap);
            }

        }
//not needed
        [HttpGet("GetAllPatient")]
        public IActionResult GetAllPatient()
        {
            return Ok(pd.GetAllPatient());
        }

        [HttpPost("EditPatient")]
        public IActionResult EditPatient(Patient p)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                pd.EditPatient(p);
                return (Ok(p));
            }
        }
        [HttpGet("ViewDrugs")]
        public IActionResult GetAllDrug()
        {
            return Ok(dd.GetAllDrug());
        }

        [HttpGet ("ViewAppointmentHistory")]
        public IActionResult View_Appointment_History(int id)
        {
            return Ok(pd.View_Appointment_History(id));
        }


    }
}
