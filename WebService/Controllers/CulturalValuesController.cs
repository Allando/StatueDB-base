using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class CulturalValuesController : ApiController
    {
        private readonly StatueContext db = new StatueContext();

        // GET: api/CulturalValues
        public IQueryable<CulturalValue> GetCulturalValues()
        {
            return db.CulturalValues;
        }

        // GET: api/CulturalValues/5
        [ResponseType(typeof(CulturalValue))]
        public IHttpActionResult GetCulturalValue(int id)
        {
            var culturalValue = db.CulturalValues.Find(id);
            if (culturalValue == null)
            {
                return NotFound();
            }

            return Ok(culturalValue);
        }

        // PUT: api/CulturalValues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCulturalValue(int id, CulturalValue culturalValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != culturalValue.Id)
            {
                return BadRequest();
            }

            db.Entry(culturalValue).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CulturalValueExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CulturalValues
        [ResponseType(typeof(CulturalValue))]
        public IHttpActionResult PostCulturalValue(CulturalValue culturalValue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CulturalValues.Add(culturalValue);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = culturalValue.Id}, culturalValue);
        }

        // DELETE: api/CulturalValues/5
        [ResponseType(typeof(CulturalValue))]
        public IHttpActionResult DeleteCulturalValue(int id)
        {
            var culturalValue = db.CulturalValues.Find(id);
            if (culturalValue == null)
            {
                return NotFound();
            }

            db.CulturalValues.Remove(culturalValue);
            db.SaveChanges();

            return Ok(culturalValue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CulturalValueExists(int id)
        {
            return db.CulturalValues.Count(e => e.Id == id) > 0;
        }
    }
}