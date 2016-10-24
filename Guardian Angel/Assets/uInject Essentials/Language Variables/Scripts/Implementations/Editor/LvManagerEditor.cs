using UnityEditor;
using UnityEngine;

namespace Lv.Impl.Editor
{
	[CustomEditor(typeof(LvManagerImpl))]
	public class LvManagerEditor : UnityEditor.Editor
	{
		private string newLang;

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			LvManagerImpl target = (LvManagerImpl)this.target;

			if (target.languages == null)
			{
				target.languages = new LvManagerImpl.LanguageSetup[0];
			}

			foreach (LvManagerImpl.LanguageSetup ls in target.languages)
			{
				EditorGUI.indentLevel = 0;
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(ls.language);
				if (GUILayout.Button("X"))
				{
					ArrayUtility.Remove(ref target.languages, ls);
					break;
				}
				EditorGUILayout.EndHorizontal();

				EditorGUI.indentLevel = 1;
				foreach (string id in target.ids)
				{
					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.PrefixLabel(id);
					LvManagerImpl.LanguageSetup.Entry entry = ls.GetEntry(id);
					if (entry == null)
					{
						entry = new LvManagerImpl.LanguageSetup.Entry(id);
						ArrayUtility.Add(ref ls.entries, entry);
					}
					entry.value = EditorGUILayout.TextField(entry.value);
					EditorGUILayout.EndHorizontal();
				}
			}

			EditorGUILayout.BeginHorizontal();
			newLang = EditorGUILayout.TextField(newLang);
			if (GUILayout.Button("Add Language") && !string.IsNullOrEmpty(newLang) && !target.ContainsLanguage(newLang))
			{
				ArrayUtility.Add(ref target.languages, new LvManagerImpl.LanguageSetup(newLang));
				newLang = "";
			}
			EditorGUILayout.EndHorizontal();
		}
	}
}