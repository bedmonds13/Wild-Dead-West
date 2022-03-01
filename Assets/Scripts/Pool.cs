using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private static Dictionary<PooledlMonoBehaviour, Pool> pools = new Dictionary<PooledlMonoBehaviour, Pool>();
    private Queue<PooledlMonoBehaviour> objects = new Queue<PooledlMonoBehaviour>();
    private PooledlMonoBehaviour prefab;

    public static Pool GetPool(PooledlMonoBehaviour prefab)
    {
        if (pools.ContainsKey(prefab))
            return pools[prefab];

        var pool = new GameObject("Pool -" + prefab.name).AddComponent<Pool>();
        pool.prefab = prefab;
        pools.Add(prefab, pool);
        return pool;
    }

    public T Get<T>() where T : PooledlMonoBehaviour
    {
        if (objects.Count == 0)
        {
            GrowPool();
        }
        var pooledObject = objects.Dequeue();
        return pooledObject as T;
    }

    private void GrowPool()
    {
        for (int i = 0; i < prefab.InitialPoolSize; i++)
        {
            var pooledObject = Instantiate(prefab) as PooledlMonoBehaviour;
            pooledObject.gameObject.name += " " + i;

            pooledObject.OnReturnToPool += AddObjectToAvailableQueue;

            pooledObject.transform.SetParent(this.transform);
            pooledObject.gameObject.SetActive(false);
        }
    }

    private void AddObjectToAvailableQueue(PooledlMonoBehaviour pooledObject)
    {
        pooledObject.transform.SetParent(this.transform);
        objects.Enqueue(pooledObject);
    }
}
