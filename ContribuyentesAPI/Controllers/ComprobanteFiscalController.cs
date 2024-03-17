using Microsoft.AspNetCore.Mvc;
using ContribuyentesAPI.Data;
using ContribuyentesAPI.Models;
using System;
using System.Collections.Generic;

namespace ContribuyentesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobantesFiscalesController : ControllerBase
    {
        private readonly ComprobantesFiscalesData _comprobantesData;

        public ComprobantesFiscalesController()
        {
            _comprobantesData = new ComprobantesFiscalesData();
        }

        // GET: api/ComprobantesFiscales
        [HttpGet]
        public ActionResult<IEnumerable<ComprobanteFiscalModel>> GetComprobantesFiscales()
        {
            var comprobantes = _comprobantesData.GetComprobantesFiscales();
            return Ok(comprobantes);
        }

        // GET: api/ComprobantesFiscales/{rncCedula}
        [HttpGet("{rncCedula}")]
        public ActionResult<IEnumerable<ComprobanteFiscalModel>> GetComprobantesFiscalesByRnc(string rncCedula)
        {
            var comprobantes = _comprobantesData.GetComprobantesFiscalesByRnc(rncCedula);

            if (comprobantes == null || comprobantes.Count == 0)
            {
                return NotFound();
            }

            return Ok(comprobantes);
        }

        // GET: api/ComprobantesFiscales/TotalMonto/{rncCedula}
        [HttpGet("TotalMonto/{rncCedula}")]
        public ActionResult<decimal> GetTotalMontoByRnc(string rncCedula)
        {
            decimal totalMonto = _comprobantesData.GetTotalMontoByRnc(rncCedula);
            return Ok(totalMonto);
        }
    }
}
