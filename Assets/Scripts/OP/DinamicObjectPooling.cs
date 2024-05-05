using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamicObjectPooling : PoolObject
{
    public override void InstantiateObjects()
    {
        base.InstantiateObjects();
    }
    public override void GetObject(Vector3 references)
    {
        GameObject tmp;
        if (objectPool.Count > 0)
        {
            tmp = objectPool[0];
            objectPool.Remove(tmp);
            tmp.transform.position = references;
            tmp.SetActive(true);
        }
        else
        {
            int randomValue;
            randomValue = Random.Range(0, objecsPrefabs.Length);
            tmp = Instantiate(objecsPrefabs[randomValue].gameObject, references, Quaternion.identity, parentSpanwObject);
            tmp.GetComponent<PoolObject>().SetObject(this.gameObject);
            tmp.SetActive(true);
        }
    }
    public override void SetObject(GameObject obj)
    {
        base.SetObject(obj);
    }  

}
