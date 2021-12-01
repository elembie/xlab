using System.Collections.Generic;
using System.Threading.Tasks;

using findabeer.api.Transfer;
using findabeer.api.Transfer.Dtos;

namespace findabeer.api.Interfaces
{
    public interface IVenueService
    {
        // Task<List<VenueDto>> CreateVenueAndTagsAsync(IEnumerable<VenueDto> venues);
        Task<List<VenueDto>> SearchVenuesAsync(VenueSearchParams searchParams);
    }
}