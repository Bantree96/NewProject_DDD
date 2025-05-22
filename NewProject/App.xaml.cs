using NewProject.Bootstrap;
using System.Windows;
namespace NewProject
{
	/// <summary>
	/// App.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class App : System.Windows.Application
	{
		

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var bootstrapper = new AppBootstrapper();
			bootstrapper.Run();
		}
	}
}
