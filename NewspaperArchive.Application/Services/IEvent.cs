using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NewspaperArchive.Application.Model;
using NewspaperArchive.Application.Common.Dtos;

namespace NewspaperArchive.Application.Services
{
    public interface IEvent
    {
        Task<int> CreateEvent(EventModel model);

        Task<IEnumerable<EventListDTO>> GetEventList();

        Task<IEnumerable<EventTypeModel>> GetEventType();

        Task<IEnumerable<VenueModel>> GetVenueList();


    }
}
