using Prism.Commands;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Shared.Constants;

namespace UI.Windows.MainWindow.ViewModels
{
	public class MainWindowViewModel
	{
		private IRegionManager _regionManager;

		public MainWindowViewModel(IContainerProvider container)
		{
			_regionManager = container.Resolve<IRegionManager>();

			_regionManager.RegisterViewWithRegion(RegionNames.MainMenuRegion, ViewNames.MainMenuView);
		}
	}
}
