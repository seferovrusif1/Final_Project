using FluentValidation;

namespace JobSearch.Business.DTOs.TypeOfVacancyDTOs
{
    public class TypeOfVacancyListItemDTO
    {
        public string Title { get; set; }
    }
    public class TypeOfVacancyListItemDTOValidator : AbstractValidator<TypeOfVacancyListItemDTO>
    {
        public TypeOfVacancyListItemDTOValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(32);
        }
    }
}
