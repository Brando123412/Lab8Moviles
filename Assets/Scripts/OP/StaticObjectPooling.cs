using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObjectPooling : PoolObject
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
            Debug.LogWarning("no hay objetos en el pool");
        }
    }
    public override void SetObject(GameObject obj)
    {
        base.SetObject(obj);
    }
}              
