using Flashochist.Web.Models;
using Orchard;
using Orchard.Security;

namespace Flashochist.Web.Services {
    public interface IFlashochistService : IDependency {
        FlashochistPart CreateFlashochist(string email, string password, string firstName, string lastName);
        IUser AuthenticateFlashochist(string email, string password);
    }
}