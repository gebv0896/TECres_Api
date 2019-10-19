using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class MensajesClienteController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/MensajesCliente/{cedula}")]
        public IHttpActionResult Mensajes_Cliente(int cedula)
        {
            spMensajesClienteModel modelo = new spMensajesClienteModel();
            modelo.Mensajes_Cliente = db.MensajesCliente(cedula);
            return Ok(modelo);

        }
    }
}
