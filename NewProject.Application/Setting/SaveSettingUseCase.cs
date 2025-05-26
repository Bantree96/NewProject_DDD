using NewProject.Domain.Entities.Settings;
using NewProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Application.Setting
{
	public class SaveSettingUseCase
	{
		private readonly ISettingRepository _settingRepository;

		public SaveSettingUseCase(ISettingRepository sr)
		{
			_settingRepository = sr;
		}

		public void Execute(AppSettings entity)
		{
			_settingRepository.Save(entity);
		}
	}
}
