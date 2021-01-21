using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPIWPFGIT.Models;
using PCLRacunari;

namespace WEBAPIWPFGIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorijaController : ControllerBase
    {
        private readonly RacunarskaOpremaContext db;

        public KategorijaController(RacunarskaOpremaContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public  IEnumerable<Kategorija> VratiKategorije()
        {
            return  db.Kategorije;
        }

        [HttpGet]
        [Route("{id}")]
        public Kategorija VratiKategoriju(int id)
        {
            Kategorija k1 = db.Kategorije.Find(id);

            if (k1 != null)
            {
                return k1;
            }
            else
            {
                return new Kategorija();
            }
        }


        [HttpPost]
        public async  Task<int> UbaciKategoriju(Kategorija k)
        {
            try
            {
                db.Kategorije.Add(k);
                await db.SaveChangesAsync();
                return k.KategorijaId;
            }
            catch (Exception)
            {
                db.Entry(k).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                return -1;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<int> ObrisiKategoriju(int id)
        {
            try
            {
                Kategorija kategorija = db.Kategorije.Find(id);
                db.Kategorije.Remove(kategorija);
                await db.SaveChangesAsync();
                return 0;
            }
            catch (Exception)
            {

                return -1;
            }

        }

        [HttpPost]
        [Route("{id}")]
        public async Task<int> PromjeniKategoriju(Kategorija k)
        {
            try
            {
                db.Entry(k).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
                return 0;
            }
            catch (Exception)
            {

                db.Entry(k).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                return -1;
            }
        }

    }
}
