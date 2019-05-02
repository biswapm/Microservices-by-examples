using UserIdentity.Api.ViewModels.Validations;
using FluentValidation.Attributes;

namespace UserIdentity.Api.ViewModels
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
