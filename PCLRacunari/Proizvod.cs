using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PCLRacunari
{
    
    [Table("Proizvod")]
    public class Proizvod
    {
        [Required]
        public int ProizvodId { get; set; }
        [ForeignKey("Kategorija")]
        public virtual int KategorijaId { get; set; }
        [Required(ErrorMessage ="Morate unijeti naziv proizvoda!")]
        [StringLength(30,ErrorMessage ="Naziv proizvoda mora biti izmedju 3 i 30 karaktera!",MinimumLength =3)]
        public string NazivProizvoda { get; set; }
        [Required(ErrorMessage ="Morate unijeti cijenu proizvoda!")]
        [DisplayFormat(DataFormatString ="{0:c}")]
        public decimal CijenaProizvoda { get; set; }
        
        
        public int KolicinaNaLagerju { get; set; }

        public virtual Kategorija Kategorija { get; set; }

        
    }
}
