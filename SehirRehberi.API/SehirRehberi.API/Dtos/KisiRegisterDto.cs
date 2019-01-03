using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Dtos
{
    public class KisiRegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string KisiTipi { get; set; }
        public string Email { get; set; }
    }
}
