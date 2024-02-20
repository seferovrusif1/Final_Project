using FluentValidation;

namespace JobSearch.Business.DTOs.GenderDTOs
{
    public class GenderListItemDTO
    {
        public string Title { get; set; }

    }
    public class GenderListItemDTOValidator : AbstractValidator<GenderListItemDTO>
    {
        public GenderListItemDTOValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(16);

        }
    }
}
  