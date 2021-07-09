using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 显示弹窗
/// </summary>
public class ToastShowControl : MonoBehaviour
{
    [SerializeField] private RectTransform toastPrefab; //弹出窗口Toast预制体
    [SerializeField] private ToastInfoLoad toastInfoLoad; //调用玩家信息展示脚本
    private Transform imgViewPointTransform; //弹窗的父物体

    //按钮绑定的生成显示玩家信息窗口
    public void ShowToastButton()
    {
        if (imgViewPointTransform == null)
        {
            imgViewPointTransform = transform.parent.parent; //获取弹窗父物体的Transform
        }
        
        RectTransform toast = Instantiate(toastPrefab, imgViewPointTransform, false);
        toast.anchoredPosition3D = Vector3.zero; //设置位置居中
        toastInfoLoad.LoadPlayerPInfo(toast); //加载玩家信息
        Destroy(toast.gameObject, 1); //显示一秒即移除
    }
}
