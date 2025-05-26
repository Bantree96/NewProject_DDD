using NewProject.Domain.Entities.Settings;
using NewProject.Domain.Interfaces.Repository;
using NewProject.Infratructure.Dtos.Settings;
using NewProject.Infratructure.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Infratructure.Setting
{
	public class JsonSettingRepository : ISettingRepository
	{
		private readonly string _filePath;
		private readonly string _directoryPath;

		public JsonSettingRepository()
		{
			_directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),Assembly.GetEntryAssembly().GetName().Name);
			_filePath = Path.Combine(_directoryPath, "AppSetting.Json");
		}

		public AppSettings Load()
		{
			return JsonParser.Load<AppSettings>(_filePath);
		}

		public void Save(AppSettings entity)
		{
			var model = new AppSettingSaveDto()
			{
				Title = entity.Title
			};

			JsonParser.Save(model, _directoryPath, _filePath);
		}
	}
}
