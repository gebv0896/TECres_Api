using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class AnunciosSinEstadisticaController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/AnunciosSinEstadistica/{id}")]
        public IHttpActionResult Anuncios_SinEstadisticas(int id)
        {
            spAnunciosSinEstadisticasModel modelo = new spAnunciosSinEstadisticasModel();
            modelo.Anuncios_SinEstadisticas = db.AnuncioSinEstadisticas(id);
            return Ok(modelo);

        }
    }
}