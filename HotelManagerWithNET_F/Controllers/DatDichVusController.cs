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
    public class DatDichVusController : ApiController
    {
        private HotelEntities db = new HotelEntities();

        // GET: api/DatDichVus
        public IQueryable<DatDichVu> GetDatDichVu()
        {
            return db.DatDichVu;
        }

        // GET: api/DatDichVus/5
        [ResponseType(typeof(DatDichVu))]
        public IHttpActionResult GetDatDichVu(int id)
        {
            DatDichVu datDichVu = db.DatDichVu.Find(id);
            if (datDichVu == null)
            {
                return NotFound();
            }

            return Ok(datDichVu);
        }

        // PUT: api/DatDichVus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDatDichVu(int id, DatDichVu datDichVu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != datDichVu.MaDat)
            {
                return BadRequest();
            }

            db.Entry(datDichVu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatDichVuExists(id))
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

        // POST: api/DatDichVus
        [ResponseType(typeof(DatDichVu))]
        public IHttpActionResult PostDatDichVu(DatDichVu datDichVu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DatDichVu.Add(datDichVu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = datDichVu.MaDat }, datDichVu);
        }

        // DELETE: api/DatDichVus/5
        [ResponseType(typeof(DatDichVu))]
        public IHttpActionResult DeleteDatDichVu(int id)
        {
            DatDichVu datDichVu = db.DatDichVu.Find(id);
            if (datDichVu == null)
            {
                return NotFound();
            }

            db.DatDichVu.Remove(datDichVu);
            db.SaveChanges();

            return Ok(datDichVu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DatDichVuExists(int id)
        {
            return db.DatDichVu.Count(e => e.MaDat == id) > 0;
        }
    }
}