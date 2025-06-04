using NewProject.Domain.Entities.Settings;
using NewProject.Domain.Interfaces.Repository;
using NewProject.Infratructure.Dtos.Settings;
using NewProject.Infratructure.Utils;
using System;
using System.IO;
using System.Reflection;

namespace NewProject.Infratructure.Setting
{
	public class JsonSettingRepository : ISettingRepository
	{
		private readonly string _directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Assembly.GetEntryAssembly().GetName().Name);

		public JsonSettingRepository()
		{
			//_filePath = Path.Combine(_directoryPath, "AppSetting.Json");
		}

		public T Load<T>() where T : class, new()
		{
			return JsonParser.Load<T>(_directoryPath);
		}

		public Settings LoadAll()
		{
			var settings = new Settings();

			var properties = typeof(Settings).GetProperties();

			foreach(var prop in properties)
			{ 
				var type = prop.PropertyType;
				var fileName = $"{type.Name}.json";
				var filePath = Path.Combine(_directoryPath, fileName);

				var method = typeof(JsonParser).GetMethod("Load").MakeGenericMethod(type);
				var value = method.Invoke(null,new object[] { filePath });

				if (value == null)
				{
					value = Activator.CreateInstance(type);
				}

				prop.SetValue(settings, value);
			}

			return settings;
		}

		public void Save<T>(T setting)
		{
			
			//var model = new AppSettingSaveDto()
			//{
			//	Title = entity.Title
			//};

			//JsonParser.Save(model, _directoryPath, _filePath);
		}

		public void SaveAll(Settings settings)
		{
			var properties = typeof(Settings).GetProperties();

			foreach (var prop in properties)
			{
				var domainObj = prop.GetValue(settings);
				if (domainObj == null) continue;

			}
		}
	}
}
