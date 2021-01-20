using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCLRacunari
{
    [Table("Kategorija")]
    public class Kategorija
    {
        [Required]
        public int KategorijaId { get; set; }
        [Required(ErrorMessage = "Morate unijeti naziv kategorije!")]
        [StringLength(30, ErrorMessage = "Broj karaktera mora biti izmedju 3 i 30!", MinimumLength = 3)]
        public string NazivKategorije { get; set; }

        [StringLength(100, ErrorMessage = "Broj karaktera mora biti do 100!")]
        public string OpisKategorije { get; set; }

        public override string ToString()
        {
            return NazivKategorije;
        }
    }
}
