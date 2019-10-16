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
    public class TIPO_INMUEBLEController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        // GET: api/TIPO_INMUEBLE
        public IQueryable<TIPO_INMUEBLE> GetTIPO_INMUEBLE()
        {
            return db.TIPO_INMUEBLE;
        }

        // GET: api/TIPO_INMUEBLE/5
        [ResponseType(typeof(TIPO_INMUEBLE))]
        public IHttpActionResult GetTIPO_INMUEBLE(string id)
        {
            TIPO_INMUEBLE tIPO_INMUEBLE = db.TIPO_INMUEBLE.Find(id);
            if (tIPO_INMUEBLE == null)
            {
                return NotFound();
            }

            return Ok(tIPO_INMUEBLE);
        }

        // PUT: api/TIPO_INMUEBLE/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTIPO_INMUEBLE(string id, TIPO_INMUEBLE tIPO_INMUEBLE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tIPO_INMUEBLE.Nombre)
            {
                return BadRequest();
            }

            db.Entry(tIPO_INMUEBLE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TIPO_INMUEBLEExists(id))
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

        // POST: api/TIPO_INMUEBLE
        [ResponseType(typeof(TIPO_INMUEBLE))]
        public IHttpActionResult PostTIPO_INMUEBLE(TIPO_INMUEBLE tIPO_INMUEBLE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TIPO_INMUEBLE.Add(tIPO_INMUEBLE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TIPO_INMUEBLEExists(tIPO_INMUEBLE.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tIPO_INMUEBLE.Nombre }, tIPO_INMUEBLE);
        }

        // DELETE: api/TIPO_INMUEBLE/5
        [ResponseType(typeof(TIPO_INMUEBLE))]
        public IHttpActionResult DeleteTIPO_INMUEBLE(string id)
        {
            TIPO_INMUEBLE tIPO_INMUEBLE = db.TIPO_INMUEBLE.Find(id);
            if (tIPO_INMUEBLE == null)
            {
                return NotFound();
            }

            db.TIPO_INMUEBLE.Remove(tIPO_INMUEBLE);
            db.SaveChanges();

            return Ok(tIPO_INMUEBLE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TIPO_INMUEBLEExists(string id)
        {
            return db.TIPO_INMUEBLE.Count(e => e.Nombre == id) > 0;
        }
    }
}