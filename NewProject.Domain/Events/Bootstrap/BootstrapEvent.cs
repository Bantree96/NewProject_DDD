using NewProject.Domain.Entities.Services;
using Prism.Events;

namespace NewProject.Domain.Events.Bootstrap
{
	public class BootstrapEvent : PubSubEvent<BootstrapInfo> { }
}
