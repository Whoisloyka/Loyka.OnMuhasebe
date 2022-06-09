using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Loyka.OnMuhasebe.Consts;
using Loyka.OnMuhasebe.Localization;
using Microsoft.Extensions.Localization;

namespace Loyka.OnMuhasebe.BankaHesaplar;
public class UpdateBankaHesapDtoValidator : AbstractValidator<UpdateBankaHesapDto>
{
    public UpdateBankaHesapDtoValidator(IStringLocalizer<OnMuhasebeResource> localizer)
    {
        RuleFor(x => x.Kod)
            .NotEmpty()
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Code"]])

            .MaximumLength(EntityConsts.MaxKodLength)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength, localizer["Code"],
             EntityConsts.MaxKodLength]);

        RuleFor(x => x.Ad)
            .NotEmpty()
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required, localizer["Name"]])

            .MaximumLength(EntityConsts.MaxAdLength)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength, localizer["Name"],
             EntityConsts.MaxAdLength]);

        RuleFor(x => x.HesapTuru)
            .IsInEnum()
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required,
             localizer["AccountType"]])

            .NotEmpty()
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required,
             localizer["AccountType"]]);

        RuleFor(x => x.BankaSubeId)
            .Must(x => x.HasValue && x.Value != Guid.Empty)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required,
             localizer["BankBranch"]]);

        RuleFor(x => x.HesapNo)
            .NotEmpty()
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.Required,
             localizer["AccountNumber"]])

            .MaximumLength(BankaHesapConsts.MaxHesapNoLength)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength,
             localizer["AccountNumber"], BankaHesapConsts.MaxHesapNoLength]);

        RuleFor(x => x.IbanNo)
            .MaximumLength(BankaHesapConsts.MaxIbanNoLength)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength,
             localizer["Iban"], BankaHesapConsts.MaxIbanNoLength]);

        RuleFor(x => x.Aciklama)
            .MaximumLength(EntityConsts.MaxAciklamaLength)
            .WithMessage(localizer[OnMuhasebeDomainErrorCodes.MaxLength,
             localizer["Description"], EntityConsts.MaxAciklamaLength]);
    }
}
