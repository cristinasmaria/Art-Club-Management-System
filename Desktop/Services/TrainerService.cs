// Code written by Streata Alexandra
using Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desktop.Services
{
	public class TrainerService
    {
        private readonly ApiConnector _apiConnector;

        public TrainerService(ApiConnector apiConnector)
        {
            _apiConnector = apiConnector;
        }

        public async Task<IList<UserData>> GetTrainersAsync()
        {
            return await _apiConnector.GetAsync<IList<UserData>>($"trainer/getTrainers");
        }
    }
}
