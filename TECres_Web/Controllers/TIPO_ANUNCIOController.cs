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
    public class TIPO_ANUNCIOController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        // GET: api/TIPO_ANUNCIO
        public IQueryable<TIPO_ANUNCIO> GetTIPO_ANUNCIO()
        {
            return db.TIPO_ANUNCIO;
        }

        // GET: api/TIPO_ANUNCIO/5
        [ResponseType(typeof(TIPO_ANUNCIO))]
        public IHttpActionResult GetTIPO_ANUNCIO(string id)
        {
            TIPO_ANUNCIO tIPO_ANUNCIO = db.TIPO_ANUNCIO.Find(id);
            if (tIPO_ANUNCIO == null)
            {
                return NotFound();
            }

            return Ok(tIPO_ANUNCIO);
        }

        // PUT: api/TIPO_ANUNCIO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTIPO_ANUNCIO(string id, TIPO_ANUNCIO tIPO_ANUNCIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tIPO_ANUNCIO.Nombre)
            {
                return BadRequest();
            }

            db.Entry(tIPO_ANUNCIO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TIPO_ANUNCIOExists(id))
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

        // POST: api/TIPO_ANUNCIO
        [ResponseType(typeof(TIPO_ANUNCIO))]
        public IHttpActionResult PostTIPO_ANUNCIO(TIPO_ANUNCIO tIPO_ANUNCIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TIPO_ANUNCIO.Add(tIPO_ANUNCIO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TIPO_ANUNCIOExists(tIPO_ANUNCIO.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tIPO_ANUNCIO.Nombre }, tIPO_ANUNCIO);
        }

        // DELETE: api/TIPO_ANUNCIO/5
        [ResponseType(typeof(TIPO_ANUNCIO))]
        public IHttpActionResult DeleteTIPO_ANUNCIO(string id)
        {
            TIPO_ANUNCIO tIPO_ANUNCIO = db.TIPO_ANUNCIO.Find(id);
            if (tIPO_ANUNCIO == null)
            {
                return NotFound();
            }

            db.TIPO_ANUNCIO.Remove(tIPO_ANUNCIO);
            db.SaveChanges();

            return Ok(tIPO_ANUNCIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TIPO_ANUNCIOExists(string id)
        {
            return db.TIPO_ANUNCIO.Count(e => e.Nombre == id) > 0;
        }
    }
}