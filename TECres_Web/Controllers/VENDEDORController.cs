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
    public class VENDEDORController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        // GET: api/VENDEDOR
        public IQueryable<VENDEDOR> GetVENDEDOR()
        {
            return db.VENDEDOR;
        }

        // GET: api/VENDEDOR/5
        [ResponseType(typeof(VENDEDOR))]
        public IHttpActionResult GetVENDEDOR(int id)
        {
            VENDEDOR vENDEDOR = db.VENDEDOR.Find(id);
            if (vENDEDOR == null)
            {
                return NotFound();
            }

            return Ok(vENDEDOR);
        }

        // PUT: api/VENDEDOR/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVENDEDOR(int id, VENDEDOR vENDEDOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vENDEDOR.Cedula)
            {
                return BadRequest();
            }

            db.Entry(vENDEDOR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VENDEDORExists(id))
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

        // POST: api/VENDEDOR
        [ResponseType(typeof(VENDEDOR))]
        public IHttpActionResult PostVENDEDOR(VENDEDOR vENDEDOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VENDEDOR.Add(vENDEDOR);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VENDEDORExists(vENDEDOR.Cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vENDEDOR.Cedula }, vENDEDOR);
        }

        // DELETE: api/VENDEDOR/5
        [ResponseType(typeof(VENDEDOR))]
        public IHttpActionResult DeleteVENDEDOR(int id)
        {
            VENDEDOR vENDEDOR = db.VENDEDOR.Find(id);
            if (vENDEDOR == null)
            {
                return NotFound();
            }

            db.VENDEDOR.Remove(vENDEDOR);
            db.SaveChanges();

            return Ok(vENDEDOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VENDEDORExists(int id)
        {
            return db.VENDEDOR.Count(e => e.Cedula == id) > 0;
        }
    }
}