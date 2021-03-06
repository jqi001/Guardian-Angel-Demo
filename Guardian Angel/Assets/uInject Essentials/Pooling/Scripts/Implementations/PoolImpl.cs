﻿using Async;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pools.Impl
{
	public class PoolImpl : Pool
	{
		private const int DEFAULT_SIZE = 10;
		private const int BOTTOM_THRESHOLD = 5;
		private const int ON_THRESHOLD_INCREASE = 2;
		private Stack<PooledGameObject> pool;
		private Transform parent;
		private GameObject prefab;
		private AsyncOperationFactory AOF;

		public int Size
		{
			get;
			private set;
		}

		public int AvailableObjects
		{
			get
			{
				return pool.Count;
			}
		}

		public PoolImpl(GameObject prefab, AsyncOperationFactory AOF)
		{
			this.prefab = prefab;
			this.AOF = AOF;
			pool = new Stack<PooledGameObject>();
			parent = new GameObject("Pool " + prefab.name).transform;
			parent.gameObject.SetActive(false);
			IncreasePoolSize(DEFAULT_SIZE);
		}

		public GameObject GetObject()
		{
			PooledGameObject go = pool.Pop();
			go.transform.SetParent(null);
			if (pool.Count < BOTTOM_THRESHOLD)
			{
				IncreasePoolSize(Size + ON_THRESHOLD_INCREASE);
			}
			return go.gameObject;
		}

		public void ReleaseObject(GameObject gameObject)
		{
			if (pool.Count >= Size)
			{
				GameObject.Destroy(gameObject);
			}
			else
			{
				pool.Push(gameObject.GetComponent<PooledGameObject>());
				gameObject.transform.SetParent(parent);
			}
		}

		public void SetSize(int size)
		{
			if (size < Size)
			{
				IncreasePoolSize(size);
			}
			else if (size > Size)
			{
				DecreasePoolSize(size);
			}
		}

		public bool Contains(GameObject gameObject)
		{
			return pool.Contains(gameObject.GetComponent<PooledGameObject>());
		}

		private void DecreasePoolSize(int size)
		{
			Size = size;
			AOF.Create(DecreasePoolSize());
		}

		private void IncreasePoolSize(int size)
		{
			Size = size;
			AOF.Create(IncreasePoolSize());
		}

		private IEnumerator DecreasePoolSize()
		{
			while (pool.Count > Size)
			{
				GameObject.Destroy(pool.Pop());
				yield return new WaitForEndOfFrame();
			}
		}

		private IEnumerator IncreasePoolSize()
		{
			while (pool.Count < Size)
			{
				yield return null;
				InstantiatePrefab();
			}
		}

		private void InstantiatePrefab()
		{
			GameObject go = GameObject.Instantiate(prefab);
			PooledGameObject pgo = go.GetComponent<PooledGameObject>();
			pgo.SetPool(this);
			go.transform.parent = parent;
			pool.Push(pgo);
		}
	}
}