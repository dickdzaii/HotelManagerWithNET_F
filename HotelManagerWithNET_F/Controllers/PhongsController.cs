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
    public class PhongsController : ApiController
    {
        private HotelEntities db = new HotelEntities();

        // GET: api/Phongs
        public IQueryable<Phong> GetPhong()
        {
            return db.Phong;
        }
        [Route("Phongs/get-by-loai/{ma}")]
        public IQueryable<Phong> GetPhongbyloai(int ma)
        {
            var kq = db.Phong.Where(s => s.MaLoai == ma);
            if(kq!=null)
            return kq;
            return null;
        }
        [Route("Phongs/get-all-with-price")]
        public IQueryable getphongwithgia()
        {
            var kq = db.Phong.Join(db.GiaPhong, p => p.MaPhong, gp => gp.MaPhong, (p, gp) => new
            {
                p.MaPhong,p.TenPhong,p.MaLoai,gp.Gia,p.TrangThai,gp.NgayKT
            }).Where(x=>x.NgayKT==null);
            return kq;
        }

        [Route("Phongs/get-all-detail")]
        public IQueryable getphongswithalldetail()
        {
            var kq = from c in db.CoSoVatChatPhong
                     join p in db.Phong on c.MaPhong equals p.MaPhong
                     join gp in db.GiaPhong on p.MaPhong equals gp.MaPhong
                     where gp.NgayKT == null
                     select new { p.MaPhong, p.TenPhong, p.MaLoai, gp.Gia, p.TrangThai, gp.NgayKT,
                     c.Ban,c.DenNgu,c.DieuHoa,c.Ghe,c.Giuong,c.PhongTam,c.TiVi,c.TuDo,c.TuLanh
                     };
            return kq;
        }
        // GET: api/Phongs/5
        [ResponseType(typeof(Phong))]
        public IHttpActionResult GetPhong(int id)
        {
            Phong phong = db.Phong.Find(id);
            if (phong == null)
            {
                return NotFound();
            }

            return Ok(phong);
        }
        [Route("Phongs/full-detail/{id}")]
        public dynamic GetPhongwithdetail(int id) {

            var kq = from c in db.CoSoVatChatPhong
                     join p in db.Phong on c.MaPhong equals p.MaPhong
                     join gp in db.GiaPhong on p.MaPhong equals gp.MaPhong
                     where gp.NgayKT == null && p.MaPhong==id
                     select new
                     {
                         p.MaPhong,
                         p.TenPhong,
                         p.MaLoai,
                         gp.Gia,
                         p.TrangThai,
                         gp.NgayKT,
                         c.Ban,
                         c.DenNgu,
                         c.DieuHoa,
                         c.Ghe,
                         c.Giuong,
                         c.PhongTam,
                         c.TiVi,
                         c.TuDo,
                         c.TuLanh
                     };
            if (kq != null) return kq.First();
            else return null;
        }
        [Route("Phongs/get-free-by-loai")]
        public dynamic getphongtrongbyloai(int id)
        {
            //var d = db.getphongwithloai(id).ToList();
            var kq = from c in db.CoSoVatChatPhong
                     join p in db.Phong on c.MaPhong equals p.MaPhong
                     join gp in db.GiaPhong on p.MaPhong equals gp.MaPhong
                     where gp.NgayKT == null && p.MaLoai == id &&p.TrangThai==0
                     select new
                     {
                         p.MaPhong,
                         p.TenPhong,
                         p.MaLoai,
                         gp.Gia,
                         p.TrangThai,
                         gp.NgayKT,
                         c.Ban,
                         c.DenNgu,
                         c.DieuHoa,
                         c.Ghe,
                         c.Giuong,
                         c.PhongTam,
                         c.TiVi,
                         c.TuDo,
                         c.TuLanh
                     };
            if (kq != null) return kq.First();
            else return null;
        }
        [Route("get-free")]
        public dynamic getphongtrong()
        {

            var kq = from c in db.CoSoVatChatPhong
                     join p in db.Phong on c.MaPhong equals p.MaPhong
                     join gp in db.GiaPhong on p.MaPhong equals gp.MaPhong
                     where gp.NgayKT == null && p.TrangThai==0
                     select new
                     {
                         p.MaPhong,
                         p.TenPhong,
                         p.MaLoai,
                         gp.Gia,
                         p.TrangThai,
                         gp.NgayKT,
                         c.Ban,
                         c.DenNgu,
                         c.DieuHoa,
                         c.Ghe,
                         c.Giuong,
                         c.PhongTam,
                         c.TiVi,
                         c.TuDo,
                         c.TuLanh
                     };
            if (kq != null) return kq.First();
            else return null;
        }
        [Route("Phongs/update-price/{ma}")]
        public int Postgiaphong(int ma,[FromBody] int gia)
        {
            var kq = db.capnhatgiaphong(ma, gia);
            db.SaveChanges();
            return kq;
        }
        // PUT: api/Phongs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhong(int id, Phong phong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phong.MaPhong)
            {
                return BadRequest();
            }

            db.Entry(phong).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhongExists(id))
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

        // POST: api/Phongs
        [ResponseType(typeof(Phong))]
        public IHttpActionResult PostPhong(Phong phong)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Phong.Add(phong);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = phong.MaPhong }, phong);
        }

        // DELETE: api/Phongs/5
        [ResponseType(typeof(Phong))]
        public IHttpActionResult DeletePhong(int id)
        {
            Phong phong = db.Phong.Find(id);
            if (phong == null)
            {
                return NotFound();
            }

            db.Phong.Remove(phong);
            db.SaveChanges();

            return Ok(phong);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhongExists(int id)
        {
            return db.Phong.Count(e => e.MaPhong == id) > 0;
        }
    }
}