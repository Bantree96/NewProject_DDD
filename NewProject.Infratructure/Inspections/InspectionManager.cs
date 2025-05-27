using NewProject.Application.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewProject.Infratructure.Inspections
{
	public class InspectionManager : IInspectionManager
	{
		public string Name => "Inspection";

		public void Init()
		{
			Thread.Sleep(1000);
		}
	}
}
