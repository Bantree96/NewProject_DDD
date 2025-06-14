﻿using NewProject.Application.Interfaces;
using Prism.Events;
using Prism.Ioc;
using System.Threading;

namespace NewProject.Infratructure.Cameras
{
	public class CameraManager : ICameraManager
	{
		private IEventAggregator _eventAggregator;
		public bool IsConnected { get; set; }

		public string Name => "Camera";

		public CameraManager(IContainerProvider container)
		{
			_eventAggregator = container.Resolve<IEventAggregator>();

		}

		public void Run()
		{
		}

		public void Init()
		{
			Thread.Sleep(1000);

			IsConnected = true;
		}
	}
}
