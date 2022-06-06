using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loyka.OnMuhasebe.Makbuzlar;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Loyka.OnMuhasebe.BankaHesaplar;
public class BankaHesapAppService : OnMuhasebeAppService, IBankaHesapAppService
{
    private readonly IBankaHesapRepository _bankaHesapRepository;
    public BankaHesapAppService(IBankaHesapRepository bankaHesapRepository)
    {
        _bankaHesapRepository = bankaHesapRepository;
    }

    public virtual async Task<SelectBankaHesapDto> GetAsync(Guid id)
    {
        var entity = await _bankaHesapRepository.GetAsync(id,
            x => x.Id == id, // predicate
            x => x.BankaSube,
            x => x.BankaSube.Banka,
            x => x.OzelKod1,
            x => x.OzelKod2);


        var mappedDto = ObjectMapper.Map<BankaHesap, SelectBankaHesapDto>(entity);
        mappedDto.HesapTuruAdi = L[$"Enum:BankaHesapTuru:{(byte)mappedDto.HesapTuru}"];

        return mappedDto;
    }
    public virtual async Task<PagedResultDto<ListBankaHesapDto>> GetListAsync(BankaHesapListParameterDto input)
    {
        var entities = await _bankaHesapRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount,
            x => input.HesapTuru == null ? x.SubeId == input.SubeId && 
            x.Durum == input.Durum : x.HesapTuru == input.HesapTuru && // bazen hesap türü göre listeleme isteyeceğiz. Bu sorgu bize onu sağlayacak.
            x.SubeId == input.SubeId && x.Durum == input.Durum,
            x => x.Kod,
            x => x.BankaSube, x => x.BankaSube.Banka, x => x.OzelKod1, x => x.OzelKod2,
            x => x.MakbuzHareketler);

        var totalCount = await _bankaHesapRepository.CountAsync(x => input.HesapTuru == null ?
            x.SubeId == input.SubeId &&
            x.Durum == input.Durum : x.HesapTuru == input.HesapTuru &&
            x.SubeId == input.SubeId && x.Durum == input.Durum);


        var mappedDtos = ObjectMapper.Map<List<BankaHesap>, List<ListBankaHesapDto>>(entities);

        mappedDtos.ForEach(x =>
        {
            x.HesapTuruAdi = L[$"Enum:BankaHesapTuru:{(byte)x.HesapTuru}"];
            x.Borc = x.MakbuzHareketler.Where(y => y.BelgeDurumu == BelgeDurumu.TahsisEdildi ||
                     y.OdemeTuru == OdemeTuru.Pos && y.BelgeDurumu == BelgeDurumu.Portfoyde)
                     .Sum(y => y.Tutar);

            x.Alacak = x.MakbuzHareketler.Where(y => y.BelgeDurumu == BelgeDurumu.TahsisEdildi)
                     .Sum(y => y.Tutar);
        });

        return new PagedResultDto<ListBankaHesapDto>(totalCount, mappedDtos);
    }






    public virtual async Task<SelectBankaHesapDto> CreateAsync(CreateBankaHesapDto input)
    {


        var entity = ObjectMapper.Map<CreateBankaHesapDto, BankaHesap>(input);

        await _bankaHesapRepository.InsertAsync(entity);
        return ObjectMapper.Map<BankaHesap, SelectBankaHesapDto>(entity);
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }



    public virtual async Task<string> GetCodeAsync(BankaHesapCodeParameterDto input)
    {
        throw new NotImplementedException();
    }


    public virtual async Task<SelectBankaHesapDto> UpdateAsync(Guid id, UpdateBankaHesapDto input)
    {
        throw new NotImplementedException();
    }

    Task<ListBankaHesapDto> IReadOnlyAppService<ListBankaHesapDto, ListBankaHesapDto, Guid, BankaHesapListParameterDto>.GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
