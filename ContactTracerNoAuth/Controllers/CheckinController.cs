using System;
using System.Threading.Tasks;
using ContactTracerNoAuth.Data;
using ContactTracerNoAuth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ContactTracerNoAuth.Controllers
{
    public class CheckinController : Controller
    {
        private readonly CtDbContext _dbContext;

        public CheckinController(CtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{venueId:int}")]
        public async Task<IActionResult> CheckIn(long venueId)
        {
            var venue = await _dbContext.Venues.SingleOrDefaultAsync(x => x.Id == venueId);
            ViewBag.VenueName = venue.DisplayName;
            return View(new CheckinModel());
        }
        
        [HttpPost("{venueId:int}")]
        public async Task<IActionResult> CheckIn(long venueId, CheckinModel model)
        {
            var venue = await _dbContext.Venues.SingleOrDefaultAsync(x => x.Id == venueId);
            ViewBag.VenueName = venue.DisplayName;

            if (string.IsNullOrWhiteSpace(model.Name) && string.IsNullOrWhiteSpace(model.Email) && string.IsNullOrWhiteSpace(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.Name), "At least one detail must be provided");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var checkin = new Checkin
            {
                CheckinAtUtc = DateTime.UtcNow,
                VenueId = venueId,
                IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                UserAgent = Request.Headers["user-agent"],
                SuppliedEmail = model.Email,
                SuppliedName = model.Name,
                SuppliedPhoneNumber = model.PhoneNumber
            };
            _dbContext.Checkins.Add(checkin);

            await _dbContext.SaveChangesAsync();
            
            return RedirectToAction("Thanks", new{venueId, checkinId = checkin.Id});
        }
        
        [HttpGet("thanks/{venueId:int}")]
        public async Task<IActionResult> Thanks(long venueId, long checkinId)
        {
            var venue = await _dbContext.Venues.SingleOrDefaultAsync(x => x.Id == venueId);
            ViewBag.VenueName = venue.DisplayName;
            return View();
        }

    }
}