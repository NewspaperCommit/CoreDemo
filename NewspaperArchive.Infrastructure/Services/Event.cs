using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using NewspaperArchive.Application.Model;
using NewspaperArchive.Application.Services;
using NewspaperArchive.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using NewspaperArchive.Application.Common.Dtos;

namespace NewspaperArchive.Infrastructure.Services
{
    public class Event : IEvent
    {
        private readonly DemoDbContext context;

        public Event(DemoDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateEvent(EventModel model)
        {
            int retunId = 0;
                SqlParameter userIdParam = new SqlParameter("@UserId", model.UserId);
                SqlParameter venueIdParam = new SqlParameter("@VenueId", model.VenueId);
                SqlParameter eventTypeIdParam = new SqlParameter("@EventTypeId", model.EventTypeId);
                SqlParameter eventNameParam = new SqlParameter("@EventName", model.EventName);
                SqlParameter hostNameParam = new SqlParameter("@HostName", model.HostName);
                SqlParameter messageParam = new SqlParameter("@Message","hghg");
                SqlParameter startDateParam = new SqlParameter("@StartDate", model.StartDate);
                SqlParameter endDateParam = new SqlParameter("@EndDate", model.EndDate);
                var result = context.StatusValue.FromSqlRaw("exec [dbo].[Sp_CreateEvent] @UserId, @VenueId, @EventTypeId, @EventName, @HostName, @Message, @StartDate, @EndDate", userIdParam,
                    venueIdParam, eventTypeIdParam, eventNameParam, hostNameParam, messageParam, startDateParam, endDateParam);
            // return await Task.FromResult(res;
            foreach (var k in result)
            {
                retunId = k.Id;

            }
            
            return await Task.FromResult<int>(retunId);
        }


        public async Task<IEnumerable<EventListDTO>> GetEventList()
        {
            //IEnumerable<EventListDTO> evtList = null;

            var result = context.EventList.FromSqlRaw("exec [dbo].[Sp_GetEventList]");
            return await Task.FromResult<IEnumerable<EventListDTO>>(result);

        }

        public async Task<IEnumerable<EventTypeModel>> GetEventType()
        {
            IEnumerable<EventTypeModel> lst = await context.EventType.ToListAsync();
            return lst;
        }

        public async Task<IEnumerable<VenueModel>> GetVenueList()
        {
            IEnumerable<VenueModel> lst = await context.Venue.ToListAsync();
            return lst;
        }
    }
}
