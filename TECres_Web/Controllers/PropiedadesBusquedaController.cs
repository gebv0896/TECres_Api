using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class PropiedadesBusquedaController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/PropiedadesBusqueda/{CantHab}/{PrecMin}/{PrecMax}")]
        public IHttpActionResult PropiedadesBusqueda(int CantHab, int PrecMin, int PrecMax)
        {
            spPropiedadesBusquedaModel modelo = new spPropiedadesBusquedaModel();
            modelo.Propiedades = db.PropiedadesBusqueda(CantHab, PrecMin,PrecMax);
            return Ok(modelo);

        }
    }
}

