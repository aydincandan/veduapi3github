using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Dtos
{
    public class SetadminUpdateDto
    {
        public int IdE { get; set; }
        public int YetkiSeviye { get; set; }
        public string Username { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string TCkimlik { get; set; }
        public string telefon1 { get; set; }
    }
}
