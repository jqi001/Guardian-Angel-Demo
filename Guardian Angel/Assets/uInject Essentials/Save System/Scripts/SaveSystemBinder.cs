using Ninject.Unity;
using Ninject.Unity.Provider;
using Saving.Impl;

namespace Saving.DI
{
	public class SaveSystemBinder : BinderMono
	{
		public override void Bind(Ninject.Syntax.IBindingRoot binding)
		{
			binding.Bind<SaveSystem>().ToProvider<PrefabProvider<XmlStore>>().InSingletonScope();
		}
	}
}