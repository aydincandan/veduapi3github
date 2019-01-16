using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public class AppRepository : IAppRepository
    {
        private MyAppDatabaseContext _context;

        public AppRepository(MyAppDatabaseContext context) { _context = context; }

        public void Add<T>(T entity) where T : class { _context.Add(entity); }
        public void Delete<T>(T entity) where T : class { _context.Remove(entity); }
        public void Update<T>(T entity) where T : class { _context.Update(entity); }
        public SaveAllreturn SaveAll() {
			SaveAllreturn don = new SaveAllreturn();
			try
			{
				don.affected = _context.SaveChanges();
				don.OK = don.affected > 0;
			}
			catch(Exception e)
			{
				don.OK = false;
				var hata1 = e.Message;
				don.ERR = e.InnerException != null ? hata1 + " (=>) " + e.InnerException.Message : hata1;
			}
			return don;
		}

		#region yeni

		public List<Kisiler> GetKisiler() {			return _context.Kisiler
			  .Include(c => c.Telefonlari)
			  .Include(c => c.Adresleri)
			  .Include(c => c.Dersleri)
			  .Include(c => c.Icerikleri)
			  .Include(c => c.Takvimleri)
			  .ToList();
		}

		public Kisiler GetKisilerById(int Id) {			return _context.Kisiler
				  .Include(c => c.Telefonlari)
				  .Include(c => c.Adresleri)
				  .FirstOrDefault(c => c.IdE == Id);
		}

		public List<KisiOgrenciler> GetOgrenciler() {     return _context.KisiOgrenciler
                .Include(c => c.Kisiler.Telefonlari)
                .Include(c => c.Kisiler.Adresleri)
                .Include(c => c.Kisiler.Dersleri)
                .Include(c => c.Kisiler.Icerikleri)
                .Include(c => c.Kisiler.Takvimleri)
                .ToList(); }
        public KisiOgrenciler GetOgrencilerById(int Id) { return _context.KisiOgrenciler
                .Include(c => c.Kisiler.Telefonlari)
                .Include(c => c.Kisiler.Adresleri)
                .FirstOrDefault(c => c.OgrenciIdE == Id); }

        public List<KisiOgretmenler> GetOgretmenler() { return _context.KisiOgretmenler
                .Include(c => c.Kisiler.Telefonlari)
                .Include(c => c.Kisiler.Adresleri)
                .Include(c => c.Kisiler.Dersleri)
                .Include(c => c.Kisiler.Icerikleri)
                .Include(c => c.Kisiler.Takvimleri)
                .ToList(); }
        public KisiOgretmenler GetOgretmenlerById(int Id) { return _context.KisiOgretmenler
                .Include(c => c.Kisiler.Telefonlari)
                .Include(c => c.Kisiler.Adresleri)
                .FirstOrDefault(c => c.OgretmenIdE == Id); }

        public List<KisiAdminler> GetAdminler() { return _context.KisiAdminler
                .Include(c => c.Kisiler.Telefonlari)
                .Include(c => c.Kisiler.Adresleri)
                .ToList(); }
        public KisiAdminler GetAdminlerById(int Id) { return _context.KisiAdminler
                .Include(c => c.Kisiler.Telefonlari)
                .Include(c => c.Kisiler.Adresleri)
                .FirstOrDefault(c => c.AdminIdE == Id); }

        public List<Dersler> GetDersler() { return _context.Dersler
                .Include(c => c.DersDetaylar)
                .ToList(); }
        public Dersler GetDerslerById(int Id) { return _context.Dersler
                .Include(c => c.DersDetaylar)
                .FirstOrDefault(c => c.IdE == Id); }

        public List<Takvimler> GetTakvimler() { return _context.Takvimler.OrderBy(c => c.Sirano).ToList(); }
        public Takvimler GetTakvimlerById(int Id) { return _context.Takvimler.FirstOrDefault(c => c.IdE == Id); }

        public List<Icerikler> GetIcerikler() { return _context.Icerikler.OrderBy(c => c.Sirano).ToList(); }
        public Icerikler GetIceriklerById(int Id) { return _context.Icerikler.FirstOrDefault(c => c.IdE == Id); }
		#endregion

	}
}

