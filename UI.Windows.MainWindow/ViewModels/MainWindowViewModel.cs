using NewProject.Application.Events.Setting;
using NewProject.Application.UseCasese.Setting;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Shared.Constants;
using UI.Windows.MainWindow.Dtos;

namespace UI.Windows.MainWindow.ViewModels
{
	public class MainWindowViewModel : BindableBase
	{
		private readonly IRegionManager _regionManager;
		private readonly IEventAggregator _eventAggregator;

		private readonly LoadSettingUseCase _loadSettingUseCase;
		private MainWindowUIDto _mainWindowUIDto;

		public MainWindowUIDto MainWindowUIDto { get => _mainWindowUIDto; set => SetProperty(ref _mainWindowUIDto, value); }
		
		public MainWindowViewModel(IContainerProvider container, LoadSettingUseCase loadSettingUseCase)
		{
			_regionManager = container.Resolve<IRegionManager>();

			_regionManager.RegisterViewWithRegion(RegionNames.MainMenuRegion, ViewNames.MainMenuView);
			_regionManager.RegisterViewWithRegion(RegionNames.ControlBarRegion, ViewNames.ControlBarView);
			_regionManager.RegisterViewWithRegion(RegionNames.InspectBarRegion, ViewNames.InspectBarView);

			_eventAggregator = container.Resolve<IEventAggregator>();
			_eventAggregator.GetEvent<AppSettingSavedEvent>().Subscribe(OnSettingSaved,ThreadOption.UIThread,false);
			
			_loadSettingUseCase = loadSettingUseCase;
			SettingLoad();
		}

		private void OnSettingSaved()
		{
			SettingLoad();
		}

		private void SettingLoad()
		{
			var entity = _loadSettingUseCase.Execute();
			MainWindowUIDto = new MainWindowUIDto()
			{
				Title = entity.Title
			};
		}


	}
}
