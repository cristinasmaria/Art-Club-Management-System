// Code written by Savescu Razvan
using Desktop.Views;

namespace Desktop.ViewModels
{
	public class MainWindowViewModel : AbstractViewModel
	{
		public MainWindowViewModel()
		{
			RegionManager.RegisterView<Login>();
		}
	}
}
