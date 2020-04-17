// Code written by Balana Ovidiu
using API.Models;
using Common;

namespace API.Helpers
{
	public static class MemberExtensions
	{
		public static MemberData ToMemberData(this Member member)
		{
			return new MemberData
			{
				MemberId = member.MemberId,
				UserId = member.UserId,
				FullName = member.User.FullName,
				Email = member.User.Email,
				MonthlyPayment = member.MonthlyPayment,
				TotalActualPayment = member.TotalActualPayment,
				TotalNeededPayment = member.TotalNeededPayment
			};
		}

		public static void UpdateData(this Member member, MemberData memberData)
		{
			member.MonthlyPayment = memberData.MonthlyPayment;
			member.TotalActualPayment = memberData.TotalActualPayment;
			member.TotalNeededPayment = memberData.TotalNeededPayment;
		}
	}
}
