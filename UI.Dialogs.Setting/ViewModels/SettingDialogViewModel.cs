using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Dialogs.Setting.ViewModels
{
	public class SettingDialogViewModel : IDialogAware
	{
		#region IDialogAware
		public string Title => "Setting";

		public event Action<IDialogResult> RequestClose;

		public bool CanCloseDialog() => true;

		public void OnDialogClosed() { }

		public void OnDialogOpened(IDialogParameters parameters) { }

		#endregion
	}
}
