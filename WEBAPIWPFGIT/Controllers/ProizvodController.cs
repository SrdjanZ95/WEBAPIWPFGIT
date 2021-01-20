using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCLRacunari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPIWPFGIT.Models;

namespace WEBAPIWPFGIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
        private readonly RacunarskaOpremaContext db;

        public ProizvodController(RacunarskaOpremaContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IEnumerable<Proizvod> VratiProizvode()
        {
            return db.Proizvodi;
        }

        [HttpGet]
        [Route("kategorija/{id}")]
        public IEnumerable<Proizvod> VratiProizvode(int id = 0)
        {
            IEnumerable<Proizvod> listaProizvoda = db.Proizvodi;

            if (id!=0)
            {
                Kategorija k1 = db.Kategorije.Find(id);

                if (k1 == null)
                {
                    return null;

                }
                else
                {
                    listaProizvoda = listaProizvoda
                        .Where(p=>p.KategorijaId == id); 
                }
            }
            return listaProizvoda;
        }
    }
}
