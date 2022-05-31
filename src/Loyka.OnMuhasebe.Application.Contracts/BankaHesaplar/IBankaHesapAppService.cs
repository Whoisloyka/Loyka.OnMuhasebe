using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.Services;

namespace Loyka.OnMuhasebe.BankaHesaplar;
public interface IBankaHesapAppService : ICrudAppService<SelectBankaHesapDto,
    ListBankaHesapDto, BankaHesapListParameterDto, CreateBankaHesapDto,
    UpdateBankaHesapDto, BankaHesapCodeParameterDto>
{
}