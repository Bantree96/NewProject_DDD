using NewProject.Application.Events.Setting;
using NewProject.Domain.Entities.Settings;
using NewProject.Domain.Interfaces.Repository;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Application.UseCasese.Setting
{
	public class SaveSettingUseCase
	{
		private readonly IEventAggregator _eventAggregator;
		private readonly ISettingRepository _settingRepository;

		public SaveSettingUseCase(ISettingRepository sr, IEventAggregator ea)
		{
			_settingRepository = sr;
			_eventAggregator = ea;

		}

		public void Execute(AppSetting entity)
		{
			_settingRepository.Save(entity);
			
			_eventAggregator.GetEvent<AppSettingSavedEvent>().Publish();

		}
	}
}
