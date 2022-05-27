﻿using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.CommonDtos;
using Volo.Abp.Application.Dtos;


// Db'den bir tane entity getirdiğimiz zaman kullanıcının ekranda göreceği verileri içeren DTO'dur.
// Bankaları listeleikten sonra üzerine tıklayıp seçtiğimizde gelen bilgiler.
namespace Loyka.OnMuhasebe.BankaHesaplar;
public class SelectBankaHesapDto : EntityDto<Guid>, IOzelKod
{
    public string Kod { get; set; }
    public string Ad { get; set; }
    public BankaHesapTuru? HesapTuru { get; set; } 
    public string HesapTuruAdi { get; set; }
    public string HesapNo { get; set; }
    public string IbanNo { get; set; }
    public string BankaAdi { get; set; }
    public Guid BankaId { get; set; }
    public string BankaSubeAdi { get; set; }
    public Guid? BankaSubeId { get; set; }
    public string OzelKod1Adi { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public string OzelKod2Adi { get; set; }
    public Guid? OzelKod2Id { get; set; }
    public Guid? SubeId { get; set; }
    public string Aciklama { get; set; }
    public bool Durum { get; set; }
}
