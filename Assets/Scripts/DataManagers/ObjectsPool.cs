using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

/// <summary>
/// 对象池
/// </summary>
public class ObjectsPool : MonoBehaviour {
    public GameObject prefab; //生成物体
    public Transform content; //生成物体的父物体
    private Queue<GameObject> pooledInstanceQueue = new Queue<GameObject>(); //存放物体对象

    //获取对象
    public GameObject GetInstance() 
    {
        if (pooledInstanceQueue.Count > 0)
        {
            GameObject instanceToReuse = pooledInstanceQueue.Dequeue();
            instanceToReuse.SetActive(true);
            return instanceToReuse;
        }

        return Instantiate(prefab, content, false);
    }

    //回收对象
    public void ReturnInstance(GameObject gameObjectToPool)
    {
        pooledInstanceQueue.Enqueue(gameObjectToPool);
        gameObjectToPool.transform.SetParent(transform, false); //把物体移到脚本所在物体下
        gameObjectToPool.SetActive(false);
    }
}

