// Code written by Savescu Razvan
using System;
using API.Models;

namespace API.Helpers
{
	public static class DefaultUserMethods
	{
		public static Member CreateDefaultMember(int userId)
		{
			return new Member
			{
				MonthlyPayment = 30.0m,
				TotalActualPayment = 90.0m,
				TotalNeededPayment = 120.0m,
				UserId = userId
			};
		}

		public static Trainer CreateDefaultTrainer(int userId)
		{
			return new Trainer
			{
				UserId = userId
			};
		}

		public static Admin CreateDefaultAdmin(int userId)
		{
			return new Admin
			{
				UserId = userId
			};
		}
	}
}
