// Code written by Streata Alexandra
using API.Models;
using Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class TrainerService : AbstractService<Trainer>
    {
        public TrainerService(UnitOfWork unitOfWork):base(unitOfWork)
        {

        }

        public IList<UserData> GetTrainers()
        {
            var trainers = _unitOfWork.Trainers.All().Include(t => t.User).Select(t => new UserData
            {
                UserId = t.User.UserId,
                Username = t.User.Username,
                TrainerId = t.TrainerId,
                Age = t.User.Age,
                FullName = t.User.FullName,
                UserRole = UserRoles.Trainer,
                Address = t.User.Address,
                TelephoneNr = t.User.TelephoneNr,
                Email = t.User.Email
            }).ToList();

            return trainers;
        }
    }
}
