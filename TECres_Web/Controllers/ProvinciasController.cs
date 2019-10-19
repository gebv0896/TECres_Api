using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class ProvinciasController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/Provincias")]
        public IHttpActionResult NombresProvincias()
        {
            spProvinciaModel modelo = new spProvinciaModel();
            modelo.Provincias = db.Provincias();
            return Ok(modelo);
        }
    }
}
