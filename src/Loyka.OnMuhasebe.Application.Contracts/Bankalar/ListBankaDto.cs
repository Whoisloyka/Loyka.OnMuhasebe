using System;
using Volo.Abp.Application.Dtos;

namespace Loyka.OnMuhasebe.Bankalar;
public class ListBankaDto : EntityDto<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public string OzelKod1Adi { get; set; }
    public string OzelKod2Adi { get; set; }
    public string Aciklama { get; set; }
    
    
    
    //public bool Durum { get; set; } Zaten aktifse aktifleri, pasifse pasifleri listeleyeceğimiz için buna da ihtiyaç yok.

    //public Guid? OzelKod1Id { get; set; } Sadece listeleme yapacağımız için Guid kısımlara ihtiyacımız yok.
    //public Guid? OzelKod2Id { get; set; }
}
