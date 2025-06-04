using NewProject.Domain.Entities.Settings;
using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UI.Dialogs.Setting.ViewModels
{
	public class SettingDialogViewModel : IDialogAware
	{
		private IRegionManager _regionManager;
		public AppSetting AppSettings { get; set; }

		public ICommand AppSettingCommand => new DelegateCommand(OnShowAppSettingView);
		public ICommand InspectionSettingCommand => new DelegateCommand(OnShowInspectionSettingView);


		public SettingDialogViewModel(IContainerProvider container)
		{
			_regionManager = container.Resolve<IRegionManager>();

		}
		private void OnShowInspectionSettingView()
		{
			_regionManager.RequestNavigate("SettingRegion", "InspectionSettingView");
		}

		private void OnShowAppSettingView()
		{
			_regionManager.RequestNavigate("SettingRegion", "AppSettingView");
		}

		#region IDialogAware
		public string Title => "Setting";

		public event Action<IDialogResult> RequestClose;

		public bool CanCloseDialog() => true;

		public void OnDialogClosed() { }

		public void OnDialogOpened(IDialogParameters parameters) 
		{
			// TODO : App Setting Init
			_regionManager.RequestNavigate("SettingRegion", "AppSettingView");

		}

		#endregion
	}
}
