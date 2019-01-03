using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SehirRehberi.API.Models;

namespace SehirRehberi.API.Data
{
    public static class MyAppDatabaseContextExtensions
    {
        /* reset
         
use veduDB04

delete TblKisiler
delete TblDersDetaylar
delete TblDersler
delete TblIcerikler             
             
             */
        public static void EnsureDatabaseSeeded(this MyAppDatabaseContext context)
        {
            /////////////////////////////////////////////////////////////
            //if (!context.Values.Any())
            //{
            //    context.AddRange(new Value[] {

            //        new Value (){ Name="değer 1"},
            //        new Value (){ Name="değer 2"},
            //        new Value (){ Name="değer 3"},

            //    });
            //    context.SaveChanges();
            //}
            /////////////////////////////////////////////////////////////
            //if (!context.TblKisitipler.Any())
            //{
            //    context.AddRange(new ClsKisiTip[] {

            //        new ClsKisiTip(){Acikla="Tea,cher", KtKod="TEA"},
            //        new ClsKisiTip(){Acikla="Stu,dent", KtKod="STU"},
            //        new ClsKisiTip(){Acikla="Adm,inis", KtKod="ADM"},

            //    });
            //    context.SaveChanges();
            //}
            /////////////////////////////////////////////////////////////
            //if (!context.TblKisiler.Any())
            //{
            //    context.AddRange(new ClsKisi[] {

            //        new ClsKisi (){ KtKod="TEA", YetkiSeviyesi=-1, Email="ogretmen2@candan.org", Adi="mehmet", Soyadi="Candan", _passWord="12345", Telefon="5324912167", Username="dede" },
            //        new ClsKisi (){ KtKod="TEA", YetkiSeviyesi=-1, Email="ogretmen3@candan.org", Adi="neşe", Soyadi="Candan", _passWord="12345", Telefon="5324912163", Username="babaanne" },
            //        new ClsKisi (){ KtKod="TEA", YetkiSeviyesi=-1, Email="ogretmen4@candan.org", Adi="derya", Soyadi="korkmaz", _passWord="12345", Telefon="5324912168", Username="teyze" },
            //        new ClsKisi (){ KtKod="TEA", YetkiSeviyesi=-1, Email="ogretmen5@candan.org", Adi="tarık", Soyadi="korkmaz", _passWord="12345", Telefon="5324912164", Username="kanka" },
            //        new ClsKisi (){ KtKod="TEA", YetkiSeviyesi=-1, Email="ogretmen1@candan.org", Adi="aylin", Soyadi="Candan", _passWord="12345", Telefon="5324912166", Username="hala" },

            //        new ClsKisi (){ KtKod="STU", YetkiSeviyesi=-1, Email="aydin6@candan.org", Adi="Aydın", Soyadi="Candan", _passWord="12345", Telefon="5324912165", Username="calypso" },
            //        new ClsKisi (){ KtKod="STU", YetkiSeviyesi=-1, Email="dicle8@candan.org", Adi="dicle", Soyadi="Candan", _passWord="12345", Telefon="5324912161", Username="daykil" },
            //        new ClsKisi (){ KtKod="STU", YetkiSeviyesi=-1, Email="efe7@candan.org", Adi="EFE", Soyadi="Candan", _passWord="12345", Telefon="5324912162", Username="xxlargepro" },

            //    });
            //    context.SaveChanges();
            //}
            /////////////////////////////////////////////////////////////
            //if (!context.TblDersler.Any())
            //{
            //    context.AddRange(new ClsDers[] {

            //        new ClsDers (){ Title="Fizik" },
            //        new ClsDers (){ Title="Matematik" },
            //        new ClsDers (){ Title="Biyoloji" },
            //        new ClsDers (){ Title="Bilgisayar" },
            //        new ClsDers (){ Title="Felsefe" },
            //        new ClsDers (){ Title="Kimya" },
            //        new ClsDers (){ Title="İngilizce" },
            //        new ClsDers (){ Title="Tarih" },

            //    });
            //    context.SaveChanges();
            //}
            /////////////////////////////////////////////////////////////
            //if (!context.TblDersDetaylar.Any())
            //{
            //    context.AddRange(new ClsDersDetay[] {

            //        new ClsDersDetay (){ Aciklama="fizik 1", Sirano=1, Ders=new ClsDers(){ ID=1 }  },
            //        new ClsDersDetay (){ Aciklama="fizik 2", Sirano=2, Ders=new ClsDers(){ ID=1 }  },
            //        new ClsDersDetay (){ Aciklama="fizik 3", Sirano=3, Ders=new ClsDers(){ ID=1 }  },
            //        new ClsDersDetay (){ Aciklama="fizik 4", Sirano=4, Ders=new ClsDers(){ ID=1 }  },
            //        new ClsDersDetay (){ Aciklama="KİMYA 1", Sirano=1, Ders=new ClsDers(){ ID=6 }  },
            //        new ClsDersDetay (){ Aciklama="KİMYA 2", Sirano=2, Ders=new ClsDers(){ ID=6 }  },
            //        new ClsDersDetay (){ Aciklama="MAT 3", Sirano=3, Ders=new ClsDers(){ ID=2 }  },
            //        new ClsDersDetay (){ Aciklama="matematik 2", Sirano=2, Ders=new ClsDers(){ ID=2 }  },
            //        new ClsDersDetay (){ Aciklama="MATAMATIK 1", Sirano=1, Ders=new ClsDers(){ ID=2 }  },

            //    });
            //    context.SaveChanges();
            //}
            /////////////////////////////////////////////////////////////
            //if (!context.TblIcerikler.Any())
            //{
            //    context.AddRange(new ClsIcerik[] {

            //        new ClsIcerik (){ BelgeAciklama="fiziğe 1 giriş 1", BelgeAdi="fizik 1 pdf1", BelgeLink="http://aure.belge.com/fizik11.txt/", DersId=1, KtKod_ID="TEA_1", Sirano=1 },
            //        new ClsIcerik (){ BelgeAciklama="fiziğe 1 giriş 2", BelgeAdi="fizik 1 pdf2", BelgeLink="http://aure.belge.com/fizik12.gif/", DersId=1, KtKod_ID="TEA_1", Sirano=2 },
            //        new ClsIcerik (){ BelgeAciklama="fiziğe 1 giriş 3", BelgeAdi="fizik 1 pdf3", BelgeLink="http://aure.belge.com/fizik13.pdf/", DersId=1, KtKod_ID="TEA_1", Sirano=3 },
            //        new ClsIcerik (){ BelgeAciklama="fiziğe 2 giriş 1", BelgeAdi="fizik 2 pdf1", BelgeLink="http://aure.belge.com/fizik21.pdf/", DersId=1, KtKod_ID="TEA_2", Sirano=3 },
            //        new ClsIcerik (){ BelgeAciklama="fiziğe 2 giriş 2", BelgeAdi="fizik 2 pdf2", BelgeLink="http://aure.belge.com/fizik22.txt/", DersId=1, KtKod_ID="TEA_2", Sirano=2 },
            //        new ClsIcerik (){ BelgeAciklama="fiziğe 2 giriş 3", BelgeAdi="fizik 2 pdf3", BelgeLink="http://aure.belge.com/fizik23.doc/", DersId=1, KtKod_ID="TEA_2", Sirano=1 },

            //        new ClsIcerik (){ BelgeAciklama="bilgisayar prog/L", BelgeAdi="CS 1 doc 1", BelgeLink="http://aure.belge.com/prog.doc/", DersId=4, KtKod_ID="TEA_4", Sirano=1 },
            //        new ClsIcerik (){ BelgeAciklama="bilgisayar teori", BelgeAdi="CS 1 doc 2", BelgeLink="http://aure.belge.com/teo.doc/", DersId=4, KtKod_ID="TEA_4", Sirano=2 },
            //        new ClsIcerik (){ BelgeAciklama="bilgisayar işletim", BelgeAdi="CS 2 doc 10", BelgeLink="http://aure.belge.com/OS.ppt/", DersId=4, KtKod_ID="TEA_3", Sirano=4 },
            //        new ClsIcerik (){ BelgeAciklama="bilgisayar Diller", BelgeAdi="CS 2 doc 11", BelgeLink="http://aure.belge.com/Langs.txt/", DersId=4, KtKod_ID="TEA_3", Sirano=3 },
            //        new ClsIcerik (){ BelgeAciklama="bilgisayar Tarihi", BelgeAdi="CS 2 doc 12", BelgeLink="http://aure.belge.com/histo.xls/", DersId=4, KtKod_ID="TEA_3", Sirano=2 },
            //        new ClsIcerik (){ BelgeAciklama="bilgisayar Gelecek", BelgeAdi="CS 2 doc 13", BelgeLink="http://aure.belge.com/getfut.gif/", DersId=4, KtKod_ID="TEA_3", Sirano=1 },

            //    });
            //    context.SaveChanges();
            //}
            /////////////////////////////////////////////////////////////
            //if (!context.TblTakvimler.Any())
            //{
            //    context.AddRange(new ClsTakvim[] {

            //        new ClsTakvim (){  },

            //    });
            //    context.SaveChanges();
            //}

        }
    }
}
