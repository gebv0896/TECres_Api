using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class CantonesProvinciaController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/CantonesProvincia/{provincia}")]
        public IHttpActionResult Cantones_Provincia(string provincia)
        {
            spCantonesPorProvinciaModel modelo = new spCantonesPorProvinciaModel();
            modelo.CantonesProvincia = db.CantonesPorProvincia(provincia);
            return Ok(modelo);

        }
    }
}
