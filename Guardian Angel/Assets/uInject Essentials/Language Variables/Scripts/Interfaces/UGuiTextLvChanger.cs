using Ninject;
using Ninject.Unity;
using UnityEngine.UI;

namespace Lv
{
	public class UGuiTextLvChanger : DIMono
	{
		public string id;
		public Text text;

		[Inject]
		private LvManager LvManager
		{
			get;
			set;
		}

		private void Start()
		{
			LvManager.OnLanguageChanged += OnLanguageChanged;
			OnLanguageChanged();
		}

		private void OnLanguageChanged()
		{
			text.text = LvManager.GetText(id);
		}
	}
}