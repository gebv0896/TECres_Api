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
    public class TIPO_PISOController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        // GET: api/TIPO_PISO
        public IQueryable<TIPO_PISO> GetTIPO_PISO()
        {
            return db.TIPO_PISO;
        }

        // GET: api/TIPO_PISO/5
        [ResponseType(typeof(TIPO_PISO))]
        public IHttpActionResult GetTIPO_PISO(string id)
        {
            TIPO_PISO tIPO_PISO = db.TIPO_PISO.Find(id);
            if (tIPO_PISO == null)
            {
                return NotFound();
            }

            return Ok(tIPO_PISO);
        }

        // PUT: api/TIPO_PISO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTIPO_PISO(string id, TIPO_PISO tIPO_PISO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tIPO_PISO.Nombre)
            {
                return BadRequest();
            }

            db.Entry(tIPO_PISO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TIPO_PISOExists(id))
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

        // POST: api/TIPO_PISO
        [ResponseType(typeof(TIPO_PISO))]
        public IHttpActionResult PostTIPO_PISO(TIPO_PISO tIPO_PISO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TIPO_PISO.Add(tIPO_PISO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TIPO_PISOExists(tIPO_PISO.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tIPO_PISO.Nombre }, tIPO_PISO);
        }

        // DELETE: api/TIPO_PISO/5
        [ResponseType(typeof(TIPO_PISO))]
        public IHttpActionResult DeleteTIPO_PISO(string id)
        {
            TIPO_PISO tIPO_PISO = db.TIPO_PISO.Find(id);
            if (tIPO_PISO == null)
            {
                return NotFound();
            }

            db.TIPO_PISO.Remove(tIPO_PISO);
            db.SaveChanges();

            return Ok(tIPO_PISO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TIPO_PISOExists(string id)
        {
            return db.TIPO_PISO.Count(e => e.Nombre == id) > 0;
        }
    }
}