using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Domain.Entities.Services
{
	public class BootstrapInfo
	{
		public string Name { get; }
		public double Progress { get; }

		public BootstrapInfo(string name, double progress)
		{
			Name = name;
			Progress = progress;
		}
	}
}
