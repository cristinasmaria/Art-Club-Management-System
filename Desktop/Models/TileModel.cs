// Code written by Balana Ovidiu
using System;
using Desktop.Models.Interfaces;
using Prism.Commands;

namespace Desktop.Models
{
	public class TileModel : ITile
	{
		public string DisplayText { get; set; }
		public DelegateCommandBase Command { get; set; }
		public bool IsVisible { get; set; }

		public TileModel(string displayText, Action action, bool isVisible = true)
		{
			DisplayText = displayText;
			Command = new DelegateCommand(action);
			IsVisible = isVisible;
		}
	}

	public class TileModel<T> : ITile
	{
		public string DisplayText { get; set; }
		public DelegateCommandBase Command { get; set; }
		public bool IsVisible { get; set; }

		public TileModel(string displayText, Action<T> action, bool isVisible = true)
		{
			DisplayText = displayText;
			Command = new DelegateCommand<T>(action);
			IsVisible = isVisible;
		}
	}
}
