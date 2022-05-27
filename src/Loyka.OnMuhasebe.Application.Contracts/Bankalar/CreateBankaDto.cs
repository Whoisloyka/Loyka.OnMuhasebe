using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.BankaHesaplar;
using Volo.Abp.Application.Dtos;

namespace Loyka.OnMuhasebe.Bankalar;
public class CreateBankaDto : IEntityDto
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
}
