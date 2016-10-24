using Events.Impl;
using Ninject.Unity;
using Ninject.Unity.Provider;

namespace Events
{
	public class EventBinder : BinderMono
	{
		public override void Bind(Ninject.Syntax.IBindingRoot binding)
		{
			binding.Bind<EventDispatcher>().ToProvider<GameObjectProvider<EventDispatcherImpl>>().InSingletonScope();
		}
	}
}