using NewProject.Application.Interfaces;
using NewProject.Application.Interfaces.Bootstrap;
using Prism.Ioc;
using Prism.Modularity;

namespace NewProject.Infratructure.IOs.Modules
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
