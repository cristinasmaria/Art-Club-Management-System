using System;
using System.Security;
using System.Windows.Controls;
using Desktop.Models.Interfaces;

namespace Desktop.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class Register : UserControl, IRegisterCredentials
	{
		public Register()
		{
			InitializeComponent();
		}

		string IRegisterCredentials.UserName => UserName.Text;

		public SecureString Password => UserPassword.SecurePassword;

		SecureString IRegisterCredentials.ConfirmPassword => ConfirmPassword.SecurePassword;

		string IRegisterCredentials.FullName => FullName.Text;

		string IRegisterCredentials.Email => Email.Text;

		int? IRegisterCredentials.Age
		{
			get
			{
				try
				{
					return Convert.ToInt32(Age.Text);
				}
				catch
				{
					return null;
				}
			}
		}

		string IRegisterCredentials.Address => Address.Text;

		string IRegisterCredentials.TelephoneNr => TelephoneNr.Text;
	}
}