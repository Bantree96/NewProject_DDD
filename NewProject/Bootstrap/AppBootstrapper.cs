﻿using NewProject.Application.Interfaces.Bootstrap;
using NewProject.Modules;
using NewProject.UI.Dialogs;
using NewProject.UI.Views.MainMenu;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using UI.Windows.MainWindow.Views;
using UI.Windows.SplashWindow.ViewModels;
using UI.Windows.SplashWindow.Views;

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
		
		private void Splash()
		{
			var splashwindow = Container.Resolve<SplashWindow>();
			splashwindow.Show();

			var bootstrapManager = Container.Resolve<IBootstrapManager>();
			var taskresult = Task.Run(() =>
			{
				bootstrapManager.Init();
			});

			DispatcherFrame frame = new DispatcherFrame();

			taskresult.ContinueWith(_ =>
			{
				// Init이 끝났을 때 메시지 루프 빠져나오게
				frame.Continue = false;
			}, TaskScheduler.FromCurrentSynchronizationContext()); // 반드시 UI Thread에서 실행되도록

			// 메시지 루프 유지 (MainThread가 여기서 대기하면서 UI 렌더링 유지)
			Dispatcher.PushFrame(frame);

			splashwindow.Close();
		}
	}
}
