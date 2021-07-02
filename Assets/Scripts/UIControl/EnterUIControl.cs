using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 主界面显示控制
/// </summary>
public class EnterUIControl : MonoBehaviour
{
    public Image mainInterfaceImage; //主界面图片

    void Start()
    {
        mainInterfaceImage.gameObject.SetActive(false);
    }

    //展示主界面
    public void ShowMainInterface()
    {
        mainInterfaceImage.gameObject.SetActive(true);
    }
}
