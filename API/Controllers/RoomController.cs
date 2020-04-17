// Code written by Streata Alexandra
using System.Collections.Generic;
using System.Linq;
using API.Models;
using API.Services;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomController : Controller
	{
        private readonly RoomService _roomService;

		public RoomController(RoomService roomService)
		{
			_roomService = roomService;
		}

		[HttpGet("getRooms")]
		public ActionResult<IEnumerable<RoomData>> GetRooms()
		{
            var rooms = new List<RoomData>(_roomService.GetRooms());

			return rooms;
		}
	}
}
