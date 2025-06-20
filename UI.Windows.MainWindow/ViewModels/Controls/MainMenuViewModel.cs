﻿using Prism.Commands;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UI.Windows.MainWindow.ViewModels.Controls
{
	public class MainMenuViewModel
	{
		private IDialogService _dialogService;

		public ICommand ShowSettingDialogCommand => new DelegateCommand(OnShowSettingDialogCommand);

		public MainMenuViewModel(IContainerProvider container)
		{
			_dialogService = container.Resolve<IDialogService>();
		}
		private void OnShowSettingDialogCommand()
		{
			_dialogService.ShowDialog("SettingDialog");
		}
	}
}
