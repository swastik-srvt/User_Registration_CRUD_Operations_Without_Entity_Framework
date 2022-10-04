using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace User_Registration_CRUD_Operations_Without_Entity_Framework.Models
{
        public class UserRegistrationModel
        {
        //property name should start with uppercase letter with no underscore
        //you should use one more field for password confirmation at the time of registration

        [Required]
        [DisplayName("User ID")]
        public int Id { get; set; }
                
                

        [Required(ErrorMessage = "Enter email")]
        [RegularExpression = ("^[a-zA-Z]+@+." , ErrorMessage = "Please Enter a Valid email ")]
        [DisplayName("Email ID")]
        public string EmailId    { get; set; }
                
                
                
        [Required(ErrorMessage = "Enter Password")]
        [RegularExpression = ("^[a-zA-Z]+$+@+_" , ErrorMessage = "Please Enter a Valid Password")]
        [DisplayName("User Password")]
        public string PasswordOfUser { get; set; }
                
        [Required(ErrorMessage = "Enter Password Again")]
        [RegularExpression = ("^[a-zA-Z]+$+@+_" , ErrorMessage = "Please Enter The Same Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPasswordOfUser { get; set;   }  
                
                
                
        [Required(ErrorMessage = "Enter Name")]
        [RegularExpression = ("^[a-zA-Z]+$" , ErrorMessage = "Please Enter a Valid Name ")]
        [DisplayName("User Name")]
        public string NameOfUser { get; set; }



    }
}
