// Code written by Savescu Razvan
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Services;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	public class UserController : Controller
	{
		private readonly UserService _userService;

		public UserController(UserService userService)
		{
			_userService = userService;
		}

		[HttpPost("login")]
		public ActionResult<UserData> Login([FromBody]LoginData loginData)
		{
			if (loginData == null)
			{
				return null;
			}

			return _userService.RetrieveUserData(loginData);
		}

		[HttpPost("register")]
		public async Task<ActionResult<bool>> Register([FromBody]UserData userData)
		{
			if (userData == null)
			{
				return false;
			}

			return await _userService.RegisterAsync(userData);
		}

		[HttpGet("getAllUsers")]
		public IList<UserData> GetAllUsers()
		{
			return _userService.GetAllUsers();
		}

		[HttpPost("setRole")]
		public async Task<ActionResult<bool>> SetRole([FromBody]UserData userData)
		{
			if (userData == null)
			{
				return BadRequest(false);
			}

			return Ok(await _userService.SetNewRole(userData));
		}
	}
}
