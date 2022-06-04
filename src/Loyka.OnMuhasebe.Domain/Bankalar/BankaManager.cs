using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loyka.OnMuhasebe.Extensions;
using Volo.Abp.Domain.Services;

namespace Loyka.OnMuhasebe.Bankalar;
public class BankaManager : DomainService
{
    // kontrolleri yaparken UI'dan gelen dataları DB'dekilerle karşılaştıracağımız için Repositye ihtiyacımız var.
    // Banka ve OzelKod'larla ilgili kontrolleri yapacağımız için bu iki entityi Constructor Injection ile içeri alacağız.
    private readonly IBankaRepository _bankaRepository;
    private readonly IOzelKodRepository _kodRepository;
    public BankaManager(IBankaRepository bankaRepository, IOzelKodRepository kodRepository)
    {
        _bankaRepository = bankaRepository;
        _kodRepository = kodRepository;
    }
    public async Task CheckCreateAsync(string kod,Guid? ozelKod1Id, Guid? ozelKod2Id)
    {
        // UI'dan gelen kod ve ozelKod  alanlarını kontrol edeceğiz.
        await _bankaRepository.KodAnyAsync(kod,x=>x.Kod==kod);
        await _kodRepository.EntityAnyAsync(ozelKod1Id,OzelKodTuru.OzelKod1,
            KartTuru.Banka);
        await _kodRepository.EntityAnyAsync(ozelKod2Id, OzelKodTuru.OzelKod2,
            KartTuru.Banka);
    }
    public async Task CheckUpdateAsync(Guid id, string kod, Banka entity,
        Guid? ozelKod1Id,Guid? ozelKod2Id)
    {
        await _bankaRepository.KodAnyAsync(kod, x => x.Id != id && x.Kod == kod,
            entity.Kod != kod );
        await _kodRepository.EntityAnyAsync(ozelKod1Id, OzelKodTuru.OzelKod1,
            KartTuru.Banka, entity.OzelKod1Id != ozelKod1Id);
        await _kodRepository.EntityAnyAsync(ozelKod2Id, OzelKodTuru.OzelKod2,
            KartTuru.Banka, entity.OzelKod2Id != ozelKod2Id);
    }
    public async Task CheckDeleteAsync(Guid id)
    {
        await _bankaRepository.RelationalEntityAsync(
            x=>x.BankaSubeler.Any(y=>y.BankaId == id) ||
                x.MakbuzHareketler.Any(y => y.CekBankaId == id));
    }
}
