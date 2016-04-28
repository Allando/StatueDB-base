using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class StatuesController : ApiController
    {
        private readonly StatueContext db = new StatueContext();

        // GET: api/Statues
        public IQueryable<Statue> GetStatues()
        {
            return db.Statues;
        }

        // GET: api/Statues/5
        [ResponseType(typeof(Statue))]
        public IHttpActionResult GetStatue(int id)
        {
            var statue = db.Statues.Find(id);
            if (statue == null)
            {
                return NotFound();
            }

            return Ok(statue);
        }

        // PUT: api/Statues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatue(int id, Statue statue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statue.Id)
            {
                return BadRequest();
            }

            db.Entry(statue).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatueExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Statues
        [ResponseType(typeof(Statue))]
        public IHttpActionResult PostStatue(Statue statue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Statues.Add(statue);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = statue.Id}, statue);
        }

        // DELETE: api/Statues/5
        [ResponseType(typeof(Statue))]
        public IHttpActionResult DeleteStatue(int id)
        {
            var statue = db.Statues.Find(id);
            if (statue == null)
            {
                return NotFound();
            }

            db.Statues.Remove(statue);
            db.SaveChanges();

            return Ok(statue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatueExists(int id)
        {
            return db.Statues.Count(e => e.Id == id) > 0;
        }
    }
}