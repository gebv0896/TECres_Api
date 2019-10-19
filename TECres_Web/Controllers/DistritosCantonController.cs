using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECres_Web.Models;

namespace TECres_Web.Controllers
{
    public class DistritosCantonController : ApiController
    {
        private DB_TECres.TECresEntities db = new DB_TECres.TECresEntities();

        [HttpGet]
        [Route("api/DistritosCanton/{provincia}/{canton}")]
        public IHttpActionResult DistritosCanton(string provincia, string canton)
        {
            spDistritosPorCantonModel modelo = new spDistritosPorCantonModel();
            modelo.DistritosCanton = db.DistritosPorCanton(provincia,canton);
            return Ok(modelo);

        }
    }
}
