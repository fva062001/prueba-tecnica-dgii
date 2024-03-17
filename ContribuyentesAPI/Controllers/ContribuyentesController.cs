using Microsoft.AspNetCore.Mvc;
using ContribuyentesAPI.Models;
using ContribuyentesAPI.Data;
using System.Collections.Generic;

namespace ContribuyentesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyentesController : ControllerBase
    {
        private readonly ContribuyentesData _contribuyentesData;

        public ContribuyentesController()
        {
            _contribuyentesData = new ContribuyentesData();
        }

        // GET: api/Contribuyentes
        [HttpGet]
        public ActionResult<IEnumerable<ContribuyenteModel>> GetContribuyentes()
        {
            var contribuyentes = _contribuyentesData.GetContribuyentes();
            return Ok(contribuyentes);
        }

        // GET: api/Contribuyentes/5
        [HttpGet("{rncCedula}")]
        public ActionResult<ContribuyenteModel> GetContribuyente(string rncCedula)
        {
            var contribuyente = _contribuyentesData.GetContribuyente(rncCedula);

            if (contribuyente == null)
            {
                return NotFound();
            }

            return Ok(contribuyente);
        }
    }
}
