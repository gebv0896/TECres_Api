using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class InsertarCompradorController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/InsertarComprador")]
        public IHttpActionResult InsertarComprador(string pNombre, string pApellido1,string pApellido2,string pGenero,System.DateTime pFecha_Nacimiento,int pIngresos_Mes,string pUsuario,string pContrasena,int pID_Ubicacion,string pOcupacion)
        {
            spInsertarCompradorModelo modelo = new spInsertarCompradorModelo();
            modelo.Insertar_Comprador = db.SP_Insertar_Comprador(pNombre,pApellido1,pApellido2,pGenero,pFecha_Nacimiento,pIngresos_Mes,pUsuario,pContrasena,pID_Ubicacion,pOcupacion);
            return Ok(modelo);

        }
    }
}