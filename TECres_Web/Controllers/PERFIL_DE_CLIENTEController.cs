using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DB_TECres;

namespace TECres_Web.Controllers
{
    public class PERFIL_DE_CLIENTEController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        // GET: api/PERFIL_DE_CLIENTE
        public IQueryable<PERFIL_DE_CLIENTE> GetPERFIL_DE_CLIENTE()
        {
            return db.PERFIL_DE_CLIENTE;
        }

        // GET: api/PERFIL_DE_CLIENTE/5
        [ResponseType(typeof(PERFIL_DE_CLIENTE))]
        public IHttpActionResult GetPERFIL_DE_CLIENTE(string id)
        {
            PERFIL_DE_CLIENTE pERFIL_DE_CLIENTE = db.PERFIL_DE_CLIENTE.Find(id);
            if (pERFIL_DE_CLIENTE == null)
            {
                return NotFound();
            }

            return Ok(pERFIL_DE_CLIENTE);
        }

        // PUT: api/PERFIL_DE_CLIENTE/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPERFIL_DE_CLIENTE(string id, PERFIL_DE_CLIENTE pERFIL_DE_CLIENTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pERFIL_DE_CLIENTE.Nombre)
            {
                return BadRequest();
            }

            db.Entry(pERFIL_DE_CLIENTE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PERFIL_DE_CLIENTEExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PERFIL_DE_CLIENTE
        [ResponseType(typeof(PERFIL_DE_CLIENTE))]
        public IHttpActionResult PostPERFIL_DE_CLIENTE(PERFIL_DE_CLIENTE pERFIL_DE_CLIENTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PERFIL_DE_CLIENTE.Add(pERFIL_DE_CLIENTE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PERFIL_DE_CLIENTEExists(pERFIL_DE_CLIENTE.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pERFIL_DE_CLIENTE.Nombre }, pERFIL_DE_CLIENTE);
        }

        // DELETE: api/PERFIL_DE_CLIENTE/5
        [ResponseType(typeof(PERFIL_DE_CLIENTE))]
        public IHttpActionResult DeletePERFIL_DE_CLIENTE(string id)
        {
            PERFIL_DE_CLIENTE pERFIL_DE_CLIENTE = db.PERFIL_DE_CLIENTE.Find(id);
            if (pERFIL_DE_CLIENTE == null)
            {
                return NotFound();
            }

            db.PERFIL_DE_CLIENTE.Remove(pERFIL_DE_CLIENTE);
            db.SaveChanges();

            return Ok(pERFIL_DE_CLIENTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PERFIL_DE_CLIENTEExists(string id)
        {
            return db.PERFIL_DE_CLIENTE.Count(e => e.Nombre == id) > 0;
        }
    }
}