using DataAccessLib;
using Medicure_Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medicure_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        Drug_Dal dd;
        public SupplierController()
        {
            dd = new Drug_Dal();
        }

        [HttpPost("CreateDrug")]
        public IActionResult CreateDrug(Drug d)
        {
            dd.CreateDrug(d);
            return Ok(d);
        }
        [HttpDelete("DeleteDrug")]
        public IActionResult DeleteDrug(int id)
        {
            dd.DeleteDrug(id);
            return Ok(id);

        }
        [HttpGet("GetAllDrug")]
        public IActionResult GetAllDrug()
        {
            return Ok(dd.GetAllDrug());
        }
        [HttpGet("DrugsToBeSuppiled")]
        public IActionResult DrugSupplier(int id)
        {
            return Ok(dd.DrugSupplier(id));
        }
        [HttpPost("SupplyDrugs")]
        public IActionResult SupplierDrugsbtn(Supplier_Log s)
        {
            dd.SupplierDrugsbtn(s);
            return Ok(s);

        }
    }
}
