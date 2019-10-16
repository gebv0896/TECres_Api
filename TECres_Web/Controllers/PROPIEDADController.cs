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
    public class PROPIEDADController : ApiController
    {
        private TECresEntities db = new TECresEntities();

        // GET: api/PROPIEDAD
        public IQueryable<PROPIEDAD> GetPROPIEDAD()
        {
            return db.PROPIEDAD;
        }

        // GET: api/PROPIEDAD/5
        [ResponseType(typeof(PROPIEDAD))]
        public IHttpActionResult GetPROPIEDAD(int id)
        {
            PROPIEDAD pROPIEDAD = db.PROPIEDAD.Find(id);
            if (pROPIEDAD == null)
            {
                return NotFound();
            }

            return Ok(pROPIEDAD);
        }

        // PUT: api/PROPIEDAD/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPROPIEDAD(int id, PROPIEDAD pROPIEDAD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pROPIEDAD.ID)
            {
                return BadRequest();
            }

            db.Entry(pROPIEDAD).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PROPIEDADExists(id))
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

        // POST: api/PROPIEDAD
        [ResponseType(typeof(PROPIEDAD))]
        public IHttpActionResult PostPROPIEDAD(PROPIEDAD pROPIEDAD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PROPIEDAD.Add(pROPIEDAD);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pROPIEDAD.ID }, pROPIEDAD);
        }

        // DELETE: api/PROPIEDAD/5
        [ResponseType(typeof(PROPIEDAD))]
        public IHttpActionResult DeletePROPIEDAD(int id)
        {
            PROPIEDAD pROPIEDAD = db.PROPIEDAD.Find(id);
            if (pROPIEDAD == null)
            {
                return NotFound();
            }

            db.PROPIEDAD.Remove(pROPIEDAD);
            db.SaveChanges();

            return Ok(pROPIEDAD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PROPIEDADExists(int id)
        {
            return db.PROPIEDAD.Count(e => e.ID == id) > 0;
        }
    }
}