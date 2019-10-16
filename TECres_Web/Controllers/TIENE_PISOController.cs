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
    public class TIENE_PISOController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        // GET: api/TIENE_PISO
        public IQueryable<TIENE_PISO> GetTIENE_PISO()
        {
            return db.TIENE_PISO;
        }

        // GET: api/TIENE_PISO/5
        [ResponseType(typeof(TIENE_PISO))]
        public IHttpActionResult GetTIENE_PISO(int id)
        {
            TIENE_PISO tIENE_PISO = db.TIENE_PISO.Find(id);
            if (tIENE_PISO == null)
            {
                return NotFound();
            }

            return Ok(tIENE_PISO);
        }

        // PUT: api/TIENE_PISO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTIENE_PISO(int id, TIENE_PISO tIENE_PISO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tIENE_PISO.ID_Propiedad)
            {
                return BadRequest();
            }

            db.Entry(tIENE_PISO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TIENE_PISOExists(id))
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

        // POST: api/TIENE_PISO
        [ResponseType(typeof(TIENE_PISO))]
        public IHttpActionResult PostTIENE_PISO(TIENE_PISO tIENE_PISO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TIENE_PISO.Add(tIENE_PISO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TIENE_PISOExists(tIENE_PISO.ID_Propiedad))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tIENE_PISO.ID_Propiedad }, tIENE_PISO);
        }

        // DELETE: api/TIENE_PISO/5
        [ResponseType(typeof(TIENE_PISO))]
        public IHttpActionResult DeleteTIENE_PISO(int id)
        {
            TIENE_PISO tIENE_PISO = db.TIENE_PISO.Find(id);
            if (tIENE_PISO == null)
            {
                return NotFound();
            }

            db.TIENE_PISO.Remove(tIENE_PISO);
            db.SaveChanges();

            return Ok(tIENE_PISO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TIENE_PISOExists(int id)
        {
            return db.TIENE_PISO.Count(e => e.ID_Propiedad == id) > 0;
        }
    }
}