using NewProject.Application.UseCases.Setting;
using NewProject.Domain.Entities.Settings;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;
using UI.Dialogs.Setting.Dtos;

namespace UI.Dialogs.Setting.ViewModels.Controls
{
	public class AppSettingViewModel : BindableBase, INavigationAware
	{
		private readonly LoadSettingUseCase _loadSettingUseCase;
		private readonly SaveSettingUseCase _saveSettingUseCase;

		private AppSettingUIDto _appSettingUIDto;
		
		public AppSettingUIDto AppSettingUIDto { get => _appSettingUIDto; set => SetProperty(ref _appSettingUIDto, value); }
		public ICommand SaveCommand => new DelegateCommand(OnSave);

		public AppSettingViewModel(LoadSettingUseCase loadSettingUseCase, SaveSettingUseCase saveSettingUseCase)
		{
			_loadSettingUseCase = loadSettingUseCase;
			_saveSettingUseCase = saveSettingUseCase;

			Load();
		}

		
		private void OnSave()
		{
			Save();
		}


		private void Save()
		{
			var entity = new AppSettings
			{
				Title = AppSettingUIDto.Title
			};

			_saveSettingUseCase.Execute(entity);
		}
		private void Load()
		{
			var dto = _loadSettingUseCase.Execute();
			AppSettingUIDto = new AppSettingUIDto
			{
				Title = dto.Title
			};
		}

		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			Load();
		}

		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}
	}
}
