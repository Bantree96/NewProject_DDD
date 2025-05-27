using NewProject.Application.Entities.Services;
using Prism.Events;

namespace NewProject.Application.Events.Bootstrap
{
	public class BootstrapProgressEvent : PubSubEvent<BootstrapInfo> { }
}
