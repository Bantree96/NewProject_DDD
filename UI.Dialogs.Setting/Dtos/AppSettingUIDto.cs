﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Dialogs.Setting.Dtos
{
	public class AppSettingUIDto : BindableBase
	{
		private string _title;
		public string Title { get => _title ; set => SetProperty(ref _title, value); }

	}
}
