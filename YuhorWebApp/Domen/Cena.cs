

namespace Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public  class Cena
    {
    
        public DateTime datumOd { get; set; }
        public double iznos { get; set; }
        public Status Status { get; set; }
        public int artikalID { get; set; }
        public virtual Artikal Artikal  { get; set; }
    }
}
