using System;
using System.Linq;
using UnityEngine;

namespace Lv.Impl
{
	public class LvManagerImpl : MonoBehaviour, LvManager
	{
		public string[] ids;

		[HideInInspector]
		public LanguageSetup[] languages;

		private LanguageSetup selectedLanguage;

		public string SelectedLanguage
		{
			get
			{
				return selectedLanguage.language;
			}
		}

		public event Action OnLanguageChanged = delegate { };

		public string[] GetAvailableLanguages()
		{
			return languages.Select(ls => ls.language).ToArray();
		}

		public string GetText(string id)
		{
			string text = selectedLanguage.GetText(id);
			if (string.IsNullOrEmpty(text))
			{
				return id;
			}
			else
			{
				return text;
			}
		}

		public void SelectLanguage(string id)
		{
			LanguageSetup newLang = null;
			foreach (LanguageSetup ls in languages)
			{
				if (ls.language.Equals(id))
				{
					newLang = ls;
					break;
				}
			}
			if (newLang == null)
			{
				throw new Exception("Invalid language " + id);
			}
			else
			{
				selectedLanguage = newLang;
				OnLanguageChanged();
			}
		}

		public bool ContainsLanguage(string id)
		{
			foreach (LanguageSetup ls in languages)
			{
				if (ls.language.Equals(id))
				{
					return true;
				}
			}
			return false;
		}

		private void Awake()
		{
			selectedLanguage = languages[0];
		}

		[Serializable]
		public class LanguageSetup
		{
			public string language;
			public Entry[] entries;

			public LanguageSetup(string name)
			{
				language = name;
				entries = new Entry[0];
			}

			public Entry GetEntry(string id)
			{
				foreach (Entry e in entries)
				{
					if (e.id.Equals(id))
					{
						return e;
					}
				}
				return null;
			}

			public string GetText(string id)
			{
				foreach (Entry e in entries)
				{
					if (e.id.Equals(id))
					{
						return e.value;
					}
				}
				return "";
			}

			[Serializable]
			public class Entry
			{
				public string id;
				public string value;

				public Entry(string id)
				{
					this.id = id;
				}
			}
		}
	}
}