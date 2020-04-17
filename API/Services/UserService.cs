// Code written by Savescu Razvan
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using API.Models;
using Common;

namespace API.Services
{
	public class UserService : AbstractService<User>
	{
		public UserService(UnitOfWork unitOfWork)
			: base(unitOfWork)
		{
		}

		public UserData RetrieveUserData(LoginData loginData)
		{
			var user = _unitOfWork.Users.All().FirstOrDefault(u => u.Username == loginData.Username && u.PasswordHash == loginData.PasswordHash);

			if (user != null)
			{
				var userData = user.ToUserData();
				SetUserRole(userData);
				return userData;
			}

			return null;
		}

		public IList<UserData> GetAllUsers()
		{
			var users = _unitOfWork.Users.All().Select(u => u.ToUserData()).ToList();
			users.ForEach(u => SetUserRole(u));
			return users;
		}

		private void SetUserRole(UserData userData)
		{
			userData.UserRole = UserRoles.Guest;

			var member = _unitOfWork.Members.All().FirstOrDefault(m => m.UserId == userData.UserId);
			var trainer = _unitOfWork.Trainers.All().FirstOrDefault(t => t.UserId == userData.UserId);
			var admin = _unitOfWork.Admins.All().FirstOrDefault(a => a.UserId == userData.UserId);

			if (member != null)
			{
				userData.UserRole = UserRoles.Member;
				userData.MemberId = member.MemberId;
			}
			else if (trainer != null)
			{
				userData.UserRole = UserRoles.Trainer;
				userData.TrainerId = trainer.TrainerId;
			}
			else if (admin != null)
			{
				userData.UserRole = UserRoles.Admin;
				userData.AdminId = admin.AdminId;
			}
		}

		public async Task<bool> SetNewRole(UserData userData)
		{
			if (userData.UserRole == userData.NewUserRole || string.IsNullOrWhiteSpace(userData.NewUserRole))
			{
				return false;
			}

			if (!string.IsNullOrWhiteSpace(userData.UserRole))
			{
				if (userData.UserRole == UserRoles.Member)
				{
					var member = _unitOfWork.Members.All().First(m => m.UserId == userData.UserId);
					_unitOfWork.Members.Delete(member);
				}
				else if (userData.UserRole == UserRoles.Trainer)
				{
					var trainer = _unitOfWork.Trainers.All().First(t => t.UserId == userData.UserId);
					_unitOfWork.Trainers.Delete(trainer);
				}
				else if (userData.UserRole == UserRoles.Admin)
				{
					var admin = _unitOfWork.Admins.All().First(a => a.UserId == userData.UserId);
					_unitOfWork.Admins.Delete(admin);
				}
			}

			if (userData.NewUserRole == UserRoles.Member)
			{
				_unitOfWork.Members.Add(DefaultUserMethods.CreateDefaultMember(userData.UserId));
			}
			else if (userData.NewUserRole == UserRoles.Trainer)
			{
				_unitOfWork.Trainers.Add(DefaultUserMethods.CreateDefaultTrainer(userData.UserId));
			}
			else if (userData.NewUserRole == UserRoles.Admin)
			{
				_unitOfWork.Admins.Add(DefaultUserMethods.CreateDefaultAdmin(userData.UserId));
			}

			await _unitOfWork.SaveChangesAsync();

			return true;
		}

		public async Task<bool> RegisterAsync(UserData userData)
		{
			var user = new User
			{
				Address = userData.Address,
				Age = userData.Age.Value,
				Email = userData.Email,
				FullName = userData.FullName,
				PasswordHash = userData.PasswordHash,
				TelephoneNr = userData.TelephoneNr,
				Username = userData.Username
			};

			if (!UserExists(user))
			{
				await AddAsync(user);
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool UserExists(User entity)
		{
			return _unitOfWork.Users.All().FirstOrDefault(u => u.Username == entity.Username || u.Email == entity.Email) != null;
		}

		public async override Task AddAsync(User entity)
		{
			_unitOfWork.Users.Add(entity);
			await _unitOfWork.SaveChangesAsync();
		}

		public override IQueryable<User> All()
		{
			return _unitOfWork.Users.All();
		}

		public async override Task DeleteAsync(User entity)
		{
			_unitOfWork.Users.Delete(entity);
			await _unitOfWork.SaveChangesAsync();
		}

		public async override Task<User> FindByIdAsync(int? id)
		{
			if (id.HasValue)
			{
				return await _unitOfWork.Users.FindByIdAsync(id.Value);
			}
			else
			{
				return null;
			}
		}

		public async override Task UpdateAsync(User entity)
		{
			_unitOfWork.Users.Update(entity);
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
