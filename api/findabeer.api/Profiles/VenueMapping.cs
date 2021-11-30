using System.Linq;
using AutoMapper;

using findabeer.Models;
using findabeer.Transfer.Dtos;

namespace findabeer.Profiles
{
    public class VenueMapping : Profile
    {
        public VenueMapping()
        {
            CreateMap<Venue, VenueDto>()
                .ForMember(dest => dest.Tags, 
                    opt => opt.MapFrom(
                        src => src.VenueTags
                            .Select(vt => new TagDto 
                            { 
                                Id = vt.TagId, 
                                Name = vt.Tag != null ? vt.Tag.Name : null
                            })));
        }   
    }
}