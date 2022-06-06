using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.MakbuzHareketler;
using Volo.Abp.Application.Dtos;

namespace Loyka.OnMuhasebe.BankaHesaplar;
public class ListBankaHesapDto : EntityDto<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public BankaHesapTuru? HesapTuru { get; set; }
    public string HesapTuruAdi { get; set; }
    public string HesapNo { get; set; }
    public string IbanNo { get; set; }
    public string BankaAdi { get; set; }
    public string BankaSubeAdi { get; set; }
    public string OzelKod1Adi { get; set; }
    public string OzelKod2Adi { get; set; }
    public decimal Borc { get; set; }
    public decimal Alacak { get; set; }

    // BorcBakiye get, set ile müdahale edilecek bir prop değil. Otomatik çalışan bir prop'tur. "=>" return demektir.
    public decimal BorcBakiye => Borc - Alacak > 0 ? Borc - Alacak : 0;
    public decimal AlacakBakiye => Alacak - Borc > 0 ? Alacak - Borc : 0;
    public string Aciklama { get; set; }



    public ICollection<SelectMakbuzHareketDto> MakbuzHareketler { get; set; }


    // public bool Durum { get; set; } // zaten true olanları listeleyeceğimiz için Durum'u göstermeye gerek yok.
    // public Guid? OzelKod2Id { get; set; }
    // public Guid? SubeId { get; set; }
    // public Guid BankaId { get; set; } // Tekli seçim değil listeleme olduğu için bankaId'ye gerek yok bankaAdi yeterli.
    // public Guid? OzelKod1Id { get; set; }
    // public Guid? BankaSubeId { get; set; }


}
