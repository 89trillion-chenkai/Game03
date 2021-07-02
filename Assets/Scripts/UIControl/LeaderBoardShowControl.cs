using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 控制排行榜的限时和隐藏
/// </summary>
public class LeaderBoardShowControl : MonoBehaviour
{
    public Image leaderBoardImage; //排行榜图片
    public Image imageContent; //展示信息背景
    private Vector3 imageContentPosition; //排列框位置

    void Start()
    {
        leaderBoardImage.gameObject.SetActive(false);
    }
    
    //展示排行榜
    public void ShowLeaderboard()
    {
        if (leaderBoardImage.IsActive() == false)
        {
            leaderBoardImage.gameObject.SetActive(true);
            imageContentPosition = imageContent.transform.position; //获取显示框的初始位置
            imageContent.GetComponent<LeaderboardInfoLoad>().ShowInfo(); //显示排行榜信息
        }
    }
    
    //关闭排行榜
    public void CloseLeaderboard()
    {
        if (leaderBoardImage.IsActive() == true)
        {
            for (int i = 0; i < imageContent.transform.childCount; i++)
            {
                Destroy(imageContent.transform.GetChild(i).gameObject); 
                //后续改进加入对象池回收
                //GetComponent<ObjectsPool>().ReturnInstance(imageContent.transform.GetChild(i).gameObject); //回收信息卡片对象
            }
            
            imageContent.transform.position = imageContentPosition; //让显示框回到的初始位置
            leaderBoardImage.gameObject.SetActive(false);
        }
    }
}
