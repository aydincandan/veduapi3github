
namespace SehirRehberi.API.Dtos
{
    public class TelefonlariDTO
    {
        //public int ide { get; set; }
        public bool newcurrent { get; set; }
        public string telefonu { get; set; }
        public string ulkekodu { get; set; }
    }

    public class AdresleriDTO
    {
        //public int ide { get; set; }
        public string acikadres { get; set; }
        public string sehir { get; set; }
        public string ulke { get; set; }
        public bool newcurrent { get; set; }
    }
}
