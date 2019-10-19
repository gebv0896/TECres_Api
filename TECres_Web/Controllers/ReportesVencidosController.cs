using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class ReportesVencidosController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/ReportesVencidos/{fecha}")]
        public IHttpActionResult Reportes_Vencidos(System.DateTime fecha)
        {
            spReportesVencidosModel modelo = new spReportesVencidosModel();
            modelo.Reportes_Vencidos = db.ReportesVencidos(fecha);
            return Ok(modelo);

        }
    }
}