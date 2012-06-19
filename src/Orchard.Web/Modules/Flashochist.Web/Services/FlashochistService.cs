using System;
using Flashochist.Web.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.DisplayManagement;
using Orchard.Security;
using Orchard.Users.Models;

namespace Flashochist.Web.Services {
    public class FlashochistService : IFlashochistService {
        private readonly IOrchardServices _orchardServices;
        private readonly IMembershipService _membershipService;

        public FlashochistService(IOrchardServices orchardServices,
            IMembershipService membershipService) {
            _orchardServices = orchardServices;
            _membershipService = membershipService;
        }
        public IUser AuthenticateFlashochist(string email, string password) {
            var user = _membershipService.ValidateUser(email, password);
            return user;
        }
        public FlashochistPart CreateFlashochist(string email, string password, string firstName, string lastName) {
            var flashochist = _orchardServices.ContentManager.New("Flashochist");
            var flashochistPart = flashochist.As<FlashochistPart>();

            flashochistPart.FirstName = firstName;
            flashochistPart.LastName = lastName;
            flashochistPart.CreatedAt = DateTime.Now;
            flashochistPart.User.Email = email;
            flashochistPart.User.UserName = email;
            flashochistPart.User.NormalizedUserName = email.ToLowerInvariant();
            flashochistPart.User.Record.HashAlgorithm = "SHA1";
            flashochistPart.User.Record.RegistrationStatus = UserStatus.Approved;
            flashochistPart.User.Record.EmailStatus = UserStatus.Approved;

            _membershipService.SetPassword(flashochistPart.User, password);
            _orchardServices.ContentManager.Create(flashochist);

            return flashochistPart;

        }
    }
}