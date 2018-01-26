using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public partial class StoreSetting
    {
        public int Id { get; set; }
        public decimal? SalesTax { get; set; }
        public string Signature { get; set; }
        public int? DefaultCurrencyId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Logo { get; set; }

        public Currency DefaultCurrency { get; set; }

        public IFormFile UploadLogo { get; set; }
    }

    public class StoreSettingValidation : AbstractValidator<StoreSetting>
    {
        public StoreSettingValidation()
        {
            RuleFor(s => s.Email).NotNull().MaximumLength(50);
            RuleFor(s => s.Name).NotNull().MaximumLength(50);
            //RuleFor(s => s.UploadLogo).NotNull();
        }
    }
}
