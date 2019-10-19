
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class PropiedadesClienteController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/PropiedadesCliente/{cedula}")]
        public IHttpActionResult PropiedadesCliente(int cedula)
        {
            spPropiedadesClienteModel modelo = new spPropiedadesClienteModel();
            modelo.Propiedades_Cliente = db.PropiedadesCliente(cedula);
            return Ok(modelo);
        }
    }
}
