using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class StatueTypesController : ApiController
    {
        private readonly StatueContext db = new StatueContext();

        // GET: api/StatueTypes
        public IQueryable<StatueType> GetStatueTypes()
        {
            return db.StatueTypes;
        }

        // GET: api/StatueTypes/5
        [ResponseType(typeof(StatueType))]
        public IHttpActionResult GetStatueType(int id)
        {
            var statueType = db.StatueTypes.Find(id);
            if (statueType == null)
            {
                return NotFound();
            }

            return Ok(statueType);
        }

        // PUT: api/StatueTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatueType(int id, StatueType statueType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statueType.Id)
            {
                return BadRequest();
            }

            db.Entry(statueType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatueTypeExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StatueTypes
        [ResponseType(typeof(StatueType))]
        public IHttpActionResult PostStatueType(StatueType statueType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatueTypes.Add(statueType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = statueType.Id}, statueType);
        }

        // DELETE: api/StatueTypes/5
        [ResponseType(typeof(StatueType))]
        public IHttpActionResult DeleteStatueType(int id)
        {
            var statueType = db.StatueTypes.Find(id);
            if (statueType == null)
            {
                return NotFound();
            }

            db.StatueTypes.Remove(statueType);
            db.SaveChanges();

            return Ok(statueType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatueTypeExists(int id)
        {
            return db.StatueTypes.Count(e => e.Id == id) > 0;
        }
    }
}