using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{


    public class Artikal
    {
        public Artikal()
        {
            this.ListaCena = new BindingList<Cena>();
        }
    
        public int artikalID { get; set; }
        public string naziv { get; set; }

        public Nullable<double> aktuelnaCena { get; set; }
        public double pdv { get; set; }
        public double rabat { get; set; }
        public virtual BindingList<Cena> ListaCena { get; set; }

        public Status Status { get; set; }

        public string ArtikalProcenti { get; set; }
        public override string ToString() => naziv;
    }
}
