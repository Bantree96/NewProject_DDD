using NewProject.Application.Interfaces.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Application.Interfaces
{
	public interface IIOManager : IService
	{
		void Run();
	}
}
