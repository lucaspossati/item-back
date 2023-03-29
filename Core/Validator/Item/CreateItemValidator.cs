using FluentValidation;
using Manager.VM.ItemVM;

namespace Core.Validator.User
{
    public class CreateItemValidator : AbstractValidator<ItemVM>
    {
        public CreateItemValidator()
        {
            RuleFor(p => p.ItemCode)
                .NotNull().WithMessage("ItemCode is required")
                .MinimumLength(1).WithMessage("ItemCode needs to have more than 1 character")
                .MaximumLength(25).WithMessage("ItemCode can't have more than 25 characters");

            RuleFor(p => p.Description)
                .NotNull().WithMessage("Description is required")
                .MinimumLength(1).WithMessage("Description needs to have more than 1 character")
                .MaximumLength(300).WithMessage("Description can't have more than 300 characters");

            RuleFor(p => p.Active)
                .NotNull().WithMessage("Active is required");

            RuleFor(p => p.CustomerDescription)
               .MaximumLength(300).WithMessage("CustomerDescription can't have more than 300 characters");

            RuleFor(p => p.SalesItem)
                .NotNull().WithMessage("SalesItem is required");

            RuleFor(p => p.StockItem)
                .NotNull().WithMessage("StockItem is required");

            RuleFor(p => p.PurchasedItem)
                .NotNull().WithMessage("PurchasedItem is required");

            RuleFor(p => p.Barcode)
                .NotNull().WithMessage("Barcode is required")
                .MinimumLength(1).WithMessage("Barcode needs to have more than 1 character")
                .MaximumLength(100).WithMessage("Barcode can't have more than 100 characters");

            RuleFor(p => p.ManageItemBy).NotNull().IsInEnum().WithMessage("ManageItemBy invalid");

            RuleFor(p => p.MinimumInventory).NotNull().WithMessage("MinimumInventory is required");

            RuleFor(p => p.MaximumInventory).NotNull().WithMessage("MaximumInventory is required");

            RuleFor(p => p.ImagePath).NotNull().WithMessage("ImagePath is required");
        }
    }
}
