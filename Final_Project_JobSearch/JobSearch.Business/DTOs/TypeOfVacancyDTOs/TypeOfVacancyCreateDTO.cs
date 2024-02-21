using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.TypeOfVacancyDTOs
{
    public class TypeOfVacancyCreateDTO
    {
        public string Title { get; set; }
    }
    public class TypeOfVacancyCreateDTOValidator : AbstractValidator<TypeOfVacancyCreateDTO>
    {
        public TypeOfVacancyCreateDTOValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
        }
    }
}