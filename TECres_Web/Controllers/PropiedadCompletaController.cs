using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class PropiedadCompletaController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/PropiedadCompleta/{id}")]
        public IHttpActionResult PropiedadCompleta(int id)
        {
            spPropiedadCompletaModel modelo = new spPropiedadCompletaModel();
            modelo.Propiedades = db.PropiedadCompleta(id);
            return Ok(modelo);

        }
    }
}

