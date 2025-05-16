using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Application.Interfaces.Bootstrap
{
	public interface IBootstrapManager
	{
		void Add(IService service);

		void Init();
	}
}
