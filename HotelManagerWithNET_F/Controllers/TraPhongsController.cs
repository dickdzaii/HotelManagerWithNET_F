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
using HotelManagerWithNET_F.Models;

namespace HotelManagerWithNET_F.Controllers
{
    public class TraPhongsController : ApiController
    {
        private HotelEntities db = new HotelEntities();

        // GET: api/TraPhongs
        public IQueryable<TraPhong> GetTraPhong()
        {
            return db.TraPhong;
        }

        // GET: api/TraPhongs/5
        [ResponseType(typeof(TraPhong))]
        public IHttpActionResult GetTraPhong(int id)
        {
            TraPhong traPhong = db.TraPhong.Find(id);
            if (traPhong == null)
            {
                return NotFound();
            }

            return Ok(traPhong);
        }

        // PUT: api/TraPhongs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTraPhong(int id, TraPhong traPhong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != traPhong.MaTraPhong)
            {
                return BadRequest();
            }

            db.Entry(traPhong).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraPhongExists(id))
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

        // POST: api/TraPhongs
        [ResponseType(typeof(TraPhong))]
        public IHttpActionResult PostTraPhong(TraPhong traPhong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TraPhong.Add(traPhong);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = traPhong.MaTraPhong }, traPhong);
        }

        // DELETE: api/TraPhongs/5
        [ResponseType(typeof(TraPhong))]
        public IHttpActionResult DeleteTraPhong(int id)
        {
            TraPhong traPhong = db.TraPhong.Find(id);
            if (traPhong == null)
            {
                return NotFound();
            }

            db.TraPhong.Remove(traPhong);
            db.SaveChanges();

            return Ok(traPhong);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TraPhongExists(int id)
        {
            return db.TraPhong.Count(e => e.MaTraPhong == id) > 0;
        }
    }
}