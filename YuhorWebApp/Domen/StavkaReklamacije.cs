

namespace Entities
{    
    public class StavkaReklamacije
    {
        public int brojReklamacije { get; set; }
        public int rb { get; set; }
        public int kolicina { get; set; }
        public string razlog { get; set; }

        public Status Status { get; set; }

        public int artikalID { get; set; }
        public virtual Reklamacija Reklamacija { get; set; }
        public virtual Artikal Artikal { get; set; }
    }
}
