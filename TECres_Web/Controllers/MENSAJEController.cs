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
    public class MENSAJEController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        // GET: api/MENSAJE
        public IQueryable<MENSAJE> GetMENSAJE()
        {
            return db.MENSAJE;
        }

        // GET: api/MENSAJE/5
        [ResponseType(typeof(MENSAJE))]
        public IHttpActionResult GetMENSAJE(int id)
        {
            MENSAJE mENSAJE = db.MENSAJE.Find(id);
            if (mENSAJE == null)
            {
                return NotFound();
            }

            return Ok(mENSAJE);
        }

        // PUT: api/MENSAJE/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMENSAJE(int id, MENSAJE mENSAJE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mENSAJE.ID)
            {
                return BadRequest();
            }

            db.Entry(mENSAJE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MENSAJEExists(id))
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

        // POST: api/MENSAJE
        [ResponseType(typeof(MENSAJE))]
        public IHttpActionResult PostMENSAJE(MENSAJE mENSAJE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MENSAJE.Add(mENSAJE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mENSAJE.ID }, mENSAJE);
        }

        // DELETE: api/MENSAJE/5
        [ResponseType(typeof(MENSAJE))]
        public IHttpActionResult DeleteMENSAJE(int id)
        {
            MENSAJE mENSAJE = db.MENSAJE.Find(id);
            if (mENSAJE == null)
            {
                return NotFound();
            }

            db.MENSAJE.Remove(mENSAJE);
            db.SaveChanges();

            return Ok(mENSAJE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MENSAJEExists(int id)
        {
            return db.MENSAJE.Count(e => e.ID == id) > 0;
        }
    }
}