namespace Loyka.OnMuhasebe.BankaHesaplar;
public class BankaHesap:FullAuditedAggregateRoot<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public BankaHesapTuru HesapTuru { get; set; }
    public string HesapNo { get; set; }
    public string IbanNo { get; set; }
    public Guid BankaSubeId { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public Guid SubeId { get; set; }
    public string Aciklama { get; set; }
    public bool Durum{ get; set; }





    public ICollection<MakbuzHareket> MakbuzHareketler { get; set; }
    public ICollection<Makbuz> Makbuzlar { get; set; }

    // Bu dördü de birden çoka türünde ilişkiye sahip.
    // Aşağıdaki yapı "Bir banka hesabının yalnız bir tane şubesi olabilir." anlamına gelmekterdir.
    // Ancak BankaSube.cs'e bakarsak orada ICollection olarak tanımladığımız yapı "Bir şubenin birden fazla hebası olabilir." anlamındadır.
    public BankaSube BankaSube { get; set; }
    public OzelKod OzelKod1 { get; set; }
    public OzelKod OzelKod2 { get; set; }
    public Sube Sube { get; set; }
    public object BankaId { get; set; }
}