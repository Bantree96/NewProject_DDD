using NewProject.Application.Entities.Services;
using NewProject.Application.Events.Bootstrap;
using NewProject.Application.Interfaces.Bootstrap;
using Prism.Events;
using Prism.Ioc;
using System;
using System.Collections.Generic;

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
				int value = CalcBootstrapCount(Services.Count);
				_eventAggregator.GetEvent<BootstrapProgressEvent>().Publish(new BootstrapInfo(service.Key,value));
				service.Value.Init();
			}
		}


		private int CalcBootstrapCount(int moduleCounts)
		{
			if (_count == 0 || moduleCounts == 0) throw new DivideByZeroException();
			int value = (int)((_count / (double)moduleCounts) * 100);
			_count++;

			return value;
		}

	}
}
