using UnityEngine;

/// <summary>
/// 显示信息弹窗的按钮绑定函数
/// </summary>
public class ToastShowControl : MonoBehaviour
{
    [SerializeField] private GameObject toastPrefab; //弹出窗口Toast预制体
    [SerializeField] private RectTransform toastRect; //Toast的矩形组件属性
    [SerializeField] private ToastDataLoad toastDataLoad; //弹窗加载信息
    private Transform imgViewPointTransform; //弹窗的父物体

    void Start()
    {
        toastPrefab.SetActive(false);
    }

    //按钮绑定的展示玩家信息窗口
    public void ShowToastButton()
    {
        if (imgViewPointTransform == null)
        {
            imgViewPointTransform = transform.parent.parent; //获取弹窗父物体的Transform
        }
        
        if (toastPrefab.activeSelf == false)
        {
            toastPrefab.SetActive(true);
            toastPrefab.transform.SetParent(imgViewPointTransform, false); //设置父物体
            toastRect.anchoredPosition3D = Vector3.zero; //设置位置居中
            toastDataLoad.LoadPlayerPInfo(); //加载玩家信息
            Invoke("CloseToast", 1); //显示1秒后即关闭弹窗
        }
    }

    //关闭展示玩家信息窗口
    public void CloseToast()
    {
        if (toastPrefab.activeSelf == true)
        {
            toastPrefab.SetActive(false);
        }
    }
}
