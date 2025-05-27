using NewProject.Application.Interfaces.Bootstrap;

namespace NewProject.Application.Interfaces
{
	public interface ICameraManager : IService
	{
		bool IsConnected { get; set; }
		void Run();
		
	}
}
