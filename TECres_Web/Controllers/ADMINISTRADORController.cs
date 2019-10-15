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
    public class ADMINISTRADORController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        // GET: api/ADMINISTRADOR
        public IQueryable<ADMINISTRADOR> GetADMINISTRADOR()
        {
            return db.ADMINISTRADOR;
        }

        // GET: api/ADMINISTRADOR/5
        [ResponseType(typeof(ADMINISTRADOR))]
        public IHttpActionResult GetADMINISTRADOR(int id)
        {
            ADMINISTRADOR aDMINISTRADOR = db.ADMINISTRADOR.Find(id);
            if (aDMINISTRADOR == null)
            {
                return NotFound();
            }

            return Ok(aDMINISTRADOR);
        }

        // PUT: api/ADMINISTRADOR/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutADMINISTRADOR(int id, ADMINISTRADOR aDMINISTRADOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aDMINISTRADOR.Cedula)
            {
                return BadRequest();
            }

            db.Entry(aDMINISTRADOR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ADMINISTRADORExists(id))
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

        // POST: api/ADMINISTRADOR
        [ResponseType(typeof(ADMINISTRADOR))]
        public IHttpActionResult PostADMINISTRADOR(ADMINISTRADOR aDMINISTRADOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ADMINISTRADOR.Add(aDMINISTRADOR);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ADMINISTRADORExists(aDMINISTRADOR.Cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aDMINISTRADOR.Cedula }, aDMINISTRADOR);
        }

        // DELETE: api/ADMINISTRADOR/5
        [ResponseType(typeof(ADMINISTRADOR))]
        public IHttpActionResult DeleteADMINISTRADOR(int id)
        {
            ADMINISTRADOR aDMINISTRADOR = db.ADMINISTRADOR.Find(id);
            if (aDMINISTRADOR == null)
            {
                return NotFound();
            }

            db.ADMINISTRADOR.Remove(aDMINISTRADOR);
            db.SaveChanges();

            return Ok(aDMINISTRADOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ADMINISTRADORExists(int id)
        {
            return db.ADMINISTRADOR.Count(e => e.Cedula == id) > 0;
        }
    }
}