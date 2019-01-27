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
			SaveAllreturn donus = new SaveAllreturn();
			try
			{
				donus.affected = _context.SaveChanges();
				donus.OK = donus.affected > 0;
			}
			catch (Exception e)
			{
				donus.OK = false;
				var hata1 = e.Message;
				donus.ERR = e.InnerException != null ? hata1 + " (=>) " + e.InnerException.Message : hata1;
			}
			return donus;
		}

		#region yeni
		public Kisiler KisiRegister(Kisiler user, string password)
		{
			byte[] passwordHash, passwordSalt;
			_ControllersHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

			user.PasswordHash = passwordHash;
			user.PasswordSalt = passwordSalt;

			 _context.Kisiler.Add(user);
			 _context.SaveChanges();

			return user;
		}

		public Kisiler KisiLogin(string Email, string password)
		{
			var user =  _context.Kisiler.FirstOrDefault(x => x.Email == Email);
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

		public bool IsKisiUsernameExists(string userName)
		{
			if ( _context.Kisiler.Any(x => x.Username == userName && userName != null)) return true;
			return false;
		}
		public bool IsKisiEmailExists(string Email)
		{
			if ( _context.Kisiler.Any(x => x.Email == Email)) return true;
			return false;
		}
		public bool IsAnylogin(int id)
		{
			if ( _context.LoginTracker.Any(x => x.KisiIdE == id)) return true;
			return false;
		}

		#region https://www.bayramucuncu.com/async-ile-asenkron-programlama/
		public DateTime GetLastlogin(int id)
		{
			DateTime sonuc = _context.LoginTracker.Where(k => k.KisiIdE == id).OrderByDescending(y => y.LoginDate).FirstOrDefault().LoginDate;
			return  sonuc;
		}
		#endregion



		public Kisiler GetKisilerByUsername(string username) { return  _context.Kisiler.FirstOrDefault(c => c.Username == username); }


		/// ////////////////////////////////////////////////////////////////////////////
		public LoginTracker AddToLoginTracker(LoginTracker obj)
		{
			 _context.LoginTracker.Add(obj);
			 _context.SaveChanges();
			return obj;
		}

		public bool KisiOgretmenlerIsExist(int IdE)
		{
			if ( _context.KisiOgretmenler.Any(x => x.OgretmenIdE == IdE)) { return true; }
			return false;
		}
		public bool KisiOgrencilerIsExist(int IdE)
		{
			if ( _context.KisiOgrenciler.Any(x => x.OgrenciIdE == IdE)) { return true; }
			return false;
		}
		public bool KisiAdminlerIsExist(int IdE)
		{
			if ( _context.KisiAdminler.Any(x => x.AdminIdE == IdE)) { return true; }
			return false;
		}

		public KisiOgretmenler AddToKisiOgretmenler(KisiOgretmenler user)
		{
			 _context.KisiOgretmenler.Add(user);
			 _context.SaveChanges();
			return user;
		}
		public KisiOgrenciler AddToKisiOgrenciler(KisiOgrenciler user)
		{
			 _context.KisiOgrenciler.Add(user);
			 _context.SaveChanges();
			return user;
		}
		public KisiAdminler AddToKisiAdminler(KisiAdminler user)
		{
			 _context.KisiAdminler.Add(user);
			 _context.SaveChanges();
			return user;
		}

		public Kisiler GetKisilerById(int Id)
		{
			Kisiler sonuc = (
				_context.Kisiler
										.Include(c => c.Telefonlari)
										.Include(c => c.Adresleri)
										.FirstOrDefault(c => c.IdE == Id)
			);
			return  sonuc;
		}

		public int UpdateToKisi(Kisiler user)
		{
			_context.Kisiler.Update(user);

			int sonuc = _context.SaveChanges();
			return  sonuc;
		}

		public List<Kisiler> KisilerList()
		{
			List<Kisiler> sonuc = _context.Kisiler
				.Include(c => c.Telefonlari)
				.Include(c => c.Adresleri)
				.Include(c => c.Dersleri)
				.Include(c => c.Icerikleri)
				.Include(c => c.Takvimleri)
				.ToList();

			return  sonuc;
		}

		#endregion
	}
}
