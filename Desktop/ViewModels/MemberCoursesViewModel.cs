// Code written by Balana Ovidiu
using Common;
using Desktop.Helpers;
using Desktop.Services;
using Desktop.Views;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Linq;

namespace Desktop.ViewModels
{
	public class MemberCoursesViewModel : AbstractViewModel
    {
        #region Private members
        private readonly MemberService _memberService;
		#endregion


		#region Commands
		public DelegateCommand SaveCommand { get; }
		public DelegateCommand BackToMainMenuCommand { get; }
		#endregion


		#region ctor
		public MemberCoursesViewModel(MemberService memberService) : base()
        {
            _memberService = memberService;

			LoadCourses();

            SaveCommand = new DelegateCommand(Save);
			BackToMainMenuCommand = new DelegateCommand(BackToMainMenu);
        }
		#endregion


		#region Properties
		private ObservableCollection<CourseData> _courses;
        public ObservableCollection<CourseData> Courses
        {
            get => _courses;
            set => ChangeAndNotify(ref _courses, value);
		}

		private string _message;
		public string Message
		{
			get => _message;
			set => ChangeAndNotify(ref _message, value);
		}
		#endregion


		#region Private Methods
		private void BackToMainMenu()
		{
			RegionManager.Load<MainMenu>();
		}

		private async void Save()
        {
            await _memberService.SaveAsync(Courses.ToList(), CurrentUser.UserData.MemberId);
			Message = "Success!";
		}

        private async void LoadCourses()
        {
            var courses = await _memberService.GetCoursesAsync(CurrentUser.UserData.MemberId);
			var approvedCourses = courses.Where(c => c.IsApproved).ToList();

			if (approvedCourses != null)
			{
				Courses = new ObservableCollection<CourseData>(approvedCourses);
			}
        }
        #endregion
    }
}
