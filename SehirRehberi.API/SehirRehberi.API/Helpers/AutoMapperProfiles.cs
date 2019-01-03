using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SehirRehberi.API.Dtos;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<City, CityForListDto>().ForMember(dest => dest.PhotoUrl, opt => { opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url); });
            //CreateMap<City, CityForDetailDto>();
            //CreateMap<PhotoForCreationDto, Photo>();
            //CreateMap<PhotoForReturnDto, Photo>();

            CreateMap<KisiOgretmenler, GetOgretmenDto>()
                .ForMember(dest => dest.KISITIPI, opt => { opt.MapFrom(src => src.Kisiler.KisiTipi); }) // 1:1
                .ForMember(dest => dest.Email,         opt => { opt.MapFrom(src => src.Kisiler.Email); }) // 1:1
                .ForMember(dest => dest.UserName, opt => { opt.MapFrom(src => src.Kisiler.Username); }) // 1:1
                .ForMember(dest => dest.adi, opt => { opt.MapFrom(src => src.Kisiler.Adi); }) // 1:1
                .ForMember(dest => dest.soyadi, opt => { opt.MapFrom(src => src.Kisiler.Soyadi); }) // 1:1
                .ForMember(dest => dest.tckimlik, opt => { opt.MapFrom(src => src.Kisiler.TCkimlik); }) // 1:1

                .ForMember(dest => dest.IdE,           opt => { opt.MapFrom(src => src.Kisiler.IdE); }) // 1:1
                .ForMember(dest => dest.tumtelefonlari, opt => { opt.MapFrom(src => src.Kisiler.Telefonlari); }) // 1:N
                .ForMember(dest => dest.tumadresleri,   opt => { opt.MapFrom(src => src.Kisiler.Adresleri); }) // 1:N

                .ForMember(dest => dest.telefon1, opt => { opt.MapFrom(src => src.Kisiler.Telefonlari.LastOrDefault(p => p.newcurrent == true).Telefonu); })
                .ForMember(dest => dest.adres1, opt => { opt.MapFrom(src => src.Kisiler.Adresleri.LastOrDefault(p => p.newcurrent == true).AcikAdres); })

                .ForMember(dest => dest.tumdersleri, opt => { opt.MapFrom(src => src.Kisiler.Dersleri); })
                .ForMember(dest => dest.tumicerikleri, opt => { opt.MapFrom(src => src.Kisiler.Icerikleri); })
                .ForMember(dest => dest.tumtakvimleri, opt => { opt.MapFrom(src => src.Kisiler.Takvimleri); })
                ;
            CreateMap<KisiOgrenciler, GetOgrenciDto>()
                .ForMember(dest => dest.KISITIPI, opt => { opt.MapFrom(src => src.Kisiler.KisiTipi); }) // 1:1
                .ForMember(dest => dest.Email,         opt => { opt.MapFrom(src => src.Kisiler.Email); }) // 1:1
                .ForMember(dest => dest.UserName,      opt => { opt.MapFrom(src => src.Kisiler.Username); }) // 1:1
                .ForMember(dest => dest.adi, opt => { opt.MapFrom(src => src.Kisiler.Adi); }) // 1:1
                .ForMember(dest => dest.soyadi, opt => { opt.MapFrom(src => src.Kisiler.Soyadi); }) // 1:1
                .ForMember(dest => dest.tckimlik, opt => { opt.MapFrom(src => src.Kisiler.TCkimlik); }) // 1:1

                .ForMember(dest => dest.IdE,           opt => { opt.MapFrom(src => src.Kisiler.IdE); }) // 1:1
                .ForMember(dest => dest.tumtelefonlari, opt => { opt.MapFrom(src => src.Kisiler.Telefonlari); }) // 1:N
                .ForMember(dest => dest.tumadresleri,   opt => { opt.MapFrom(src => src.Kisiler.Adresleri); }) // 1:N

                .ForMember(dest => dest.telefon1, opt => { opt.MapFrom(src => src.Kisiler.Telefonlari.LastOrDefault(p => p.newcurrent == true).Telefonu); })
                .ForMember(dest => dest.adres1, opt => { opt.MapFrom(src => src.Kisiler.Adresleri.LastOrDefault(p => p.newcurrent == true).AcikAdres); })

                .ForMember(dest => dest.tumdersleri, opt => { opt.MapFrom(src => src.Kisiler.Dersleri); })
                .ForMember(dest => dest.tumicerikleri, opt => { opt.MapFrom(src => src.Kisiler.Icerikleri); })
                .ForMember(dest => dest.tumtakvimleri, opt => { opt.MapFrom(src => src.Kisiler.Takvimleri); })
                ;
            CreateMap<KisiAdminler, GetAdminDto>()
                .ForMember(dest => dest.KISITIPI, opt => { opt.MapFrom(src => src.Kisiler.KisiTipi); }) // 1:1
                .ForMember(dest => dest.Email,         opt => { opt.MapFrom(src => src.Kisiler.Email); }) // 1:1
                .ForMember(dest => dest.UserName,      opt => { opt.MapFrom(src => src.Kisiler.Username); }) // 1:1
                .ForMember(dest => dest.adi, opt => { opt.MapFrom(src => src.Kisiler.Adi); }) // 1:1
                .ForMember(dest => dest.soyadi, opt => { opt.MapFrom(src => src.Kisiler.Soyadi); }) // 1:1
                .ForMember(dest => dest.tckimlik, opt => { opt.MapFrom(src => src.Kisiler.TCkimlik); }) // 1:1

                .ForMember(dest => dest.IdE,           opt => { opt.MapFrom(src => src.Kisiler.IdE); }) // 1:1
                .ForMember(dest => dest.tumtelefonlari, opt => { opt.MapFrom(src => src.Kisiler.Telefonlari); }) // 1:N
                .ForMember(dest => dest.tumadresleri,   opt => { opt.MapFrom(src => src.Kisiler.Adresleri); }) // 1:N

                .ForMember(dest => dest.telefon1, opt => { opt.MapFrom(src => src.Kisiler.Telefonlari.LastOrDefault(p => p.newcurrent == true).Telefonu); })
                .ForMember(dest => dest.adres1, opt => { opt.MapFrom(src => src.Kisiler.Adresleri.LastOrDefault(p => p.newcurrent == true).AcikAdres); })
                ;
            CreateMap<Kisiler, GetKisiDto>() // login için
                .ForMember(dest => dest.KISITIPI, opt => { opt.MapFrom(src => src.KisiTipi); }) // 1:1
                .ForMember(dest => dest.Email, opt => { opt.MapFrom(src => src.Email); }) // 1:1
                .ForMember(dest => dest.UserName, opt => { opt.MapFrom(src => src.Username); }) // 1:1
                .ForMember(dest => dest.adi, opt => { opt.MapFrom(src => src.Adi); }) // 1:1
                .ForMember(dest => dest.soyadi, opt => { opt.MapFrom(src => src.Soyadi); }) // 1:1
                .ForMember(dest => dest.tckimlik, opt => { opt.MapFrom(src => src.TCkimlik); }) // 1:1

                .ForMember(dest => dest.IdE, opt => { opt.MapFrom(src => src.IdE); }) // 1:1
                .ForMember(dest => dest.tumtelefonlari, opt => { opt.MapFrom(src => src.Telefonlari); }) // 1:N
                .ForMember(dest => dest.tumadresleri, opt => { opt.MapFrom(src => src.Adresleri); }) // 1:N

                .ForMember(dest => dest.telefon1, opt => { opt.MapFrom(src => src.Telefonlari.LastOrDefault(p => p.newcurrent == true).Telefonu); })
                .ForMember(dest => dest.adres1, opt => { opt.MapFrom(src => src.Adresleri.LastOrDefault(p => p.newcurrent == true).AcikAdres); })
				.ForMember(dest => dest.IsAnylogin, opt => { opt.MapFrom(src => src.IsAnyLogin); })
				.ForMember(dest => dest.LastloginDate, opt => { opt.MapFrom(src => src.LastLoginDate); })
				;
		}
    }
}
