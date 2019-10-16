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
    public class ANUNCIOController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        // GET: api/ANUNCIO
        public IQueryable<ANUNCIO> GetANUNCIO()
        {
            return db.ANUNCIO;
        }

        // GET: api/ANUNCIO/5
        [ResponseType(typeof(ANUNCIO))]
        public IHttpActionResult GetANUNCIO(int id)
        {
            ANUNCIO aNUNCIO = db.ANUNCIO.Find(id);
            if (aNUNCIO == null)
            {
                return NotFound();
            }

            return Ok(aNUNCIO);
        }

        // PUT: api/ANUNCIO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutANUNCIO(int id, ANUNCIO aNUNCIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aNUNCIO.ID)
            {
                return BadRequest();
            }

            db.Entry(aNUNCIO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ANUNCIOExists(id))
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

        // POST: api/ANUNCIO
        [ResponseType(typeof(ANUNCIO))]
        public IHttpActionResult PostANUNCIO(ANUNCIO aNUNCIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ANUNCIO.Add(aNUNCIO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aNUNCIO.ID }, aNUNCIO);
        }

        // DELETE: api/ANUNCIO/5
        [ResponseType(typeof(ANUNCIO))]
        public IHttpActionResult DeleteANUNCIO(int id)
        {
            ANUNCIO aNUNCIO = db.ANUNCIO.Find(id);
            if (aNUNCIO == null)
            {
                return NotFound();
            }

            db.ANUNCIO.Remove(aNUNCIO);
            db.SaveChanges();

            return Ok(aNUNCIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ANUNCIOExists(int id)
        {
            return db.ANUNCIO.Count(e => e.ID == id) > 0;
        }
    }
}