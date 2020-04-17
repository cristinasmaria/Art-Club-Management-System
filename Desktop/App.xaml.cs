using System.Windows;
using CommonServiceLocator;
using Desktop.Helpers;
using Desktop.Models;
using Desktop.Services;
using Desktop.Views;
using Prism.Ioc;
using Prism.Unity;

namespace Desktop
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : PrismApplication
	{
		protected override Window CreateShell()
		{
			return ServiceLocator.Current.GetInstance<MainWindow>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<ApiConnector>();
			containerRegistry.RegisterSingleton<AppRegionManager>();
			containerRegistry.RegisterSingleton<UserService>();
			containerRegistry.RegisterSingleton<CurrentUser>();
            containerRegistry.RegisterSingleton<MemberService>();

            containerRegistry.RegisterForNavigation<Login>(nameof(Login));
			containerRegistry.RegisterForNavigation<Register>(nameof(Register));
			containerRegistry.RegisterForNavigation<MainMenu>(nameof(MainMenu));
            containerRegistry.RegisterForNavigation<MemberCourses>(nameof(MemberCourses));
            containerRegistry.RegisterForNavigation<CreateCourse>(nameof(CreateCourse));
            containerRegistry.RegisterForNavigation<Requests>(nameof(Requests));
			containerRegistry.RegisterForNavigation<PromoteUsers>(nameof(PromoteUsers));
			containerRegistry.RegisterForNavigation<EditMembers>(nameof(EditMembers));
		}
	}
}
