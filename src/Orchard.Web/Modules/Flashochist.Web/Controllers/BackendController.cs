using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flashochist.Web.Services;
using Flashochist.Web.ViewModels;
using Orchard;
using Orchard.DisplayManagement;
using Orchard.Mvc;
using Orchard.Security;
using Orchard.Themes;

namespace Flashochist.Web.Controllers
{
    [Themed]
    public class BackendController : Controller
    {
        private readonly IOrchardServices _orchardServices;
        private dynamic _shapeFactory;
        private readonly IAuthenticationService _authenticationService;
        private readonly IFlashochistService _flashochistService;

        public BackendController(IOrchardServices orchardServices, IShapeFactory shapeFactory, 
            IAuthenticationService authenticationService, IFlashochistService flashochistService) {
            _orchardServices = orchardServices;
            _shapeFactory = shapeFactory;
            _authenticationService = authenticationService;
            _flashochistService = flashochistService;
        }

        public ActionResult Signup() {
            var shape = _shapeFactory.Backend_Signup(Signup: new SignupViewModel());
            return new ShapeResult(this, shape);
        }
        [HttpPost, ActionName("Signup")]
        public ActionResult SignupPOST(FormCollection collection) {
            if(!ModelState.IsValid) {
                
                return new ShapeResult(this, _shapeFactory.Backend_Signup(Signup: new SignupViewModel()));
            }

            var flashochistPart = _flashochistService
                .CreateFlashochist(collection[2], collection[3], collection[0], collection[1]);
            _authenticationService.SignIn(flashochistPart.User, true);
            return RedirectToAction("Index");

        }
        public ActionResult Login() {
            var shape = _shapeFactory.Backend_Login();
            return new ShapeResult(this, shape);
        }
        [HttpPost, ActionName("Login")]
        public ActionResult Login(BackendLoginViewModel viewModel)
        {
            
        }
        public ActionResult Index() {
            throw new NotImplementedException();
        }
    }
}