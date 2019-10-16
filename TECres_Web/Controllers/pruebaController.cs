using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class pruebaController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        public IHttpActionResult NombresOcupacion() {
            spPruebaModel prueba = new spPruebaModel();
            prueba.NombresOcupacion = db.spPrueba();
            return Ok(prueba);

        }
    }
}
