using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.ExperianceYearDTOs
{
    public class ExperienceYearCreateDTO
    {
        public string ExpYear { get; set; }
    }
    public class ExperianceYearCreateDTOValidator : AbstractValidator<ExperienceYearCreateDTO>
    {
        public ExperianceYearCreateDTOValidator()
        {
            RuleFor(a => a.ExpYear)
                .NotNull()
                .NotEmpty()
                .MaximumLength(32);
        }
    }
}
