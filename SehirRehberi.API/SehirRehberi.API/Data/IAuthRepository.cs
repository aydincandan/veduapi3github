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

		Task<Kisiler> KisiRegister(Kisiler user, string password);
        Task<Kisiler> KisiLogin(string Email, string password);
        Task<bool> IsKisiUsernameExists(string userName);
		Task<bool> IsKisiEmailExists(string Email);
		Task<bool> IsAnylogin(int id);
		Task<DateTime> GetLastlogin(int id);
		List<Kisiler> KisilerList();
        Kisiler GetKisilerById(int Id);
        Task<Kisiler> GetKisilerByUsername(string username);

        /// ////////////////////////////////////////////////////////////////////////////
        Task<LoginTracker> AddToLoginTracker(LoginTracker lT);
		Kisiler UpdateToKisi(Kisiler user); // update async olmuyor galiba
		Task<int> UpdateToKisiTaskAsync(Kisiler user); // test et olmuştur
		Task<bool> KisiOgretmenlerIsExist(int IdE);
        Task<bool> KisiOgrencilerIsExist(int IdE);
        Task<bool> KisiAdminlerIsExist(int IdE);
        Task<KisiOgretmenler> AddToKisiOgretmenler(KisiOgretmenler user);
        Task<KisiOgrenciler> AddToKisiOgrenciler(KisiOgrenciler user);
        Task<KisiAdminler> AddToKisiAdminler(KisiAdminler user);
    }
}
