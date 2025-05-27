using NewProject.Application.Interfaces;
using NewProject.Application.Interfaces.Bootstrap;
using Prism.Ioc;
using Prism.Modularity;

namespace NewProject.Infratructure.Cameras.Modules
{
	public class CameraModule : IModule
	{
		public void OnInitialized(IContainerProvider containerProvider)
		{
			var bootstrapManager = containerProvider.Resolve<IBootstrapManager>();
			bootstrapManager.Add(containerProvider.Resolve<ICameraManager>());
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterSingleton<ICameraManager, CameraManager>();
		}

	}
}
