// Code written by Streata Alexandra
using Common;
using Desktop.Helpers;
using Desktop.Models.Interfaces;
using Desktop.Services;
using Desktop.Views;
using Prism.Commands;

namespace Desktop.ViewModels
{
	public class RegisterViewModel : AbstractViewModel
	{
		private readonly UserService _userService;

		public DelegateCommand<IRegisterCredentials> RegisterCommand { get; }

		private string _message;
		public string Message
		{
			get => _message;
			set => ChangeAndNotify(ref _message, value);
		}

		public RegisterViewModel(UserService userService)
		{
			_userService = userService;

			RegisterCommand = new DelegateCommand<IRegisterCredentials>(Register);
		}

		private async void Register(IRegisterCredentials credentials)
		{
			if (credentials != null)
			{
				if (!string.IsNullOrWhiteSpace(credentials.UserName) && !string.IsNullOrWhiteSpace(credentials.Email) && credentials.Age != null)
				{
					var passwordHash = PasswordCryptor.EncryptPassword(credentials.Password);
					var confirmPasswordHash = PasswordCryptor.EncryptPassword(credentials.ConfirmPassword);

					if (passwordHash != null && passwordHash == confirmPasswordHash)
					{
						var success = await _userService.RegisterAsync(new UserData
						{
							Username = credentials.UserName,
							PasswordHash = passwordHash,
							FullName = credentials.FullName,
							Email = credentials.Email,
							Age = credentials.Age,
							Address = credentials.Address,
							TelephoneNr = credentials.TelephoneNr
						});

						if (success)
						{
							RegionManager.Load<Login>();
						}
						else
						{
							Message = "Username already exists!";
						}
					}
					else
					{
						if (passwordHash != null)
						{
							Message = "Passwords do not match!";
						}
						else
						{
							Message = "Password cannot be empty!";
						}
					}
				}
				else
				{
					if (string.IsNullOrWhiteSpace(credentials.UserName))
					{
						Message = "Username cannot be empty!";
					}
					else if (string.IsNullOrWhiteSpace(credentials.Email))
					{
						Message = "Email cannot be empty!";
					}
					else
					{
						Message = "Wrong age format!";
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
