using SehirRehberi.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Dtos
{
    public class GetOgrenciDto
    {
        public int IdE { get; set; }
        public int OgrenciIdE { get; set; }

        public string KISITIPI { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string tckimlik { get; set; }

        public string IlgiAlanlari { get; set; }
        public int Sirano { get; set; }

        //public List<TelefonlariDTO> tumtelefonlari { get; set; }
        //public List<AdresleriDTO> tumadresleri { get; set; }
        public List<KisiTelefonlar> tumtelefonlari { get; set; }
        public List<KisiAdresler> tumadresleri { get; set; }

        public string telefon1 { get; set; }
        public string adres1 { get; set; }

        public List<Kisiler_Dersler> tumdersleri { get; set; }
        public List<Kisiler_Icerikler> tumicerikleri { get; set; }
        public List<Kisiler_Takvimler> tumtakvimleri { get; set; }
    }
}
