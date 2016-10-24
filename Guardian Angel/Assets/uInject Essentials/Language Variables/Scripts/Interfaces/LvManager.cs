using System;

namespace Lv
{
	public interface LvManager
	{
		string SelectedLanguage
		{
			get;
		}

		event Action OnLanguageChanged;

		string GetText(string id);

		string[] GetAvailableLanguages();

		void SelectLanguage(string id);
	}
}