using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.ExperianceYearDTOs
{
    public class ExperienceYearListItemDTO
    {
        public string ExpYear { get; set; }
    }
    public class ExperianceYearListItemDTODTOValidator : AbstractValidator<ExperienceYearListItemDTO>
    {
        public ExperianceYearListItemDTODTOValidator()
        {
            RuleFor(a => a.ExpYear)
                .NotNull()
                .NotEmpty()
                .MaximumLength(32);
        }
    }
}
