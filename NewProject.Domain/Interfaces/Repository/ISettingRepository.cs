using NewProject.Domain.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Interfaces.Repository
{
	public interface ISettingRepository
	{
		Settings LoadAll();
		T Load<T>() where T : class, new();

		void SaveAll(Settings settings);
		void Save<T>(T settings);

	}
}
