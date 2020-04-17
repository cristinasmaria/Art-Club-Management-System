// Code written by Savescu Razvan
using System.Collections.Generic;
using System.Threading.Tasks;
using Common;

namespace Desktop.Services
{
	public class UserService
	{
		private readonly ApiConnector _apiConnector;

		public UserService(ApiConnector apiConnector)
		{
			_apiConnector = apiConnector;
		}

		public async Task<UserData> LoginAsync(LoginData loginData)
		{
			return await _apiConnector.PostAsync<UserData, LoginData>("user/login", loginData);
		}

		public async Task<bool> RegisterAsync(UserData userData)
		{
			return await _apiConnector.PostAsync<bool, UserData>("user/register", userData);
		}

		public async Task<IList<UserData>> GetAllUsersAsync()
		{
			return await _apiConnector.GetAsync<IList<UserData>>("user/getAllUsers");
		}

		public async Task<bool> SetUserRoleAsync(UserData userData)
		{
			return await _apiConnector.PostAsync<bool, UserData>("user/setRole", userData);
		}
	}
}
