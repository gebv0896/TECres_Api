using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class AnuncioEstadisticaController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/AnuncioEstadistica/{id}")]
        public IHttpActionResult Anuncio_Estadistica(int id)
        {
            spAnuncioEstadisticaModel modelo = new spAnuncioEstadisticaModel();
            modelo.Anuncio_Estadistica = db.AnuncioEstadistica(id);
            return Ok(modelo);

        }
    }
}