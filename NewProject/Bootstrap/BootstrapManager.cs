using NewProject.Application.Interfaces.Bootstrap;
using NewProject.Domain.Entities.Services;
using NewProject.Domain.Events.Bootstrap;
using Prism.Events;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Bootstrap
{
	public class BootstrapManager : IBootstrapManager
	{
		private IEventAggregator _eventAggregator;

		private int _count = 1;

		public Dictionary<string, IService> Services = new Dictionary<string, IService>();
		public BootstrapManager(IContainerProvider container)
		{
			_eventAggregator = container.Resolve<IEventAggregator>();
		}

		public void Add(IService service)
		{
			Services.Add(service.Name, service);
		}

		public void Init()
		{
			foreach(var service in Services)
			{
				double value = CalcBootstrapCount(Services.Count);
				_eventAggregator.GetEvent<BootstrapEvent>().Publish(new BootstrapInfo(service.Key,value));
				service.Value.Init();
			}
		}


		private double CalcBootstrapCount(int maxCount)
		{
			if (_count == 0 || maxCount == 0) throw new DivideByZeroException();
			double value = _count / maxCount;
			_count++;

			return value;
		}

	}
}
