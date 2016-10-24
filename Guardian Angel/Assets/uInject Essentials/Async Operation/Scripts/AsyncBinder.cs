using Async.Impl;
using Ninject.Unity;

namespace Async
{
	public class AsyncBinder : BinderMono
	{
		public override void Bind(Ninject.Syntax.IBindingRoot binding)
		{
			binding.Bind<AsyncOperationFactory>().To<AsyncOperationFactoryImpl>().InSingletonScope();
		}
	}
}