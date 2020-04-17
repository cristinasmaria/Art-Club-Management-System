// Code written by Balana Ovidiu
using API.Services;
using Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("api/[controller]")]
    public class EventController: Controller
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet("getUnapprovedEvents")]
        public IList<EventData> GetUnapprovedEvents()
        {
            return _eventService.GetUnapprovedEvents();
        }

        [HttpPost("updateEvents")]
        public async Task UpdateEvents([FromBody]IList<EventData> eventDatas)
        {
            await _eventService.UpdateEventsAsync(eventDatas);
        }
    }
}
