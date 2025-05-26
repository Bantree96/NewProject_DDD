using NewProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewProject.Infratructure.IOs
{
	public class IOManager : IIOManager
	{
		public string Name => "IO";

		public IOManager()
		{

		}

		public void Init()
		{
			// 작업 Event

			// init 작업
			Thread.Sleep(1000);

		}

		public void Run()
		{
		}
	}
}
