using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using UnityEngine;

namespace Saving.Impl
{
	public class XmlStore : MonoBehaviour, SaveSystem
	{
		public string fileName;
		private const string BASE_NODE = "Save";
		private static XmlWriterSettings writerSettings;
		private Dictionary<string, Storable> store;

		public string FileName
		{
			get;
			set;
		}

		static XmlStore()
		{
			writerSettings = new XmlWriterSettings();
			writerSettings.Indent = true;
			writerSettings.NewLineOnAttributes = true;
		}

		public void Store<T>(string key, T value) where T : Storable
		{
			store[key] = value;
		}

		public T Load<T>(string key) where T : Storable
		{
			T value = default(T);
			if (store.ContainsKey(key))
			{
				value = (T)store[key];
			}
			return value;
		}

		public void Persist()
		{
			string filePath = GetFilePath();
			if (!File.Exists(filePath))
			{
				using (XmlWriter writer = XmlWriter.Create(filePath, writerSettings))
				{
					writer.WriteStartDocument();
					writer.WriteStartElement(BASE_NODE);
					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}
			}
			XmlReader reader = XmlReader.Create(filePath);
			XmlDocument doc = new XmlDocument();
			doc.Load(reader);
			reader.Close();
			foreach (var kvp in store)
			{
				string[] subkeys = kvp.Key.Split('/');
				XmlNode node = doc.DocumentElement;
				foreach (string k in subkeys)
				{
					XmlNode oldNode = node;
					node = node.SelectSingleNode(k);
					if (node == null)
					{
						node = oldNode.AppendChild(doc.CreateElement(k));
					}
				}
				XmlAttribute att = doc.CreateAttribute("Type");
				att.Value = kvp.Value.GetType().ToString();
				node.Attributes.Append(att);
				foreach (var data in kvp.Value.GetStorageData())
				{
					att = doc.CreateAttribute(data.Key);
					att.Value = data.Value;
					node.Attributes.Append(att);
				}
			}
			using (XmlWriter writer = XmlWriter.Create(filePath, writerSettings))
			{
				doc.Save(writer);
				writer.Close();
			}
		}

		public void LoadPersistentData()
		{
			store = new Dictionary<string, Storable>();
			string filePath = GetFilePath();
			XmlReader reader = XmlReader.Create(filePath);
			List<string> pathParts = new List<string>();
			bool isFirstElement = true;
			while (reader.Read())
			{
				switch (reader.NodeType)
				{
					case XmlNodeType.Element:
						if (!isFirstElement)
						{
							pathParts.Add(reader.Name);
						}
						else
						{
							isFirstElement = false;
						}
						if (reader.HasAttributes)
						{
							Dictionary<string, string> attributes = GetAttributes(reader);
							CreateInstance(pathParts, attributes);
							pathParts.RemoveLast();
						}
						break;

					case XmlNodeType.EndElement:
						pathParts.RemoveLast();
						break;
				}
			}
			reader.Close();
		}

		private static Dictionary<string, string> GetAttributes(XmlReader reader)
		{
			Dictionary<string, string> attributes = new Dictionary<string, string>();
			while (reader.MoveToNextAttribute())
			{
				attributes[reader.Name] = reader.Value;
			}
			return attributes;
		}

		private void Awake()
		{
			store = new Dictionary<string, Storable>();
		}

		private void OnDestroy()
		{
			Persist();
		}

		private void CreateInstance(List<string> pathParts, Dictionary<string, string> attributes)
		{
			Type type = Assembly.GetExecutingAssembly().GetType(attributes["Type"]);
			Storable instance = (Storable)type.GetConstructor(new Type[0]).Invoke(new object[0]);
			instance.SetData(attributes);
			store[Utility.ListToString(pathParts, '/')] = instance;
		}

		private string GetFilePath()
		{
			return Path.Combine(Application.persistentDataPath, FileName + ".xml");
		}
	}
}