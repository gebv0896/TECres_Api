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
    public class COMPRADORController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        // GET: api/COMPRADOR
        public IQueryable<COMPRADOR> GetCOMPRADOR()
        {
            return db.COMPRADOR;
        }

        // GET: api/COMPRADOR/5
        [ResponseType(typeof(COMPRADOR))]
        public IHttpActionResult GetCOMPRADOR(int id)
        {
            COMPRADOR cOMPRADOR = db.COMPRADOR.Find(id);
            if (cOMPRADOR == null)
            {
                return NotFound();
            }

            return Ok(cOMPRADOR);
        }

        // PUT: api/COMPRADOR/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCOMPRADOR(int id, COMPRADOR cOMPRADOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cOMPRADOR.ID)
            {
                return BadRequest();
            }

            db.Entry(cOMPRADOR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!COMPRADORExists(id))
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

        // POST: api/COMPRADOR
        [ResponseType(typeof(COMPRADOR))]
        public IHttpActionResult PostCOMPRADOR(COMPRADOR cOMPRADOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.COMPRADOR.Add(cOMPRADOR);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cOMPRADOR.ID }, cOMPRADOR);
        }

        // DELETE: api/COMPRADOR/5
        [ResponseType(typeof(COMPRADOR))]
        public IHttpActionResult DeleteCOMPRADOR(int id)
        {
            COMPRADOR cOMPRADOR = db.COMPRADOR.Find(id);
            if (cOMPRADOR == null)
            {
                return NotFound();
            }

            db.COMPRADOR.Remove(cOMPRADOR);
            db.SaveChanges();

            return Ok(cOMPRADOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool COMPRADORExists(int id)
        {
            return db.COMPRADOR.Count(e => e.ID == id) > 0;
        }
    }
}