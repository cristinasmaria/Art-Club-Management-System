// Code written by Savescu Razvan
using System.Security;

namespace Desktop.Models.Interfaces
{
	public interface ILoginCredentials
	{
		string UserName { get; }
		SecureString UserPassword { get; }
	}
}
