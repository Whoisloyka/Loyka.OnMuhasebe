using AutoMapper;
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
        CreateMap<Banka, SelectBankaDto>()
            .ForMember(x=>x.OzelKod1Adi,y=>y.MapFrom(z=>z.OzelKod1.Ad)) //navigation propertyleri getiriyor. İlgili alanları mapleryip dolduruyor.
            .ForMember(x=>x.OzelKod2Adi,y=>y.MapFrom(z=>z.OzelKod2.Ad));
        CreateMap<Banka, ListBankaDto>()
            .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
            .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
        CreateMap<CreateBankaDto, Banka>();
        CreateMap<UpdateBankaDto, Banka>();
    }
}
