using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SehirRehberi.API.Controllers;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private MyAppDatabaseContext _context;

        public AuthRepository(MyAppDatabaseContext context) { _context = context; }

        public void Add<T>(T entity) where T : class { _context.Add(entity); }
        public void Delete<T>(T entity) where T : class { _context.Remove(entity); }
        public void Update<T>(T entity) where T : class { _context.Update(entity); }
		public SaveAllreturn SaveAll()
		{
			SaveAllreturn don = new SaveAllreturn();
			try
			{
				don.affected = _context.SaveChanges();
				don.OK = don.affected > 0;
			}
			catch (Exception e)
			{
				don.OK = false;
				var hata1 = e.Message;
				var hata2 = e.InnerException.Message;
				don.ERR = hata2;
			}
			return don;
		}

		#region yeni
		public async Task<Kisiler> KisiRegister(Kisiler user, string password)
        {
            byte[] passwordHash, passwordSalt;
            _ControllersHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Kisiler.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<Kisiler> KisiLogin(string Email, string password)
        {
            var user = await _context.Kisiler.FirstOrDefaultAsync(x => x.Email == Email);
            if (user == null)
            {
                return null;
            }

            if (!_ControllersHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        public async Task<bool> IsKisiUsernameExists(string userName) {
            if (await _context.Kisiler.AnyAsync(x => x.Username == userName && userName != null)) return true;
			return false;
        }
        public async Task<bool> IsKisiEmailExists(string Email) {
            if (await _context.Kisiler.AnyAsync(x => x.Email == Email)) return true;
			return false;
        }
		public async Task<bool> IsAnylogin(int id) {
			if (await _context.LoginTracker.AnyAsync(x => x.KisiIdE == id)) return true;
			return false;
		}

		#region https://www.bayramucuncu.com/asyncawait-ile-asenkron-programlama/
		public async Task<DateTime> GetLastlogin(int id) {
			Task<DateTime> sonuc = Task.Run(() => _context.LoginTracker.Where(k => k.KisiIdE == id).OrderByDescending(y => y.LoginDate).FirstOrDefaultAsync().Result.LoginDate); // public Task<DateTime> GetLastloginTaskAsync(int id)
			return await sonuc;
		}
		#endregion

		public List<Kisiler> KisilerList()
        {
            return _context.Kisiler
              .Include(c => c.Telefonlari)
              .Include(c => c.Adresleri)
              .Include(c => c.Dersleri)
              .Include(c => c.Icerikleri)
              .Include(c => c.Takvimleri)
              .ToList();
        }

        public Kisiler GetKisilerById(int Id) { return _context.Kisiler.Include(c => c.Telefonlari).Include(c => c.Adresleri).FirstOrDefault(c => c.IdE == Id); }
        public async Task<Kisiler> GetKisilerByUsername(string username) { return await _context.Kisiler.FirstOrDefaultAsync(c => c.Username == username); }


        /// ////////////////////////////////////////////////////////////////////////////
        public async Task<LoginTracker> AddToLoginTracker(LoginTracker obj)
        {           
            await _context.LoginTracker.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        // async olamadı
        public Kisiler UpdateToKisi(Kisiler user)
        {
            _context.Kisiler.Update(user);
            _context.SaveChanges();
            return user;
        }
		public async Task<int> UpdateToKisiTaskAsync(Kisiler user)
		{
			_context.Kisiler.Update(user);

			Task<int> sonuc = Task.Run(() => _context.SaveChanges());
			return await sonuc;
		}

		public async Task<bool> KisiOgretmenlerIsExist(int IdE)
        {
            if (await _context.KisiOgretmenler.AnyAsync(x => x.OgretmenIdE == IdE)) { return true; }
            return false;
        }
        public async Task<bool> KisiOgrencilerIsExist(int IdE)
        {
            if (await _context.KisiOgrenciler.AnyAsync(x => x.OgrenciIdE == IdE)) { return true; }
            return false;
        }
        public async Task<bool> KisiAdminlerIsExist(int IdE)
        {
            if (await _context.KisiAdminler.AnyAsync(x => x.AdminIdE == IdE)) { return true; }
            return false;
        }

        public async Task<KisiOgretmenler> AddToKisiOgretmenler(KisiOgretmenler user)
        {
            await _context.KisiOgretmenler.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<KisiOgrenciler> AddToKisiOgrenciler(KisiOgrenciler user)
        {
            await _context.KisiOgrenciler.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<KisiAdminler> AddToKisiAdminler(KisiAdminler user)
        {
            await _context.KisiAdminler.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
		#endregion
	}
}
