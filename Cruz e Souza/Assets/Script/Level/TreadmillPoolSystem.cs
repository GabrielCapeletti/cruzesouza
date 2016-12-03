using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreadmillPoolSystem : MonoBehaviour {

    public GameObject biggerObject;
    public GameObject[] objects;
    public int poolSize;

    private GameObject[][] poolObjects;
    private List<GameObject>[] freeObjects;

    public TileController Initialize (Vector3 spawnPosition) {
        poolObjects = new GameObject[objects.Length][];
        freeObjects = new List<GameObject>[objects.Length];        
        for (int i = 0; i < objects.Length; i++)
        {            
            float objectLenght = objects[i].GetComponent<BoxCollider>().size.z;            
            freeObjects[i] = new List<GameObject>();
            poolObjects[i] = new GameObject[poolSize];
            for (int j = 0; j < poolSize; j++)
            {
                poolObjects[i][j] = GameObject.Instantiate(objects[i], spawnPosition- new Vector3(0,0,objectLenght*j), Quaternion.identity) as GameObject;
                poolObjects[i][j].transform.SetParent(this.transform);
                freeObjects[i].Add(poolObjects[i][j]);
            }
            GameObject go = GameObject.Instantiate(biggerObject, spawnPosition - new Vector3(0, 0, objectLenght * (poolSize-0.5f)), Quaternion.identity) as GameObject;
        }

        return poolObjects[0][0].GetComponent<TileController>();
    }	

    public float GetTotalLenght()
    {
        float totalLenght = 0;
        for (int i = 0; i < objects.Length; i++)
        {
            float objectLenght = objects[i].GetComponent<BoxCollider>().size.z;
            totalLenght += objectLenght * poolSize;
        }
        totalLenght+= biggerObject.GetComponent<BoxCollider>().size.z;
        return totalLenght-objects[0].GetComponent<BoxCollider>().size.z;
    }  
    
    public void ClearObject()
    {
        for (int i = 0; i < objects.Length; i++)
        {           
            for (int j = 0; j < poolSize; j++)
            {
                GameObject.Destroy(poolObjects[i][j]);             
            }
        }        
    } 
    
    public GameObject GetObject(int i)
    {
        if (this.freeObjects[i].Count <= 0)
        {
            Debug.LogError("TreadmillPoolSystem::GetObject: PoolSystem is empty, but someone is trying get new instance");
            return null;
        }
        GameObject freeObjet = this.freeObjects[i][0];
        this.freeObjects[i].RemoveAt(0);
        return freeObjet;
    }	
	
    public void ReleaseObject(GameObject gameObject, int i)
    {
        this.freeObjects[i].Add(gameObject);
    }
}
