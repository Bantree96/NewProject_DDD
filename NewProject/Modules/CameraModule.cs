using NewProject.Application.Interfaces;
using NewProject.Application.Interfaces.Bootstrap;
using NewProject.Infratructure.Cameras;
using Prism.Ioc;
using Prism.Modularity;

namespace NewProject.Modules
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
