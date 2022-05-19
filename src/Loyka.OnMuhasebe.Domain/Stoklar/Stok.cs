namespace Loyka.OnMuhasebe.Bankalar;
public class Stok : FullAuditedAggregateRoot<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public int KdvOranı { get; set; }
    public decimal BirimFiyatı { get; set; }
    public Guid BirimId { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }



    public Birim Birim { get; set; }
    public OzelKod OzelKod1 { get; set; }
    public ICollection<FaturaHareket> faturaHareketler{ get; set; }
    public OzelKod OzelKod2 { get; set; }
}
