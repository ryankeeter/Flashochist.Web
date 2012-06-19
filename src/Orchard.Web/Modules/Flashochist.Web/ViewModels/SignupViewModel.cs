using System.ComponentModel.DataAnnotations;

namespace Flashochist.Web.ViewModels {
    public class SignupViewModel{

        [StringLength(50), Required, Display(Name = "Firstname")]
        public string FirstName { get; set; }
 
        [StringLength(50), Required, Display(Name="Lastname")]
        public string LastName { get; set; }
 
        [StringLength(255), Required, DataType(DataType.EmailAddress), Display(Name = "Email")]
        public string Email { get; set; }
 
        [StringLength(255), Required, DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }
 
        [StringLength(255), Required, DataType(DataType.Password), System.Web.Mvc.Compare("Password"), Display(Name = "Repeat password")]
        public string RepeatPassword { get; set; }
 
        
    }
}