// Code written by Streata Alexandra
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Services
{
    public class RoomService
    {
        private readonly ApiConnector _apiConnector;

        public RoomService(ApiConnector apiConnector)
        {
            _apiConnector = apiConnector;
        }

        public async Task<IEnumerable<RoomData>> GetRoomsAsync()
        {
            return await _apiConnector.GetAsync<IEnumerable<RoomData>>($"room/getRooms");
        }
    }
}
