using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/*
PS C:\ops\veduapi3\veduapi3github\SehirRehberi.API\SehirRehberi.API> dotnet ef migrations add step0
PS C:\ops\veduapi3\veduapi3github\SehirRehberi.API\SehirRehberi.API> dotnet ef migrations remove  (istersek bi öncekini böyle geri alabiliyoruz.)

PS C:\ops\veduapi3\veduapi3github\SehirRehberi.API\SehirRehberi.API> dotnet ef database update
*/
//(xxyyzz) var olan veritabanından model oluşturmak için
// Package Manager Console dan: Scaffold-DbContext "data source=.\\SQLEXPRESS2014; initial catalog=veduDB07; Trusted_Connection=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models2
/* düzelt 
The EF Core tools version '2.1.1-rtm-30846' is older than that of the runtime '2.1.4-rtm-31024'. Update the tools for the latest features and bug fixes. 
uyguladım : Install-Package Microsoft.EntityFrameworkCore.Tools -Version 2.1.4   kaynak:https://stackoverflow.com/questions/52702182/how-to-upgrade-ef-core-tools
tekrar çalıştırdım : (xxyyzz) => sunuç: Instance failure.
	 */
// https://docs.microsoft.com/tr-tr/ef/core/managing-schemas/migrations/

namespace SehirRehberi.API.Models
{
    #region vedu data abstacts
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdE { get; set; }
    }

    // kişi yada kurumsal varlıklar için
    public abstract class AuditableEntity : BaseEntity
    {
        protected AuditableEntity()
        {
            this.IsActive = false;
            this.IsDeleted = false;
            this.IsEmailConfirmed = false;
        }
        public DateTime? RegisterDate { get; set; }
        [MaxLength(15)] public string RegisterDateIP { get; set; }
        public DateTime? ConfirmDate { get; set; }
        [MaxLength(15)] public string ConfirmDateIP { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsEmailConfirmed { get; set; }

        [Required] [MaxLength(64)] public string Email { get; set; }
        [MaxLength(32)] public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
    // kişi (özel)
    public abstract class PersonEntity : AuditableEntity
    {
        [MaxLength(32)] public string Adi { get; set; }
        [MaxLength(32)] public string Soyadi { get; set; }
        [MaxLength(11)] public string TCkimlik { get; set; }
    }
    // kurumsal (tüzel)
    public abstract class LegalEntity : AuditableEntity
    {
        [MaxLength(32)] public string Unvan { get; set; }
        [MaxLength(32)] public string SirketAdi { get; set; }
        [MaxLength(10)] public string VergiDairesi { get; set; }
        [MaxLength(10)] public string VergiNo { get; set; }
    }
	#endregion


	#region yeni
	public class Kisiler : PersonEntity
	{
		[Required]
		[MaxLength(3)] public string KisiTipi { get; set; }

		public KisiOgretmenler KisiOgretmenler { get; set; } // 1->1
		public KisiOgrenciler KisiOgrenciler { get; set; } // 1->1
		public KisiAdminler KisiAdminler { get; set; } // 1->1

		public List<KisiAdresler> Adresleri { get; set; } // 1->N
		public List<KisiTelefonlar> Telefonlari { get; set; } // 1->N

		public List<Kisiler_Icerikler> Icerikleri { get; set; } // **
		public List<Kisiler_Dersler> Dersleri { get; set; } // **
		public List<Kisiler_Takvimler> Takvimleri { get; set; } // **

		public List<LoginTracker> LoginTrackers { get; set; } // N->1

		public bool IsAnyLogin { get; set; }
		public DateTime LastLoginDate { get; set; }
    }
    public class KisiAdresler : BaseEntity
    {
        //public Kisiler Kisiler { get; set; } // 1->N // gerek olmayabilir(eğer ki kaldırısak MyAppDBdataContext den)
        [MaxLength(128)]       public string AcikAdres { get; set; }
        [MaxLength(20)]        public string Sehir { get; set; }
        [MaxLength(20)]        public string Ulke { get; set; }
        public bool newcurrent { get; set; }
    }
    public class KisiTelefonlar: BaseEntity
    {
        //public Kisiler Kisiler { get; set; } // 1->N // gerek olmayabilir(eğer ki kaldırısak MyAppDBdataContext den)
        [MaxLength(10)]        public string Telefonu { get; set; }
        [MaxLength(2)]         public string UlkeKodu { get; set; }
        public bool newcurrent { get; set; }
		public bool confirmed { get; set; }
	}

	public class KisiOgretmenler
    {
        [Key] public int OgretmenIdE { get; set; }
        public Kisiler Kisiler { get; set; } // 1->1 // automapper için gerekli
        [MaxLength(80)] public string UzmanlikAlanlari { get; set; }
    }
    public class KisiOgrenciler
    {
        [Key] public int OgrenciIdE { get; set; }
        public Kisiler Kisiler { get; set; } // 1->1 // automapper için gerekli
        [MaxLength(80)] public string IlgiAlanlari { get; set; }
    }
    public class KisiAdminler
    {
        [Key] public int AdminIdE { get; set; }
        public Kisiler Kisiler { get; set; } // 1->1 // automapper için gerekli
        public int? YetkiSeviye { get; set; }
    }

    public class Kisiler_Icerikler : BaseEntity
    {
        //public Kisiler Kisiler { get; set; } // gerek olmayabilir
        //public Icerikler Icerikler { get; set; } // gerek olmayabilir
        public int KisilerIdE { get; set; }
        public int IceriklerIdE { get; set; }
    }
    public class Kisiler_Dersler : BaseEntity
    {
        //public Kisiler Kisiler { get; set; } // gerek olmayabilir
        //public Dersler Dersler { get; set; } // gerek olmayabilir
        public int KisilerIdE { get; set; }
        public int DerslerIdE { get; set; }
    }
    public class Kisiler_Takvimler : BaseEntity
    {
        //public Kisiler Kisiler { get; set; } // gerek olmayabilir
        //public Takvimler Takvimler { get; set; } // gerek olmayabilir
        public int KisilerIdE { get; set; }
        public int TakvimlerIdE { get; set; }
    }

    public class Icerikler : BaseEntity
    {
        public List<Kisiler_Icerikler> KisininIcerikleri { get; set; } // N:N

        [MaxLength(32)]
        public string BelgeAdi { get; set; }

        [MaxLength(128)]
        public string BelgeLink { get; set; }

        [MaxLength(256)]
        public string BelgeAciklama { get; set; }

        public int DerslerIdE { get; set; }
        public int? Sirano { get; set; }
    }

    public class Takvimler : BaseEntity
    {
        public List<Kisiler_Takvimler> KisininTakvimleri { get; set; } // N:N

        public int DerslerIdE { get; set; }
        public int DersDetaylarIdE { get; set; }

        public DateTime KursZamani { get; set; }

        [MaxLength(256)]
        public string KursAciklama { get; set; }

        public int? Sirano { get; set; }
    }

    public class Dersler : BaseEntity
    {
        public List<Kisiler_Dersler> KisininDersleri { get; set; } // N:N

        [MaxLength(64)] public string Title { get; set; }
        public int? Sirano { get; set; }
        public List<DersDetaylar> DersDetaylar { get; set; } // 1:N
    }
    public class DersDetaylar : BaseEntity
    {
		//public Dersler Dersler { get; set; } // gerek olmayabilir(eğer ki kaldırısak MyAppDBdataContext den)
		[MaxLength(255)]
        public string TitleAciklama { get; set; }
        public int? Sirano { get; set; }
    }


    public class LoginTracker : BaseEntity
    {
        //public Kisiler Kisiler { get; set; } // gerek olmayabilir
        public LoginTracker()
        {
            this.LoginDate = DateTime.Now;
        }
        public int KisiIdE { get; set; }
        public DateTime LoginDate { get; set; }
        [MaxLength(15)] public string LoginDateIP { get; set; }
    }
    public class TestTuzel1 : LegalEntity
    {
        public string testtuzel1value { get; set; }
    }
    public class TestTuzel2 : LegalEntity
    {
        public string testtuzel2value { get; set; }
    }

    #endregion

}
