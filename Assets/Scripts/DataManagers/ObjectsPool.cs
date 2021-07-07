using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

/// <summary>
/// 对象池
/// </summary>
public class ObjectsPool : MonoBehaviour {
    [SerializeField]
    private GameObject prefab; //生成物体，需拖拽
    private Queue<GameObject> poolQueue = new Queue<GameObject>(); //存放物体对象

    //获取对象
    public GameObject GetInstance() 
    {
        if (poolQueue.Count > 0)
        {
            GameObject instanceObject = poolQueue.Dequeue(); //出队
            instanceObject.SetActive(true);
            return instanceObject;
        }

        return Instantiate(prefab); //如果对象池里没有则直接生成
    }

    //回收对象
    public void ReturnInstance(GameObject returnGameObject)
    {
        poolQueue.Enqueue(returnGameObject); //入队
        returnGameObject.transform.SetParent(transform, false); //把物体移到脚本所在物体下
        returnGameObject.SetActive(false);
    }
}

