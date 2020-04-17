using System.Security;
using System.Windows.Controls;
using Desktop.Models.Interfaces;

namespace Desktop.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class Login : UserControl, ILoginCredentials
	{
		public Login()
		{
			InitializeComponent();
		}

		string ILoginCredentials.UserName => UserName.Text;
		SecureString ILoginCredentials.UserPassword => UserPassword.SecurePassword;
	}
}
