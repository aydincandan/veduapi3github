using SehirRehberi.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Dtos
{
    public class GetDersDto
    {
        //public int IdE { get; set; }
        //public string Title { get; set; }
        public int? Sirano { get; set; }
        public List<DersDetaylar> DersDetaylar { get; set; }
    }
}
