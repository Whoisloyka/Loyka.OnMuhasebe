using AutoMapper;
using Loyka.OnMuhasebe.Bankalar;
using Loyka.OnMuhasebe.BankaSubeler;

namespace Loyka.OnMuhasebe;

public class OnMuhasebeApplicationAutoMapperProfile : Profile
{
    public OnMuhasebeApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */


        // Yaptığımız tüm maplemeleri buraya ekliyoruz.

        // Banka
        CreateMap<Banka, SelectBankaDto>()
            .ForMember(x=>x.OzelKod1Adi,y=>y.MapFrom(z=>z.OzelKod1.Ad)) //navigation propertyleri getiriyor. İlgili alanları mapleryip dolduruyor.
            .ForMember(x=>x.OzelKod2Adi,y=>y.MapFrom(z=>z.OzelKod2.Ad));
        CreateMap<Banka, ListBankaDto>()
            .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
            .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));
        CreateMap<CreateBankaDto, Banka>();
        CreateMap<UpdateBankaDto, Banka>();

        // BankaSube
        CreateMap<BankaSube, SelectBankaSubeDto>()
            .ForMember(x => x.BankaAdi, y => y.MapFrom(z => z.Banka.Ad))
            .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
            .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<BankaSube, ListBankaSubeDto>()
            .ForMember(x => x.BankaAdi, y => y.MapFrom(z => z.Banka.Ad))
            .ForMember(x => x.OzelKod1Adi, y => y.MapFrom(z => z.OzelKod1.Ad))
            .ForMember(x => x.OzelKod2Adi, y => y.MapFrom(z => z.OzelKod2.Ad));

        CreateMap<CreateBankaSubeDto, BankaSube>();
        CreateMap<UpdateBankaSubeDto, BankaSube>();


    }
}
