using Gigya.Process.Model;

namespace Gigya.Service.Abstract
{
    public interface IUserService
    {
        UserProfile GetUserProfile(string gigyaId);
    }
}
