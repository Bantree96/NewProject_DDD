using NewProject.Application.Entities.Services;
using NewProject.Application.Events.Bootstrap;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;

namespace UI.Windows.SplashWindow.ViewModels
{
	public class SplashWindowViewModel : BindableBase
	{
		IEventAggregator _eventAggregator;

		private string _message;
		private int _progressValue;

		public string Message { get => _message; set => SetProperty(ref _message,value); }
		public int ProgressValue { get => _progressValue; set => SetProperty(ref _progressValue, value); }
		public SplashWindowViewModel(IContainerProvider container)
		{
			_eventAggregator = container.Resolve<IEventAggregator>();
			_eventAggregator.GetEvent<BootstrapProgressEvent>().Subscribe(OnServiceLoaded);
		}

		private void OnServiceLoaded(BootstrapInfo info)
		{
			System.Windows.Application.Current.Dispatcher.Invoke(() =>
			{
				// UI에 관여하는 하고싶은 작업
				Message = info.Name;
				ProgressValue = info.ProgressValue;
			});
		}
	}
}
