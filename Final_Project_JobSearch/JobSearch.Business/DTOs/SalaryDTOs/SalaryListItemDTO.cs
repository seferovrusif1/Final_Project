using FluentValidation;

namespace JobSearch.Business.DTOs.SalaryDTOs
{
    public  class SalaryListItemDTO
    {
        public string Amount { get; set; }
    }
    public class SalarySalaryListItemDTOValidator : AbstractValidator<SalaryListItemDTO>
    {
        public SalarySalaryListItemDTOValidator()
        {
            RuleFor(a=>a.Amount)
                .NotEmpty()
                .NotNull()
                .MaximumLength(16);
        }
    }
}
