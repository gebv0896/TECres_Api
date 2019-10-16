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
    public class FOTOController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        // GET: api/FOTO
        public IQueryable<FOTO> GetFOTO()
        {
            return db.FOTO;
        }

        // GET: api/FOTO/5
        [ResponseType(typeof(FOTO))]
        public IHttpActionResult GetFOTO(int id)
        {
            FOTO fOTO = db.FOTO.Find(id);
            if (fOTO == null)
            {
                return NotFound();
            }

            return Ok(fOTO);
        }

        // PUT: api/FOTO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFOTO(int id, FOTO fOTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fOTO.ID)
            {
                return BadRequest();
            }

            db.Entry(fOTO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FOTOExists(id))
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

        // POST: api/FOTO
        [ResponseType(typeof(FOTO))]
        public IHttpActionResult PostFOTO(FOTO fOTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FOTO.Add(fOTO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fOTO.ID }, fOTO);
        }

        // DELETE: api/FOTO/5
        [ResponseType(typeof(FOTO))]
        public IHttpActionResult DeleteFOTO(int id)
        {
            FOTO fOTO = db.FOTO.Find(id);
            if (fOTO == null)
            {
                return NotFound();
            }

            db.FOTO.Remove(fOTO);
            db.SaveChanges();

            return Ok(fOTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FOTOExists(int id)
        {
            return db.FOTO.Count(e => e.ID == id) > 0;
        }
    }
}