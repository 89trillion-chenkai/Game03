using UnityEngine;

/// <summary>
/// 显示信息弹窗的按钮绑定函数
/// </summary>
public class ToastShowControl : MonoBehaviour
{
    public GameObject toast; //弹出窗口

    void Start()
    {
        toast.SetActive(false);
    }

    //按钮绑定的展示玩家信息窗口
    public void ShowToastButton()
    {
        if (toast.activeSelf == false)
        {
            toast.SetActive(true);
            toast.transform.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero; //设置位置居中
            toast.GetComponent<ToastDataLoad>().LoadPlayerPInfo(); //加载玩家信息
            Invoke("CloseToast", 1); //显示两秒后即关闭弹窗
        }
    }

    //关闭展示玩家信息窗口
    public void CloseToast()
    {
        if (toast.activeSelf == true)
        {
            toast.SetActive(false);
        }
    }
}
