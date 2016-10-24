using Ninject;
using Ninject.Unity;
using UnityEngine;

namespace Saving.Test
{
	public class SaveTest : DIMono
	{
		public float value;
		public StorableData data;
		public StorableData data2;

		[Inject]
		private SaveSystem SaveSystem
		{
			get;
			set;
		}

		private void Start()
		{
			SaveSystem.FileName = "MySave";
			SaveSystem.LoadPersistentData();
			//SaveSystem.Store("Saving/Test/data", data);
			//SaveSystem.Store("Saving/Test/data2", data2);
			SaveSystem.Store("Saving/Test2/data", data);

			Storable loadedData = SaveSystem.Load<StorableData>("Saving/Test/data");
			Debug.Log(loadedData);
			loadedData = SaveSystem.Load<StorableData>("Saving/Test/data2");
			Debug.Log(loadedData);
		}
	}
}