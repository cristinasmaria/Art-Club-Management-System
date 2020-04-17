// Code written by Popescu Cristina
using System.Collections.ObjectModel;
using System.Linq;
using Common;
using Desktop.Services;
using Desktop.Views;
using Prism.Commands;

namespace Desktop.ViewModels
{
	public class PromoteUsersViewModel : AbstractViewModel
	{
		private readonly UserService _userService;

		private ObservableCollection<UserData> _users;
		public ObservableCollection<UserData> Users
		{
			get => _users;
			set => ChangeAndNotify(ref _users, value);
		}

		private int _selectedUserId;
		public int SelectedUserId
		{
			get => _selectedUserId;
			set => ChangeAndNotify(ref _selectedUserId, value);
		}

		public DelegateCommand BackToMainMenuCommand { get; }
		public DelegateCommand<string> SetRoleCommand { get; }

		public PromoteUsersViewModel(UserService userService)
		{
			_userService = userService;

			RetrieveAllUsers();

			BackToMainMenuCommand = new DelegateCommand(BackToMainMenu);
			SetRoleCommand = new DelegateCommand<string>(SetRole);
		}

		private async void SetRole(string newRole)
		{
			var userData = Users.FirstOrDefault(u => u.UserId == SelectedUserId);
			userData.NewUserRole = newRole;

			var roleChanged = await _userService.SetUserRoleAsync(userData);

			if (roleChanged)
			{
				userData.UserRole = newRole;
				userData.NewUserRole = null;
			}
		}

		private async void RetrieveAllUsers()
		{
			var users = await _userService.GetAllUsersAsync();
			if (users != null)
			{
				Users = new ObservableCollection<UserData>(users);
			}
		}

		private void BackToMainMenu()
		{
			RegionManager.Load<MainMenu>();
		}
	}
}
