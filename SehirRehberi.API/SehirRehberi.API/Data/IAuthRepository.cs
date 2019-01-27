using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public interface IAuthRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

		SaveAllreturn SaveAll();

		Kisiler KisiRegister(Kisiler user, string password);
        Kisiler KisiLogin(string Email, string password);
        bool IsKisiUsernameExists(string userName);
		bool IsKisiEmailExists(string Email);
		bool IsAnylogin(int id);
		DateTime GetLastlogin(int id);
        Kisiler GetKisilerByUsername(string username);
        LoginTracker AddToLoginTracker(LoginTracker lT);
		int UpdateToKisi(Kisiler user); // test et olmuştur
		bool KisiOgretmenlerIsExist(int IdE);
        bool KisiOgrencilerIsExist(int IdE);
        bool KisiAdminlerIsExist(int IdE);
        KisiOgretmenler AddToKisiOgretmenler(KisiOgretmenler user);
        KisiOgrenciler AddToKisiOgrenciler(KisiOgrenciler user);
        KisiAdminler AddToKisiAdminler(KisiAdminler user);

		List<Kisiler> KisilerList();
		Kisiler GetKisilerById(int Id);

	}
}
