﻿using AutoMapper;
using Loyka.OnMuhasebe.Bankalar;

namespace Loyka.OnMuhasebe;

public class OnMuhasebeApplicationAutoMapperProfile : Profile
{
    public OnMuhasebeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */


        // Yaptığımız tüm maplemeleri buraya ekliyoruz.
        CreateMap<Banka, SelectBankaDto>();
        CreateMap<Banka, ListBankaDto>();
        CreateMap<CreateBankaDto, Banka>();
        CreateMap<UpdateBankaDto, Banka>();
    }
}
