using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.CommonDtos;
using Volo.Abp.Application.Dtos;


// DB'den vereceğimiz parametreye göre kodun gelmesi.
namespace Loyka.OnMuhasebe.BankaHesaplar;
public class BankaHesapCodeParameterDto : IEntityDto, IDurum
{
    // BankaHesapKod'u getirirken bu iki bilgi lazım. Hesabın hangi şubede olduğu ve akftil veya pasiflik durumu.
    public Guid SubeId { get; set; }
    public bool Durum { get; set; }
}
