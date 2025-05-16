using NewProject.Domain.Entities.Services;
using NewProject.Domain.Events.Bootstrap;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;

namespace NewProject.UI.Windows.Splash
{
	public class SplashWindowViewModel : BindableBase
	{
		IEventAggregator _eventAggregator;

		private string _message;

		public string Message { get => _message; set => SetProperty(ref _message,value); }
		public SplashWindowViewModel(IContainerProvider container)
		{
			_eventAggregator = container.Resolve<IEventAggregator>();
			_eventAggregator.GetEvent<BootstrapEvent>().Subscribe(OnServiceLoaded, ThreadOption.UIThread, false);
		}

		private void OnServiceLoaded(BootstrapInfo info)
		{
			Message = info.Name;
		}
	}
}
