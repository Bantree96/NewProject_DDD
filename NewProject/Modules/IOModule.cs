using NewProject.Application.Interfaces;
using NewProject.Application.Interfaces.Bootstrap;
using NewProject.Infratructure.IOs;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Modules
{
	public class IOModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var bootstrapManager = containerProvider.Resolve<IBootstrapManager>();
			bootstrapManager.Add(containerProvider.Resolve<IIOManager>());
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<IIOManager, IOManager>();

		}
	}
}
