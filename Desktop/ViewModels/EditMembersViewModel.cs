// Code written by Balana Ovidiu
using System.Collections.ObjectModel;
using System.Linq;
using Common;
using Desktop.Services;
using Desktop.Views;
using Prism.Commands;

namespace Desktop.ViewModels
{
	public class EditMembersViewModel : AbstractViewModel
	{
		private readonly MemberService _memberService;

		public DelegateCommand BackToMainMenuCommand { get; }
		public DelegateCommand SaveCommand { get; }

		private string _message;
		public string Message
		{
			get => _message;
			set => ChangeAndNotify(ref _message, value);
		}

		private ObservableCollection<MemberData> _members;
		public ObservableCollection<MemberData> Members
		{
			get => _members;
			set => ChangeAndNotify(ref _members, value);
		}

		public EditMembersViewModel(MemberService memberService)
		{
			_memberService = memberService;

			LoadMembers();

			BackToMainMenuCommand = new DelegateCommand(BackToMainMenu);
			SaveCommand = new DelegateCommand(UpdateMembers);
		}

		private async void UpdateMembers()
		{
			await _memberService.UpdateMembersAsync(Members.ToList());
			Message = "Success!";
		}

		private async void LoadMembers()
		{
			var members = await _memberService.GetAllMembersAsync();
			if (members != null)
			{
				Members = new ObservableCollection<MemberData>(members);
			}
		}

		private void BackToMainMenu()
		{
			RegionManager.Load<MainMenu>();
		}
	}
}
