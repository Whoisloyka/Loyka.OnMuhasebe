namespace Loyka.OnMuhasebe.OzelKodlar;
public class OzelKod : FullAuditedAggregateRoot<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public OzelKodTuru KodTuru { get; set; }
    public KartTuru KartTuru { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }


    public ICollection<BankaHesap> OzelKod1BankaHesaplar { get; set; }
    public ICollection<BankaHesap> OzelKod2BankaHesaplar { get; set; }
    public ICollection<Banka> OzelKod1Bankalar { get; set; }
    public ICollection<Banka> OzelKod2Bankalar { get; set; }
    public ICollection<BankaSube> OzelKod1BankaSubeler { get; set; }
    public ICollection<BankaSube> OzelKod2BankaSubeler { get; set; }
    public ICollection<Birim> OzelKod1Birimler { get; set; }
    public ICollection<Birim> OzelKod2Birimler { get; set; }
    public ICollection<Cari> OzelKod1Cariler { get; set; }
    public ICollection<Cari> OzelKod2Cariler { get; set; }
    public ICollection<Depo> OzelKod1Depolar { get; set; }
    public ICollection<Depo> OzelKod2Depolar { get; set; }
}
