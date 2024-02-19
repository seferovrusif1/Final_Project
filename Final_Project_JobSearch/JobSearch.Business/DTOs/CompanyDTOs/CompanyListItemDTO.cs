using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.CompanyDTOs
{
    public class CompanyListItemDTO
    {

        public string Name { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AuthorizedPerson { get; set; }
        ///TODO: belke ayri table a cixardim
        public string Website { get; set; }
    }
    public class CompanyListItemDTOValidator : AbstractValidator<CompanyListItemDTO>
    {
        public CompanyListItemDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
            RuleFor(x => x.About)
                .MaximumLength(2048);
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .MaximumLength(320);
            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .MaximumLength(16)
                .MinimumLength(7);
            RuleFor(x => x.AuthorizedPerson)
                .NotEmpty()
                .NotNull()
                .MaximumLength(64)
                .MinimumLength(3);
            RuleFor(x => x.Website)
                .NotEmpty()
                .NotNull()
                .MaximumLength(256);
        }
    }