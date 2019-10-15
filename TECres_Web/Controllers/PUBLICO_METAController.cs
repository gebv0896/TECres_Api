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
    public class PUBLICO_METAController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        // GET: api/PUBLICO_META
        public IQueryable<PUBLICO_META> GetPUBLICO_META()
        {
            return db.PUBLICO_META;
        }

        // GET: api/PUBLICO_META/5
        [ResponseType(typeof(PUBLICO_META))]
        public IHttpActionResult GetPUBLICO_META(string id)
        {
            PUBLICO_META pUBLICO_META = db.PUBLICO_META.Find(id);
            if (pUBLICO_META == null)
            {
                return NotFound();
            }

            return Ok(pUBLICO_META);
        }

        // PUT: api/PUBLICO_META/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPUBLICO_META(string id, PUBLICO_META pUBLICO_META)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pUBLICO_META.Nombre)
            {
                return BadRequest();
            }

            db.Entry(pUBLICO_META).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PUBLICO_METAExists(id))
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

        // POST: api/PUBLICO_META
        [ResponseType(typeof(PUBLICO_META))]
        public IHttpActionResult PostPUBLICO_META(PUBLICO_META pUBLICO_META)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PUBLICO_META.Add(pUBLICO_META);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PUBLICO_METAExists(pUBLICO_META.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pUBLICO_META.Nombre }, pUBLICO_META);
        }

        // DELETE: api/PUBLICO_META/5
        [ResponseType(typeof(PUBLICO_META))]
        public IHttpActionResult DeletePUBLICO_META(string id)
        {
            PUBLICO_META pUBLICO_META = db.PUBLICO_META.Find(id);
            if (pUBLICO_META == null)
            {
                return NotFound();
            }

            db.PUBLICO_META.Remove(pUBLICO_META);
            db.SaveChanges();

            return Ok(pUBLICO_META);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PUBLICO_METAExists(string id)
        {
            return db.PUBLICO_META.Count(e => e.Nombre == id) > 0;
        }
    }
}