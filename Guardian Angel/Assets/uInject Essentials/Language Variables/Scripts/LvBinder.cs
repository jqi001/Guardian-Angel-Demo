using Lv.Impl;
using Ninject.Unity;
using Ninject.Unity.Provider;

namespace Lv
{
	public class LvBinder : BinderMono
	{
		public override void Bind(Ninject.Syntax.IBindingRoot binding)
		{
			binding.Bind<LvManager>().ToProvider<PrefabProvider<LvManagerImpl>>().InSingletonScope();
		}
	}
}