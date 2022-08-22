using Gigya.Process.Model;

namespace Gigya.Process.Abstract
{
    public interface IGigyaService
    {
        UserSignatureValidationResult ValidateUserSignature(LoggedUser loggedUser);

        UserProfile GetUserProfileByGigyaId(string gigyaId);

        GigyaResponse DeleteProfile(string gigyaId);
    }
}
