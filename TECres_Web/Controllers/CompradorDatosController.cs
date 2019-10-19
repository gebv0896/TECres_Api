using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class CompradorDatosController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/CompradorDatos/{id}")]
        public IHttpActionResult Comprador_Datos(int id)
        {
            spCompradorDatosModel modelo = new spCompradorDatosModel();
            modelo.Comprador_Datos = db.CompradorDatos(id);
            return Ok(modelo);

        }
    }
}