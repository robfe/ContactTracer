using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContactTracerNoAuth.Models
{
    public class RegisterVenueModel
    {
        [Required]
        [StringLength(200, MinimumLength = 5)]
        [DisplayName("Display name of Venue, shown to attendees")]
        public string DisplayName { get; set; }
        
        /*
         TODO: add these to db
        public string OwnerContactName { get; set; }
        public string OwnerContactNumber { get; set; }
        public string Address { get; set; }
        */
    }
}