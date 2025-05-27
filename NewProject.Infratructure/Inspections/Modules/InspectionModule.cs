using NewProject.Application.Interfaces.Bootstrap;
using NewProject.Application.Interfaces.Managers;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Infratructure.Inspections.Modules
{
	public class InspectionModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var bootstrapManager = containerProvider.Resolve<IBootstrapManager>();
			bootstrapManager.Add(containerProvider.Resolve<IInspectionManager>());
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<IInspectionManager, InspectionManager>();
		}

	}
}
