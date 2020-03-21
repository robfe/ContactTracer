using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactTracerNoAuth.Models
{
    public class CheckinModel
    {
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        [StringLength(50)]
        [Phone]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
}