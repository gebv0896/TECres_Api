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
    public class OCUPACIONController : ApiController
    {
        public IHttpActionResult Options()
        {
            HttpContext.Current.Response.AppendHeader("Allow", "GET,DELETE,PUT,POST,OPTIONS");
            return Ok();
        }

        private TECresEntities db = new TECresEntities();

        // GET: api/OCUPACION
        public IQueryable<OCUPACION> GetOCUPACION()
        {
            return db.OCUPACION;
        }

        // GET: api/OCUPACION/5
        [ResponseType(typeof(OCUPACION))]
        public IHttpActionResult GetOCUPACION(string id)
        {
            OCUPACION oCUPACION = db.OCUPACION.Find(id);
            if (oCUPACION == null)
            {
                return NotFound();
            }

            return Ok(oCUPACION);
        }

        // PUT: api/OCUPACION/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOCUPACION(string id, OCUPACION oCUPACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oCUPACION.Nombre)
            {
                return BadRequest();
            }

            db.Entry(oCUPACION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OCUPACIONExists(id))
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

        // POST: api/OCUPACION
        [ResponseType(typeof(OCUPACION))]
        public IHttpActionResult PostOCUPACION(OCUPACION oCUPACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OCUPACION.Add(oCUPACION);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (OCUPACIONExists(oCUPACION.Nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = oCUPACION.Nombre }, oCUPACION);
        }

        // DELETE: api/OCUPACION/5
        [ResponseType(typeof(OCUPACION))]
        public IHttpActionResult DeleteOCUPACION(string id)
        {
            OCUPACION oCUPACION = db.OCUPACION.Find(id);
            if (oCUPACION == null)
            {
                return NotFound();
            }

            db.OCUPACION.Remove(oCUPACION);
            db.SaveChanges();

            return Ok(oCUPACION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OCUPACIONExists(string id)
        {
            return db.OCUPACION.Count(e => e.Nombre == id) > 0;
        }
    }
}