using NewProject.Application.Interfaces;
using NewProject.Application.Interfaces.Bootstrap;
using NewProject.Modules;
using NewProject.UI.Dialogs;
using NewProject.UI.Views.MainMenu;
using NewProject.UI.Windows.Main;
using NewProject.UI.Windows.Splash;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using System.Threading.Tasks;
using System.Windows;

namespace NewProject.Bootstrap
{
	public class AppBootstrapper : PrismBootstrapper
	{
		// 3
		protected override DependencyObject CreateShell()
		{
			InitializeModules();
			
			// 먼저 Resolve된 Window를 MainWindow로 생각함
			var mainWindow = Container.Resolve<MainWindow>();

			Splash();
			return mainWindow;
		}

		// 1
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<IBootstrapManager, BootstrapManager>();

			containerRegistry.RegisterForNavigation<MainMenuView, MainMenuViewModel>();


			containerRegistry.RegisterDialog<SettingDialog, SettingDialogViewModel>();
		}

		// 2 
		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<CameraModule>();
			moduleCatalog.AddModule<IOModule>();

			base.ConfigureModuleCatalog(moduleCatalog);
		}

		// 0
		protected override void ConfigureViewModelLocator()
		{
			base.ConfigureViewModelLocator();

			ViewModelLocationProvider.Register<SplashWindow, SplashWindowViewModel>();
		}

		protected override void InitializeModules()
		{
			base.InitializeModules();
		}
		private async void Splash()
		{
			var splashwindow = Container.Resolve<SplashWindow>();
			splashwindow.Show();

			var bootstrapManager = Container.Resolve<IBootstrapManager>();
			var taskresult =  Task.Run(() =>
			{
				bootstrapManager.Init();
			});

			Task.WaitAll(taskresult);

			splashwindow.Close();
		}
	}
}
