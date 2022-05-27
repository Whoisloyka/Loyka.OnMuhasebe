using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace Loyka.OnMuhasebe.BankaHesaplar;
public class BankaHesapListParameterDto : PagedResultRequestDto, IEntityDto, IDurum
{
    // Banka Hesaplarının bir listesini UI'da gösterirken. Bu propetyleri parametre olarak gönderip filtreleme yapabiliriz.

    public BankaHesapTuru? HesapTuru { get; set; }
    public Guid SubeId { get; set; }
    public bool Durum { get; set; }
}
