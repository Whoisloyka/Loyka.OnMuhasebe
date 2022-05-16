namespace Loyka.OnMuhasebe.Bankalar;
public class Masraf : FullAuditedAggregateRoot<Guid>
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public int KdvOranı { get; set; }
    public decimal BirimFiyatı { get; set; }
    public Guid BirimId{ get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
}
