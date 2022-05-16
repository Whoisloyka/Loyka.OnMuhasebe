﻿namespace Loyka.OnMuhasebe.Parametreler;
public class FirmaParametre : Entity<Guid>
{
    // Bu class'taki bilgiler sürekli değişeceği için FullAuditedAggregateRoot yerine Entity Class'ından ürettik.
    public Guid UserId { get; set; }
    public Guid SubeID { get; set; }
    public Guid DonemId { get; set; }
    public Guid? DepoId { get; set; }
}
