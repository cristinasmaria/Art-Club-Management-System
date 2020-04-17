// Code written by Balana Ovidiu
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services
{
    public class EventService
    {
        private readonly ApiConnector _apiConnector;

        public EventService(ApiConnector apiConnector)
        {
            _apiConnector = apiConnector;
        }

        public async Task<IList<EventData>> GetUnapprovedEvents()
        {
            return await _apiConnector.GetAsync<IList<EventData>>($"event/getUnapprovedEvents");
        }

        public async Task UpdateEvents(IList<EventData> events)
        {
            await _apiConnector.PostAsync("event/updateEvents", events);
        }
    }
}
