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
    public class TIENE_OCUPACIONController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        // GET: api/TIENE_OCUPACION
        public IQueryable<TIENE_OCUPACION> GetTIENE_OCUPACION()
        {
            return db.TIENE_OCUPACION;
        }

        // GET: api/TIENE_OCUPACION/5
        [ResponseType(typeof(TIENE_OCUPACION))]
        public IHttpActionResult GetTIENE_OCUPACION(int id)
        {
            TIENE_OCUPACION tIENE_OCUPACION = db.TIENE_OCUPACION.Find(id);
            if (tIENE_OCUPACION == null)
            {
                return NotFound();
            }

            return Ok(tIENE_OCUPACION);
        }

        // PUT: api/TIENE_OCUPACION/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTIENE_OCUPACION(int id, TIENE_OCUPACION tIENE_OCUPACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tIENE_OCUPACION.ID_Comprador)
            {
                return BadRequest();
            }

            db.Entry(tIENE_OCUPACION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TIENE_OCUPACIONExists(id))
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

        // POST: api/TIENE_OCUPACION
        [ResponseType(typeof(TIENE_OCUPACION))]
        public IHttpActionResult PostTIENE_OCUPACION(TIENE_OCUPACION tIENE_OCUPACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TIENE_OCUPACION.Add(tIENE_OCUPACION);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TIENE_OCUPACIONExists(tIENE_OCUPACION.ID_Comprador))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tIENE_OCUPACION.ID_Comprador }, tIENE_OCUPACION);
        }

        // DELETE: api/TIENE_OCUPACION/5
        [ResponseType(typeof(TIENE_OCUPACION))]
        public IHttpActionResult DeleteTIENE_OCUPACION(int id)
        {
            TIENE_OCUPACION tIENE_OCUPACION = db.TIENE_OCUPACION.Find(id);
            if (tIENE_OCUPACION == null)
            {
                return NotFound();
            }

            db.TIENE_OCUPACION.Remove(tIENE_OCUPACION);
            db.SaveChanges();

            return Ok(tIENE_OCUPACION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TIENE_OCUPACIONExists(int id)
        {
            return db.TIENE_OCUPACION.Count(e => e.ID_Comprador == id) > 0;
        }
    }
}