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
using BookingApp.Models;

namespace BookingApp.Controllers
{
    public class AccommodationsController : ApiController
    {
        private BAContext db = new BAContext();

        // GET: api/Accommodations
        public IQueryable<Accommodation> GetAccommodations()
        {
            var x= db.Accommodations;
            return HelperJebeni.accomodations.AsQueryable<Accommodation>();
            
        }

        // GET: api/Accommodations/5
        [ResponseType(typeof(Accommodation))]
        public IHttpActionResult GetAccommodation(int id)
        {
            //Accommodation accommodation = db.Accommodations.Find(id);
            //if (accommodation == null)
            //{
            //    return NotFound();
            //}

            //return Ok(accommodation);
            Accommodation accommodation = HelperJebeni.accomodations.Find(x => x.Id == id);
            if (accommodation == null)
            {
                return NotFound();
            }

            return Ok(accommodation);
        }

        // PUT: api/Accommodations/5
       [ResponseType(typeof(void))]
        //[Authorize(Roles = "Manager")]
        public IHttpActionResult PutAccommodation(int id, Accommodation accommodation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accommodation.Id)
            {
                return BadRequest();
            }

            db.Entry(accommodation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccommodationExists(id))
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

        // POST: api/Accommodations
        [HttpPost]
        [ResponseType(typeof(Accommodation))]
      //  [Authorize(Roles ="Manager")]
        public IHttpActionResult PostAccommodation(Accommodation accommodation)
        {
            try { 
         //   accommodation.AccomodationType.Accommodations = new List<Accommodation>();
        //    accommodation.Place.Accommodations = new List<Accommodation>();
            accommodation.User.Accomodations =new List<Accommodation>();
            accommodation.Place.RegionId = 1;
            accommodation.User = new BAIdentityUser();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Accommodations.Add(accommodation);
            db.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = accommodation.Id }, accommodation);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // DELETE: api/Accommodations/5
        [ResponseType(typeof(Accommodation))]
        [Authorize(Roles = "Manager")]
        public IHttpActionResult DeleteAccommodation(int id)
        {
            Accommodation accommodation = db.Accommodations.Find(id);
            if (accommodation == null)
            {
                return NotFound();
            }

            db.Accommodations.Remove(accommodation);
            db.SaveChanges();

            return Ok(accommodation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccommodationExists(int id)
        {
            return db.Accommodations.Count(e => e.Id == id) > 0;
        }
    }
}