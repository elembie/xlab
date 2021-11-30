using System.Collections.Generic;
using System.Threading.Tasks;

using findabeer.Transfer;
using findabeer.Transfer.Dtos;

namespace findabeer.Interfaces
{
    public interface IVenueService
    {
        // Task<List<VenueDto>> CreateVenueAndTagsAsync(IEnumerable<VenueDto> venues);
        Task<List<VenueDto>> SearchVenuesAsync(VenueSearchParams searchParams);
    }
}