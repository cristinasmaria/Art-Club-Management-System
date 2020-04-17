// Code written by Streata Alexandra
using System.Collections.Generic;
using API.Services;
using Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
	[Route("api/[controller]")]
    public class TrainerController : Controller
    {
        private readonly TrainerService _trainerService;

        public TrainerController(TrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet("getTrainers")]
        public IList<UserData> GetTrainers()
        {
            return _trainerService.GetTrainers();
        }
    }
}
