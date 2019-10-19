using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class AnunciosPropiedadController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/AnunciosPropiedad/{id}")]
        public IHttpActionResult Anuncios_Propiedad(int id)
        {
            spAnunciosPropiedadModel modelo = new spAnunciosPropiedadModel();
            modelo.Anuncios_Propiedad = db.AnunciosPropiedad(id);
            return Ok(modelo);

        }
    }
}