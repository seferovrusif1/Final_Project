using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Business.DTOs.CategoryDTOs
{
   public class CategoryListItemDTO
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
    public class CategoryListItemDTOValidator : AbstractValidator<CategoryListItemDTO>
    {
        public CategoryListItemDTOValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(128);

            RuleFor(a => a.ParentId)
                .GreaterThan(0);
        }
    }

}