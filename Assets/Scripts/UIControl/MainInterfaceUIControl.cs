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
    [SerializeField] private CountDownUIControl countDownUIControl; //调用脚本里的倒计时协程
    private Vector3 imageContentPosition; //排列框位置
    private bool countDownTimeStartFlag; //倒计时是否开启标记

    void Start()
    {
        mainInterfaceImage.SetActive(false);
        imageContentPosition = contentImage.position; //获取显示框的初始位置
        countDownTimeStartFlag = false;
    }

    //展示主界面
    public void ShowMainInterface()
    {
        if (mainInterfaceImage.activeSelf == false)
        {
            mainInterfaceImage.SetActive(true);
            leaderBoardInfoLoad.ShowInfo(); //加载排行榜信息

            if (countDownTimeStartFlag == false)
            {
                countDownUIControl.StartCoroutine("CountDownTime"); //开启倒计时协程
                countDownTimeStartFlag = true; //标记变量更新
            }
        }
    }
    
    //关闭主界面
    public void CloseMainInterface()
    {
        if (mainInterfaceImage.activeSelf == true)
        {
            ClearLeaderboard(); //清除排行榜数据
            contentImage.position = imageContentPosition; //让滑动框回到的初始位置
            mainInterfaceImage.SetActive(false);
        }
    }
    
    //清除排行榜数据
    private void ClearLeaderboard()
    {
        for (int i = contentImage.childCount - 1; i >= 0; i--)
        {
            objectsPool.ReturnInstance(contentImage.GetChild(i).gameObject); //对象池回收信息卡片物体
            imageScrollShowControl.loopItems.Clear(); //清除链表里的排行榜卡片信息数据
        }
    }
}
