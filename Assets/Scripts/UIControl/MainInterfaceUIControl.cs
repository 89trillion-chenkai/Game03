using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// 主界面显示控制
/// </summary>
public class MainInterfaceUIControl : MonoBehaviour
{
    [SerializeField] private GameObject mainInterfaceImage; //主界面图片
    [SerializeField] private Transform contentImage; //展示信息滑动框
    [SerializeField] private LeaderBoardInfoLoad leaderBoardInfoLoad; //Content的信息加载脚本
    [SerializeField] private ImageScrollShowControl imageScrollShowControl; //Content的滑动展示脚本
    [SerializeField] private ObjectsPool objectsPool; //对象池脚本
    private Vector3 imageContentPosition; //排列框位置

    void Start()
    {
        mainInterfaceImage.SetActive(false);
        imageContentPosition = contentImage.position; //获取显示框的初始位置
    }

    //展示主界面
    public void ShowMainInterface()
    {
        if (mainInterfaceImage.activeSelf == false)
        {
            mainInterfaceImage.SetActive(true);
            leaderBoardInfoLoad.ShowInfo(); //加载排行榜信息
        }
    }
    
    //关闭主界面
    public void CloseMainInterface()
    {
        if (mainInterfaceImage.activeSelf == true)
        {
            ClearLeaderboard(); //清除排行榜数据
            mainInterfaceImage.SetActive(false);
        }
    }
    
    //清楚排行榜数据
    private void ClearLeaderboard()
    {
        for (int i = contentImage.childCount - 1; i >= 0; i--)
        {
            objectsPool.ReturnInstance(contentImage.GetChild(i).gameObject); //对象池回收信息卡片对象
            imageScrollShowControl.loopItems.Clear(); //清除链表里的信息数据
        }

        contentImage.position = imageContentPosition; //让滑动框回到的初始位置
    }
}
