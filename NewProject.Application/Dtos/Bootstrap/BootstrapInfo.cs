namespace NewProject.Application.Entities.Services
{
	public class BootstrapInfo
	{
		public string Name { get; }
		public int ProgressValue { get; }

		public BootstrapInfo(string name, int progress)
		{
			Name = name;
			ProgressValue = progress;
		}
	}
}
