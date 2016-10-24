using Ninject;
using Ninject.Unity;
using UnityEngine;

namespace Lv.Test
{
	public class LvTester : DIMono
	{
		[Inject]
		private LvManager LvManager
		{
			get;
			set;
		}

		private void Start()
		{
			LvManager.OnLanguageChanged += LvManager_OnLanguageChanged;
			LvManager.SelectLanguage("German");
			LvManager.SelectLanguage("English");
		}

		private void LvManager_OnLanguageChanged()
		{
			Debug.Log(LvManager.GetText("new_game"));
			Debug.Log(LvManager.GetText("end_game"));
		}
	}
}