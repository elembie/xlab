using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

using findabeer.api.Models;
using findabeer.api.Interfaces;
using findabeer.api.Transfer;
using findabeer.api.Transfer.Dtos;

namespace findabeer.api.Services
{
    public class VenueService : IVenueService
    {
        private readonly FindABeerContext _context;
        private readonly IMapper _mapper;

        public VenueService(FindABeerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // public async Task<List<VenueDto>> CreateVenueAndTagsAsync(IEnumerable<VenueDto> venues)
        // {
        //     // okay for small data set
        //     var existingTags = await _context.Tags
        //         .Distinct()
        //         .ToListAsync();

        //     // create tags
        //     var newTags = venues
        //         .SelectMany(v => v.Tags.Select(t => t.Name))
        //         .Where(n => !existingTags.Select(t => t.Name).Contains(n))
        //         .Select(n => new Tag { Name = n })
        //         .ToList();

        //     await _context.Tags.AddRangeAsync(newTags);
        //     await _context.SaveChangesAsync();

        //     var tags = existingTags.Concat(newTags).ToList();
        // }

        public async Task<List<VenueDto>> SearchVenuesAsync(VenueSearchParams searchParams)
        {
            var venues = await _context.Venues
                .Include(v => v.VenueTags)
                    .ThenInclude(vt => vt.Tag)
                .Where(v => 
                    v.Name.Contains(searchParams.Query)
                    || v.Address.Contains(searchParams.Query)
                    || v.Twitter.Contains(searchParams.Query))
                .OrderBy(v => v.Name)
                .Take(10)
                .ToListAsync();

            return venues
                .Select(v => 
                {
                    var venue = _mapper.Map<VenueDto>(v);
                    venue.DistanceTo = searchParams.HasLocation 
                        ? v.DistanceTo((float)searchParams.Lat, (float)searchParams.Lng)
                        : null;
                    return venue;
                })
                .ToList();
        }
    }
}