using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public interface IAuthRepositoryAsync
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

		SaveAllreturn SaveAll();

		Task<Kisiler> KisiRegisterAsync(Kisiler user, string password);
        Task<Kisiler> KisiLoginAsync(string Email, string password);
        Task<bool> IsKisiUsernameExistsAsync(string userName);
		Task<bool> IsKisiEmailExistsAsync(string Email);
		Task<bool> IsAnyloginAsync(int id);
		Task<DateTime> GetLastloginAsync(int id);
        Task<Kisiler> GetKisilerByUsernameAsync(string username);
        Task<LoginTracker> AddToLoginTrackerAsync(LoginTracker lT);
		Task<int> UpdateToKisiAsync(Kisiler user); // test et olmuştur
		Task<bool> KisiOgretmenlerIsExistAsync(int IdE);
        Task<bool> KisiOgrencilerIsExistAsync(int IdE);
        Task<bool> KisiAdminlerIsExistAsync(int IdE);
        Task<KisiOgretmenler> AddToKisiOgretmenlerAsync(KisiOgretmenler user);
        Task<KisiOgrenciler> AddToKisiOgrencilerAsync(KisiOgrenciler user);
        Task<KisiAdminler> AddToKisiAdminlerAsync(KisiAdminler user);

		Task<List<Kisiler>> KisilerListAsync();
		Task<Kisiler> GetKisilerByIdAsync(int Id);

	}
}
