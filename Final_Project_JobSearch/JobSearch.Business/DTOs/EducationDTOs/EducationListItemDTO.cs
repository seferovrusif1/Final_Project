using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.EducationDTOs
{
    public class EducationListItemDTO
    {
        public string Degree { get; set; }
    }
    public class EducationListItemDTOValidtor : AbstractValidator<EducationListItemDTO>
    {
        public EducationListItemDTOValidtor()
        {
            RuleFor(a => a.Degree)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
        }
    }
}

