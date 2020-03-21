using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactTracerNoAuth.Data
{
    public class Checkin : EntityBase
    {
        public long VenueId { get; set; }
        public Venue Venue { get; set; }

        [StringLength(39)]
        public string IpAddress { get; set; }

        [StringLength(1000)]
        public string UserAgent { get; set; }

        [StringLength(200)]
        public string SuppliedName { get; set; }

        [StringLength(200)]
        public string SuppliedEmail { get; set; }

        [StringLength(50)]
        public string SuppliedPhoneNumber { get; set; }

        [Column(TypeName = "datetime2(2)")]
        public DateTime CheckinAtUtc { get; set; }
    }
}