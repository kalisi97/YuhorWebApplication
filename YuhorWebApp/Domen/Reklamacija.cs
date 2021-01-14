
using System;
using System.ComponentModel;

namespace Entities
{
 

    public  class Reklamacija
    {
       
        public Reklamacija()
        {
            this.StavkeReklamacije = new BindingList<StavkaReklamacije>();
        }
    
        public int brojReklamacije { get; set; }
        public DateTime datum { get; set; }
        public string razlog { get; set; }
        public string naziv { get; set; }
        public Nullable<double> ukupno { get; set; }
        public int kupacID { get; set; }
        public virtual Kupac Kupac { get; set; }

        public Status Status { get; set; }

        public virtual BindingList<StavkaReklamacije> StavkeReklamacije { get; set; }
    }
}
