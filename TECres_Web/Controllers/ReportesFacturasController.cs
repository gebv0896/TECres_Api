using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class ReportesFacturasController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/ReportesFacturas/{fecha_ini}/{fecha_fin}")]
        public IHttpActionResult Reportes_Facturas(System.DateTime fecha_ini,System.DateTime fecha_fin)
        {
            spReportesFacturasModel modelo = new spReportesFacturasModel();
            modelo.Reportes_Facturas = db.ReportesFacturas(fecha_ini,fecha_fin);
            return Ok(modelo);
        }
    }
}