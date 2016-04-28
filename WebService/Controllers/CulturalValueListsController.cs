using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebService.Controllers
{
    public class CulturalValueListsController : ApiController
    {
        private readonly StatueContext db = new StatueContext();

        // GET: api/CulturalValueLists
        public IQueryable<CulturalValueList> GetCulturalValueLists()
        {
            return db.CulturalValueLists;
        }

        // GET: api/CulturalValueLists/5
        [ResponseType(typeof(CulturalValueList))]
        public IHttpActionResult GetCulturalValueList(int id)
        {
            var culturalValueList = db.CulturalValueLists.Find(id);
            if (culturalValueList == null)
            {
                return NotFound();
            }

            return Ok(culturalValueList);
        }

        // PUT: api/CulturalValueLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCulturalValueList(int id, CulturalValueList culturalValueList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != culturalValueList.Id)
            {
                return BadRequest();
            }

            db.Entry(culturalValueList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CulturalValueListExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CulturalValueLists
        [ResponseType(typeof(CulturalValueList))]
        public IHttpActionResult PostCulturalValueList(CulturalValueList culturalValueList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CulturalValueLists.Add(culturalValueList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new {id = culturalValueList.Id}, culturalValueList);
        }

        // DELETE: api/CulturalValueLists/5
        [ResponseType(typeof(CulturalValueList))]
        public IHttpActionResult DeleteCulturalValueList(int id)
        {
            var culturalValueList = db.CulturalValueLists.Find(id);
            if (culturalValueList == null)
            {
                return NotFound();
            }

            db.CulturalValueLists.Remove(culturalValueList);
            db.SaveChanges();

            return Ok(culturalValueList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CulturalValueListExists(int id)
        {
            return db.CulturalValueLists.Count(e => e.Id == id) > 0;
        }
    }
}