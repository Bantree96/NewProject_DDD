using NewProject.Application.Interfaces;

namespace NewProject.Application.Logics
{
	public class MainLogic
	{
		private IIOManager _ioManager;
		private ICameraManager _cameraManager;
		public MainLogic(ICameraManager cm, IIOManager im)
		{
			_cameraManager = cm;
			_ioManager = im;
		}

		public void Run()
		{
			if(_cameraManager.IsConnected)
			{
				_cameraManager.Run();
				_ioManager.Run();
			}
		}
	}
}
