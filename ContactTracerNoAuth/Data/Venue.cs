using System.ComponentModel.DataAnnotations;

namespace ContactTracerNoAuth.Data
{
    public class Venue : EntityBase
    {
        [StringLength(200)]
        public string DisplayName { get; set; }
    }
}