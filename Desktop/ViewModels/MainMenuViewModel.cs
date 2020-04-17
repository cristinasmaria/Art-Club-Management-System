// Code written by Savescu Razvan
using System.Collections.Generic;
using Desktop.Models;
using Desktop.Models.Interfaces;
using Desktop.Views;

namespace Desktop.ViewModels
{
	public class MainMenuViewModel : AbstractViewModel
	{
		public List<ITile> Tiles { get; }

		public MainMenuViewModel()
		{
			Tiles = new List<ITile>
			{
				new TileModel("Go back to login", BackToLogin),
                new TileModel("View courses", LoadMemberCoursesView, CurrentUser.IsMember),
                new TileModel("Create course", LoadCreateCourseView, CurrentUser.IsTrainer || CurrentUser.IsAdmin),
                new TileModel("View requests for new courses and events", LoadRequestsView, CurrentUser.IsAdmin),
				new TileModel("Change users role", LoadChangeUsersRoleView, CurrentUser.IsAdmin),
				new TileModel("Edit members", LoadEditMembersView, CurrentUser.IsAdmin),
			};
		}

		private void LoadEditMembersView()
		{
			RegionManager.Load<EditMembers>();
		}

		private void LoadChangeUsersRoleView()
		{
			RegionManager.Load<PromoteUsers>();
		}

		private void LoadMemberCoursesView()
        {
            RegionManager.Load<MemberCourses>();
        }

        private void LoadCreateCourseView()
        {
            RegionManager.Load<CreateCourse>();
        }

        private void LoadRequestsView()
        {
            RegionManager.Load<Requests>();
		}

		public void BackToLogin()
		{
			RegionManager.Load<Login>();
		}
	}
}
