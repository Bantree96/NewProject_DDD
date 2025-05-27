using NewProject.Domain.Entities.Settings;
using NewProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Application.UseCasese.Setting
{
	public class LoadSettingUseCase
	{
		private readonly ISettingRepository _settingRepository;

		public LoadSettingUseCase(ISettingRepository sr)
		{
			_settingRepository = sr;

		}

		public AppSettings Execute()
		{
			var entity = _settingRepository.Load();
			return new AppSettings
			{
				Title = entity.Title
			};
		}
	}
}
