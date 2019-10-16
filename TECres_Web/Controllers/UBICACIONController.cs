using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using DB_TECres;

namespace TECres_Web.Controllers
{
    public class UBICACIONController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        public IHttpActionResult Options()
        {
            HttpContext.Current.Response.AppendHeader("Allow", "GET,DELETE,PUT,POST,OPTIONS");
            return Ok();
        }

        // GET: api/UBICACION
        public IQueryable<UBICACION> GetUBICACION()
        {
            return db.UBICACION;
        }

        // GET: api/UBICACION/5
        [ResponseType(typeof(UBICACION))]
        public IHttpActionResult GetUBICACION(int id)
        {
            UBICACION uBICACION = db.UBICACION.Find(id);
            if (uBICACION == null)
            {
                return NotFound();
            }

            return Ok(uBICACION);
        }

        // PUT: api/UBICACION/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUBICACION(int id, UBICACION uBICACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uBICACION.ID)
            {
                return BadRequest();
            }

            db.Entry(uBICACION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UBICACIONExists(id))
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

        // POST: api/UBICACION
        [ResponseType(typeof(UBICACION))]
        public IHttpActionResult PostUBICACION(UBICACION uBICACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UBICACION.Add(uBICACION);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uBICACION.ID }, uBICACION);
        }

        // DELETE: api/UBICACION/5
        [ResponseType(typeof(UBICACION))]
        public IHttpActionResult DeleteUBICACION(int id)
        {
            UBICACION uBICACION = db.UBICACION.Find(id);
            if (uBICACION == null)
            {
                return NotFound();
            }

            db.UBICACION.Remove(uBICACION);
            db.SaveChanges();

            return Ok(uBICACION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UBICACIONExists(int id)
        {
            return db.UBICACION.Count(e => e.ID == id) > 0;
        }
    }
}