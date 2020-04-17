// Code written by Streata Alexandra
using System.Security;

namespace Desktop.Models.Interfaces
{
	public interface IRegisterCredentials
	{
		string UserName { get; }
		SecureString Password { get; }
		SecureString ConfirmPassword { get; }
		string FullName { get; }
		string Email { get; }
		int? Age { get; }
		string Address { get; }
		string TelephoneNr { get; }
	}
}