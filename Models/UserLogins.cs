using System.ComponentModel.DataAnnotations;

namespace RestAPisUserCore.Models
{
    public class UserLogins
    {
        [Required]
        public string EmailID
        {
            get;
            set;
        }
        [Required]
        public string Password
        {
            get;
            set;
        }
        public UserLogins() { }
    }
}
