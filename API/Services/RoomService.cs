// Code written by Streata Alexandra
using API.Models;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class RoomService : AbstractService<Room>
    {
        public RoomService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IEnumerable<RoomData> GetRooms()
        {
            var rooms = _unitOfWork.Rooms.All();
            var dataRooms = rooms.Select(r => new RoomData
            {
                RoomId = r.RoomId,
                RoomName = r.Name,
                NumberOfSeats = r.NrSeats
            });

            return dataRooms;
        }
    }
}
