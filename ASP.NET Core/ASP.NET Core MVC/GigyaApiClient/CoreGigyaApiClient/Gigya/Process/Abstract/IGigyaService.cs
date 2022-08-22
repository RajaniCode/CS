using Gigya.Process.Model;

namespace Gigya.Process.Abstract
{
    public interface IGigyaService
    {
        UserSignatureValidationResult ValidateUserSignature(LoggedUser loggedUser);
    }
}
