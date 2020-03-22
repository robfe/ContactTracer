using System;
using System.Threading.Tasks;
using ContactTracerNoAuth.Data;
using ContactTracerNoAuth.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactTracerNoAuth.Controllers
{
    public class VenueController : Controller
    {
        private readonly CtDbContext _dbContext;

        public VenueController(CtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View(new RegisterVenueModel());
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterVenueModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var newVenue = new Venue {DisplayName = model.DisplayName};
            _dbContext.Venues.Add(newVenue);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("ViewVenueFlyer", new {id = newVenue.Id});
        }

        [HttpGet("flyer/{id}")]
        public async Task<IActionResult> ViewVenueFlyer(long id)
        {
            var venue = await _dbContext.Venues.SingleOrDefaultAsync(x => x.Id == id);
            return View(new VenueFlyerModel
            {
                DisplayName = venue.DisplayName,
                VenueId = venue.Id,
                QrUrl = new Uri(new Uri(Request.GetEncodedUrl()), Url.Action("CheckIn", "Checkin", new {venueId = id})).ToString()
            });
        }
    }
}