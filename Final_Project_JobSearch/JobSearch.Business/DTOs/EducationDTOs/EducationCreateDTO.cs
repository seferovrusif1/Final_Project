using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.EducationDTOs
{
    public class EducationCreateDTO
    {
        public string Degree { get; set; }
    }
    public class EducationUpdateDTOValidtor : AbstractValidator<EducationCreateDTO>
    {
        public EducationUpdateDTOValidtor()
        {
            RuleFor(a=>a.Degree)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
        }
    }
}
