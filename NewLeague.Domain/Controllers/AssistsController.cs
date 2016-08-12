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
using NewLeague.Domain.Models.NewLeague;
using NewLeague.Models;

namespace NewLeague.Domain.Controllers
{
    public class AssistsController : ApiController
    {
        private DomainContext db = new DomainContext();

        // GET: api/Assists
        public IQueryable<Assist> GetAssists()
        {
            return db.Assists;
        }

        // GET: api/Assists/5
        [ResponseType(typeof(Assist))]
        public IHttpActionResult GetAssist(int id)
        {
            Assist assist = db.Assists.Find(id);
            if (assist == null)
            {
                return NotFound();
            }

            return Ok(assist);
        }

        // PUT: api/Assists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssist(int id, Assist assist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assist.Id)
            {
                return BadRequest();
            }

            db.Entry(assist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssistExists(id))
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

        // POST: api/Assists
        [ResponseType(typeof(Assist))]
        public IHttpActionResult PostAssist(Assist assist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Assists.Add(assist);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assist.Id }, assist);
        }

        // DELETE: api/Assists/5
        [ResponseType(typeof(Assist))]
        public IHttpActionResult DeleteAssist(int id)
        {
            Assist assist = db.Assists.Find(id);
            if (assist == null)
            {
                return NotFound();
            }

            db.Assists.Remove(assist);
            db.SaveChanges();

            return Ok(assist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssistExists(int id)
        {
            return db.Assists.Count(e => e.Id == id) > 0;
        }
    }
}