using Ninject;
using Ninject.Unity;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace Lv
{
	public class LanguageSelector : DIMono
	{
		public Text text;
		private List<string> availableLanguages;
		private int id;

		[Inject]
		private LvManager LvManager
		{
			get;
			set;
		}

		public void NextLanguage()
		{
			id++;
			if (id == availableLanguages.Count)
			{
				id = 0;
			}
			SelectLanguage(availableLanguages[id]);
		}

		public void PreviousLanguage()
		{
			id--;
			if (id == -1)
			{
				id = availableLanguages.Count - 1;
			}
			SelectLanguage(availableLanguages[id]);
		}

		public void SelectLanguage(string id)
		{
			LvManager.SelectLanguage(id);
			UpdateText();
		}

		private void Start()
		{
			availableLanguages = LvManager.GetAvailableLanguages().ToList();
			id = availableLanguages.IndexOf(LvManager.SelectedLanguage);
			UpdateText();
		}

		private void UpdateText()
		{
			if (text != null)
			{
				text.text = LvManager.SelectedLanguage;
			}
		}
	}
}