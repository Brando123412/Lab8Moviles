using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] protected List<GameObject> objectPool;
    [SerializeField] protected PoolObject[] objecsPrefabs;
    [SerializeField] protected Transform parentSpanwObject;
    [SerializeField] protected int maxQuantity;

    public virtual void Start() { }

    public virtual void InstantiateObjects()
    {
        GameObject tmp;
        int randomValue;
        for (int i = 0; i < maxQuantity; i++)
        {
            randomValue = Random.Range(0, objecsPrefabs.Length);
            tmp = Instantiate(objecsPrefabs[randomValue].gameObject, transform.position, Quaternion.identity, parentSpanwObject);
            tmp.GetComponent<PoolObject>().SetObject(this.gameObject);
            tmp.SetActive(false);
            objectPool.Add(tmp);
        }
    }
    public virtual void GetObject(Vector3 references)
    {
        
    }
    public virtual void SetObject(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Add(obj);
    }
}
