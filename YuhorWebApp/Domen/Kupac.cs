

namespace Entities
{    
    public  class Kupac
    {    
        public int kupacID { get; set; }
        public string naziv { get; set; }
        public string pib { get; set; }
        public string mb { get; set; }
        public string tr { get; set; }

        public Status Status { get; set; }

        public override string ToString() => naziv;
    }
}
