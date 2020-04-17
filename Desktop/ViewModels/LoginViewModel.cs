// Code written by Savescu Razvan
using Common;
using Desktop.Helpers;
using Desktop.Models;
using Desktop.Models.Interfaces;
using Desktop.Services;
using Desktop.Views;
using Prism.Commands;

namespace Desktop.ViewModels
{
	public class LoginViewModel : AbstractViewModel
	{
		private readonly UserService _userService;

		public DelegateCommand<ILoginCredentials> LoginCommand { get; }
		public DelegateCommand RegisterCommand { get; }

		private string _message;
		public string Message
		{
			get => _message;
			set => ChangeAndNotify(ref _message, value);
		}

		public LoginViewModel(UserService userService)
		{
			_userService = userService;

			LoginCommand = new DelegateCommand<ILoginCredentials>(Login);
			RegisterCommand = new DelegateCommand(Register);
		}

		private void Register()
		{
			RegionManager.Load<Register>();
		}

		private async void Login(ILoginCredentials credentials)
		{
			if (credentials != null)
			{
				var username = credentials.UserName;
				string passwordHash = string.Empty;

				try
				{
					passwordHash = PasswordCryptor.EncryptPassword(credentials.UserPassword);
				}
				catch
				{
					// ignore
				}

				if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(passwordHash))
				{
					var userData = await _userService.LoginAsync(new LoginData
					{
						Username = username,
						PasswordHash = passwordHash
					});

					CurrentUser.UserData = userData;

					if (userData != null)
					{
						RegionManager.Load<MainMenu>();
					}
					else
					{
						Message = "Wrong credentials!";
					}
				}
				else
				{
					if (!string.IsNullOrWhiteSpace(username))
					{
						Message = "Password cannot be empty!";
					}
					else
					{
						Message = "Username cannot be empty!";
					}
				}
			}
			else
			{
				Message = "Invalid credentials!";
			}
		}
	}
}
