using FluentValidation;

namespace JobSearch.Business.DTOs.SMJobSeekerDTOs
{
    public class SMJobSeekerListItemDTO
    {
        public string SocialMediaId { get; set; }
        public string JobSeekerId { get; set; }

        public string Username { get; set; }
    }
    public class SMJobSeekerListItemDTOValidator : AbstractValidator<SMJobSeekerListItemDTO>
    {
        public SMJobSeekerListItemDTOValidator()
        {
            RuleFor(a=>a.Username)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);
            RuleFor(a => a.SocialMediaId)
                .NotEmpty()
                .NotNull();
            RuleFor(a => a.JobSeekerId)
                .NotEmpty()
                .NotNull();
        }
    }

}
