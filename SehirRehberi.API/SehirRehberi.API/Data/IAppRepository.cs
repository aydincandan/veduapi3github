using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public interface IAppRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
		SaveAllreturn SaveAll();

		List<Kisiler> GetKisiler();
		Kisiler GetKisilerById(int Id);

		List<KisiOgrenciler> GetOgrenciler();
        KisiOgrenciler GetOgrencilerById(int Id);

        List<KisiOgretmenler> GetOgretmenler();
        KisiOgretmenler GetOgretmenlerById(int Id);

        List<KisiAdminler> GetAdminler();
        KisiAdminler GetAdminlerById(int Id);

        List<Dersler> GetDersler();
        Dersler GetDerslerById(int Id);

        //List<DersDetaylar> GetDersDetaylar();
        //DersDetaylar GetDersDetaylarById(int Id);

        List<Takvimler> GetTakvimler();
        Takvimler GetTakvimlerById(int Id);

        List<Icerikler> GetIcerikler();
        Icerikler GetIceriklerById(int Id);
    }
}
