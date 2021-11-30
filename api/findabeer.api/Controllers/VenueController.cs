using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using findabeer.Interfaces;
using findabeer.Transfer;

namespace findabeer.api.Controllers
{
    [ApiController]
    [Route("api/venues")]
    public class VenueController : ControllerBase
    {
        private readonly IVenueService _venueService;
        private readonly ILogger<VenueController> _logger;

        public VenueController(IVenueService venueService, ILogger<VenueController> logger)
        {
            _venueService = venueService;
            _logger = logger;
        }

        // [HttpPost("")]
        // public async Task<IActionResult> CreateVenuesAsync()
        // {

        // }

        [HttpGet("search")]
        public async Task<IActionResult> SearchVenuesAsync([FromQuery] VenueSearchParams searchParams)
        {
            var venues = await _venueService.SearchVenuesAsync(searchParams);
            return Ok(venues);
        }

    }
}
