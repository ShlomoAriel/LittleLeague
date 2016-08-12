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
using AutoMapper;

namespace NewLeague.Domain.Controllers
{
    public class AssistController : ApiController
    {
        private DomainContext db = new DomainContext();

        // GET: api/Assists
        public IEnumerable<AssistViewModel> GetAssists()
        {
            var assists = db.Assists.Include(g => g.Player).Include(g => g.Match);
            var assistModel = Mapper.Map<List<AssistViewModel>>(assists);
            return assistModel;
        }

        // GET: api/Assists/5
        public AssistViewModel GetAssist(int id)
        {
            Assist assist = db.Assists.Find(id);
            if (assist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            var assistModel = Mapper.Map<AssistViewModel>(assist);
            return assistModel;
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
        public AssistViewModel PostAssist(Assist assist)
        {
            if (ModelState.IsValid)
            {

                db.Assists.Add(assist);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, assist);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = assist.Id }));
                var savedAssist = db.Assists.Find(assist.Id);
                //TODO check out virtual properties and when are filled. PLAYER IS NULL.
                var newAssist = Mapper.Map<AssistViewModel>(savedAssist);
                newAssist.Player = Mapper.Map<PlayerViewModel>(db.Players.Find(assist.PlayerId));
                return newAssist;
            }
            return null;
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