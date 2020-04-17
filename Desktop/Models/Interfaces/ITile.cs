// Code written by Balana Ovidiu
using Prism.Commands;

namespace Desktop.Models.Interfaces
{
	public interface ITile
	{
		string DisplayText { get; set; }

		DelegateCommandBase Command { get; set; }

		bool IsVisible { get; set; }
	}
}
