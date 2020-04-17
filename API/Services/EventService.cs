// Code written by Balana Ovidiu
using API.Helpers;
using API.Models;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class EventService: AbstractService<Event>
    {
        public EventService(UnitOfWork unitOfWork):base(unitOfWork)
        {

        }

        public List<EventData> GetUnapprovedEvents()
        {
            var events = _unitOfWork.Events.All().Where(e => e.IsApproved == false);
            var result = events.Select(e => new EventData
            {
                Name = e.Name,
                RoomId = e.RoomId,
                RoomName = e.Room.Name,
                ParticipationFee = e.ParticipationFee,
                NrParticipants = e.NrParticipants,
                EventId = e.EventId,
                IsApproved = e.IsApproved,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
            }).ToList();

            return result;
        }

        public async Task UpdateEventsAsync(IList<EventData> eventDatas)
        {
            foreach(var eventData in eventDatas)
            {
                var eventToUpdate = await _unitOfWork.Events.FindByIdAsync(eventData.EventId);
                eventToUpdate.UpdateIsApproved(eventToUpdate.IsApproved);
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
