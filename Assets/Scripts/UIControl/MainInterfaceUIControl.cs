using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

/// <summary>
/// 主界面显示控制
/// </summary>
public class MainInterfaceUIControl : MonoBehaviour
{
    [SerializeField] private GameObject imgMainInterface; //主界面图片
    [SerializeField] private Transform imgContentTransform; //展示信息滑动框
    [SerializeField] private LeaderBoardInfoShow leaderBoardInfoShow; //Content的信息加载脚本
    [SerializeField] private ScrollShowControl scrollShowControl; //Content的滑动展示脚本
    [SerializeField] private InfoCardObjectsPool infoCardObjectsPool; //对象池脚本
    [SerializeField] private CountDownUIControl countDownUIControl; //调用脚本里的倒计时协程
    private Vector3 imageContentPosition; //排列框位置
    private bool isCountDownStart; //倒计时是否开启标记

    void Start()
    {
        imgMainInterface.SetActive(false);
        imageContentPosition = imgContentTransform.position; //获取显示框的初始位置
        isCountDownStart = false;
    }

    //展示主界面
    public void ShowMainInterface()
    {
        if (imgMainInterface.activeSelf == false)
        {
            imgMainInterface.SetActive(true); //主界面显示
            leaderBoardInfoShow.ShowInfo(); //加载排行榜信息
            
            if (isCountDownStart == false)
            {
                countDownUIControl.StartCoroutine("CountDownTime"); //开启倒计时协程
                isCountDownStart = true; //标记变量更新
            }
        }
    }
    
    //关闭主界面
    public void CloseMainInterface()
    {
        if (imgMainInterface.activeSelf == true)
        {
            ClearLeaderboard(); //清除排行榜数据
            imgContentTransform.position = imageContentPosition; //让滑动框回到的初始位置
            imgMainInterface.SetActive(false); //主界面隐藏
        }
    }
    
    //清除排行榜数据
    private void ClearLeaderboard()
    {
        for (int i = imgContentTransform.childCount - 1; i >= 0; i--)
        {
            infoCardObjectsPool.ReturnInstance(imgContentTransform.GetChild(i).gameObject); //对象池回收信息卡片物体
        }
        
        scrollShowControl.loopItems.Clear(); //清除链表里的排行榜卡片信息数据
    }
}
