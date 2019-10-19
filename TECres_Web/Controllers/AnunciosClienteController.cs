using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class AnunciosClienteController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/AnunciosCliente/{cedula}")]
        public IHttpActionResult Anuncios_Cliente(int cedula)
        {
            spAnunciosClienteModel modelo = new spAnunciosClienteModel();
            modelo.Anuncios_Cliente = db.AnunciosCliente(cedula);
            return Ok(modelo);

        }
    }
}
