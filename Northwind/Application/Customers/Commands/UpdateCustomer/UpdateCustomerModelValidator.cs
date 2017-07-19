using FluentValidation;
using FluentValidation.Validators;

namespace NorthwindTraders.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerModelValidator : AbstractValidator<UpdateCustomerModel>
    {
        public UpdateCustomerModelValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty()
                .WithMessage("Required");

            RuleFor(c => c.PostalCode).Matches(@"^\d{4}$")
                .When(c => c.Country == "Australia")
                .WithMessage("Australian Postcodes have 4 digits");

            RuleFor(c => c.Phone).Must(HaveAQldLandLine)
                .When(c => c.Country == "Australia" && c.PostalCode.StartsWith("4"))
                .WithMessage("Customers in QLD require at least one QLD landline.");
        }

        
        private bool HaveAQldLandLine(UpdateCustomerModel model, string phoneValue, PropertyValidatorContext ctx)
        {
            return model.Phone.StartsWith("07") || model.Fax.StartsWith("07");
        }
    }
}