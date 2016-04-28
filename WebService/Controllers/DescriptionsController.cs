using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class DescriptionsController : ApiController
    {
        private readonly StatueContext db = new StatueContext();

        // GET: api/Descriptions
        public IQueryable<Description> GetDescriptions()
        {
            return db.Descriptions;
        }

        // GET: api/Descriptions/5
        [ResponseType(typeof(Description))]
        public IHttpActionResult GetDescription(int id)
        {
            var description = db.Descriptions.Find(id);
            if (description == null)
            {
                return NotFound();
            }

            return Ok(description);
        }

        // PUT: api/Descriptions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDescription(int id, Description description)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != description.Id)
            {
                return BadRequest();
            }

            db.Entry(description).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescriptionExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Descriptions
        [ResponseType(typeof(Description))]
        public IHttpActionResult PostDescription(Description description)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Descriptions.Add(description);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = description.Id}, description);
        }

        // DELETE: api/Descriptions/5
        [ResponseType(typeof(Description))]
        public IHttpActionResult DeleteDescription(int id)
        {
            var description = db.Descriptions.Find(id);
            if (description == null)
            {
                return NotFound();
            }

            db.Descriptions.Remove(description);
            db.SaveChanges();

            return Ok(description);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DescriptionExists(int id)
        {
            return db.Descriptions.Count(e => e.Id == id) > 0;
        }
    }
}