using FluentValidation;
using JobSearch.Business.DTOs.TypeOfVacancyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.WorkTypeDTOs
{
    public class WorkTypeCreateDTO
    {
        public string Title { get; set; }
    }
    public class WorkTypeCreateDTOValidator : AbstractValidator<WorkTypeCreateDTO>
    {
        public WorkTypeCreateDTOValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
        }
    }
}