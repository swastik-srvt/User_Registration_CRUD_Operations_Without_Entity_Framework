using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace User_Registration_CRUD_Operations_Without_Entity_Framework.Models
{
        public class UserRegistrationModel
        {

        [Required]
        [DisplayName("User ID")]
        public int id { get; set; }

        [Required]
        [DisplayName("Email ID")]
        public string emailid    { get; set; }
        [Required]
        [DisplayName("User Password")]
        public string password_of_user { get; set; }
        [Required]
        [DisplayName("User Name")]
        public string name_of_user { get; set; }



    }
}
