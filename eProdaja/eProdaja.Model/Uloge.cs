using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Model
{
    public partial class Uloge
    {
        public int UlogaId { get; set; }

        public string Naziv { get; set; } = null!;

        public string? Opis { get; set; }
    }
}
